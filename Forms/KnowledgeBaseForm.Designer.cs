namespace ExpertSystemWinForms.Forms;

partial class KnowledgeBaseForm
{
    private System.ComponentModel.IContainer components = null;
    private TabControl tabControl;
    private TabPage symptomTab;
    private TableLayoutPanel symptomPanel;
    private ListBox symptomListBox;
    private Panel symptomButtonPanel;
    private Button addSymptomButton;
    private Button editSymptomButton;
    private Button deleteSymptomButton;
    private TabPage diseaseTab;
    private TableLayoutPanel diseasePanel;
    private ListBox diseaseListBox;
    private Panel diseaseButtonPanel;
    private Button addDiseaseButton;
    private Button editDiseaseButton;
    private Button deleteDiseaseButton;
    private Panel actionPanel;
    private Button importJsonButton;
    private Button exportJsonButton;

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
        tabControl = new TabControl();
        symptomTab = new TabPage();
        symptomPanel = new TableLayoutPanel();
        symptomListBox = new ListBox();
        symptomButtonPanel = new Panel();
        addSymptomButton = new Button();
        editSymptomButton = new Button();
        deleteSymptomButton = new Button();
        diseaseTab = new TabPage();
        diseasePanel = new TableLayoutPanel();
        diseaseListBox = new ListBox();
        diseaseButtonPanel = new Panel();
        addDiseaseButton = new Button();
        editDiseaseButton = new Button();
        deleteDiseaseButton = new Button();
        actionPanel = new Panel();
        importJsonButton = new Button();
        exportJsonButton = new Button();
        tabControl.SuspendLayout();
        symptomTab.SuspendLayout();
        symptomPanel.SuspendLayout();
        symptomButtonPanel.SuspendLayout();
        diseaseTab.SuspendLayout();
        diseasePanel.SuspendLayout();
        diseaseButtonPanel.SuspendLayout();
        actionPanel.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Controls.Add(symptomTab);
        tabControl.Controls.Add(diseaseTab);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Font = new Font("Segoe UI", 9F);
        tabControl.Location = new Point(12, 12);
        tabControl.Margin = new Padding(0);
        tabControl.Name = "tabControl";
        // Make tabs wider so long labels fit on a single line
        tabControl.Padding = new Point(6, 6);
        tabControl.SizeMode = TabSizeMode.Fixed;
        tabControl.ItemSize = new Size(240, 32);
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(1216, 781);
        tabControl.TabIndex = 0;
        // Use owner-draw to enable custom selected-tab background coloring
        tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
        tabControl.DrawItem += TabControl_DrawItem;
        // 
        // symptomTab
        // 
        symptomTab.BackColor = Color.White;
        symptomTab.Controls.Add(symptomPanel);
        symptomTab.Location = new Point(4, 34);
        symptomTab.Margin = new Padding(0);
        symptomTab.Name = "symptomTab";
        symptomTab.Padding = new Padding(12);
        symptomTab.Size = new Size(1208, 813);
        symptomTab.TabIndex = 0;
        symptomTab.Text = "Quản lý triệu chứng";
        symptomTab.UseVisualStyleBackColor = true;
        // 
        // symptomPanel
        // 
        symptomPanel.ColumnCount = 2;
        symptomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        symptomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        symptomPanel.Controls.Add(symptomListBox, 0, 0);
        symptomPanel.Controls.Add(symptomButtonPanel, 1, 0);
        symptomPanel.Dock = DockStyle.Fill;
        symptomPanel.Location = new Point(12, 12);
        symptomPanel.Margin = new Padding(0);
        symptomPanel.Name = "symptomPanel";
        symptomPanel.RowCount = 1;
        symptomPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        symptomPanel.Size = new Size(1184, 789);
        symptomPanel.TabIndex = 0;
        // 
        // symptomListBox
        // 
        symptomListBox.Dock = DockStyle.Fill;
        symptomListBox.Font = new Font("Segoe UI", 10F);
        symptomListBox.ItemHeight = 28;
        symptomListBox.Location = new Point(4, 4);
        symptomListBox.Margin = new Padding(4, 4, 4, 4);
        symptomListBox.Name = "symptomListBox";
        symptomListBox.Size = new Size(820, 781);
        symptomListBox.TabIndex = 0;
        symptomListBox.SelectedIndexChanged += SymptomListBox_SelectedIndexChanged;
        // 
        // symptomButtonPanel
        // 
        symptomButtonPanel.AutoScroll = true;
        symptomButtonPanel.Controls.Add(deleteSymptomButton);
        symptomButtonPanel.Controls.Add(editSymptomButton);
        symptomButtonPanel.Controls.Add(addSymptomButton);
        symptomButtonPanel.Dock = DockStyle.Fill;
        symptomButtonPanel.Location = new Point(832, 4);
        symptomButtonPanel.Margin = new Padding(0);
        symptomButtonPanel.Name = "symptomButtonPanel";
        symptomButtonPanel.Padding = new Padding(8);
        symptomButtonPanel.Size = new Size(348, 781);
        symptomButtonPanel.TabIndex = 1;
        // 
        // addSymptomButton
        // 
        addSymptomButton.BackColor = Color.FromArgb(34, 177, 76);
        addSymptomButton.Dock = DockStyle.Top;
        addSymptomButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        addSymptomButton.ForeColor = Color.White;
        addSymptomButton.Location = new Point(12, 112);
        addSymptomButton.Margin = new Padding(0, 8, 0, 0);
        addSymptomButton.Name = "addSymptomButton";
        addSymptomButton.Size = new Size(324, 48);
        addSymptomButton.TabIndex = 0;
        addSymptomButton.Text = "Thêm triệu chứng";
        addSymptomButton.UseVisualStyleBackColor = false;
        addSymptomButton.Click += AddSymptomButton_Click;
        // 
        // editSymptomButton
        // 
        editSymptomButton.BackColor = Color.FromArgb(155, 155, 155);
        editSymptomButton.Dock = DockStyle.Top;
        editSymptomButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        editSymptomButton.ForeColor = Color.White;
        editSymptomButton.Location = new Point(12, 62);
        editSymptomButton.Margin = new Padding(0, 8, 0, 0);
        editSymptomButton.Name = "editSymptomButton";
        editSymptomButton.Size = new Size(324, 48);
        editSymptomButton.TabIndex = 1;
        editSymptomButton.Text = "Sửa";
        editSymptomButton.UseVisualStyleBackColor = false;
        editSymptomButton.Click += EditSymptomButton_Click;
        // 
        // deleteSymptomButton
        // 
        deleteSymptomButton.BackColor = Color.FromArgb(220, 53, 69);
        deleteSymptomButton.Dock = DockStyle.Top;
        deleteSymptomButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        deleteSymptomButton.ForeColor = Color.White;
        deleteSymptomButton.Location = new Point(12, 12);
        deleteSymptomButton.Margin = new Padding(0, 0, 0, 8);
        deleteSymptomButton.Name = "deleteSymptomButton";
        deleteSymptomButton.Size = new Size(324, 48);
        deleteSymptomButton.TabIndex = 2;
        deleteSymptomButton.Text = "Xóa";
        deleteSymptomButton.UseVisualStyleBackColor = false;
        deleteSymptomButton.Click += DeleteSymptomButton_Click;
        // 
        // diseaseTab
        // 
        diseaseTab.BackColor = Color.White;
        diseaseTab.Controls.Add(diseasePanel);
        diseaseTab.Location = new Point(4, 34);
        diseaseTab.Margin = new Padding(0);
        diseaseTab.Name = "diseaseTab";
        diseaseTab.Padding = new Padding(12);
        diseaseTab.Size = new Size(967, 687);
        diseaseTab.TabIndex = 1;
        diseaseTab.Text = "Quản lý bệnh";
        diseaseTab.UseVisualStyleBackColor = true;
        // 
        // diseasePanel
        // 
        diseasePanel.ColumnCount = 2;
        diseasePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        diseasePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        diseasePanel.Controls.Add(diseaseListBox, 0, 0);
        diseasePanel.Controls.Add(diseaseButtonPanel, 1, 0);
        diseasePanel.Dock = DockStyle.Fill;
        diseasePanel.Location = new Point(12, 12);
        diseasePanel.Margin = new Padding(0);
        diseasePanel.Name = "diseasePanel";
        diseasePanel.RowCount = 1;
        diseasePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        diseasePanel.Size = new Size(943, 663);
        diseasePanel.TabIndex = 0;
        // 
        // diseaseListBox
        // 
        diseaseListBox.Dock = DockStyle.Fill;
        diseaseListBox.Font = new Font("Segoe UI", 10F);
        diseaseListBox.ItemHeight = 28;
        diseaseListBox.Location = new Point(4, 4);
        diseaseListBox.Margin = new Padding(4, 4, 4, 4);
        diseaseListBox.Name = "diseaseListBox";
        diseaseListBox.Size = new Size(652, 655);
        diseaseListBox.TabIndex = 0;
        diseaseListBox.SelectedIndexChanged += DiseaseListBox_SelectedIndexChanged;
        // 
        // diseaseButtonPanel
        // 
        diseaseButtonPanel.AutoScroll = true;
        diseaseButtonPanel.Controls.Add(deleteDiseaseButton);
        diseaseButtonPanel.Controls.Add(editDiseaseButton);
        diseaseButtonPanel.Controls.Add(addDiseaseButton);
        diseaseButtonPanel.Dock = DockStyle.Fill;
        diseaseButtonPanel.Location = new Point(664, 4);
        diseaseButtonPanel.Margin = new Padding(0);
        diseaseButtonPanel.Name = "diseaseButtonPanel";
        diseaseButtonPanel.Padding = new Padding(8);
        diseaseButtonPanel.Size = new Size(275, 655);
        diseaseButtonPanel.TabIndex = 1;
        // 
        // addDiseaseButton
        // 
        addDiseaseButton.BackColor = Color.FromArgb(34, 177, 76);
        addDiseaseButton.Dock = DockStyle.Top;
        addDiseaseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        addDiseaseButton.ForeColor = Color.White;
        addDiseaseButton.Location = new Point(12, 112);
        addDiseaseButton.Margin = new Padding(0, 8, 0, 0);
        addDiseaseButton.Name = "addDiseaseButton";
        addDiseaseButton.Size = new Size(251, 48);
        addDiseaseButton.TabIndex = 0;
        addDiseaseButton.Text = "Thêm bệnh";
        addDiseaseButton.UseVisualStyleBackColor = false;
        addDiseaseButton.Click += AddDiseaseButton_Click;
        // 
        // editDiseaseButton
        // 
        editDiseaseButton.BackColor = Color.FromArgb(155, 155, 155);
        editDiseaseButton.Dock = DockStyle.Top;
        editDiseaseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        editDiseaseButton.ForeColor = Color.White;
        editDiseaseButton.Location = new Point(12, 62);
        editDiseaseButton.Margin = new Padding(0, 8, 0, 0);
        editDiseaseButton.Name = "editDiseaseButton";
        editDiseaseButton.Size = new Size(251, 48);
        editDiseaseButton.TabIndex = 1;
        editDiseaseButton.Text = "Sửa";
        editDiseaseButton.UseVisualStyleBackColor = false;
        editDiseaseButton.Click += EditDiseaseButton_Click;
        // 
        // deleteDiseaseButton
        // 
        deleteDiseaseButton.BackColor = Color.FromArgb(220, 53, 69);
        deleteDiseaseButton.Dock = DockStyle.Top;
        deleteDiseaseButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        deleteDiseaseButton.ForeColor = Color.White;
        deleteDiseaseButton.Location = new Point(12, 12);
        deleteDiseaseButton.Margin = new Padding(0, 0, 0, 8);
        deleteDiseaseButton.Name = "deleteDiseaseButton";
        deleteDiseaseButton.Size = new Size(251, 48);
        deleteDiseaseButton.TabIndex = 2;
        deleteDiseaseButton.Text = "Xóa";
        deleteDiseaseButton.UseVisualStyleBackColor = false;
        deleteDiseaseButton.Click += DeleteDiseaseButton_Click;
        // 
        // actionPanel
        // 
        actionPanel.BackColor = Color.FromArgb(245, 248, 255);
        actionPanel.Controls.Add(exportJsonButton);
        actionPanel.Controls.Add(importJsonButton);
        actionPanel.Dock = DockStyle.Bottom;
        actionPanel.Location = new Point(12, 793);
        actionPanel.Margin = new Padding(0);
        actionPanel.Name = "actionPanel";
        actionPanel.Padding = new Padding(12, 12, 12, 12);
        actionPanel.Size = new Size(1216, 70);
        actionPanel.TabIndex = 1;
        // 
        // importJsonButton
        // 
        importJsonButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        importJsonButton.BackColor = Color.FromArgb(52, 152, 219);
        importJsonButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        importJsonButton.ForeColor = Color.White;
        importJsonButton.Location = new Point(752, 15);
        importJsonButton.Margin = new Padding(0, 0, 8, 0);
        importJsonButton.Name = "importJsonButton";
        importJsonButton.Size = new Size(200, 40);
        importJsonButton.TabIndex = 0;
        importJsonButton.Text = "Nhập JSON";
        importJsonButton.UseVisualStyleBackColor = false;
        // 
        // exportJsonButton
        // 
        exportJsonButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        exportJsonButton.BackColor = Color.FromArgb(26, 188, 156);
        exportJsonButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        exportJsonButton.ForeColor = Color.White;
        exportJsonButton.Location = new Point(974, 15);
        exportJsonButton.Margin = new Padding(0);
        exportJsonButton.Name = "exportJsonButton";
        exportJsonButton.Size = new Size(200, 40);
        exportJsonButton.TabIndex = 1;
        exportJsonButton.Text = "Xuất JSON";
        exportJsonButton.UseVisualStyleBackColor = false;
        // 
        // KnowledgeBaseForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        BackColor = Color.White;
        Controls.Add(tabControl);
        Controls.Add(actionPanel);
        Margin = new Padding(0);
        Name = "KnowledgeBaseForm";
        Padding = new Padding(12);
        Size = new Size(1240, 875);
        tabControl.ResumeLayout(false);
        symptomTab.ResumeLayout(false);
        symptomPanel.ResumeLayout(false);
        symptomButtonPanel.ResumeLayout(false);
        diseaseTab.ResumeLayout(false);
        diseasePanel.ResumeLayout(false);
        diseaseButtonPanel.ResumeLayout(false);
        actionPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}


