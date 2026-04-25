using ExpertSystemWinForms.Models;
using ExpertSystemWinForms.Services;

namespace ExpertSystemWinForms.Forms;

public partial class DiagnosisHistoryForm : UserControl
{
    private List<DiagnosisRecord> history = [];
    private List<Symptom> symptoms = [];

    public DiagnosisHistoryForm()
    {
        InitializeComponent();
        historyListBox.HorizontalScrollbar = true;
        historyListBox.ScrollAlwaysVisible = true;
        historyListBox.IntegralHeight = false;
        detailPanel.AutoScroll = true;
    }

    public void LoadData(List<DiagnosisRecord> history, List<Symptom> symptoms)
    {
        this.history = history;
        this.symptoms = symptoms;
        RefreshHistoryList();
    }

    private void RefreshHistoryList()
    {
        historyListBox.DataSource = null;
        historyListBox.Items.Clear();

        if (history.Count == 0)
        {
            detailPanel.Controls.Clear();
            var emptyLabel = new Label
            {
                Text = "Chưa có lịch sử chẩn đoán nào.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F),
            };
            detailPanel.Controls.Add(emptyLabel);
            clearButton.Enabled = false;
            return;
        }

        clearButton.Enabled = true;
        historyListBox.DataSource = history;
        historyListBox.DisplayMember = "DisplayText";
    }

    private void HistoryListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (historyListBox.SelectedIndex < 0)
        {
            detailPanel.Controls.Clear();
            return;
        }

        var record = (DiagnosisRecord)historyListBox.SelectedItem;
        if (record == null) return;

        DisplayRecordDetails(record);
    }

    private void DisplayRecordDetails(DiagnosisRecord record)
    {
        detailPanel.Controls.Clear();

        var container = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            AutoSize = true,
            WrapContents = false,
        };

        // Date
        var dateLabel = new Label
        {
            Text = $"Ngày: {record.Date:dd/MM/yyyy HH:mm}",
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            AutoSize = true,
            Width = 600,
        };
        container.Controls.Add(dateLabel);

        // Symptoms
        var symptomLabel = new Label
        {
            Text = "Triệu chứng đã chọn:",
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            AutoSize = true,
            Width = 600,
            Margin = new Padding(0, 10, 0, 5),
        };
        container.Controls.Add(symptomLabel);

        var symptomPanel = new FlowLayoutPanel
        {
            AutoSize = true,
            Width = 600,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
        };

        foreach (var symptomId in record.SelectedSymptoms)
        {
            var symptom = symptoms.FirstOrDefault(s => s.Id == symptomId);
            var badge = new Label
            {
                Text = symptom?.Name ?? "Không xác định",
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5, 2, 5, 2),
                AutoSize = true,
                BackColor = Color.LightGray,
                Margin = new Padding(0, 0, 5, 5),
            };
            symptomPanel.Controls.Add(badge);
        }

        container.Controls.Add(symptomPanel);

        // Results
        var resultLabel = new Label
        {
            Text = "Kết quả chẩn đoán:",
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            AutoSize = true,
            Width = 600,
            Margin = new Padding(0, 10, 0, 5),
        };
        container.Controls.Add(resultLabel);

        if (record.Results.Count > 0)
        {
            foreach (var result in record.Results.Take(5))
            {
                var resultCard = CreateResultCard(result);
                container.Controls.Add(resultCard);
            }

            if (record.Results.Count > 5)
            {
                var moreLabel = new Label
                {
                    Text = $"... và {record.Results.Count - 5} kết quả khác",
                    Font = new Font("Segoe UI", 9F),
                    AutoSize = true,
                    Width = 600,
                };
                container.Controls.Add(moreLabel);
            }
        }
        else
        {
            var noResultLabel = new Label
            {
                Text = "Không tìm thấy kết quả phù hợp",
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Width = 600,
            };
            container.Controls.Add(noResultLabel);
        }

        detailPanel.Controls.Add(container);
    }

    private static Panel CreateResultCard(DiagnosisResult result)
    {
        var card = new Panel
        {
            // Increased height and bottom padding to avoid text clipping of descenders
            Size = new Size(600, 120),
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(0, 6, 0, 6),
            Padding = new Padding(16, 14, 16, 14),
        };

        // Line 1: Disease name (centered)
        var titleLabel = new Label
        {
            Text = result.Disease.Name,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 28,
            TextAlign = ContentAlignment.MiddleCenter,
            Margin = new Padding(0, 0, 0, 10),
        };

        // Line 2: Confidence (left) and CF (right)
        var row2Panel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 26,
            Margin = new Padding(0, 0, 0, 8),
        };

        var confidenceLabel = new Label
        {
            Text = result.Confidence == "high" ? "Độ tin cậy cao" :
                   result.Confidence == "medium" ? "Độ tin cậy TB" : "Độ tin cậy thấp",
            AutoSize = true,
            ForeColor = result.Confidence == "high" ? Color.Green :
                       result.Confidence == "medium" ? Color.Orange : Color.Gray,
            Font = new Font("Segoe UI", 9F),
            Location = new Point(0, 0),
        };

        var cfLabel = new Label
        {
            Text = $"CF: {(result.CertaintyFactor * 100):F1}%",
            AutoSize = true,
            Font = new Font("Segoe UI", 9F),
            Location = new Point(0, 0),
        };

        row2Panel.Controls.Add(confidenceLabel);
        row2Panel.Controls.Add(cfLabel);

        row2Panel.Layout += (s, e) =>
        {
            cfLabel.Location = new Point(row2Panel.Width - cfLabel.Width, 0);
        };

        // Line 3: Match percentage (left) and severity (right)
        var row3Panel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 26,
        };

        var matchLabel = new Label
        {
            Text = $"Độ khớp: {Math.Round(result.MatchPercentage)}%",
            AutoSize = true,
            Font = new Font("Segoe UI", 9F),
            Location = new Point(0, 2),
        };

        var severityLabel = new Label
        {
            Text = result.Disease.Severity == "high" ? "Độ nguy hiểm cao" :
                   result.Disease.Severity == "medium" ? "Độ nguy hiểm TB" : "Độ nguy hiểm thấp",
            AutoSize = true,
            ForeColor = result.Disease.Severity == "high" ? Color.Red :
                       result.Disease.Severity == "medium" ? Color.Orange : Color.Green,
            Font = new Font("Segoe UI", 9F),
            Location = new Point(0, 2),
        };

        row3Panel.Controls.Add(matchLabel);
        row3Panel.Controls.Add(severityLabel);

        row3Panel.Layout += (s, e) =>
        {
            severityLabel.Location = new Point(row3Panel.Width - severityLabel.Width, 0);
        };

        card.Controls.Add(row3Panel);
        card.Controls.Add(row2Panel);
        card.Controls.Add(titleLabel);

        return card;
    }


    private void ClearButton_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ lịch sử?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            DataService.SaveHistory([]);
            history.Clear();
            RefreshHistoryList();
        }
    }
}

