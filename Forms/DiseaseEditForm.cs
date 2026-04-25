using ExpertSystemWinForms.Models;

namespace ExpertSystemWinForms.Forms;

public class DiseaseEditForm : Form
{
    public Disease? Disease { get; private set; }
    private List<Symptom> availableSymptoms;

    private TextBox nameTextBox;
    private TextBox descTextBox;
    private ComboBox severityComboBox;
    private TextBox treatmentTextBox;
    private CheckedListBox symptomCheckedListBox;
    private Dictionary<string, double> symptomCFs = new();

    public DiseaseEditForm(Disease? disease, List<Symptom> symptoms)
    {
        Disease = disease;
        availableSymptoms = symptoms;
        if (disease != null)
        {
            symptomCFs = new Dictionary<string, double>(disease.SymptomsCF);
        }
        SetupUI();
    }

    private void SetupUI()
    {
        Text = Disease == null ? "Thêm bệnh mới" : "Sửa bệnh";
        Size = new Size(700, 650);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Color.White;
        Padding = new Padding(0);

        var mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 6,
            Padding = new Padding(20),
            BackColor = Color.White,
        };
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize) { Height = 40 });
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize) { Height = 70 });
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize) { Height = 40 });
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize) { Height = 90 });
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize) { Height = 50 });

        var nameLabel = new Label
        {
            Text = "Tên bệnh:",
            Dock = DockStyle.Fill,
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(0, 0, 12, 0),
        };

        nameTextBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Text = Disease?.Name ?? "",
            Font = new Font("Segoe UI", 10F),
            Margin = new Padding(0, 0, 0, 12),
            BorderStyle = BorderStyle.FixedSingle,
        };

        var descLabel = new Label
        {
            Text = "Mô tả:",
            Dock = DockStyle.Fill,
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(0, 0, 12, 0),
        };

        descTextBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Text = Disease?.Description ?? "",
            Multiline = true,
            Font = new Font("Segoe UI", 10F),
            Margin = new Padding(0, 0, 0, 12),
            BorderStyle = BorderStyle.FixedSingle,
            ScrollBars = ScrollBars.Vertical,
        };

        var severityLabel = new Label
        {
            Text = "Mức độ:",
            Dock = DockStyle.Fill,
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(0, 0, 12, 0),
        };

        severityComboBox = new ComboBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10F),
            DropDownStyle = ComboBoxStyle.DropDownList,
            Margin = new Padding(0, 0, 0, 12),
        };
        severityComboBox.Items.AddRange(new[] { "Thấp", "Trung bình", "Cao" });
        severityComboBox.SelectedItem = (Disease?.Severity == "low" ? "Thấp" : 
                                        Disease?.Severity == "medium" ? "Trung bình" : 
                                        Disease?.Severity == "high" ? "Cao" : "Trung bình");

        var symptomLabel = new Label
        {
            Text = "Triệu chứng:",
            Dock = DockStyle.Fill,
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(0, 0, 12, 0),
        };

        symptomCheckedListBox = new CheckedListBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10F),
            BorderStyle = BorderStyle.FixedSingle,
            Height = 200,
            DisplayMember = "DisplayText",
            Margin = new Padding(0, 0, 0, 12),
        };
        foreach (var symptom in availableSymptoms)
        {
            bool isChecked = Disease?.Symptoms.Contains(symptom.Id) ?? false;
            symptomCheckedListBox.Items.Add(symptom, isChecked);
        }
        symptomCheckedListBox.ItemCheck += SymptomCheckedListBox_ItemCheck;

        var treatmentLabel = new Label
        {
            Text = "Điều trị:",
            Dock = DockStyle.Fill,
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(0, 0, 12, 0),
        };

        treatmentTextBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Text = Disease?.Treatment ?? "",
            Multiline = true,
            Font = new Font("Segoe UI", 10F),
            Height = 80,
            BorderStyle = BorderStyle.FixedSingle,
            ScrollBars = ScrollBars.Vertical,
            Margin = new Padding(0, 0, 0, 12),
        };

        var buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(0),
            BackColor = Color.White,
        };

        var okButton = new Button
        {
            Text = "Lưu",
            Size = new Size(120, 40),
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            BackColor = Color.FromArgb(46, 152, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
            DialogResult = DialogResult.OK,
            Margin = new Padding(0, 0, 3, 0),
        };
        okButton.FlatAppearance.BorderSize = 0;
        okButton.Click += OkButton_Click;

        var cancelButton = new Button
        {
            Text = "Hủy",
            Size = new Size(120, 40),
            Font = new Font("Segoe UI", 11F),
            BackColor = Color.FromArgb(155, 155, 155),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
            DialogResult = DialogResult.Cancel,
        };
        cancelButton.FlatAppearance.BorderSize = 0;

        buttonPanel.Controls.Add(okButton);
        buttonPanel.Controls.Add(cancelButton);

        mainPanel.Controls.Add(nameLabel, 0, 0);
        mainPanel.Controls.Add(nameTextBox, 1, 0);
        mainPanel.Controls.Add(descLabel, 0, 1);
        mainPanel.Controls.Add(descTextBox, 1, 1);
        mainPanel.Controls.Add(severityLabel, 0, 2);
        mainPanel.Controls.Add(severityComboBox, 1, 2);
        mainPanel.Controls.Add(symptomLabel, 0, 3);
        mainPanel.Controls.Add(symptomCheckedListBox, 1, 3);
        mainPanel.Controls.Add(treatmentLabel, 0, 4);
        mainPanel.Controls.Add(treatmentTextBox, 1, 4);
        mainPanel.Controls.Add(buttonPanel, 0, 5);
        mainPanel.SetColumnSpan(buttonPanel, 2);

        this.Controls.Add(mainPanel);
    }

    private void SymptomCheckedListBox_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        if (e.NewValue == CheckState.Checked)
        {
            var symptom = (Symptom)symptomCheckedListBox.Items[e.Index];
            if (!symptomCFs.ContainsKey(symptom.Id))
            {
                symptomCFs[symptom.Id] = 0.5; // Default CF
            }

            // Show CF input dialog
            var cfForm = new CFInputForm(symptomCFs[symptom.Id], symptom.Name);
            if (cfForm.ShowDialog() == DialogResult.OK)
            {
                symptomCFs[symptom.Id] = cfForm.CFValue;
                // Checkbox will remain checked after OK
            }
            else
            {
                // If user clicks Cancel, prevent the check by keeping previous state
                e.NewValue = e.CurrentValue;
            }
        }
        else if (e.NewValue == CheckState.Unchecked)
        {
            var symptom = (Symptom)symptomCheckedListBox.Items[e.Index];
            symptomCFs.Remove(symptom.Id);
        }
    }

    private void OkButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("Vui lòng nhập tên bệnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.None;
            return;
        }

        var selectedSymptoms = new List<string>();
        for (int i = 0; i < symptomCheckedListBox.Items.Count; i++)
        {
            if (symptomCheckedListBox.GetItemChecked(i))
            {
                var symptom = (Symptom)symptomCheckedListBox.Items[i];
                selectedSymptoms.Add(symptom.Id);
            }
        }

        if (selectedSymptoms.Count == 0)
        {
            MessageBox.Show("Vui lòng chọn ít nhất một triệu chứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.None;
            return;
        }

        // Only include CFs for selected symptoms
        var selectedCFs = symptomCFs.Where(kv => selectedSymptoms.Contains(kv.Key)).ToDictionary(kv => kv.Key, kv => kv.Value);

        Disease = new Disease
        {
            Id = Disease?.Id ?? $"d{DateTime.Now.Ticks}",
            Name = nameTextBox.Text.Trim(),
            Description = descTextBox.Text.Trim(),
            Symptoms = selectedSymptoms,
            SymptomsCF = selectedCFs,
            Severity = (severityComboBox.SelectedItem?.ToString() == "Thấp" ? "low" :
                       severityComboBox.SelectedItem?.ToString() == "Trung bình" ? "medium" :
                       severityComboBox.SelectedItem?.ToString() == "Cao" ? "high" : "medium"),
            Treatment = treatmentTextBox.Text.Trim(),
        };
    }
}

// Helper form for CF input
internal class CFInputForm : Form
{
    public double CFValue { get; private set; }

    public CFInputForm(double initialValue, string symptomName = "")
    {
        CFValue = initialValue;
        SetupCFInputUI(symptomName);
    }

    private void SetupCFInputUI(string symptomName)
    {
        this.Text = "Nhập Certainty Factor";
        this.Size = new Size(600, 420);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.BackColor = Color.White;
        this.Padding = new Padding(0);

        var mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4,
            Padding = new Padding(40, 32, 40, 32),
            BackColor = Color.White,
        };

        // Title with symptom name
        var titleLabel = new Label
        {
            Text = symptomName.Length > 0 ? $"Nhập CF cho bệnh - {symptomName}" : "Nhập Certainty Factor (CF)",
            Dock = DockStyle.Fill,
            AutoSize = false,
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            Height = 44,
            Margin = new Padding(0, 0, 0, 20),
            TextAlign = ContentAlignment.MiddleLeft,
        };

        // Info label
        var infoLabel = new Label
        {
            Text = "- CF (Certainty Factor) phải từ 0.0 đến 1.0 -",
            Dock = DockStyle.Fill,
            AutoSize = false,
            Font = new Font("Segoe UI", 13F),
            ForeColor = Color.FromArgb(100, 100, 100),
            Height = 60,
            Margin = new Padding(0, 0, 0, 20),
            TextAlign = ContentAlignment.TopLeft,
        };

        var cfLabel = new Label
        {
            Text = "CF (0.0 - 1.0):",
            Dock = DockStyle.Fill,
            AutoSize = false,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = Color.FromArgb(41, 128, 185),
            Height = 32,
            TextAlign = ContentAlignment.MiddleLeft,
            Margin = new Padding(0, 0, 0, 12),
        };

        var numericUpDown = new NumericUpDown
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 14F),
            Minimum = 0,
            Maximum = 1,
            DecimalPlaces = 2,
            Increment = 0.1m,
            Value = (decimal)CFValue,
            Height = 48,
            Margin = new Padding(0, 0, 0, 20),
        };

        var buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            BackColor = Color.White,
            Height = 80,
            Padding = new Padding(0, 16, 24, 0),
        };

        var saveButton = new Button
        {
            Text = "Lưu",
            Size = new Size(140, 48),
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            BackColor = Color.FromArgb(46, 152, 235),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
            DialogResult = DialogResult.OK,
            Margin = new Padding(12, 0, 0, 0),
        };
        saveButton.FlatAppearance.BorderSize = 0;
        saveButton.Click += (s, e) => { CFValue = (double)numericUpDown.Value; };

        var cancelButton = new Button
        {
            Text = "Hủy",
            Size = new Size(140, 48),
            Font = new Font("Segoe UI", 12F),
            BackColor = Color.FromArgb(155, 155, 155),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
            DialogResult = DialogResult.Cancel,
        };
        cancelButton.FlatAppearance.BorderSize = 0;

        buttonPanel.Controls.Add(saveButton);
        buttonPanel.Controls.Add(cancelButton);

        mainPanel.Controls.Add(titleLabel, 0, 0);
        mainPanel.Controls.Add(infoLabel, 0, 1);
        mainPanel.Controls.Add(cfLabel, 0, 2);
        mainPanel.Controls.Add(numericUpDown, 0, 3);
        
        var bottomPanel = new Panel { Dock = DockStyle.Bottom, Height = 90, BackColor = Color.White };
        bottomPanel.Controls.Add(buttonPanel);

        this.Controls.Add(mainPanel);
        this.Controls.Add(bottomPanel);
    }
}

