using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Drawing3D.Projectors
{
	public interface IProjector
	{
		PointF Project( Point3D point );
	}
}
