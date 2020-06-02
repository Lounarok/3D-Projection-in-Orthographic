using System;

namespace Drawing3D
{
	public static class MathMatrix
	{
		public static float[,] Multiply( this float[,] A, float[,] B )
		{
			int nARows = A.GetLength( 0 );
			int nACols = A.GetLength( 1 );
			int nBRows = B.GetLength( 0 );
			int nBCols = B.GetLength( 1 );

			if( nARows == 0 ) {
				throw new Exception( "this has zero rows" );
			}
			if( nBRows == 0 ) {
				throw new Exception( "Other has zero rows" );
			}

			if( nACols != nBRows ) {
				throw new Exception( $"Unmatched operation: { nACols } columns are in A and { nBRows } rows are in B." );
			}

			float[,] C = new float[ nARows, nBCols ];
			int nCRows = C.GetLength( 0 );
			int nCCols = C.GetLength( 1 );

			//perform the matrix multiplication
			for( int i = 0; i < nCRows; i++ ) {
				for( int j = 0; j < nCCols; j++ ) {
					for( int n = 0; n < nACols; n++ ) {
						C[ i, j ] += A[ i, n ] * B[ n, j ];
					}
				}
			}

			//return the result matrix
			return C;
		}

		public static void Add( this float[,] A, float[,] B )
		{
			int nARows = A.GetLength( 0 );
			int nACols = A.GetLength( 1 );
			int nBRows = B.GetLength( 0 );
			int nBCols = B.GetLength( 1 );

			//Check for empty matrices
			if( 0 == nARows ) {
				throw new Exception( "Matrix this has 0 rows" );
			}
			if( 0 == nBRows ) {
				throw new Exception( "Matrix other has 0 rows" );
			}

			if( ( nARows >= nBRows && nACols >= nBCols ) == false ) {
				throw new Exception( "Not enough size to add other matrix" );
			}

			//Perform the addition operation
			int maxI = Math.Min( nARows, nBRows );
			int maxJ = Math.Min( nARows, nBRows );
			for( int i = 0; i < maxI; i++ ) {
				for( int j = 0; j < maxJ; j++ ) {

					A[ i, j ] = A[ i, j ] + B[ i, j ];
				}
			}
		}

		public static float[,] CalcRotationMatrix( float thetaX, float thetaY, float thetaZ )
		{
			float[,] XRotationMatrix =
			{
				{1, 0, 0},
				{0, cos(thetaX), -sin(thetaX)},
				{0, sin(thetaX), cos(thetaX)}
			};
			float[,] YRotationMatrix =
			{
				{cos(thetaY), 0, sin(thetaY)},
				{0, 1, 0},
				{-sin(thetaY), 0, cos(thetaY)}
			};
			float[,] ZRotationMatrix =
			{
				{cos(thetaZ), -sin(thetaZ), 0},
				{sin(thetaZ), cos(thetaZ), 0},
				{0, 0, 1}
			};
			float[,] XxYMatrix = XRotationMatrix.Multiply( YRotationMatrix );
			float[,] xyz = XxYMatrix.Multiply( ZRotationMatrix );
			return xyz;
		}

		public static float[,] CalcHomogeneousRotMatrix( float thetaX, float thetaY, float thetaZ )
		{
			float[,] XRotationMatrix =
			{
				{1, 0, 0, 0},
				{0, cos(thetaX), -sin(thetaX), 0},
				{0, sin(thetaX), cos(thetaX), 0},
				{0, 0, 0, 1}
			};
			float[,] YRotationMatrix =
			{
				{cos(thetaY), 0, sin(thetaY), 0},
				{0, 1, 0, 0},
				{-sin(thetaY), 0, cos(thetaY), 0},
				{0, 0, 0, 1}
			};
			float[,] ZRotationMatrix =
			{
				{cos(thetaZ), -sin(thetaZ), 0, 0},
				{sin(thetaZ), cos(thetaZ), 0, 0},
				{0, 0, 1, 0},
				{0, 0, 0, 1}
			};
			float[,] XxYMatrix = XRotationMatrix.Multiply( YRotationMatrix );
			float[,] xyz = XxYMatrix.Multiply( ZRotationMatrix );
			return xyz;
		}

		public static float[,] Transpose( this float[,] matrix )
		{
			int w = matrix.GetLength( 0 );
			int h = matrix.GetLength( 1 );

			float[,] result = new float[ h, w ];

			for( int i = 0; i < w; i++ ) {
				for( int j = 0; j < h; j++ ) {
					result[ j, i ] = matrix[ i, j ];
				}
			}

			return result;
		}

		public static void printMatrix( float[,] A )
		{
			for( int i = 0; i < A.GetLength( 0 ); i++ ) {
				for( int j = 0; j < A.GetLength( 1 ); j++ ) {
					Console.Write( A[ i, j ] + "\t" );
				}
				Console.Write( "\n" );
			}
		}

		// private syntax sugar
		static float sin( float x )
		{
			return (float)Math.Sin( x );
		}
		static float cos( float x )
		{
			return (float)Math.Cos( x );
		}
	}
}
