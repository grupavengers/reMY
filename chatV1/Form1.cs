using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

using Guna.UI2.WinForms;
using DocuSign.eSign.Model;
using System.Text.RegularExpressions;

namespace chatV1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Color btn = Color.SpringGreen;
		Color btr = Color.FromArgb(137, 140, 142);
		Color bb = Color.DarkSlateGray;

		// veri tabanı bağlantı cümlesi
		string constring = "Data Source =.\\SQLEXPRESS;Initial Catalog = chat; Integrated Security = True;TrustServerCertificate=True";

		private void label3_Click(object sender, EventArgs e)
		{

		}

		// Giriş Yap Butonu
		private void ButtonLogin_Click(object sender, EventArgs e)
		{
			panel1.BringToFront();

			ButtonKayıt.FillColor = btn;
			ButtonLogin.FillColor = btr;

			panel3.BackColor = btn;
			panel4.BackColor = bb;
		}

		// Yukarıdaki Kayıt Ol Butonu
		private void ButtonKayıt_Click(object sender, EventArgs e)
		{
			panel2.BringToFront();

			ButtonLogin.FillColor = btn;
			ButtonKayıt.FillColor = btr;

			panel3.BackColor = bb;
			panel4.BackColor = btn;
		}

		// Form
		private void Form1_Load(object sender, EventArgs e)
		{
			ButtonLogin.PerformClick();
		}

		// Kayıt Ol
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			if (guna2CirclePictureBox1.Image == null)
			{
				MessageBox.Show("Lütfen bir fotoğraf seçiniz!");
			}
			else
			{

			if (string.IsNullOrEmpty(guna2TextBox3.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox3, "isim yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox3, string.Empty);
			}

			if (string.IsNullOrEmpty(guna2TextBox4.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox4, "soyisim yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox4, string.Empty);
			}

			if (string.IsNullOrEmpty(guna2TextBox5.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox5, "e-posta yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox5, string.Empty);
			}

				if (string.IsNullOrEmpty(guna2TextBox6.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox6, "şifre yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox6, string.Empty);
			}

			if (string.IsNullOrEmpty(guna2TextBox7.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox7, "şifre tekrarı yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox7, string.Empty);
			}

				if (guna2TextBox6.Text != guna2TextBox7.Text)
				{
					MessageBox.Show("Şifre Uyuşmazlığı! Tekrar deneyiniz.");
				}
				else
				{
					SqlConnection con = new SqlConnection(constring);
					string q = "insert into login(firstname,lastname,email,password,confirmpass,image)values(@firstname,@lastname,@email,@password,@confirmpass,@image)";

					SqlCommand cmd = new SqlCommand(q, con);

					MemoryStream me = new MemoryStream();

					guna2CirclePictureBox1.Image.Save(me, guna2CirclePictureBox1.Image.RawFormat);

					cmd.Parameters.AddWithValue("firstname", guna2TextBox3.Text);
					cmd.Parameters.AddWithValue("lastname", guna2TextBox4.Text);
					cmd.Parameters.AddWithValue("email", guna2TextBox5.Text);
					cmd.Parameters.AddWithValue("password", guna2TextBox6.Text);
					cmd.Parameters.AddWithValue("confirmpass", guna2TextBox7.Text);
					cmd.Parameters.AddWithValue("image", me.ToArray());

					con.Open();

					cmd.ExecuteNonQuery();

					con.Close();

					MessageBox.Show("Kayıt olma işlemi başarılı!");

					guna2TextBox3.Clear();
					guna2TextBox4.Clear();
					guna2TextBox5.Clear();
					guna2TextBox6.Clear();
					guna2TextBox7.Clear();

					guna2CirclePictureBox1.Image = null;
				}
			}
		}

		private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Profil Resmi Seçiniz(*Jpg; *.png; *Gif|*.Jpg; *.png; *Gif)";

			if (openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				guna2CirclePictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
			}
		}

		// Giriş Yap
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(guna2TextBox1.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox1, "e-posta yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox1, string.Empty);
			}

			if (string.IsNullOrEmpty(guna2TextBox2.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox2, "şifre yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox2, string.Empty);
			}

			SqlConnection con = new SqlConnection(constring);

			con.Open();

			string q = "select * from login WHERE email = '" + guna2TextBox1.Text + "' AND password = '" + guna2TextBox2.Text + "'";

			SqlCommand cmd = new SqlCommand(q, con);

			SqlDataReader dataReader;

			dataReader = cmd.ExecuteReader();

			if (dataReader.HasRows == true)
			{
				panel5.BringToFront();

				timer1.Start();
			}
			else
			{
				MessageBox.Show("e-posta ve şifreyi kontrol ediniz. ");
			}
			con.Close();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (guna2CircleProgressBar1.Value < 100)
			{
				guna2CircleProgressBar1.Value += 2;
			}
			else
			{
				timer1.Stop();

				Form2 f2 = new Form2();

				f2.emailname = guna2TextBox1.Text;

				this.Hide();

				f2.Show();
			}
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// form 1 kayıt ol şifreyi göster
		private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (guna2TextBox6.PasswordChar == '*' && guna2TextBox7.PasswordChar == '*')
			{
				guna2TextBox6.PasswordChar = '\0';
				guna2TextBox7.PasswordChar = '\0';
			}
			else
			{
				guna2TextBox6.PasswordChar = '*';
				guna2TextBox7.PasswordChar = '*';
			}
		}

		// giriş yap şifreyi göster
		private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (guna2TextBox2.PasswordChar == '*')
			{
				guna2TextBox2.PasswordChar = '\0';
			}
			else
			{
				guna2TextBox2.PasswordChar = '*';
			}
		}
	}
}