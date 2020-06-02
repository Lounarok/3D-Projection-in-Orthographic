using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Drawing3D.GdiPlusDrawers
{
	public partial class PenPicker
	{
		public Pen PickPen( Color color, bool isDashLine, float penWidth )
		{
			return InitPen( color, isDashLine, penWidth );
		}

		public Pen PickPen( Color color, bool isDashLine )
		{
			return InitPen( color, isDashLine, defaultWidth );
		}

		public Brush PickBrush( Color color )
		{
			return new SolidBrush( color );
		}
	}

	// Protected
	public partial class PenPicker
	{
	}

	// Private
	public partial class PenPicker
	{
		const float defaultWidth = 1f;

		Pen InitPen( Color color, bool isDashLine, float penWidth )
		{
			System.Drawing.Pen pen = new System.Drawing.Pen( color, penWidth );
			if( isDashLine ) {
				pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			}
			else {
				pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			}
			return pen;
		}

	}
}
