using System.Linq;
using ExpertSystemWinForms.Models;

namespace ExpertSystemWinForms.Forms;

public partial class SymptomSelectionForm : UserControl
{
    private List<Symptom> symptoms = new();
    private List<Symptom> filteredSymptoms = new();
    private List<string> selectedSymptoms = new();
    private Dictionary<string, string> symptomResponses = new(); // "yes", "no", "unknown"

    public event Action<List<string>, Dictionary<string, string>>? OnDiagnose;

    public SymptomSelectionForm()
    {
        InitializeComponent();
    }

    public void LoadData(List<Symptom> symptoms)
    {
        this.symptoms = symptoms;
        ApplyFilters();
    }

    private void RefreshSymptomList()
    {
        symptomPanel.Controls.Clear();

        var parent = symptomPanel.Parent;
        int panelWidth = 600;
        if (parent != null && parent.ClientSize.Width > 0)
        {
            panelWidth = parent.ClientSize.Width - 30;
            symptomPanel.Width = panelWidth;
        }

        var isFiltering = IsFilterActive;
        var displaySymptoms = isFiltering ? filteredSymptoms : symptoms;

        if (displaySymptoms.Count == 0)
        {
            var emptyLabel = new Label
            {
                Text = isFiltering
                    ? "Không tìm thấy triệu chứng phù hợp với bộ lọc hiện tại."
                    : "Chưa có dữ liệu triệu chứng. Vui lòng thêm trong mục Cơ Sở Tri Thức.",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = Color.Gray,
                Padding = new Padding(20),
                Height = 120,
            };

            symptomPanel.Controls.Add(emptyLabel);
            UpdateSelectedCount();
            return;
        }

        // Nhóm triệu chứng theo Category với thứ tự ưu tiên
        var categoryOrder = new Dictionary<string, int>
        {
            { "Toàn thân", 1 },
            { "Cơ xương khớp", 2 },
            { "Hô hấp", 3 },
            { "Tiêu hóa", 4 },
            { "Thần kinh", 5 },
            { "Tim mạch", 6 },
            { "Da liễu", 7 },
            { "Mắt", 8 },
            { "Tai", 9 },
            { "Tiết niệu", 10 },
            { "Gan mật", 11 },
            { "Nội tiết", 12 },
            { "Khác", 99 }
        };

        var groupedSymptoms = displaySymptoms
            .GroupBy(s => string.IsNullOrWhiteSpace(s.Category) ? "Khác" : s.Category)
            .OrderBy(g => categoryOrder.TryGetValue(g.Key, out int order) ? order : 99)
            .ThenBy(g => g.Key);

        foreach (var group in groupedSymptoms)
        {
            // Tạo GroupBox cho mỗi nhóm
            var groupBox = new GroupBox
            {
                Text = group.Key,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Padding = new Padding(15, 20, 15, 15),
                Margin = new Padding(5, 10, 5, 5),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            var groupPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
            };

            foreach (var symptom in group.OrderBy(s => s.Name))
            {
                var symptomItem = new Panel
                {
                    Size = new Size(Math.Max(panelWidth - 50, 570), 95),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(8, 8, 8, 5),
                    Padding = new Padding(15),
                    BackColor = Color.White,
                };

                var checkBox = new CheckBox
                {
                    Text = symptom.Name,
                    Location = new Point(12, 8),
                    AutoSize = true,
                    Tag = symptom.Id,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                };
                checkBox.Checked = selectedSymptoms.Contains(symptom.Id);
                checkBox.CheckedChanged += (s, e) => ToggleSymptom(symptom.Id, checkBox.Checked);

                var descLabel = new Label
                {
                    Text = symptom.Description,
                    AutoSize = false,
                    // dock to bottom so it always spans full width of the item
                    Dock = DockStyle.Bottom,
                    Height = 44,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.Gray,
                    Padding = new Padding(0),
                    TextAlign = ContentAlignment.MiddleCenter,
                };

                symptomItem.Controls.Add(checkBox);
                symptomItem.Controls.Add(descLabel);
                groupPanel.Controls.Add(symptomItem);
            }

            groupBox.Controls.Add(groupPanel);
            symptomPanel.Controls.Add(groupBox);
        }

        UpdateSelectedCount();
    }

    private void ToggleSymptom(string symptomId, bool isSelected)
    {
        if (isSelected)
        {
            if (!selectedSymptoms.Contains(symptomId))
            {
                selectedSymptoms.Add(symptomId);
                symptomResponses[symptomId] = "yes";
            }
        }
        else
        {
            selectedSymptoms.Remove(symptomId);
            symptomResponses.Remove(symptomId);
        }

        UpdateSelectedCount();
        diagnoseButton.Enabled = selectedSymptoms.Count > 0;

        if (IsFilterActive)
        {
            ApplyFilters();
        }
    }

    private void UpdateSelectedCount()
    {
        selectedCountLabel.Text = $"Đã chọn: {selectedSymptoms.Count} triệu chứng";
    }

    private void DiagnoseButton_Click(object? sender, EventArgs e)
    {
        OnDiagnose?.Invoke(selectedSymptoms, symptomResponses);
    }

    private void ResetButton_Click(object? sender, EventArgs e)
    {
        selectedSymptoms.Clear();
        symptomResponses.Clear();
        searchTextBox.Text = string.Empty;
        showSelectedOnlyCheckBox.Checked = false;
        ApplyFilters();
        diagnoseButton.Enabled = false;
    }

    public List<string> GetSelectedSymptoms() => selectedSymptoms;
    public Dictionary<string, string> GetSymptomResponses() => symptomResponses;

    private bool IsFilterActive =>
        (searchTextBox != null && !string.IsNullOrWhiteSpace(searchTextBox.Text)) ||
        (showSelectedOnlyCheckBox != null && showSelectedOnlyCheckBox.Checked);

    private void ApplyFilters()
    {
        if (symptoms == null) return;

        IEnumerable<Symptom> view = symptoms;

        var keyword = searchTextBox?.Text?.Trim();
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            view = view.Where(s =>
                s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                s.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (showSelectedOnlyCheckBox?.Checked == true)
        {
            view = view.Where(s => selectedSymptoms.Contains(s.Id));
        }

        filteredSymptoms = view.ToList();
        RefreshSymptomList();
    }

    private void SearchTextBox_TextChanged(object? sender, EventArgs e) => ApplyFilters();

    private void ShowSelectedOnlyCheckBox_CheckedChanged(object? sender, EventArgs e) => ApplyFilters();

    private void SymptomScrollPanel_Layout(object? sender, LayoutEventArgs e)
    {
        if (sender is Panel panel)
        {
            symptomPanel.Width = panel.ClientSize.Width - 30;
        }
    }
}

