using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Drawing3D.Projectors;

namespace Drawing3D.GdiPlusDrawers
{
	public class LineItem : GdiPlusDrawItem
	{
		public Point3D Start
		{
			get;set;
		}

		public Point3D End
		{
			get;set;
		}

		public LineItem( Point3D start, Point3D end, bool isDashed )
		{
			Start = start;
			End = end;
			isFilled = true;
			isDashedLine = isDashed;
		}

		public override void Draw( Graphics g, IProjector projector, CartesianToGdi GdiTrans )
		{
			PointF start2d = projector.Project( Start );
			PointF end2d = projector.Project( End );
			PenPicker picker = new PenPicker();
			Pen pen = picker.PickPen( Color, isDashedLine );
			g.DrawLine( pen, GdiTrans.ToGdi( start2d ), GdiTrans.ToGdi( end2d ) );
		}
	}
}
