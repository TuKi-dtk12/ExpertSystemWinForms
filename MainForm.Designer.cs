namespace ExpertSystemWinForms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private TabControl tabControl;
    private Panel headerPanel;
    private Label headerLabel;
    private Label subtitleLabel;
    private TabPage symptomSelectionTab;
    private TabPage diagnosisTab;
    private TabPage knowledgeTab;
    private TabPage historyTab;

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
        headerPanel = new Panel();
        headerLabel = new Label();
        subtitleLabel = new Label();
        tabControl = new TabControl();
        symptomSelectionTab = new TabPage();
        diagnosisTab = new TabPage();
        knowledgeTab = new TabPage();
        historyTab = new TabPage();
        headerPanel.SuspendLayout();
        tabControl.SuspendLayout();
        SuspendLayout();
        // 
        // headerPanel
        // 
        headerPanel.BackColor = Color.FromArgb(41, 128, 185);
        headerPanel.Controls.Add(headerLabel);
        headerPanel.Controls.Add(subtitleLabel);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Margin = new Padding(0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(20, 16, 20, 16);
        headerPanel.Size = new Size(1500, 120);
        headerPanel.TabIndex = 1;
        // 
        // headerLabel
        // 
        headerLabel.AutoSize = false;
        headerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        headerLabel.ForeColor = Color.White;
        headerLabel.Location = new Point(0, 16);
        headerLabel.Margin = new Padding(0, 0, 0, 6);
        headerLabel.Name = "headerLabel";
        headerLabel.Size = new Size(1500, 42);
        headerLabel.TabIndex = 0;
        headerLabel.Text = "HỆ THỐNG CHẨN ĐOÁN BỆNH THÔNG MINH";
        headerLabel.TextAlign = ContentAlignment.MiddleCenter;
        headerLabel.Dock = DockStyle.Top;
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = false;
        subtitleLabel.Font = new Font("Segoe UI", 10F);
        subtitleLabel.ForeColor = Color.FromArgb(230, 240, 250);
        subtitleLabel.Location = new Point(0, 58);
        subtitleLabel.Margin = new Padding(0);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(1500, 28);
        subtitleLabel.TabIndex = 1;
        subtitleLabel.Text = "CHỌN CÁC TRIỆU CHỨNG ĐỂ NHẬN KẾT QUẢ CHẨN ĐOÁN";
        subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        subtitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        // 
        // tabControl
        // 
        tabControl.Controls.Add(symptomSelectionTab);
        tabControl.Controls.Add(diagnosisTab);
        // Swap order: historyTab should be third, knowledgeTab fourth
        tabControl.Controls.Add(historyTab);
        tabControl.Controls.Add(knowledgeTab);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        tabControl.Location = new Point(0, 120);
        tabControl.Margin = new Padding(0);
        tabControl.Name = "tabControl";
        tabControl.Padding = new Point(6, 6);
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(1500, 880);
        tabControl.SizeMode = TabSizeMode.Fixed;
        tabControl.TabIndex = 0;
        // 
        // symptomSelectionTab
        // 
        symptomSelectionTab.BackColor = Color.FromArgb(52, 152, 219);
        symptomSelectionTab.Location = new Point(4, 34);
        symptomSelectionTab.Margin = new Padding(0);
        symptomSelectionTab.Name = "symptomSelectionTab";
        symptomSelectionTab.Padding = new Padding(0);
        symptomSelectionTab.Size = new Size(1400, 842);
        symptomSelectionTab.TabIndex = 0;
        symptomSelectionTab.Text = "CHỌN TRIỆU CHỨNG";
        // 
        // diagnosisTab
        // 
        diagnosisTab.BackColor = Color.FromArgb(255, 140, 0);
        diagnosisTab.Location = new Point(4, 34);
        diagnosisTab.Margin = new Padding(0);
        diagnosisTab.Name = "diagnosisTab";
        diagnosisTab.Padding = new Padding(0);
        diagnosisTab.Size = new Size(1492, 842);
        diagnosisTab.TabIndex = 1;
        diagnosisTab.Text = "KẾT QUẢ CHẨN ĐOÁN";
        // 
        // knowledgeTab
        // 
        knowledgeTab.BackColor = Color.FromArgb(39, 174, 96);
        knowledgeTab.Location = new Point(4, 34);
        knowledgeTab.Margin = new Padding(0);
        knowledgeTab.Name = "knowledgeTab";
        knowledgeTab.Padding = new Padding(0);
        knowledgeTab.Size = new Size(1492, 842);
        knowledgeTab.TabIndex = 3;
        knowledgeTab.Text = "CƠ SỞ TRI THỨC";
        // 
        // historyTab
        // 
        historyTab.BackColor = Color.FromArgb(155, 89, 182);
        historyTab.Location = new Point(4, 34);
        historyTab.Margin = new Padding(0);
        historyTab.Name = "historyTab";
        historyTab.Padding = new Padding(0);
        historyTab.Size = new Size(1492, 842);
        historyTab.TabIndex = 2;
        historyTab.Text = "LỊCH SỬ CHẨN ĐOÁN";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1500, 1000);
        Controls.Add(tabControl);
        Controls.Add(headerPanel);
        Margin = new Padding(0);
        MinimumSize = new Size(800, 600);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Hệ thống chẩn đoán bệnh thông minh";
        WindowState = FormWindowState.Maximized;
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        tabControl.ResumeLayout(false);
        ResumeLayout(false);
    }
}


