using ExpertSystemWinForms.Models;

namespace ExpertSystemWinForms.Forms;

public class SymptomEditForm : Form
{
    public Symptom? Symptom { get; private set; }

    private TextBox nameTextBox;
    private TextBox descTextBox;

    public SymptomEditForm(Symptom? symptom)
    {
        Symptom = symptom;
        SetupUI();
    }

    private void SetupUI()
    {
        Text = Symptom == null ? "Thêm triệu chứng mới" : "Sửa triệu chứng";
        Size = new Size(780, 460);
        MinimumSize = new Size(720, 420);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = Color.White;
        Padding = new Padding(0);

        var mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 4,
            Padding = new Padding(24, 20, 24, 20),
            BackColor = Color.White,
        };
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        var nameLabel = new Label
        {
            Text = "Tên triệu chứng:",
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
            Text = Symptom?.Name ?? "",
            Font = new Font("Segoe UI", 11F),
            Margin = new Padding(0, 0, 0, 16),
            BorderStyle = BorderStyle.FixedSingle,
        };

        var descLabel = new Label
        {
            Text = "Mô tả chi tiết:",
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
            Text = Symptom?.Description ?? "",
            Multiline = true,
            Font = new Font("Segoe UI", 10F),
            Margin = new Padding(0, 0, 0, 16),
            ScrollBars = ScrollBars.Vertical,
            MinimumSize = new Size(0, 160),
            BorderStyle = BorderStyle.FixedSingle,
        };

        var buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(0, 12, 0, 0),
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
            Margin = new Padding(0, 0, 8, 0),
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
        mainPanel.SetRowSpan(descTextBox, 2);
        mainPanel.Controls.Add(buttonPanel, 0, 3);
        mainPanel.SetColumnSpan(buttonPanel, 2);

        this.Controls.Add(mainPanel);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // SymptomEditForm
        // 
        ClientSize = new Size(278, 244);
        Name = "SymptomEditForm";
        Load += SymptomEditForm_Load;
        ResumeLayout(false);

    }

    private void OkButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            MessageBox.Show("Vui lòng nhập tên triệu chứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.None;
            return;
        }

        Symptom = new Symptom
        {
            Id = Symptom?.Id ?? $"s{DateTime.Now.Ticks}",
            Name = nameTextBox.Text.Trim(),
            Description = descTextBox.Text.Trim(),
        };
    }

    private void SymptomEditForm_Load(object sender, EventArgs e)
    {

    }
}

