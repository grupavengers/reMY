namespace chatV1
{
	partial class UserControl3
	{
		/// <summary> 
		///Gerekli tasarımcı değişkeni.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		///Kullanılan tüm kaynakları temizleyin.
		/// </summary>
		///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Bileşen Tasarımcısı üretimi kod

		/// <summary> 
		/// Tasarımcı desteği için gerekli metot - bu metodun 
		///içeriğini kod düzenleyici ile değiştirmeyin.
		/// </summary>
		private void InitializeComponent()
		{
			this.rjBlabel1 = new chatV1.RJBlabel();
			this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
			((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// rjBlabel1
			// 
			this.rjBlabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rjBlabel1.BackColor = System.Drawing.Color.SpringGreen;
			this.rjBlabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rjBlabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.rjBlabel1.ForeColor = System.Drawing.Color.White;
			this.rjBlabel1.Location = new System.Drawing.Point(77, 14);
			this.rjBlabel1.Name = "rjBlabel1";
			this.rjBlabel1.Padding = new System.Windows.Forms.Padding(8);
			this.rjBlabel1.Size = new System.Drawing.Size(323, 51);
			this.rjBlabel1.TabIndex = 1;
			this.rjBlabel1.Text = "rjBlabel1";
			// 
			// guna2CirclePictureBox1
			// 
			this.guna2CirclePictureBox1.ImageRotate = 0F;
			this.guna2CirclePictureBox1.Location = new System.Drawing.Point(14, 19);
			this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
			this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
			this.guna2CirclePictureBox1.Size = new System.Drawing.Size(46, 38);
			this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.guna2CirclePictureBox1.TabIndex = 2;
			this.guna2CirclePictureBox1.TabStop = false;
			// 
			// UserControl3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSlateGray;
			this.Controls.Add(this.guna2CirclePictureBox1);
			this.Controls.Add(this.rjBlabel1);
			this.Name = "UserControl3";
			this.Size = new System.Drawing.Size(408, 78);
			this.Load += new System.EventHandler(this.UserControl3_Load);
			((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RJBlabel rjBlabel1;
		private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
	}
}
