using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class GradientPanelMouseOver : Panel
{
    public GradientPanelMouseOver()
    {
        this.ResizeRedraw = true;
    }
    protected override void OnPaintBackground(PaintEventArgs e)
    {
        var brush = new LinearGradientBrush(this.ClientRectangle,
                Color.SkyBlue, Color.LightBlue, LinearGradientMode.Vertical);
        var brush2 = new SolidBrush(Color.Navy);
        var brush3 = new LinearGradientBrush(this.ClientRectangle,
                Color.SkyBlue, Color.SeaGreen, LinearGradientMode.Horizontal);

        if (this.BackColor == Color.LightBlue)
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
        else if (this.BackColor == Color.LightSkyBlue)
        {
            e.Graphics.FillRectangle(brush2, this.ClientRectangle);
        }
        else if (this.BackColor == Color.SeaGreen)
        {
            e.Graphics.FillRectangle(brush3, this.ClientRectangle);
        }
    }
    protected override void OnScroll(ScrollEventArgs se)
    {
        this.Invalidate();
        base.OnScroll(se);
    }
}