namespace ExpertSystemWinForms.Forms;

partial class DiagnosisForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private Panel wrapperPanel;
    private Panel headerPanel;
    private Panel resultPanel;
    private Label headerLabel;
    private Label instructionLabel;
    private Label emptyLabel;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        wrapperPanel = new Panel();
        resultPanel = new Panel();
        emptyLabel = new Label();
        headerPanel = new Panel();
        instructionLabel = new Label();
        headerLabel = new Label();
        wrapperPanel.SuspendLayout();
        resultPanel.SuspendLayout();
        headerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // wrapperPanel
        // 
        wrapperPanel.BackColor = Color.White;
        wrapperPanel.Controls.Add(resultPanel);
        wrapperPanel.Controls.Add(headerPanel);
        wrapperPanel.Dock = DockStyle.Fill;
        wrapperPanel.Location = new Point(12, 12);
        wrapperPanel.Margin = new Padding(0);
        wrapperPanel.Name = "wrapperPanel";
        wrapperPanel.Padding = new Padding(6);
        wrapperPanel.Size = new Size(1351, 851);
        wrapperPanel.TabIndex = 0;
        // 
        // resultPanel
        // 
        resultPanel.AutoScroll = true;
        resultPanel.BackColor = Color.FromArgb(250, 250, 250);
        resultPanel.Controls.Add(emptyLabel);
        resultPanel.Dock = DockStyle.Fill;
        resultPanel.Location = new Point(6, 112);
        resultPanel.Margin = new Padding(0);
        resultPanel.Name = "resultPanel";
        resultPanel.Padding = new Padding(12);
        resultPanel.Size = new Size(1339, 739);
        resultPanel.TabIndex = 1;
        // 
        // emptyLabel
        // 
        emptyLabel.Dock = DockStyle.Fill;
        emptyLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        emptyLabel.ForeColor = Color.Gray;
        emptyLabel.Location = new Point(6, 12);
        emptyLabel.Margin = new Padding(4, 0, 4, 0);
        emptyLabel.Name = "emptyLabel";
        emptyLabel.Size = new Size(1327, 677);
        emptyLabel.TabIndex = 0;
        emptyLabel.Text = "Chọn triệu chứng ở tab 'Chọn Triệu Chứng' và nhấn 'Chẩn Đoán' để xem kết quả tại đây.";
        emptyLabel.TextAlign = ContentAlignment.MiddleCenter;
        emptyLabel.Click += emptyLabel_Click;
        // 
        // headerPanel
        // 
        headerPanel.BackColor = Color.White;
        headerPanel.Controls.Add(instructionLabel);
        headerPanel.Controls.Add(headerLabel);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(6, 6);
        headerPanel.Margin = new Padding(0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(20, 12, 20, 12);
        headerPanel.Size = new Size(1339, 100);
        headerPanel.TabIndex = 0;
        // 
        // instructionLabel
        // 
        instructionLabel.AutoSize = false;
        instructionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        instructionLabel.ForeColor = Color.FromArgb(90, 90, 90);
        instructionLabel.Dock = DockStyle.Top;
        instructionLabel.Location = new Point(20, 62);
        instructionLabel.Margin = new Padding(0, 0, 0, 0);
        instructionLabel.Name = "instructionLabel";
        instructionLabel.Size = new Size(1299, 38);
        instructionLabel.TabIndex = 1;
        instructionLabel.Text = "Các kết quả sẽ hiển thị bên dưới với mức độ tin cậy (CF) rõ ràng hơn. Bạn có thể quay lại tab trước để điều chỉnh triệu chứng.";
        instructionLabel.TextAlign = ContentAlignment.MiddleCenter;
        instructionLabel.UseCompatibleTextRendering = true;
        // 
        // headerLabel
        // 
        headerLabel.AutoSize = false;
        headerLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        headerLabel.ForeColor = Color.FromArgb(41, 128, 185);
        headerLabel.Dock = DockStyle.Top;
        headerLabel.Location = new Point(20, 12);
        headerLabel.Margin = new Padding(0, 0, 0, 8);
        headerLabel.Name = "headerLabel";
        headerLabel.Size = new Size(1299, 50);
        headerLabel.TabIndex = 0;
        headerLabel.Text = "KẾT QUẢ CHẨN ĐOÁN";
        headerLabel.TextAlign = ContentAlignment.MiddleCenter;
        headerLabel.UseCompatibleTextRendering = true;
        // 
        // DiagnosisForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        BackColor = Color.White;
        Controls.Add(wrapperPanel);
        Margin = new Padding(0);
        Name = "DiagnosisForm";
        Padding = new Padding(12);
        Size = new Size(1375, 875);
        wrapperPanel.ResumeLayout(false);
        resultPanel.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        ResumeLayout(false);
    }
}


