namespace ExpertSystemWinForms.Forms;

partial class DiagnosisHistoryForm
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel mainPanel;
    private Panel headerPanel;
    private Label headerLabel;
    private Button clearButton;
    private ListBox historyListBox;
    private Panel detailPanel;

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
        mainPanel = new TableLayoutPanel();
        headerPanel = new Panel();
        headerLabel = new Label();
        clearButton = new Button();
        historyListBox = new ListBox();
        detailPanel = new Panel();
        mainPanel.SuspendLayout();
        headerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainPanel
        // 
        mainPanel.ColumnCount = 2;
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        mainPanel.Controls.Add(headerPanel, 0, 0);
        mainPanel.Controls.Add(historyListBox, 0, 1);
        mainPanel.Controls.Add(detailPanel, 1, 1);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(12, 12);
        mainPanel.Margin = new Padding(0);
        mainPanel.Name = "mainPanel";
        mainPanel.RowCount = 2;
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainPanel.Size = new Size(1351, 851);
        mainPanel.TabIndex = 0;
        // 
        // headerPanel
        // 
        headerPanel.BackColor = Color.FromArgb(245, 248, 255);
        mainPanel.SetColumnSpan(headerPanel, 2);
        headerPanel.Controls.Add(headerLabel);
        headerPanel.Controls.Add(clearButton);
        headerPanel.Dock = DockStyle.Fill;
        headerPanel.Location = new Point(4, 4);
        headerPanel.Margin = new Padding(0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(12);
        headerPanel.Size = new Size(1343, 92);
        headerPanel.TabIndex = 0;
        // 
        // headerLabel
        // 
        headerLabel.AutoSize = false;
        // fill remaining headerPanel space so text can be centered while clearButton stays on the right
        headerLabel.Dock = DockStyle.Fill;
        headerLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        headerLabel.ForeColor = Color.FromArgb(41, 128, 185);
        headerLabel.Location = new Point(12, 12);
        headerLabel.Margin = new Padding(0);
        headerLabel.Name = "headerLabel";
        headerLabel.Size = new Size(243, 36);
        headerLabel.TabIndex = 0;
        headerLabel.Text = "LỊCH SỬ CHẨN ĐOÁN";
        headerLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // clearButton
        // 
        clearButton.BackColor = Color.FromArgb(220, 53, 69);
        clearButton.Dock = DockStyle.Right;
        clearButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        clearButton.ForeColor = Color.White;
        clearButton.Location = new Point(1156, 12);
        clearButton.Margin = new Padding(0, 12, 12, 12);
        clearButton.Name = "clearButton";
        clearButton.Padding = new Padding(12, 0, 12, 0);
        clearButton.Size = new Size(175, 68);
        clearButton.TabIndex = 1;
        clearButton.Text = "Xóa lịch sử";
        clearButton.UseVisualStyleBackColor = false;
        clearButton.Click += ClearButton_Click;
        // 
        // historyListBox
        // 
        historyListBox.Dock = DockStyle.Fill;
        historyListBox.Font = new Font("Segoe UI", 10F);
        historyListBox.ItemHeight = 28;
        historyListBox.Location = new Point(4, 104);
        historyListBox.Margin = new Padding(4);
        historyListBox.Name = "historyListBox";
        historyListBox.Size = new Size(464, 743);
        historyListBox.TabIndex = 1;
        historyListBox.SelectedIndexChanged += HistoryListBox_SelectedIndexChanged;
        // 
        // detailPanel
        // 
        detailPanel.AutoScroll = true;
        detailPanel.BackColor = Color.White;
        detailPanel.Dock = DockStyle.Fill;
        detailPanel.Location = new Point(476, 104);
        detailPanel.Margin = new Padding(4);
        detailPanel.Name = "detailPanel";
        detailPanel.Padding = new Padding(12);
        detailPanel.Size = new Size(871, 743);
        detailPanel.TabIndex = 2;
        // 
        // DiagnosisHistoryForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        BackColor = Color.White;
        Controls.Add(mainPanel);
        Margin = new Padding(0);
        Name = "DiagnosisHistoryForm";
        Padding = new Padding(12);
        Size = new Size(1375, 875);
        mainPanel.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        ResumeLayout(false);
    }
}


