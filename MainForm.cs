using ExpertSystemWinForms.Forms;
using ExpertSystemWinForms.Services;
using System.Drawing;
using System.Windows.Forms;

namespace ExpertSystemWinForms;

public partial class MainForm : Form
{
    private SymptomSelectionForm symptomSelectionForm = null!;
    private DiagnosisForm diagnosisForm = null!;
    private KnowledgeBaseForm knowledgeBaseForm = null!;
    private DiagnosisHistoryForm historyForm = null!;
    // Colors for each tab (one color per tab page)
    private Color[] tabColors = new Color[]
    {
        Color.FromArgb(46, 152, 235), // Chọn triệu chứng - action blue
        Color.FromArgb(255, 140, 0), // Kết quả chẩn đoán - orange
        Color.FromArgb(149,165,166), // Cơ sở tri thức - gray
        Color.FromArgb(255,105,180)    // Lịch sử chẩn đoán - pink
    };

    public MainForm()
    {
        InitializeComponent();
        InitializeForms();
        LoadData();
        
        // Configure tab control after initialization
        ConfigureTabControl();
        // Enable owner-draw to allow per-tab background colors and precise text centering
        tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
        tabControl.DrawItem += TabControl_DrawItem;
        
        // Enable responsive scaling
        this.Resize += (s, e) => 
        {
            // Refresh layouts when resizing
            tabControl.Invalidate();
            symptomSelectionTab.Invalidate();
            diagnosisTab.Invalidate();
            
            // Recalculate tab widths on resize to keep them equal
            UpdateTabWidths();
        };

        // Force initial repaint so all tabs show their background immediately
        this.Shown += (s, e) =>
        {
            UpdateTabWidths();
            tabControl.Invalidate();
        };
    }

    private void ConfigureTabControl()
    {
        // Set initial tab widths
        UpdateTabWidths();
    }

    private void UpdateTabWidths()
    {
        // Calculate width so N tabs = total width; keep a reasonable minimum width
        int count = Math.Max(1, tabControl.TabCount);
        // Subtract a small margin to avoid built-in scroll buttons appearing due to rounding
        int available = Math.Max(0, tabControl.ClientSize.Width - 6);
        int tabWidth = available / count;
        tabControl.ItemSize = new Size(Math.Max(tabWidth, 100), 36);
        // Repaint tabs after changing size
        tabControl.Invalidate();
    }

    private void TabControl_DrawItem(object? sender, DrawItemEventArgs e)
    {

        var g = e.Graphics;
        // Determine tab rectangle from event args (more reliable)
        Rectangle tabRect = e.Bounds;

        // Improve text rendering quality
        var oldSmoothing = g.SmoothingMode;
        var oldTextHint = g.TextRenderingHint;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        // Choose background color for this tab (fall back to default if not enough colors)
        Color bg = tabColors.Length > e.Index ? tabColors[e.Index] : SystemColors.Control;

        // If selected, slightly darken the color
        if (e.Index == tabControl.SelectedIndex)
        {
            bg = ControlPaint.Dark(bg, 0.05f);
        }

        using (var brush = new SolidBrush(bg))
        {
            g.FillRectangle(brush, tabRect);
        }

        // Draw a subtle bottom border to separate tab bar from content
        using (var pen = new Pen(SystemColors.ControlDark))
        {
            g.DrawLine(pen, tabRect.Left, tabRect.Bottom - 1, tabRect.Right, tabRect.Bottom - 1);
        }

        // Prepare text drawing centered horizontally and vertically
        string text = tabControl.TabPages[e.Index].Text.ToUpperInvariant();
        using (var sf = new StringFormat())
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisCharacter;

            // Choose contrasting text color based on background brightness
            Color textColor = bg.GetBrightness() < 0.6f ? Color.White : Color.Black;

            using (var textBrush = new SolidBrush(textColor))
            {
                // Slightly inset the text so it doesn't touch edges
                RectangleF textRect = new RectangleF(tabRect.Left + 4, tabRect.Top, tabRect.Width - 8, tabRect.Height);
                g.DrawString(text, tabControl.Font, textBrush, textRect, sf);
            }
        }

        // restore graphics state
        g.SmoothingMode = oldSmoothing;
        g.TextRenderingHint = oldTextHint;
    }

    private void InitializeForms()
    {
        // Setup header labels
        headerLabel.Text = "HỆ THỐNG CHẨN ĐOÁN BỆNH THÔNG MINH";
        subtitleLabel.Text = "CHỌN CÁC TRIỆU CHỨNG ĐỂ NHẬN KẾT QUẢ CHẨN ĐOÁN";

        // Setup tab control with equal-width tabs
        tabControl.Dock = DockStyle.Fill;
        tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        tabControl.SizeMode = TabSizeMode.Fixed;
        // Remove internal padding so computed widths fit exactly and avoid scroll buttons
        tabControl.Padding = new Point(0, 0);
        tabControl.Multiline = false;
        // Use UpdateTabWidths to compute item size dynamically
        UpdateTabWidths();
        
        // Ensure tabs fill properly
        symptomSelectionTab.Dock = DockStyle.Fill;
        diagnosisTab.Dock = DockStyle.Fill;
        knowledgeTab.Dock = DockStyle.Fill;
        historyTab.Dock = DockStyle.Fill;

        // Create and setup forms
        symptomSelectionForm = new SymptomSelectionForm();
        symptomSelectionForm.Dock = DockStyle.Fill;
        symptomSelectionForm.OnDiagnose += (selectedSymptoms, symptomResponses) =>
        {
            diagnosisForm.PerformDiagnosis(selectedSymptoms, symptomResponses);
            tabControl.SelectedTab = diagnosisTab; // Switch to diagnosis tab
        };
        symptomSelectionTab.Controls.Add(symptomSelectionForm);

        diagnosisForm = new DiagnosisForm();
        diagnosisForm.Dock = DockStyle.Fill;
        diagnosisForm.OnDiagnosisAdded += DiagnosisForm_OnDiagnosisAdded;
        diagnosisTab.Controls.Add(diagnosisForm);

        knowledgeBaseForm = new KnowledgeBaseForm();
        knowledgeBaseForm.Dock = DockStyle.Fill;
        knowledgeBaseForm.OnDataChanged += KnowledgeBaseForm_OnDataChanged;
        knowledgeTab.Controls.Add(knowledgeBaseForm);

        historyForm = new DiagnosisHistoryForm();
        historyForm.Dock = DockStyle.Fill;
        historyTab.Controls.Add(historyForm);
    }

    private void LoadData()
    {
        var symptoms = DataService.LoadSymptoms();
        var diseases = DataService.LoadDiseases();
        var history = DataService.LoadHistory();

        symptomSelectionForm.LoadData(symptoms);
        diagnosisForm.LoadData(symptoms, diseases);
        knowledgeBaseForm.LoadData(symptoms, diseases);
        historyForm.LoadData(history, symptoms);
    }

    private void KnowledgeBaseForm_OnDataChanged(object? sender, EventArgs e)
    {
        // Reload data when knowledge base changes
        LoadData();
    }

    private void DiagnosisForm_OnDiagnosisAdded(object? sender, EventArgs e)
    {
        // Reload history when new diagnosis is added
        var history = DataService.LoadHistory();
        var symptoms = DataService.LoadSymptoms();
        historyForm.LoadData(history, symptoms);
    }
}

