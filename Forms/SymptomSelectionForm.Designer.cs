namespace ExpertSystemWinForms.Forms;

partial class SymptomSelectionForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel mainPanel;
    private Panel headerPanel;
    private Label titleLabel;
    private Label subtitleLabel;
    private FlowLayoutPanel filterPanel;
    private TextBox searchTextBox;
    private CheckBox showSelectedOnlyCheckBox;
    private Label selectedCountLabel;
    private Panel symptomScrollPanel;
    private FlowLayoutPanel symptomPanel;
    private Panel buttonPanel;
    private Button diagnoseButton;
    private Button resetButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        mainPanel = new Panel();
        symptomScrollPanel = new Panel();
        symptomPanel = new FlowLayoutPanel();
        filterPanel = new FlowLayoutPanel();
        searchTextBox = new TextBox();
        showSelectedOnlyCheckBox = new CheckBox();
        selectedCountLabel = new Label();
        headerPanel = new Panel();
        subtitleLabel = new Label();
        titleLabel = new Label();
        buttonPanel = new Panel();
        diagnoseButton = new Button();
        resetButton = new Button();
        mainPanel.SuspendLayout();
        symptomScrollPanel.SuspendLayout();
        filterPanel.SuspendLayout();
        headerPanel.SuspendLayout();
        buttonPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainPanel
        // 
        mainPanel.BackColor = Color.FromArgb(245, 248, 255);
        mainPanel.Controls.Add(symptomScrollPanel);
        mainPanel.Controls.Add(filterPanel);
        mainPanel.Controls.Add(headerPanel);
        mainPanel.Controls.Add(buttonPanel);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Margin = new Padding(0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new Size(1796, 1034);
        mainPanel.TabIndex = 0;
        // 
        // symptomScrollPanel
        // 
        symptomScrollPanel.AutoScroll = true;
        symptomScrollPanel.Controls.Add(symptomPanel);
        symptomScrollPanel.Dock = DockStyle.Fill;
        symptomScrollPanel.Location = new Point(0, 177);
        symptomScrollPanel.Margin = new Padding(0);
        symptomScrollPanel.Name = "symptomScrollPanel";
        symptomScrollPanel.Padding = new Padding(12);
        symptomScrollPanel.Size = new Size(1796, 769);
        symptomScrollPanel.TabIndex = 3;
        symptomScrollPanel.Layout += SymptomScrollPanel_Layout;
        // 
        // symptomPanel
        // 
        symptomPanel.AutoSize = true;
        symptomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        symptomPanel.FlowDirection = FlowDirection.TopDown;
        symptomPanel.Location = new Point(6, 6);
        symptomPanel.Margin = new Padding(4, 4, 4, 4);
        symptomPanel.Name = "symptomPanel";
        symptomPanel.Padding = new Padding(6, 6, 6, 6);
        symptomPanel.Size = new Size(12, 12);
        symptomPanel.TabIndex = 0;
        symptomPanel.WrapContents = false;
        // 
        // filterPanel
        // 
        filterPanel.Controls.Add(searchTextBox);
        filterPanel.Controls.Add(showSelectedOnlyCheckBox);
        filterPanel.Controls.Add(selectedCountLabel);
        filterPanel.Dock = DockStyle.Top;
        filterPanel.Location = new Point(0, 112);
        filterPanel.Margin = new Padding(0);
        filterPanel.Name = "filterPanel";
        filterPanel.Padding = new Padding(12, 8, 12, 8);
        filterPanel.Size = new Size(1796, 65);
        filterPanel.TabIndex = 2;
        filterPanel.WrapContents = true;
        // 
        // searchTextBox
        // 
        searchTextBox.Font = new Font("Segoe UI", 10F);
        searchTextBox.Location = new Point(10, 10);
        searchTextBox.Margin = new Padding(4, 4, 19, 4);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.PlaceholderText = "Tìm kiếm theo tên hoặc mô tả...";
        searchTextBox.Size = new Size(349, 34);
        searchTextBox.TabIndex = 0;
        searchTextBox.TextChanged += SearchTextBox_TextChanged;
        // 
        // showSelectedOnlyCheckBox
        // 
        showSelectedOnlyCheckBox.AutoSize = true;
        showSelectedOnlyCheckBox.Font = new Font("Segoe UI", 10F);
        showSelectedOnlyCheckBox.Location = new Point(382, 16);
        showSelectedOnlyCheckBox.Margin = new Padding(4, 10, 4, 4);
        showSelectedOnlyCheckBox.Name = "showSelectedOnlyCheckBox";
        showSelectedOnlyCheckBox.Size = new Size(316, 32);
        showSelectedOnlyCheckBox.TabIndex = 1;
        showSelectedOnlyCheckBox.Text = "Chỉ hiển thị triệu chứng đã chọn";
        showSelectedOnlyCheckBox.UseVisualStyleBackColor = true;
        showSelectedOnlyCheckBox.CheckedChanged += ShowSelectedOnlyCheckBox_CheckedChanged;
        // 
        // selectedCountLabel
        // 
        selectedCountLabel.AutoSize = true;
        selectedCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        selectedCountLabel.Location = new Point(733, 16);
        selectedCountLabel.Margin = new Padding(31, 10, 4, 4);
        selectedCountLabel.Name = "selectedCountLabel";
        selectedCountLabel.Size = new Size(229, 28);
        selectedCountLabel.TabIndex = 2;
        selectedCountLabel.Text = "Đã chọn: 0 triệu chứng";
        // 
        // headerPanel
        // 
        headerPanel.BackColor = Color.White;
        headerPanel.Controls.Add(subtitleLabel);
        headerPanel.Controls.Add(titleLabel);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Margin = new Padding(0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(12, 12, 12, 12);
        headerPanel.Size = new Size(1796, 100);
        headerPanel.TabIndex = 0;
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = false;
        subtitleLabel.Font = new Font("Segoe UI", 10F);
        subtitleLabel.ForeColor = Color.FromArgb(85, 85, 85);
        subtitleLabel.Dock = DockStyle.Top;
        subtitleLabel.Location = new Point(12, 62);
        subtitleLabel.Margin = new Padding(0, 0, 0, 0);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(1772, 38);
        subtitleLabel.TabIndex = 1;
        subtitleLabel.Text = "Chọn các triệu chứng liên quan, bạn có thể tìm kiếm hoặc lọc danh sách";
        subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        subtitleLabel.UseCompatibleTextRendering = true;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = false;
        titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(41, 128, 185);
        titleLabel.Dock = DockStyle.Top;
        titleLabel.Location = new Point(12, 12);
        titleLabel.Margin = new Padding(0, 0, 0, 0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(1772, 50);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "CHỌN TRIỆU CHỨNG";
        titleLabel.TextAlign = ContentAlignment.MiddleCenter;
        titleLabel.UseCompatibleTextRendering = true;
        // 
        // buttonPanel
        // 
        buttonPanel.BackColor = Color.FromArgb(245, 248, 255);
        buttonPanel.Controls.Add(diagnoseButton);
        buttonPanel.Controls.Add(resetButton);
        buttonPanel.Dock = DockStyle.Bottom;
        buttonPanel.Location = new Point(0, 946);
        buttonPanel.Margin = new Padding(0);
        buttonPanel.Name = "buttonPanel";
        buttonPanel.Padding = new Padding(12, 12, 12, 12);
        buttonPanel.Size = new Size(1796, 88);
        buttonPanel.TabIndex = 1;
        // 
        // diagnoseButton
        // 
        diagnoseButton.BackColor = Color.FromArgb(46, 152, 235);
        diagnoseButton.Enabled = false;
        diagnoseButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        diagnoseButton.ForeColor = Color.White;
        diagnoseButton.Location = new Point(25, 19);
        diagnoseButton.Margin = new Padding(0, 0, 8, 0);
        diagnoseButton.Name = "diagnoseButton";
        diagnoseButton.Size = new Size(188, 50);
        diagnoseButton.TabIndex = 0;
        diagnoseButton.Text = "Chẩn đoán";
        diagnoseButton.UseVisualStyleBackColor = false;
        diagnoseButton.Click += DiagnoseButton_Click;
        // 
        // resetButton
        // 
        resetButton.BackColor = Color.FromArgb(155, 155, 155);
        resetButton.Font = new Font("Segoe UI", 11F);
        resetButton.ForeColor = Color.White;
        resetButton.Location = new Point(238, 19);
        resetButton.Margin = new Padding(0);
        resetButton.Name = "resetButton";
        resetButton.Size = new Size(188, 50);
        resetButton.TabIndex = 1;
        resetButton.Text = "Làm mới";
        resetButton.UseVisualStyleBackColor = false;
        resetButton.Click += ResetButton_Click;
        // 
        // SymptomSelectionForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        BackColor = Color.White;
        Controls.Add(mainPanel);
        Margin = new Padding(0);
        Name = "SymptomSelectionForm";
        Padding = new Padding(0);
        Size = new Size(1820, 1058);
        mainPanel.ResumeLayout(false);
        symptomScrollPanel.ResumeLayout(false);
        symptomScrollPanel.PerformLayout();
        filterPanel.ResumeLayout(false);
        filterPanel.PerformLayout();
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        buttonPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}


