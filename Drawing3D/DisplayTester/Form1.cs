using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawing3D;
using Drawing3D.GdiPlusDrawers;
using Drawing3D.Projectors;

namespace DisplayTester
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Draw_Click( this, null );
		}

		const float FIXEDincrement = 10f;

		float len = 100f;
		float x = 0, y = 0, z = 0;
		float scale = 1f;
		float rotinc = (float)( -10f / 180 * Math.PI );
		private void Draw_Click( object sender, EventArgs e )
		{
			List<GdiPlusDrawItem> items = new List<GdiPlusDrawItem>();
			//items.Add( new LineItem( new Point3D( 0,0,0 ), new Point3D(100,100,100), false ) );
			//items.Add( new LineItem( new Point3D( 100, 100, 100 ), new Point3D( 200, 100, 100 ), true ) );
			//items.AddRange(  addtest3Line() );
			items.AddRange( addCube() );
			//items.AddRange( add500kitem() );
			gdiPlus3DDisplay1.SetDrawItems( items.ToArray() );
		}

		List<GdiPlusDrawItem> add500kitem()
		{
			int nCount = 50000;
			Random rnd = new Random();
			Point3D prev = new Point3D( rnd.Next( 0, 100 ), rnd.Next( 0, 100 ), rnd.Next( 0, 100 ) );
			List<GdiPlusDrawItem> list = new List<GdiPlusDrawItem>();
			for( int i = 0; i < nCount; i++ ) {
				Point3D cur = new Point3D( rnd.Next( 0, 100 ), rnd.Next( 0, 100 ), rnd.Next( 0, 100 ) );
				list.Add( new LineItem( prev, cur, false ) );
			}
			return list;
		}

		List<GdiPlusDrawItem> addCube()
		{
			List<GdiPlusDrawItem> items = new List<GdiPlusDrawItem>();


			Point3D p1 = new Point3D( 0, 0, 0 );
			Point3D p2 = new Point3D( len, 0, 0 );
			Point3D p3 = new Point3D( len, 2* len, 0 );
			Point3D p4 = new Point3D( 0, 2 * len, 0 );
			Point3D p5 = new Point3D( 0, 0, len );
			Point3D p6 = new Point3D( len, 0, len );
			Point3D p7 = new Point3D( len, len, len );
			Point3D p8 = new Point3D( 0, len, len );
			// bot 4
			LineItem first = new LineItem( p1, p2, false );
			first.Color = Color.Red;
			items.Add( first );
			items.Add( new LineItem( p2, p3, false ) );
			items.Add( new LineItem( p3, p4, false ) );
			LineItem l2 = new LineItem( p4, p1, false );
			l2.Color = Color.Green;
			items.Add( l2 );

			// pillars
			items.Add( new LineItem( p1, p5, false ) );
			items.Add( new LineItem( p2, p6, false ) );
			items.Add( new LineItem( p3, p7, false ) );
			items.Add( new LineItem( p4, p8, false ) );
			// top 4
			LineItem top1 = new LineItem( p5, p6, false );
			top1.Color = Color.Blue;
			items.Add( top1 );
			items.Add( new LineItem( p6, p7, false ) );
			items.Add( new LineItem( p7, p8, false ) );
			items.Add( new LineItem( p8, p5, false ) );

			return items;
		}

		List<GdiPlusDrawItem> addtest3Line()
		{
			List<GdiPlusDrawItem> items = new List<GdiPlusDrawItem>();
			items.Add( new LineItem( new Point3D( 0, 0, 0 ), new Point3D( 100, 0, 0 ), false ) );
			items.Add( new LineItem( new Point3D( 100, 0, 0 ), new Point3D( 100, 100, 0 ), false ) );
			items.Add( new LineItem( new Point3D( 100, 100, 0 ), new Point3D( 0, 0, 0 ), false ) );
			return items;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.SetView( EOrthographicView.XY );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.SetView( EOrthographicView.Isometric );
		}


		private void button6_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.AddOffset( FIXEDincrement, 0, 0 );
		}
		private void button5_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.AddOffset( -FIXEDincrement, 0, 0 );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.AddOffset( 0, FIXEDincrement, 0 );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.AddOffset( 0, -FIXEDincrement, 0 );
			
		}

		private void button7_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.AddOffset( 0, FIXEDincrement, 0 );
			
		}

		private void button8_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.AddOffset( 0, -FIXEDincrement, 0 );
			
		}

		private void rxm_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.RotateView( -rotinc, 0, 0 );
			
		}

		private void rxp_Click( object sender, EventArgs e )
		{

			gdiPlus3DDisplay1.RotateView( rotinc, 0, 0 );
			
		}

		private void ryp_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.RotateView( 0, rotinc, 0 );
			
		}

		private void rym_Click( object sender, EventArgs e )
		{

			gdiPlus3DDisplay1.RotateView( 0, -rotinc, 0 );
			
		}

		private void rzm_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.RotateView( 0, 0, -rotinc );
			
		}

		private void rzp_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.RotateView( 0, 0, rotinc );
			
		}

		private void btnScaleLarger_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.IncreaseScale( 1.1f );
			
		}

		private void scaleMinus_Click_1( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.IncreaseScale( (float)( 1 / 1.1 ) );
			
		}

		private void YZView_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.SetView( EOrthographicView.YZ );
			
		}

		private void XZView_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.SetView( EOrthographicView.XZ );
			
		}

		private void btnFit_Click( object sender, EventArgs e )
		{
			gdiPlus3DDisplay1.FitCamera();
			
		}
	}
}
