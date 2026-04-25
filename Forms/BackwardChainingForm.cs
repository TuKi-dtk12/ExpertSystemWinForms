using ExpertSystemWinForms.Models;
using ExpertSystemWinForms.Utils;

namespace ExpertSystemWinForms.Forms;

public class BackwardChainingForm : Form
{
    private Disease disease;
    private List<Symptom> symptoms;
    private Dictionary<string, string> responses;
    private List<SymptomQuestion>? questionsToAsk;
    private int currentQuestionIndex = 0;
    private double currentCF = 0;

    private Label? questionLabel;
    private Label? descLabel;
    private Label? cfLabel;
    private ProgressBar? cfProgressBar;
    private ListBox? inferenceLog;
    private Button? yesButton;
    private Button? noButton;
    private Button? unknownButton;
    private Button? finishButton;

    public event Action<Dictionary<string, string>>? OnUpdateResponses;

    public BackwardChainingForm(Disease disease, List<Symptom> symptoms, Dictionary<string, string> currentResponses)
    {
        this.disease = disease;
        this.symptoms = symptoms;
        this.responses = new Dictionary<string, string>(currentResponses);

        SetupUI();
        InitializeQuestions();
        UpdateUI();
    }

    private void SetupUI()
    {
        this.Text = "Suy diễn lùi (Backward Chaining)";
        this.Size = new Size(780, 700);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.White;
        this.Padding = new Padding(0);

        var mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4,
            Padding = new Padding(20),
            BackColor = Color.White,
        };
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        // Header
        var headerLabel = new Label
        {
            Text = $"Xác định bệnh: {disease.Name}",
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            Dock = DockStyle.Fill,
            AutoSize = true,
            Margin = new Padding(0, 0, 0, 12),
        };

        // CF display with proper margins
        var cfPanel = new Panel
        {
            Height = 100,
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(245, 248, 255),
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(20, 10, 20, 10),
            Margin = new Padding(0, 0, 0, 16),
        };

        cfLabel = new Label
        {
            Text = "Độ tin cậy (CF): 0%",
            Dock = DockStyle.Top,
            Height = 35,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(52, 152, 219),
            Margin = new Padding(0, 0, 0, 8),
        };

        cfProgressBar = new ProgressBar
        {
            Dock = DockStyle.Bottom,
            Height = 30,
            Minimum = 0,
            Maximum = 100,
            Style = ProgressBarStyle.Continuous,
            Margin = new Padding(0),
        };

        cfPanel.Controls.Add(cfProgressBar);
        cfPanel.Controls.Add(cfLabel);

        // Question panel
        var questionPanel = new GroupBox
        {
            Text = "Câu hỏi hiện tại",
            Height = 180,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            Padding = new Padding(16, 20, 16, 16),
            Margin = new Padding(0, 0, 0, 16),
        };

        questionLabel = new Label
        {
            Text = "",
            AutoSize = true,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            ForeColor = Color.FromArgb(33, 33, 33),
            Dock = DockStyle.Top,
            Margin = new Padding(0, 0, 0, 8),
        };

        descLabel = new Label
        {
            Text = "",
            AutoSize = true,
            Font = new Font("Segoe UI", 10F),
            ForeColor = Color.FromArgb(100, 100, 100),
            Dock = DockStyle.Top,
            Margin = new Padding(0, 0, 0, 12),
        };

        var buttonPanel = new FlowLayoutPanel
        {
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight,
            Dock = DockStyle.Bottom,
            AutoSize = false,
            Margin = new Padding(0),    
        };

        yesButton = new Button
        {
            Text = "Có",
            Size = new Size(140, 40),
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            BackColor = Color.FromArgb(39, 174, 96),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 0, 8, 0),
            Anchor = AnchorStyles.None,
        };
        yesButton.FlatAppearance.BorderSize = 0;
        yesButton.Click += (s, e) => HandleResponse("yes");

        noButton = new Button
        {
            Text = "Không",
            Size = new Size(140, 40),
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            BackColor = Color.FromArgb(220, 53, 69),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 0, 8, 0),
            Anchor = AnchorStyles.None,
        };
        noButton.FlatAppearance.BorderSize = 0;
        noButton.Click += (s, e) => HandleResponse("no");

        unknownButton = new Button
        {
            Text = "Không chắc",
            Size = new Size(140, 40),
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            BackColor = Color.FromArgb(155, 155, 155),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 0, 0, 0),
            Anchor = AnchorStyles.None,
        };
        unknownButton.FlatAppearance.BorderSize = 0;
        unknownButton.Click += (s, e) => HandleResponse("unknown");

        finishButton = new Button
        {
            Text = "Cập nhật kết quả",
            Size = new Size(200, 40),
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            BackColor = Color.FromArgb(46, 152, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Visible = false,
            Margin = new Padding(0, 0, 0, 0),
        };
        finishButton.FlatAppearance.BorderSize = 0;
        finishButton.Click += FinishButton_Click;

        buttonPanel.Controls.Add(yesButton);
        buttonPanel.Controls.Add(noButton);
        buttonPanel.Controls.Add(unknownButton);
        buttonPanel.Controls.Add(finishButton);

        questionPanel.Controls.Add(buttonPanel);
        questionPanel.Controls.Add(descLabel);
        questionPanel.Controls.Add(questionLabel);
        questionPanel.Controls.Add(buttonPanel);

        // Inference log
        var logGroup = new GroupBox
        {
            Text = "Quá trình suy diễn",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            Padding = new Padding(12, 16, 12, 12),
        };

        inferenceLog = new ListBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 9F),
            BorderStyle = BorderStyle.FixedSingle,
        };

        logGroup.Controls.Add(inferenceLog);

        mainPanel.Controls.Add(headerLabel, 0, 0);
        mainPanel.Controls.Add(cfPanel, 0, 1);
        mainPanel.Controls.Add(questionPanel, 0, 2);
        mainPanel.Controls.Add(logGroup, 0, 3);

        this.Controls.Add(mainPanel);

        // Add initial log entries
        inferenceLog.Items.Add($"🎯 Mục tiêu: Xác định bệnh \"{disease.Name}\"");
        inferenceLog.Items.Add($"📋 Triệu chứng cần kiểm tra: {disease.Symptoms.Count} triệu chứng");
        inferenceLog.Items.Add($"🔍 Bắt đầu suy diễn lùi...");
    }

    private void InitializeQuestions()
    {
        questionsToAsk = disease.Symptoms
            .Select(symptomId => new
            {
                SymptomId = symptomId,
                CF = disease.SymptomsCF.ContainsKey(symptomId) ? disease.SymptomsCF[symptomId] : 0.5,
                Symptom = symptoms.FirstOrDefault(s => s.Id == symptomId),
            })
            .Where(x => x.Symptom != null)
            .Where(x => !responses.ContainsKey(x.SymptomId) || responses[x.SymptomId] == "unknown")
            .OrderByDescending(x => x.CF)
            .Select(x => new SymptomQuestion
            {
                SymptomId = x.SymptomId,
                Symptom = x.Symptom!,
                CF = x.CF,
            })
            .ToList();
    }

    private void UpdateUI()
    {
        // Calculate current CF
        currentCF = CertaintyFactor.CalculateDiseaseCF(responses, disease.SymptomsCF);
        cfLabel!.Text = $"Độ tin cậy hiện tại (CF): {(currentCF * 100):F1}%";
        cfProgressBar!.Value = (int)CertaintyFactor.CfToPercentage(currentCF);

        if (currentQuestionIndex >= questionsToAsk!.Count)
        {
            // All questions answered
            questionLabel!.Text = "Đã hoàn thành tất cả câu hỏi!";
            descLabel!.Text = $"CF cuối cùng: {(currentCF * 100):F1}%";
            yesButton!.Visible = false;
            noButton!.Visible = false;
            unknownButton!.Visible = false;
            finishButton!.Visible = true;
        }
        else
        {
            var question = questionsToAsk![currentQuestionIndex];
            questionLabel!.Text = $"Câu hỏi {currentQuestionIndex + 1}/{questionsToAsk.Count}: Bạn có triệu chứng \"{question.Symptom.Name}\" không?";
            descLabel!.Text = $"{question.Symptom.Description} (Mức độ quan trọng: {(question.CF * 100):F0}%)";
        }
    }

    private void HandleResponse(string answer)
    {
        if (currentQuestionIndex >= questionsToAsk!.Count) return;

        var question = questionsToAsk![currentQuestionIndex];
        responses[question.SymptomId] = answer;

        var newCF = CertaintyFactor.CalculateDiseaseCF(responses, disease.SymptomsCF);
        var step = answer == "yes"
            ? $"✅ Có triệu chứng \"{question.Symptom.Name}\" (CF: {(question.CF * 100):F0}%) → CF hiện tại: {(newCF * 100):F1}%"
            : answer == "no"
            ? $"❌ Không có triệu chứng \"{question.Symptom.Name}\" → Giảm CF: {(newCF * 100):F1}%"
            : $"❓ Không chắc về triệu chứng \"{question.Symptom.Name}\" → CF không đổi";

        inferenceLog!.Items.Add(step);
        inferenceLog!.SelectedIndex = inferenceLog.Items.Count - 1;

        currentQuestionIndex++;
        UpdateUI();
    }

    private void FinishButton_Click(object? sender, EventArgs e)
    {
        var finalCF = CertaintyFactor.CalculateDiseaseCF(responses, disease.SymptomsCF);
        inferenceLog!.Items.Add($"🎉 Kết thúc suy diễn lùi. CF cuối cùng cho bệnh \"{disease.Name}\": {(finalCF * 100):F1}%");

        OnUpdateResponses?.Invoke(responses);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private class SymptomQuestion
    {
        public string SymptomId { get; set; } = string.Empty;
        public Symptom Symptom { get; set; } = new();
        public double CF { get; set; }
    }
}

