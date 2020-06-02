using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawing3D
{
	public struct Point3D
	{
		public float X;
		public float Y;
		public float Z;
		public Point3D( float x, float y, float z )
		{
			X = x;
			Y = y;
			Z = z;
		}

		public float[,] ToVerticalMatrix( bool bHomogeneousCoord )
		{
			int nLength = bHomogeneousCoord ? SIZE + 1 : SIZE;

			float[,] m = new float[ nLength, 1 ];
			m[0, 0 ] = X;
			m[1, 0 ] = Y;
			m[2, 0 ] = Z;
			if( bHomogeneousCoord ) {
				m[ 3, 0 ] = 1;
			}
			return m;
		}

		public override string ToString()
		{
			return $"{X} {Y} {Z}";
		}

		// private
		const int SIZE = 3;
	}
}
