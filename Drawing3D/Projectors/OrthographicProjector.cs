using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Drawing3D.Projectors
{

	public enum EOrthographicView
	{
		Isometric,
		XY,
		YZ,
		XZ,
	}
	public class OrthographicProjector : IProjector
	{
		public OrthographicProjector()
		{
			InitMatrix();
			SetView( EOrthographicView.Isometric );
		}

		public float Scale
		{
			get
			{
				return m_ScaleM[ 0, 0 ];
			}
			set
			{
				for( int i = 0; i < MATRIXSize; i++ ) {
					m_ScaleM[ i, i ] = value;
				}
			}
		}

		public void IncreaseScale( float ratio )
		{
			for( int i = 0; i < MATRIXSize; i++ ) {
				m_ScaleM[ i, i ] *= ratio;
			}
		}

		public void SetView( EOrthographicView view )
		{
			float rot90deg = (float)( Math.PI * 0.5 );
			switch( view ) {
				case EOrthographicView.XY:
					SetRotationMatrixAsXYPlane();
					break;
				case EOrthographicView.XZ: {
						float[,] rotMatrix = 
							MathMatrix.CalcHomogeneousRotMatrix( -1 * rot90deg, 0, 0 );
						SetRotationMatrixAsXYPlane();
						m_RotationMatrix = m_RotationMatrix.Multiply( rotMatrix );
					}
					break;
				case EOrthographicView.YZ: {
						float[,] rotMatrix = 
							MathMatrix.CalcHomogeneousRotMatrix( 0, -1 * rot90deg, 0 );
						SetRotationMatrixAsXYPlane();
						m_RotationMatrix = m_RotationMatrix.Multiply( rotMatrix );
					}
					break;
				case EOrthographicView.Isometric: {
						// Assume currently is XY plane, rotate to isometric position

						// Rot X 45 deg
						float thetaX = -1 * (float)( 0.25 * Math.PI );
						float thetaY = 0f;

						// Then Rot Z 135 deg 
						float thetaZ = (float)( -135f / 180 * Math.PI );
						float[,] rotMatrix = MathMatrix.CalcHomogeneousRotMatrix( thetaX, thetaY, thetaZ );
						float[,] vec = new float[ 3, 1 ] { { (float)( 1f / Math.Sqrt( 3 ) ) }, { (float)( 1f / Math.Sqrt( 3 ) ) }, { (float)( 1f / Math.Sqrt( 3 ) ) } };

						SetRotationMatrixAsXYPlane();
						m_RotationMatrix = m_RotationMatrix.Multiply( rotMatrix );
					}
					break;
				default:
					// undone
					break;
			}
		}

		public void RotateView( float thetaX, float thetaY, float thetaZ )
		{
			float[,] rotMatrix = MathMatrix.CalcHomogeneousRotMatrix( thetaX, thetaY, thetaZ );
			m_RotationMatrix = m_RotationMatrix.Multiply( rotMatrix );
		}

		public void SetOffset( float x, float y, float z )
		{
			const int translateIndex = 3;
			m_OffsetMatrix[ 0, translateIndex ] = x;
			m_OffsetMatrix[ 1, translateIndex ] = y;
			m_OffsetMatrix[ 2, translateIndex ] = z;
		}

		public void AddOffset( float x, float y, float z )
		{
			const int translateIndex = 3;
			m_OffsetMatrix[ 0, translateIndex ] += x;
			m_OffsetMatrix[ 1, translateIndex ] += y;
			m_OffsetMatrix[ 2, translateIndex ] += z;
		}

		public PointF Project( Point3D point )
		{
			// Let Offset as first matrix, so offset depends on projected coord instead of space coord
			float[,] fullMatrix = m_OffsetMatrix.Multiply( m_ScaleM ).Multiply( m_RotationMatrix );
			return Project( fullMatrix, point );
		}

		public PointF OnlyRotationProject( Point3D point )
		{
			float[,] fullMatrix = m_RotationMatrix;
			return Project( fullMatrix, point );
		}

		public PointF Project( float[,] fullMatrix, Point3D point )
		{
			float x = fullMatrix[ ix, 0 ] * point.X + fullMatrix[ ix, 1 ] * point.Y
				+ fullMatrix[ ix, 2 ] * point.Z + fullMatrix[ ix, 3 ];

			float y = fullMatrix[ iy, 0 ] * point.X + fullMatrix[ iy, 1 ] * point.Y
				+ fullMatrix[ iy, 2 ] * point.Z + fullMatrix[ iy, 3 ];

			return new PointF( x, y );
		}

		// private
		const int MATRIXSize = 4;

		// Ref: https://stackoverflow.com/questions/45159118/how-to-use-the-projection-camera-technique-in-c-sharp
		// According to orthographic projection https://en.wikipedia.org/wiki/Orthographic_projection

		// Input is (X,Y,Z) and output is (x,y,z)
		// Left is Matrix P and right is 3D point ( in homogeneous coordinate, just assume it's x,y,z,1 )
		// [ X2x Y2x Z2x offsetX ] [X]   [2dy]
		// [ X2y Y2y Z2y offsetY ] [Y] = [2dy]
		// [ X2z Y2z Z2z offsetZ ] [Z]	 [2dz] <-- no use
		// [  0    0   0       1 ] [1]	 [  1] <-- homogeneous coord
		// X2x == [0,0]
		// Z2x == [0,2]
		// X2z == [2,0]
		const int ix = 0;
		const int iy = 1;
		float[,] m_RotationMatrix = new float[ MATRIXSize, MATRIXSize ];
		float[,] m_OffsetMatrix = new float[ MATRIXSize, MATRIXSize ];
		float[,] m_ScaleM = new float[ MATRIXSize, MATRIXSize ];
		void InitMatrix()
		{
			SetInitOffsetMatrix();
			SetRotationMatrixAsXYPlane();
			Scale = 1f;
		}

		void SetInitOffsetMatrix()
		{
			// Only reset rotation part
			for( int i = 0; i < MATRIXSize; i++ ) {
				for( int j = 0; j < MATRIXSize; j++ ) {
					m_OffsetMatrix[ i, j ] = 0f;
				}
			}
			// Default offset is zero, only diagonal value
			for( int i = 0; i < MATRIXSize; i++ ) {
				m_OffsetMatrix[ i, i ] = 1f;
			}
		}

		void SetRotationMatrixAsXYPlane()
		{
			ClearRotationMatrix();

			// Default set to XY plane
			m_RotationMatrix[ 0, 0 ] = 1f;
			m_RotationMatrix[ 1, 1 ] = 1f;
		}

		void ClearRotationMatrix()
		{
			// Only reset rotation part
			for( int i = 0; i < MATRIXSize - 1; i++ ) {
				for( int j = 0; j < MATRIXSize - 1; j++ ) {
					m_RotationMatrix[ i, j ] = 0f;
				}
			}
			// Homogeneous matrix element
			m_RotationMatrix[ 3, 3 ] = 1f;
		}
	}
}
