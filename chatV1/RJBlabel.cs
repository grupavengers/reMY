using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace chatV1
{
	internal class RJBlabel : Label
	{
		private int borderSize = 0;
		private int borderRadius = 40;
		private Color borderColor = Color.PaleVioletRed;

		public RJBlabel()
		{
			this.FlatStyle = FlatStyle.Flat;
			//this.FlatAppearance.BorderSize = 0;
			this.Size = new Size(150, 40);
			this.BackColor = Color.MediumSlateBlue;
			this.ForeColor = Color.White;
			this.borderColor = Color.DarkSlateGray;
		}

		private GraphicsPath GetFigurePath(RectangleF rect, float radius)
		{
			GraphicsPath path = new GraphicsPath();
			path.StartFigure();
			path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
			path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
			path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
			path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
			path.CloseFigure();
			return path;
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
		}
	}
}
