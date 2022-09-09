using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TenAndLitvinovWFControlLibrary
{
    public class ToggleSwitch : CheckBox
    {
        public Color OnColor { get; set; } = Color.Green;
        public Color OffColor { get; set; } = Color.Beige;
        public Color OnBackColor { get; set; } = Color.DarkGray;
        public Color OffBackColor { get; set; } = Color.LightGray;
        public ToggleSwitch()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = new GraphicsPath())
            {
                var d = DisplayRectangle.X;
                var r = Height - 2 * d;
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d - 1, d, r, r, -90, 180);

                path.CloseFigure();
                e.Graphics.FillPath(Checked ? new SolidBrush(OnBackColor) : new SolidBrush(OffBackColor), path);
                r = Height;
                var rect = Checked ? new Rectangle(Width - r - 1, 0, r, r - 1)//r
                                                                              //: new Rectangle(0, 0, r, r);
                                   : new Rectangle(0, 0, r, r - 1);//l

                e.Graphics.FillEllipse(Checked ? new SolidBrush(OnColor) : new SolidBrush(OffColor), rect);
            }
        }
    }
}