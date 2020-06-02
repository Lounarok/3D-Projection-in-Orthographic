using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Drawing3D.Projectors
{
	public class CartesianToGdi
	{
		public CartesianToGdi( Size size )
		{
			m_Size = size;
		}

		public PointF ToGdi( PointF Cartesian2DPt )
		{
			// Gdi coord origin is top left, but Cartesian is bottom left
			PointF gdiPt = new PointF();
			gdiPt.X = Cartesian2DPt.X;
			gdiPt.Y = m_Size.Height - Cartesian2DPt.Y;
			return gdiPt;
		}

		// private
		Size m_Size;
	}
}
