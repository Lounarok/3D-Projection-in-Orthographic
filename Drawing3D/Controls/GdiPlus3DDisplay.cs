using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Drawing3D.GdiPlusDrawers;
using Drawing3D.Projectors;

namespace Drawing3D.Controls
{
	public partial class GdiPlus3DDisplay : UserControl
	{
		public GdiPlus3DDisplay()
		{
			InitializeComponent();
			SetDoubleBuffer();

			Paint += GdiPlus3DDisplay_Paint;
			Resize += GdiPlus3DDisplay_Resize;

			m_Projector = new OrthographicProjector();
			m_CartToGdiTransform = new CartesianToGdi( Size );
		}
		public void SetDrawItems( GdiPlusDrawItem[] items )
		{
			if( items is null ) {
				return;
			}
			m_Items = items;
			Refresh();
		}

		public void FitCamera()
		{
			fitCamera();
			Refresh();
		}

		// packing operation for view, so user don't need to call refresh each time.
		public void IncreaseScale( float ratio )
		{
			m_Projector.IncreaseScale( ratio );
			Refresh();
		}

		public void SetView( EOrthographicView view )
		{
			m_Projector.SetView( view );
			fitCamera();
			Refresh();
		}

		public void RotateView( float thetaX, float thetaY, float thetaZ )
		{
			m_Projector.RotateView( thetaX, thetaY, thetaZ );
			Refresh();
		}

		public void SetOffset( float x, float y, float z )
		{
			m_Projector.SetOffset( x, y, z );
			Refresh();
		}

		public void AddOffset( float x, float y, float z )
		{
			m_Projector.AddOffset( x, y, z );
			Refresh();
		}

		//====== private
		CartesianToGdi m_CartToGdiTransform;
		OrthographicProjector m_Projector;
		GdiPlusDrawItem[] m_Items;

		struct BoundF
		{
			public float MaxX;
			public float MinX;
			public float MaxY;
			public float MinY;
			public float MaxZ;
			public float MinZ;

			public float LengthX
			{
				get
				{
					return MaxX - MinX;
				}
			}

			public float LengthY
			{
				get
				{
					return MaxY - MinY;
				}
			}

			public PointF Center
			{
				get
				{
					float x = 0.5f * ( MaxX + MinX );
					float y = 0.5f * ( MaxY + MinY );
					return new PointF( x, y );
				}
			}

			public Point3D Center3D
			{
				get
				{
					float x = 0.5f * ( MaxX + MinX );
					float y = 0.5f * ( MaxY + MinY );
					float z = 0.5f * ( MaxZ + MinZ );
					return new Point3D( x, y, z );
				}
			}

			public BoundF( bool bInitToSmallestValue )
			{
				if( bInitToSmallestValue ) {
					MaxX = float.MinValue;
					MaxY = float.MinValue;
					MinX = float.MaxValue;
					MinY = float.MaxValue;
					MaxZ = float.MinValue;
					MinZ = float.MaxValue;
					return;
				}

				MaxX = 0f;
				MaxY = 0f;
				MinX = 0f;
				MinY = 0f;
				MaxZ = 0f;
				MinZ = 0f;
			}

			// For 2d points
			public BoundF( List<PointF> ptList ) :
				this( true )
			{
				foreach( var item in ptList ) {
					if( item.X > MaxX ) {
						MaxX = item.X;
					}
					if( item.X < MinX ) {
						MinX = item.X;
					}
					if( item.Y > MaxY ) {
						MaxY = item.Y;
					}
					if( item.Y < MinY ) {
						MinY = item.Y;
					}
				}
			}

			// For 3d points
			public BoundF( List<Point3D> ptList ) :
				this( true )
			{
				foreach( var item in ptList ) {
					if( item.X > MaxX ) {
						MaxX = item.X;
					}
					if( item.X < MinX ) {
						MinX = item.X;
					}
					if( item.Y > MaxY ) {
						MaxY = item.Y;
					}
					if( item.Y < MinY ) {
						MinY = item.Y;
					}
					if( item.Z > MaxZ ) {
						MaxZ = item.Z;
					}
					if( item.Z < MinZ ) {
						MinZ = item.Z;
					}
				}
			}
		}

		void SetDoubleBuffer()
		{
			var doubleBufferPropertyInfo = this.GetType().GetProperty( "DoubleBuffered",
				System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic );
			doubleBufferPropertyInfo.SetValue( this, true, null );
		}

		void GdiPlus3DDisplay_Resize( object sender, EventArgs e )
		{
			m_CartToGdiTransform = new CartesianToGdi( Size );
		}


		void GdiPlus3DDisplay_Paint( object sender, PaintEventArgs e )
		{
			if( m_Items == null ) {
				return;
			}
			for( int i = 0; i < m_Items.Length; i++ ) {
				m_Items[ i ].Draw( e.Graphics, m_Projector, m_CartToGdiTransform );
			}
		}

		void fitCamera()
		{
			if( m_Items == null ) {
				return;
			}
			// Get all points
			List<PointF> ptOnScreen = new List<PointF>();
			for( int i = 0; i < m_Items.Length; i++ ) {
				PointF cartStart2d = m_Projector.OnlyRotationProject( ( (LineItem)m_Items[ i ] ).Start );
				//PointF startgraphics = m_CartToGdiTransform.ToGdi( cart2d );
				ptOnScreen.Add( cartStart2d );

				PointF cartEnd2d = m_Projector.OnlyRotationProject( ( (LineItem)m_Items[ i ] ).End );
				//PointF startgraphics = m_CartToGdiTransform.ToGdi( cart2d );
				ptOnScreen.Add( cartEnd2d );
			}
			// Calc Max and Min
			BoundF bound2d = new BoundF( ptOnScreen );

			// Get XY ratio
			float ratioX = Size.Width / bound2d.LengthX;
			float ratioY = Size.Height / bound2d.LengthY;

			// Do set a little ratio to make it fit full screen
			const float fitRatio = 0.95f;

			float ratio = fitRatio * Math.Min( ratioX, ratioY );
			m_Projector.Scale = ratio;

			// Move bounding box center to screen center. 
			float ratioAfterScaled = m_Projector.Scale;
			PointF center2d = bound2d.Center;

			// Because screen is display after scale, translate it into unscaled position
			PointF unscaleScrCenter = new PointF(
				Width * 0.5f / ratioAfterScaled,
				Height * 0.5f / ratioAfterScaled );
			float x = unscaleScrCenter.X - center2d.X;
			float y = unscaleScrCenter.Y - center2d.Y;

			m_Projector.SetOffset( x, y, 0 );
			return;
		}
	}
}
