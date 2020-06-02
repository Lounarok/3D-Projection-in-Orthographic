using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Drawing3D.Projectors;

namespace Drawing3D.GdiPlusDrawers
{
	public abstract class GdiPlusDrawItem
	{
		public virtual bool isDashedLine
		{
			get; set;
		} = false;

		public virtual bool isFilled
		{
			get; set;
		} = false;

		public Color Color
		{
			get; set;
		} = Color.Black;

		public int ID
		{
			get; set;
		} = 0;

		public abstract void Draw( Graphics g, IProjector projector, CartesianToGdi transformer );
	}
}
