using ExpertSystemWinForms.Models;
using ExpertSystemWinForms.Services;
using Newtonsoft.Json;
using System.IO;

namespace ExpertSystemWinForms.Forms;

public partial class KnowledgeBaseForm : UserControl
{
    private List<Symptom> symptoms = new();
    private List<Disease> diseases = new();

    public event EventHandler? OnDataChanged;

    public KnowledgeBaseForm()
    {
        InitializeComponent();
        importJsonButton.Click += ImportJsonButton_Click;
        exportJsonButton.Click += ExportJsonButton_Click;
    }

    // Draw handler for inner tab control (Quản lý triệu chứng / Quản lý bệnh)
    private void TabControl_DrawItem(object? sender, DrawItemEventArgs e)
    {
        var tc = sender as TabControl;
        if (tc == null) return;

        var g = e.Graphics;
        var tabRect = e.Bounds;

        var oldSmoothing = g.SmoothingMode;
        var oldText = g.TextRenderingHint;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        // If this tab is selected, paint purple; otherwise white
        Color bg = e.Index == tc.SelectedIndex ? Color.FromArgb(128, 0, 128) : Color.White;

        using (var b = new SolidBrush(bg))
        {
            g.FillRectangle(b, tabRect);
        }

        // Draw tab text centered
        string text = tc.TabPages[e.Index].Text;
        using (var sf = new StringFormat())
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Color textColor = bg.GetBrightness() < 0.5f ? Color.White : Color.Black;
            using (var tb = new SolidBrush(textColor))
            {
                var textRect = new RectangleF(tabRect.Left + 4, tabRect.Top, tabRect.Width - 8, tabRect.Height);
                g.DrawString(text, tc.Font, tb, textRect, sf);
            }
        }

        g.SmoothingMode = oldSmoothing;
        g.TextRenderingHint = oldText;
    }

    public void LoadData(List<Symptom> symptoms, List<Disease> diseases)
    {
        this.symptoms = symptoms;
        this.diseases = diseases;
        RefreshLists();
    }

    private void RefreshLists()
    {
        symptomListBox.DataSource = null;
        symptomListBox.Items.Clear();
        symptomListBox.DataSource = symptoms;
        symptomListBox.DisplayMember = "DisplayText";
        
        diseaseListBox.DataSource = null;
        diseaseListBox.Items.Clear();
        diseaseListBox.DataSource = diseases;
        diseaseListBox.DisplayMember = "DisplayText";
    }

    private void SymptomListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        editSymptomButton.Enabled = symptomListBox.SelectedIndex >= 0;
        deleteSymptomButton.Enabled = symptomListBox.SelectedIndex >= 0;
    }

    private void DiseaseListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        editDiseaseButton.Enabled = diseaseListBox.SelectedIndex >= 0;
        deleteDiseaseButton.Enabled = diseaseListBox.SelectedIndex >= 0;
    }

    private void AddSymptomButton_Click(object? sender, EventArgs e)
    {
        var form = new SymptomEditForm(null);
        if (form.ShowDialog() == DialogResult.OK && form.Symptom != null)
        {
            symptoms.Add(form.Symptom);
            DataService.SaveSymptoms(symptoms);
            RefreshLists();
            OnDataChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void EditSymptomButton_Click(object? sender, EventArgs e)
    {
        if (symptomListBox.SelectedIndex < 0) return;
        var symptom = (Symptom)symptomListBox.SelectedItem;
        if (symptom == null) return;

        var form = new SymptomEditForm(symptom);
        if (form.ShowDialog() == DialogResult.OK && form.Symptom != null)
        {
            var index = symptoms.FindIndex(s => s.Id == symptom.Id);
            if (index >= 0)
            {
                symptoms[index] = form.Symptom;
                DataService.SaveSymptoms(symptoms);
                RefreshLists();
                OnDataChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void DeleteSymptomButton_Click(object? sender, EventArgs e)
    {
        if (symptomListBox.SelectedIndex < 0) return;
        var symptom = (Symptom)symptomListBox.SelectedItem;
        if (symptom == null) return;

        if (MessageBox.Show($"Bạn có chắc muốn xóa triệu chứng \"{symptom.Name}\"?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            symptoms.Remove(symptom);
            // Remove from diseases
            foreach (var disease in diseases)
            {
                disease.Symptoms.Remove(symptom.Id);
                disease.SymptomsCF.Remove(symptom.Id);
            }
            DataService.SaveSymptoms(symptoms);
            DataService.SaveDiseases(diseases);
            RefreshLists();
            OnDataChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void AddDiseaseButton_Click(object? sender, EventArgs e)
    {
        var form = new DiseaseEditForm(null, symptoms);
        if (form.ShowDialog() == DialogResult.OK && form.Disease != null)
        {
            diseases.Add(form.Disease);
            DataService.SaveDiseases(diseases);
            RefreshLists();
            OnDataChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void EditDiseaseButton_Click(object? sender, EventArgs e)
    {
        if (diseaseListBox.SelectedIndex < 0) return;
        var disease = (Disease)diseaseListBox.SelectedItem;
        if (disease == null) return;

        var form = new DiseaseEditForm(disease, symptoms);
        if (form.ShowDialog() == DialogResult.OK && form.Disease != null)
        {
            var index = diseases.FindIndex(d => d.Id == disease.Id);
            if (index >= 0)
            {
                diseases[index] = form.Disease;
                DataService.SaveDiseases(diseases);
                RefreshLists();
                OnDataChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void DeleteDiseaseButton_Click(object? sender, EventArgs e)
    {
        if (diseaseListBox.SelectedIndex < 0) return;
        var disease = (Disease)diseaseListBox.SelectedItem;
        if (disease == null) return;

        if (MessageBox.Show($"Bạn có chắc muốn xóa bệnh \"{disease.Name}\"?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            diseases.Remove(disease);
            DataService.SaveDiseases(diseases);
            RefreshLists();
            OnDataChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void ExportJsonButton_Click(object? sender, EventArgs e) => ExportKnowledgeBase();

    private void ImportJsonButton_Click(object? sender, EventArgs e) => ImportKnowledgeBase();

    private void ExportKnowledgeBase()
    {
        if (symptoms.Count == 0 && diseases.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "JSON files (*.json)|*.json",
            FileName = $"knowledge-base-{DateTime.Now:yyyyMMddHHmm}.json",
            Title = "Xuất dữ liệu kiến thức"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var payload = new KnowledgeBasePayload
            {
                Symptoms = symptoms,
                Diseases = diseases
            };

            File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(payload, Formatting.Indented));
            MessageBox.Show("Xuất dữ liệu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ImportKnowledgeBase()
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "JSON files (*.json)|*.json",
            Title = "Nhập dữ liệu kiến thức"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        try
        {
            var json = File.ReadAllText(dialog.FileName);
            var payload = JsonConvert.DeserializeObject<KnowledgeBasePayload>(json);

            if (payload?.Symptoms == null || payload.Diseases == null)
            {
                MessageBox.Show("Tệp JSON không đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            symptoms = payload.Symptoms;
            diseases = payload.Diseases;
            DataService.SaveSymptoms(symptoms);
            DataService.SaveDiseases(diseases);
            RefreshLists();
            OnDataChanged?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("Nhập dữ liệu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không thể đọc dữ liệu JSON.\nChi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private sealed class KnowledgeBasePayload
    {
        public List<Symptom> Symptoms { get; set; } = new();
        public List<Disease> Diseases { get; set; } = new();
    }
}

