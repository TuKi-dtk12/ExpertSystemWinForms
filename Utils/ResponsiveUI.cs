using System;
using System.Windows.Forms;

namespace ExpertSystemWinForms.Utils;

/// <summary>
/// Utility class to handle responsive UI adjustments based on form size
/// </summary>
public static class ResponsiveUI
{
    /// <summary>
    /// Enable responsive scaling for a control and all its children
    /// </summary>
    public static void EnableResponsiveScaling(Control parent, Action<float>? onScaleChanged = null)
    {
        if (parent is Form form)
        {
            form.Resize += (s, e) =>
            {
                var scale = GetResponsiveScale(form);
                onScaleChanged?.Invoke(scale);
                AdjustControlsForSize(form, scale);
            };
        }
    }

    /// <summary>
    /// Calculate responsive scale factor based on form size
    /// </summary>
    private static float GetResponsiveScale(Form form)
    {
        float baseWidth = 1500f;
        float baseHeight = 1000f;
        
        float scaleX = form.Width / baseWidth;
        float scaleY = form.Height / baseHeight;
        
        // Use average scale, but ensure minimum scale of 0.8
        float scale = (scaleX + scaleY) / 2;
        return Math.Max(scale, 0.8f);
    }

    /// <summary>
    /// Adjust font sizes and spacing based on responsive scale
    /// </summary>
    private static void AdjustControlsForSize(Control control, float scale)
    {
        if (control is Label label && label.Font.Bold && label.Font.Size > 12)
        {
            // Adjust large header fonts
            float newSize = Math.Max(10f, label.Font.Size * scale);
            label.Font = new Font(label.Font.FontFamily, newSize, label.Font.Style);
        }
        else if (control is Button button)
        {
            // Adjust button heights proportionally
            int newHeight = Math.Max(30, (int)(40 * scale));
            if (button.Height != newHeight)
            {
                button.Height = newHeight;
            }
        }
        else if (control is TextBox || control is ListBox || control is CheckedListBox)
        {
            // Keep list/text boxes responsive
            if (control.Parent is FlowLayoutPanel || control.Parent is TableLayoutPanel)
            {
                // The layout panel will handle sizing
            }
        }

        // Recursively adjust child controls
        foreach (Control child in control.Controls)
        {
            AdjustControlsForSize(child, scale);
        }
    }

    /// <summary>
    /// Set TableLayoutPanel column/row styles to be responsive
    /// </summary>
    public static void MakeTableLayoutPanelResponsive(TableLayoutPanel panel)
    {
        // Ensure all columns and rows use percentage sizing for responsiveness
        panel.AutoSize = false;
        panel.Dock = DockStyle.Fill;
    }

    /// <summary>
    /// Ensure all controls in a container resize with the container
    /// </summary>
    public static void MakePanelResponsive(Panel panel)
    {
        panel.AutoSize = false;
        panel.Dock = DockStyle.Fill;
        panel.Margin = new Padding(0);
        panel.Padding = new Padding(0);

        foreach (Control child in panel.Controls)
        {
            if (child is Panel childPanel)
            {
                MakePanelResponsive(childPanel);
            }
            else if (child is TableLayoutPanel tlp)
            {
                MakeTableLayoutPanelResponsive(tlp);
            }
            else
            {
                child.Dock = DockStyle.Fill;
                child.Margin = new Padding(0);
            }
        }
    }

    /// <summary>
    /// Configure a FlowLayoutPanel to be responsive
    /// </summary>
    public static void MakeFlowLayoutPanelResponsive(FlowLayoutPanel panel)
    {
        panel.AutoSize = false;
        panel.Dock = DockStyle.Fill;
        panel.Margin = new Padding(0);
        panel.Padding = new Padding(0);
        panel.WrapContents = true;
    }

    /// <summary>
    /// Set responsive minimum and maximum sizes for a form
    /// </summary>
    public static void SetResponsiveFormSize(Form form, Size minimumSize, Size maximumSize)
    {
        form.MinimumSize = minimumSize;
        form.MaximumSize = maximumSize;
        form.AutoScaleMode = AutoScaleMode.Font;
        form.AutoScaleDimensions = new SizeF(10F, 25F);
    }
}
