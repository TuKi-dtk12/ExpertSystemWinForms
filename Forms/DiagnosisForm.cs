using ExpertSystemWinForms.Models;
using ExpertSystemWinForms.Services;
using ExpertSystemWinForms.Utils;

namespace ExpertSystemWinForms.Forms;

public partial class DiagnosisForm : UserControl
{
    private List<Symptom> symptoms = new();
    private List<Disease> diseases = new();
    private List<string> selectedSymptoms = new();
    private Dictionary<string, string> symptomResponses = new();
    private List<DiagnosisResult>? results = null;

    public event EventHandler? OnDiagnosisAdded;

    public DiagnosisForm()
    {
        InitializeComponent();
    }

    public void LoadData(List<Symptom> symptoms, List<Disease> diseases)
    {
        this.symptoms = symptoms;
        this.diseases = diseases;
    }

    public void PerformDiagnosis(List<string> selectedSymptoms, Dictionary<string, string> symptomResponses)
    {
        this.selectedSymptoms = selectedSymptoms;
        this.symptomResponses = symptomResponses;
        CalculateDiagnosis();
    }

    private void CalculateDiagnosis()
    {
        if (selectedSymptoms.Count == 0)
        {
            DisplayEmpty();
            return;
        }

        var diagnosisResults = new List<DiagnosisResult>();

        foreach (var disease in diseases)
        {
            // Tính CF dựa trên triệu chứng
            var cf = CertaintyFactor.CalculateDiseaseCF(symptomResponses, disease.SymptomsCF);

            // Tính độ khớp (% triệu chứng khớp)
            var matchingSymptoms = disease.Symptoms.Count(s => selectedSymptoms.Contains(s));
            var matchPercentage = disease.Symptoms.Count > 0
                ? (matchingSymptoms / (double)disease.Symptoms.Count) * 100
                : 0;

            var confidence = CertaintyFactor.CfToConfidence(cf);

            if (cf > 0.1) // Chỉ lấy CF > 0.1
            {
                diagnosisResults.Add(new DiagnosisResult
                {
                    Disease = disease,
                    MatchPercentage = matchPercentage,
                    CertaintyFactor = cf,
                    Confidence = confidence,
                });
            }
        }

        // Sắp xếp theo CF giảm dần
        results = diagnosisResults.OrderByDescending(r => r.CertaintyFactor).ToList();
        DisplayResults();
    }

    private void DisplayEmpty()
    {
        resultPanel.Controls.Clear();
        resultPanel.Controls.Add(emptyLabel);
    }

    private void DisplayResults()
    {
        resultPanel.Controls.Clear();
        resultPanel.Visible = true;

        if (results == null || results.Count == 0)
        {
            var noResultLabel = new Label
            {
                Text = "Không tìm thấy kết quả phù hợp với các triệu chứng đã chọn.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F),
            };
            resultPanel.Controls.Add(noResultLabel);
            return;
        }

        var resultGroup = new GroupBox
        {
            Text = $"Kết quả dựa trên Certainty Factor · {selectedSymptoms.Count} triệu chứng",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Padding = new Padding(20),
            Margin = new Padding(15),
        };

        var resultContainer = new FlowLayoutPanel
        {
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(15),
            Margin = new Padding(0),
        };

        foreach (var result in results)
        {
            var resultCard = CreateResultCard(result);
            resultContainer.Controls.Add(resultCard);
        }

        var warningLabel = new Label
        {
            Text = "Lưu ý: Kết quả chẩn đoán dựa trên hệ số Certainty Factor (CF) chỉ mang tính chất tham khảo. " +
                   "Vui lòng đến cơ sở y tế để được bác sĩ thăm khám và chẩn đoán chính xác.",
            Dock = DockStyle.Bottom,
            ForeColor = Color.Blue,
            Font = new Font("Segoe UI", 9F, FontStyle.Italic),
            Padding = new Padding(10),
            AutoSize = false,
            Height = 60,
        };

        var scrollPanel = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(5, 5, 5, 20),
        };

        scrollPanel.Controls.Add(resultContainer);

        resultGroup.Controls.Add(scrollPanel);
        resultGroup.Controls.Add(warningLabel);

        resultPanel.Controls.Add(resultGroup);

        // Update card widths after adding to panel
        scrollPanel.Layout += (s, e) =>
        {
            var cardWidth = Math.Max(scrollPanel.ClientSize.Width - 50, 400);
            foreach (Control control in resultContainer.Controls)
            {
                if (control is Panel card && scrollPanel.ClientSize.Width > 0)
                {
                    card.Width = cardWidth;
                }
            }
        };

        // Initial width update
        if (scrollPanel.ClientSize.Width > 0)
        {
            var cardWidth = Math.Max(scrollPanel.ClientSize.Width - 50, 400);
            foreach (Control control in resultContainer.Controls)
            {
                if (control is Panel card)
                {
                    card.Width = cardWidth;
                }
            }
        }

        // Save to history
        SaveToHistory();

        // Trigger event
        OnDiagnosisAdded?.Invoke(this, EventArgs.Empty);
    }

    private Panel CreateResultCard(DiagnosisResult result)
    {
        var card = new Panel
        {
            Size = new Size(820, 380),
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(10, 12, 10, 12),
            Padding = new Padding(20),
            BackColor = Color.White,
        };

        // Line 1: Disease Name (Centered)
        var titleLabel = new Label
        {
            Text = result.Disease.Name,
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 36,
            TextAlign = ContentAlignment.MiddleCenter,
            Margin = new Padding(0, 0, 0, 12),
        };

        // Line 2: Severity (Left) and CF (Right)
        var metricRowPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 26,
            Margin = new Padding(0, 0, 0, 12),
        };

        var severityDot = new Label
        {
            Text = "●",
            Font = new Font("Arial", 12F),
            ForeColor = result.Disease.Severity == "high" ? Color.Red :
                       result.Disease.Severity == "medium" ? Color.Orange : Color.Green,
            AutoSize = true,
            Location = new Point(0, 3),
        };

        var severityLabel = new Label
        {
            Text = $"Mức độ: {result.Disease.Severity.ToUpperInvariant()}",
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(20, 0),
        };

        var cfBadge = new Label
        {
            Text = $"CF: {(result.CertaintyFactor * 100):F1}% - " +
                   (result.Confidence == "high" ? "Độ tin cậy cao" :
                    result.Confidence == "medium" ? "Độ tin cậy TB" : "Độ tin cậy thấp"),
            Font = new Font("Segoe UI", 10F),
            ForeColor = result.Confidence == "high" ? Color.Green :
                       result.Confidence == "medium" ? Color.Orange : Color.Gray,
            AutoSize = true,
            Location = new Point(0, 0),
        };

        metricRowPanel.Controls.Add(severityDot);
        metricRowPanel.Controls.Add(severityLabel);
        metricRowPanel.Controls.Add(cfBadge);

        metricRowPanel.Layout += (s, e) =>
        {
            cfBadge.Location = new Point(metricRowPanel.Width - cfBadge.Width, 0);
        };

        // Line 3: Description (Centered)
        var descLabel = new Label
        {
            Text = result.Disease.Description,
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 40,
            Font = new Font("Segoe UI", 9.5F),
            ForeColor = Color.FromArgb(60, 60, 60),
            Margin = new Padding(0, 0, 0, 12),
            TextAlign = ContentAlignment.MiddleCenter,
        };

        // Line 4: Progress bar (NO label)
        var progressBar = new ProgressBar
        {
            Dock = DockStyle.Top,
            Height = 22,
            Minimum = 0,
            Maximum = 100,
            Value = (int)CertaintyFactor.CfToPercentage(result.CertaintyFactor),
            Margin = new Padding(0, 0, 0, 12),
        };

        // Treatment section with proper padding
        var treatmentGroup = new GroupBox
        {
            Text = "Hướng dẫn điều trị",
            Dock = DockStyle.Top,
            Height = 100,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Padding = new Padding(12, 12, 12, 12),
            Margin = new Padding(0, 0, 0, 12),
        };

        var treatmentLabel = new Label
        {
            Text = result.Disease.Treatment,
            Dock = DockStyle.Fill,
            AutoSize = false,
            Font = new Font("Segoe UI", 9.5F),
            TextAlign = ContentAlignment.TopLeft,
        };

        treatmentGroup.Controls.Add(treatmentLabel);

        // Bottom button
        var buttonRow = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 40,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(0),
            Margin = new Padding(0),
        };

        var backwardButton = new Button
        {
            Text = result.Confidence != "high" ? "Hỏi thêm để tăng CF" : "Xem giải thích",
            Width = 150,
            Height = 35,
            Tag = result,
            Font = new Font("Segoe UI", 9F),
            FlatStyle = FlatStyle.Standard,
        };
        backwardButton.Click += (s, e) =>
        {
            var backwardForm = new BackwardChainingForm(result.Disease, symptoms, symptomResponses);
            backwardForm.OnUpdateResponses += (responses) =>
            {
                symptomResponses = responses;
                selectedSymptoms = responses.Where(kv => kv.Value == "yes").Select(kv => kv.Key).ToList();
                CalculateDiagnosis();
            };
            backwardForm.ShowDialog();
        };

        buttonRow.Controls.Add(backwardButton);

        card.Controls.Add(buttonRow);
        card.Controls.Add(treatmentGroup);
        card.Controls.Add(progressBar);
        card.Controls.Add(descLabel);
        card.Controls.Add(metricRowPanel);
        card.Controls.Add(titleLabel);

        return card;
    }

    private void SaveToHistory()
    {
        if (results == null || results.Count == 0) return;

        var history = DataService.LoadHistory();
        var record = new DiagnosisRecord
        {
            Id = DateTime.Now.Ticks.ToString(),
            Date = DateTime.Now,
            SelectedSymptoms = selectedSymptoms,
            SymptomResponses = symptomResponses,
            Results = results,
        };

        history.Insert(0, record);
        DataService.SaveHistory(history);
    }

    private void emptyLabel_Click(object sender, EventArgs e)
    {

    }
}
