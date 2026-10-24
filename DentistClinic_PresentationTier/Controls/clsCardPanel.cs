using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DentistClinic_PresentationTier.Controls
{
    public class clsCardPanel : Panel
    {
        private int _borderRadius = 8;
        private Color _borderColor = Color.FromArgb(220, 224, 230);
        private int _borderSize = 1;

        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                UpdateRegion();
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = Math.Max(0, value);
                Invalidate();
            }
        }

        public clsCardPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.White;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0) return;

            if (_borderRadius > 0)
            {
                using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, Width, Height), _borderRadius))
                {
                    this.Region = new Region(path);
                }
            }
            else
            {
                this.Region = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Width <= 0 || Height <= 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);

            if (_borderRadius > 0)
            {
                using (GraphicsPath path = GetRoundedRectanglePath(bounds, _borderRadius))
                {
                    using (SolidBrush brush = new SolidBrush(this.BackColor))
                    {
                        g.FillPath(brush, path);
                    }

                    if (_borderSize > 0)
                    {
                        using (Pen pen = new Pen(_borderColor, _borderSize))
                        {
                            pen.Alignment = PenAlignment.Inset;
                            g.DrawPath(pen, path);
                        }
                    }
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillRectangle(brush, bounds);
                }

                if (_borderSize > 0)
                {
                    using (Pen pen = new Pen(_borderColor, _borderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        g.DrawRectangle(pen, bounds);
                    }
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            if (diameter > bounds.Width) diameter = bounds.Width;
            if (diameter > bounds.Height) diameter = bounds.Height;

            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Top left
            path.AddArc(arc, 180, 90);

            // Top right
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
