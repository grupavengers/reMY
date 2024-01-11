namespace chatV1
{
	partial class UserControl1
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
			this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2CirclePictureBox1
			// 
			this.guna2CirclePictureBox1.ImageRotate = 0F;
			this.guna2CirclePictureBox1.Location = new System.Drawing.Point(3, 16);
			this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
			this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
			this.guna2CirclePictureBox1.Size = new System.Drawing.Size(55, 55);
			this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.guna2CirclePictureBox1.TabIndex = 0;
			this.guna2CirclePictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(68, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(202, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// UserControl1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSlateGray;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.guna2CirclePictureBox1);
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(319, 91);
			((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
		private System.Windows.Forms.Label label1;
	}
}
