namespace DisplayTester
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Draw = new System.Windows.Forms.Button();
			this.XYView = new System.Windows.Forms.Button();
			this.btnIsometric = new System.Windows.Forms.Button();
			this.yp = new System.Windows.Forms.Button();
			this.ym = new System.Windows.Forms.Button();
			this.xm = new System.Windows.Forms.Button();
			this.xp = new System.Windows.Forms.Button();
			this.zp = new System.Windows.Forms.Button();
			this.zm = new System.Windows.Forms.Button();
			this.rzm = new System.Windows.Forms.Button();
			this.rzp = new System.Windows.Forms.Button();
			this.rxp = new System.Windows.Forms.Button();
			this.rxm = new System.Windows.Forms.Button();
			this.rym = new System.Windows.Forms.Button();
			this.ryp = new System.Windows.Forms.Button();
			this.btnScaleLarger = new System.Windows.Forms.Button();
			this.btnScaleMinus = new System.Windows.Forms.Button();
			this.btnFit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.YZView = new System.Windows.Forms.Button();
			this.XZView = new System.Windows.Forms.Button();
			this.gdiPlus3DDisplay1 = new Drawing3D.Controls.GdiPlus3DDisplay();
			this.SuspendLayout();
			// 
			// Draw
			// 
			this.Draw.Location = new System.Drawing.Point(592, 21);
			this.Draw.Name = "Draw";
			this.Draw.Size = new System.Drawing.Size(75, 23);
			this.Draw.TabIndex = 1;
			this.Draw.Text = "Draw";
			this.Draw.UseVisualStyleBackColor = true;
			this.Draw.Click += new System.EventHandler(this.Draw_Click);
			// 
			// XYView
			// 
			this.XYView.Location = new System.Drawing.Point(766, 21);
			this.XYView.Name = "XYView";
			this.XYView.Size = new System.Drawing.Size(75, 23);
			this.XYView.TabIndex = 2;
			this.XYView.Text = "XYView";
			this.XYView.UseVisualStyleBackColor = true;
			this.XYView.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnIsometric
			// 
			this.btnIsometric.Location = new System.Drawing.Point(685, 21);
			this.btnIsometric.Name = "btnIsometric";
			this.btnIsometric.Size = new System.Drawing.Size(75, 52);
			this.btnIsometric.TabIndex = 3;
			this.btnIsometric.Text = "isometric view";
			this.btnIsometric.UseVisualStyleBackColor = true;
			this.btnIsometric.Click += new System.EventHandler(this.button2_Click);
			// 
			// yp
			// 
			this.yp.Location = new System.Drawing.Point(658, 232);
			this.yp.Name = "yp";
			this.yp.Size = new System.Drawing.Size(75, 23);
			this.yp.TabIndex = 4;
			this.yp.Text = "Y+";
			this.yp.UseVisualStyleBackColor = true;
			this.yp.Click += new System.EventHandler(this.button3_Click);
			// 
			// ym
			// 
			this.ym.Location = new System.Drawing.Point(658, 291);
			this.ym.Name = "ym";
			this.ym.Size = new System.Drawing.Size(75, 23);
			this.ym.TabIndex = 5;
			this.ym.Text = "Y-";
			this.ym.UseVisualStyleBackColor = true;
			this.ym.Click += new System.EventHandler(this.button4_Click);
			// 
			// xm
			// 
			this.xm.Location = new System.Drawing.Point(592, 261);
			this.xm.Name = "xm";
			this.xm.Size = new System.Drawing.Size(75, 23);
			this.xm.TabIndex = 6;
			this.xm.Text = "X-";
			this.xm.UseVisualStyleBackColor = true;
			this.xm.Click += new System.EventHandler(this.button5_Click);
			// 
			// xp
			// 
			this.xp.Location = new System.Drawing.Point(713, 261);
			this.xp.Name = "xp";
			this.xp.Size = new System.Drawing.Size(75, 23);
			this.xp.TabIndex = 7;
			this.xp.Text = "X+";
			this.xp.UseVisualStyleBackColor = true;
			this.xp.Click += new System.EventHandler(this.button6_Click);
			// 
			// zp
			// 
			this.zp.Location = new System.Drawing.Point(739, 232);
			this.zp.Name = "zp";
			this.zp.Size = new System.Drawing.Size(49, 23);
			this.zp.TabIndex = 8;
			this.zp.Text = "Z+";
			this.zp.UseVisualStyleBackColor = true;
			this.zp.Click += new System.EventHandler(this.button7_Click);
			// 
			// zm
			// 
			this.zm.Location = new System.Drawing.Point(592, 291);
			this.zm.Name = "zm";
			this.zm.Size = new System.Drawing.Size(49, 23);
			this.zm.TabIndex = 9;
			this.zm.Text = "Z-";
			this.zm.UseVisualStyleBackColor = true;
			this.zm.Click += new System.EventHandler(this.button8_Click);
			// 
			// rzm
			// 
			this.rzm.Location = new System.Drawing.Point(592, 415);
			this.rzm.Name = "rzm";
			this.rzm.Size = new System.Drawing.Size(49, 23);
			this.rzm.TabIndex = 15;
			this.rzm.Text = "Z-";
			this.rzm.UseVisualStyleBackColor = true;
			this.rzm.Click += new System.EventHandler(this.rzm_Click);
			// 
			// rzp
			// 
			this.rzp.Location = new System.Drawing.Point(739, 356);
			this.rzp.Name = "rzp";
			this.rzp.Size = new System.Drawing.Size(49, 23);
			this.rzp.TabIndex = 14;
			this.rzp.Text = "Z+";
			this.rzp.UseVisualStyleBackColor = true;
			this.rzp.Click += new System.EventHandler(this.rzp_Click);
			// 
			// rxp
			// 
			this.rxp.Location = new System.Drawing.Point(713, 385);
			this.rxp.Name = "rxp";
			this.rxp.Size = new System.Drawing.Size(75, 23);
			this.rxp.TabIndex = 13;
			this.rxp.Text = "X+";
			this.rxp.UseVisualStyleBackColor = true;
			this.rxp.Click += new System.EventHandler(this.rxp_Click);
			// 
			// rxm
			// 
			this.rxm.Location = new System.Drawing.Point(592, 385);
			this.rxm.Name = "rxm";
			this.rxm.Size = new System.Drawing.Size(75, 23);
			this.rxm.TabIndex = 12;
			this.rxm.Text = "X-";
			this.rxm.UseVisualStyleBackColor = true;
			this.rxm.Click += new System.EventHandler(this.rxm_Click);
			// 
			// rym
			// 
			this.rym.Location = new System.Drawing.Point(658, 415);
			this.rym.Name = "rym";
			this.rym.Size = new System.Drawing.Size(75, 23);
			this.rym.TabIndex = 11;
			this.rym.Text = "Y-";
			this.rym.UseVisualStyleBackColor = true;
			this.rym.Click += new System.EventHandler(this.rym_Click);
			// 
			// ryp
			// 
			this.ryp.Location = new System.Drawing.Point(658, 356);
			this.ryp.Name = "ryp";
			this.ryp.Size = new System.Drawing.Size(75, 23);
			this.ryp.TabIndex = 10;
			this.ryp.Text = "Y+";
			this.ryp.UseVisualStyleBackColor = true;
			this.ryp.Click += new System.EventHandler(this.ryp_Click);
			// 
			// btnScaleLarger
			// 
			this.btnScaleLarger.Location = new System.Drawing.Point(592, 102);
			this.btnScaleLarger.Name = "btnScaleLarger";
			this.btnScaleLarger.Size = new System.Drawing.Size(75, 23);
			this.btnScaleLarger.TabIndex = 18;
			this.btnScaleLarger.Text = "Scale+";
			this.btnScaleLarger.UseVisualStyleBackColor = true;
			this.btnScaleLarger.Click += new System.EventHandler(this.btnScaleLarger_Click);
			// 
			// btnScaleMinus
			// 
			this.btnScaleMinus.Location = new System.Drawing.Point(592, 131);
			this.btnScaleMinus.Name = "btnScaleMinus";
			this.btnScaleMinus.Size = new System.Drawing.Size(75, 23);
			this.btnScaleMinus.TabIndex = 20;
			this.btnScaleMinus.Text = "Scale-";
			this.btnScaleMinus.UseVisualStyleBackColor = true;
			this.btnScaleMinus.Click += new System.EventHandler(this.scaleMinus_Click_1);
			// 
			// btnFit
			// 
			this.btnFit.Location = new System.Drawing.Point(592, 50);
			this.btnFit.Name = "btnFit";
			this.btnFit.Size = new System.Drawing.Size(75, 23);
			this.btnFit.TabIndex = 21;
			this.btnFit.Text = "FitCamera";
			this.btnFit.UseVisualStyleBackColor = true;
			this.btnFit.Click += new System.EventHandler(this.btnFit_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(612, 334);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 12);
			this.label1.TabIndex = 22;
			this.label1.Text = "Rotation";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(596, 232);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 12);
			this.label2.TabIndex = 23;
			this.label2.Text = "Offset";
			// 
			// YZView
			// 
			this.YZView.Location = new System.Drawing.Point(766, 50);
			this.YZView.Name = "YZView";
			this.YZView.Size = new System.Drawing.Size(75, 23);
			this.YZView.TabIndex = 24;
			this.YZView.Text = "YZView";
			this.YZView.UseVisualStyleBackColor = true;
			this.YZView.Click += new System.EventHandler(this.YZView_Click);
			// 
			// XZView
			// 
			this.XZView.Location = new System.Drawing.Point(766, 79);
			this.XZView.Name = "XZView";
			this.XZView.Size = new System.Drawing.Size(75, 23);
			this.XZView.TabIndex = 25;
			this.XZView.Text = "XZView";
			this.XZView.UseVisualStyleBackColor = true;
			this.XZView.Click += new System.EventHandler(this.XZView_Click);
			// 
			// gdiPlus3DDisplay1
			// 
			this.gdiPlus3DDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gdiPlus3DDisplay1.Dock = System.Windows.Forms.DockStyle.Left;
			this.gdiPlus3DDisplay1.Location = new System.Drawing.Point(0, 0);
			this.gdiPlus3DDisplay1.Name = "gdiPlus3DDisplay1";
			this.gdiPlus3DDisplay1.Size = new System.Drawing.Size(586, 450);
			this.gdiPlus3DDisplay1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(862, 450);
			this.Controls.Add(this.XZView);
			this.Controls.Add(this.YZView);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnFit);
			this.Controls.Add(this.btnScaleMinus);
			this.Controls.Add(this.btnScaleLarger);
			this.Controls.Add(this.rzm);
			this.Controls.Add(this.rzp);
			this.Controls.Add(this.rxp);
			this.Controls.Add(this.rxm);
			this.Controls.Add(this.rym);
			this.Controls.Add(this.ryp);
			this.Controls.Add(this.zm);
			this.Controls.Add(this.zp);
			this.Controls.Add(this.xp);
			this.Controls.Add(this.xm);
			this.Controls.Add(this.ym);
			this.Controls.Add(this.yp);
			this.Controls.Add(this.btnIsometric);
			this.Controls.Add(this.XYView);
			this.Controls.Add(this.Draw);
			this.Controls.Add(this.gdiPlus3DDisplay1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Drawing3D.Controls.GdiPlus3DDisplay gdiPlus3DDisplay1;
		private System.Windows.Forms.Button Draw;
		private System.Windows.Forms.Button XYView;
		private System.Windows.Forms.Button btnIsometric;
		private System.Windows.Forms.Button yp;
		private System.Windows.Forms.Button ym;
		private System.Windows.Forms.Button xm;
		private System.Windows.Forms.Button xp;
		private System.Windows.Forms.Button zp;
		private System.Windows.Forms.Button zm;
		private System.Windows.Forms.Button rzm;
		private System.Windows.Forms.Button rzp;
		private System.Windows.Forms.Button rxp;
		private System.Windows.Forms.Button rxm;
		private System.Windows.Forms.Button rym;
		private System.Windows.Forms.Button ryp;
		private System.Windows.Forms.Button btnScaleLarger;
		private System.Windows.Forms.Button btnScaleMinus;
		private System.Windows.Forms.Button btnFit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button YZView;
		private System.Windows.Forms.Button XZView;
	}
}

