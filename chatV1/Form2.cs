// using Amazon.Auth.AccessControlPolicy;
using chatV1.Properties;
using DocuSign.eSign.Model;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace chatV1
{
	public partial class Form2 : Form
	{
		// herkese açık public şekilde emailname ismnide string veri tipinde bir özellik (property) tanımladık.
		public string emailname { set; get; }

		public Form2()
		{
			InitializeComponent();
		}

		string constring = "Data Source =.\\SQLEXPRESS;Initial Catalog = chat; Integrated Security = True;TrustServerCertificate=True";

		// showProfile metodu ile kullanıcının profiline ait bilgileri ve profil resmini bir kullanıcı arayüzünde göstermiş oluyoruz.
		public void showProfile()
		{
			// Boş bir byte dizisi (getimage) oluşturduk. Bu diziye resim datasını ekleyeceğiz.
			byte[] getimage = new byte[0];

			// veritabanına bağlantı oluşturduk.
			SqlConnection con = new SqlConnection(constring);

			// Veri tabanı bağlantısını açtık.
			con.Open();

			// Kullanıcının girdiği email adresine göre SQL sorgusu oluşturduk.
			string q = "select * from login WHERE email = '" + guna2TextBox7.Text + "'";

			// Yukarıda oluşturduğumuz sorgu ve bağlantı bilgisini kullanarak bir SqlCommand nesnesi oluşturduk.
			SqlCommand cmd = new SqlCommand(q, con);

			// SqlCommand nesnesi üzerinden veri tabanından veri okuma işlemi gerçekleştirip bir SqlDataReader nesnesi elde ettik.
			SqlDataReader dataReader = cmd.ExecuteReader();

			// SqlDataReader nesnesi ile bir satır ilerlenir.
			dataReader.Read();

			//  Eğer SqlDataReader'da okunan satır varsa, kullanıcının profil bilgileri gösteriliyor.

			// Profil bilgilerini etiketlere atadık.
			// (label2, guna2TextBox1, guna2TextBox2, guna2TextBox3, guna2TextBox4, guna2TextBox5, guna2TextBox6, guna2TextBox7)

			if (dataReader.HasRows)
			{
				label2.Text = dataReader["email"].ToString();
				guna2TextBox1.Text = dataReader["firstname"].ToString();
				guna2TextBox2.Text = dataReader["lastname"].ToString();
				guna2TextBox3.Text = dataReader["email"].ToString();
				guna2TextBox4.Text = dataReader["password"].ToString();

				guna2TextBox5.Text = dataReader["firstname"].ToString();
				guna2TextBox6.Text = dataReader["lastname"].ToString();
				guna2TextBox7.Text = dataReader["email"].ToString();

				// Veri tabanından alınan resim bilgisini bir byte dizisine (images) atadık.
				byte[] images = (byte[])dataReader["image"];

				// Eğer resim bilgisi null ise, profil resimleri null olarak ayarladık.
				if (images == null)
				{
					guna2CircleButton1.Image = null;
					guna2CirclePictureBox2.Image = null;
					guna2CirclePictureBox3.Image = null;

				}
				// Eğer resim bilgisi null değilse, bir MemoryStream oluşturularak byte dizisi içindeki resim verileri bu stream'e yazıp ardından bu MemoryStream'den alınan resim, programda kullandığımız üç ayrı guna2CirclePictureBox kontrolüne atadık.
				else
				{
					MemoryStream me = new MemoryStream(images);
					guna2CirclePictureBox1.Image = Image.FromStream(me);
					guna2CirclePictureBox2.Image = Image.FromStream(me);
					guna2CirclePictureBox3.Image = Image.FromStream(me);
				}
			}
			// Veri tabanı bağlantısını sonlandırıp, işlemi tamamladık.
			con.Close();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			// zamanlayıcının süresini ayarladık
			Timer timer = new Timer();
			timer.Interval = (10 * 1000);
			timer.Tick += new EventHandler(timer3_Tick);
			timer.Start();

			MessageChat();

			label2.Text = emailname;

			byte[] getimage = new byte[0];

			SqlConnection con = new SqlConnection(constring);

			con.Open();

			string q = "select * from login WHERE email = '" + label2.Text + "'";

			SqlCommand cmd = new SqlCommand(q, con);

			SqlDataReader dataReader = cmd.ExecuteReader();

			dataReader.Read();

			// Eğer seçilen kayıt varsa, bu kayıttan gerekli bilgiler alınarak form kontrollerine yerleştiriyoruz
			if (dataReader.HasRows)
			{
				label2.Text = dataReader["email"].ToString();
				guna2TextBox1.Text = dataReader["firstname"].ToString();
				guna2TextBox2.Text = dataReader["lastname"].ToString();
				guna2TextBox3.Text = dataReader["email"].ToString();
				guna2TextBox4.Text = dataReader["password"].ToString();

				// profil güncelle 
				guna2TextBox5.Text = dataReader["firstname"].ToString();
				guna2TextBox6.Text = dataReader["lastname"].ToString();
				guna2TextBox7.Text = dataReader["email"].ToString();

				byte[] images = (byte[])dataReader["image"];

				if (images == null)
				{
					guna2CircleButton1.Image = null;
					guna2CirclePictureBox2.Image = null;
					guna2CirclePictureBox3.Image = null;
				}
				else
				{
					MemoryStream me = new MemoryStream(images);
					guna2CirclePictureBox1.Image = Image.FromStream(me);
					guna2CirclePictureBox2.Image = Image.FromStream(me);
					guna2CirclePictureBox3.Image = Image.FromStream(me);
				}
			}
			con.Close();

			showProfile();

		}

		// Çıkış Butonu
		private void guna2CircleButton1_Click(object sender, EventArgs e)
		{
			//Form f1 = new Form();
			//this.Hide();
			//f1.Show();
		}

		private bool check;

		private void timer1_Tick(object sender, EventArgs e)
		{
			// check adlı bir boolean değişkenimiz var Eğer check true ise, panel genişliği arttırıyor.

			// Eğer panelin boyutu maksimum boyuta ulaştıysa, bir resim kutusu (pictureBox1) belirli bir konuma (pictureBox1.Left = +172) yerleştirilir, zamanlayıcı durdurulur (timer1.Stop()), check değişkeni false yapılır ve resim kutusunun içeriği değiştirilir.
			if (check)
			{
				panel1.Width += 10;
				if (panel1.Size == panel1.MaximumSize)
				{
					pictureBox1.Left = +172;
					timer1.Stop();
					check = false;
					pictureBox1.Image = Resources.Arrows_Left_Round_icon;
				}
			}
			else
			{
				panel1.Width -= 10;
				if (panel1.Size == panel1.MinimumSize)
				{
					pictureBox1.Left = 1;
					timer1.Stop();
					check = true;
					pictureBox1.Image = Resources.menu_icon;
				}
			}
		}

		// menüyü açıp kapatan navigasyon butonu
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			timer1.Start();
		}

		// form'da sağ üstte bulunan tıklayınca hesap bilgilerini gösteren ve çıkış yapmayı sağlayan butonlar var.
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			if (panel4.Visible == false)
			{
				panel4.Visible = true;
			}
			else
			{
				panel4.Visible = false;
			}
		}

		// Çkış butonu
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// hesabım  butonu
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			if (panel5.Visible == false)
			{
				panel5.Visible = true;
			}
			else
			{
				panel5.Visible = false;
			}
		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Profil Resmi Seçiniz(*Jpg; *.png; *Gif|*.Jpg; *.png; *Gif)";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				guna2CirclePictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
			}
		}

		// profil güncelle'deki kaydet butonu
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(guna2TextBox5.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox5, "İsim yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox5, string.Empty);
			}

			if (string.IsNullOrEmpty(guna2TextBox6.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox6, "Soyisim yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox6, string.Empty);
			}

			if (string.IsNullOrEmpty(guna2TextBox7.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox7, "E-Posta yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox7, string.Empty);
			}

			//string validEmail = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"+@"C[-a-z0-9!#$%&!*+/=?^_`{l}~][(?<!\.)\.J»)(?<!\.)"+@"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z] [a-z\.]*[a-z]$";
			//if (Regex.IsMatch(guna2TextBox7.Text, validEmail))
			//{
			//	errorProvider1.Clear();
			//}
			//else
			//{
			//	errorProvider1.SetError(this.guna2TextBox7, "please provide vaild Mail address");
			//	return;
			//}

			SqlConnection con = new SqlConnection(constring);

			con.Open();

			// burada veri tabanına bağlanmayı, kullanıcının profil bilgilerini güncellemeyi ve güncelleme işleminin ardından kullanıcıya bir bilgi mesajı verir.

			string q = "UPDATE login SET password = '" + guna2TextBox4.Text + "', firstname=@fname,lastname=@lname,email=@email,image=@image";

			MemoryStream me = new MemoryStream();
			guna2CirclePictureBox3.Image.Save(me, guna2CirclePictureBox1.Image.RawFormat);

			SqlCommand cmd = new SqlCommand(q, con);

			cmd.Parameters.AddWithValue("@fname", guna2TextBox5.Text);
			cmd.Parameters.AddWithValue("@lname", guna2TextBox6.Text);
			cmd.Parameters.AddWithValue("@email", guna2TextBox7.Text);
			cmd.Parameters.AddWithValue("@image", me.ToArray());

			cmd.ExecuteNonQuery();

			con.Close();

			MessageBox.Show("Profil güncellendi!");

			showProfile();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (check)
			{
				panel7.Height += 10;
				guna2Button10.Image = Resources.Arrows_Up_4_icon;
				if (panel7.Size == panel7.MaximumSize)
				{
					timer2.Stop();
					check = false;
				}
			}
			else
			{
				panel7.Height -= 10;
				guna2Button10.Image = Resources.Arrows_Down_4_icon;
				if (panel7.Size == panel7.MinimumSize)
				{
					timer2.Stop();
					check = true;
				}
			}
		}

		private void guna2Button10_Click(object sender, EventArgs e)
		{
			timer2.Start();
		}

		// profil güncelle
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			panel6.BringToFront(); // panel8.BringToFront();

			if (panel6.Visible == false)
			{
				panel6.Visible = true;
			}
			if (panel8.Visible == true)
			{
				panel8.Visible = false;
			}
			//else
			//{
			//	panel6.Visible = false;
			//}
		}

		// profil güncelle'deki geri tuşu
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			if (panel6.Visible == true)
			{
				panel6.Visible = false;
			}
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
		}

		// şifreyi güncelleme
		private void guna2Button9_Click(object sender, EventArgs e)
		{
			panel8.BringToFront(); // panel6.BringToFront();

			if (panel8.Visible == false && panel6.Visible == true)
			{
				panel6.Visible = false;
				panel8.Visible = true;
			}
			if (panel6.Visible == true)
			{
				panel6.Visible = false;
				panel8.Visible = true;
			}
			else
			{ 
			panel8.Visible = true;
				panel6.Visible = false;
			}


			//if (panel6.Visible == true)
			//{
			//	panel8.Visible = false;
			//}
			//if (panel9.Visible == true)
			//{
			//	panel8.Visible = false;
			//	panel6.Visible = false;
			//}
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			panel8.BringToFront();

			if (panel6.Visible == false)
			{
				panel6.Visible = true;
			}
		}

		// Şifre güncelle kaydet butonu
		private void guna2Button11_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(guna2TextBox7.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox8, "Eski şifre yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox8, string.Empty);
			}

			//if (string.IsNullOrEmpty(guna2TextBox9.Text.Trim()))
			//{
			//	errorProvider1.SetError(guna2TextBox9, "Yeni şifre yazılması zorunludur!");
			//	return;
			//}
			//else
			//{
			//	errorProvider1.SetError(guna2TextBox9, string.Empty);
			//}

			if (string.IsNullOrEmpty(guna2TextBox10.Text.Trim()))
			{
				errorProvider1.SetError(guna2TextBox10, "Yeni şifre tekrarı yazılması zorunludur!");
				return;
			}
			else
			{
				errorProvider1.SetError(guna2TextBox10, string.Empty);
			}

			if (guna2TextBox9.Text == guna2TextBox10.Text)
			{
				validatepassword();
			}
			else
			{
				MessageBox.Show("yeni şifre ve şifre tekrarı aynı olmalıdır!");

				guna2TextBox8.Clear();
				guna2TextBox9.Clear();
				guna2TextBox10.Clear();
			}

			validatepassword();

			//SqlConnection con = new SqlConnection(constring);

			//con.Open();

			//SqlCommand cmd = new SqlCommand("UPDATE login set password = '" + guna2TextBox9.Text +"' AND confirmpass = '" + guna2TextBox10.Text + "' where email = '" + label2.Text + "' AND password = '" + guna2TextBox8 + "'   ",con);

			//cmd.ExecuteNonQuery();

			//con.Close();

			//MessageBox.Show("Şifre Değiştirildi.");
		}

		public void validatepassword()
		{
			var input = guna2TextBox9.Text;

			if (string.IsNullOrWhiteSpace(input))
			{
				errorProvider1.SetError(guna2TextBox9, "Şifre boş geçilemez!");
				return;
			}

			var hasNumber = new Regex(@"[0-9]+");
			var hasUpperChar = new Regex(@"[A-Z]+");
			var hasMinMaxChars = new Regex(@".{8,8}");
			var hasLowerChar = new Regex(@"[a-z]+");
			var hasSymbols = new Regex(@"[!@#$%^&*()_ +=\[{\]};:<>|./?,-]");

			if (!hasLowerChar.IsMatch(input))
			{
				MessageBox.Show("Şifre En az bir küçük harf içermelidir");
			}

			if (!hasUpperChar.IsMatch(input))
			{
				MessageBox.Show("Şifre En az bir büyük harf içermelidir");
			}

			if (!hasMinMaxChars.IsMatch(input))
			{
				MessageBox.Show("Şifre 8 karakterden az veya fazla olmamalıdır");
			}

			if (!hasNumber.IsMatch(input))
			{
				MessageBox.Show("Şifre en az bir sayısal değer içermelidir");
			}

			if (!hasSymbols.IsMatch(input))
			{
				MessageBox.Show("Şifre en az bir özel durum karakteri içermelidir");
			}
			else
			{
				SqlConnection con = new SqlConnection(constring);

				con.Open();

				SqlCommand cmd = new SqlCommand("UPDATE login set password = '" + guna2TextBox9.Text + "' ,confirmpass = '" + guna2TextBox10.Text + "' where email = '" + label2.Text + "' AND password = '" + guna2TextBox8 + "'   ", con);

				cmd.ExecuteNonQuery();

				con.Close();

				MessageBox.Show("Şifre Değiştirildi.");

				return;
			}
		}

		// Başka hesaba geçmek için form 2'den form 1'e geçme butonu
		private void guna2Button12_Click(object sender, EventArgs e)
		{
			Form1 f1 = new Form1();
			this.Hide();
			f1.ShowDialog();
		}

		// şifre güncelle show password
		private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (guna2TextBox8.PasswordChar == '*' && guna2TextBox9.PasswordChar == '*' && guna2TextBox10.PasswordChar == '*')
			{
				guna2TextBox8.PasswordChar = '\0';
				guna2TextBox9.PasswordChar = '\0';
				guna2TextBox10.PasswordChar = '\0';
			}
			else
			{
				guna2TextBox8.PasswordChar = '*';
				guna2TextBox9.PasswordChar = '*';
				guna2TextBox10.PasswordChar = '*';
			}
		}

		// sohbet butonu
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			panel9.BringToFront();
			// MessageChat();

			
			if (panel6.Visible == false && panel8.Visible == false && panel9.Visible == false)
			{
				panel6.Visible = false;
				panel8.Visible = true;
				panel9.Visible = true;
			}
			if (panel6.Visible == true)
			{
				panel6.Visible = true;
				panel9.Visible = true;
			}
			if (panel6.Visible == true)
			{
				panel6.Visible = false;
				panel8.Visible = true;
				panel9.Visible = true;
			}
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			if (panel6.Visible == true || panel8.Visible == true || panel9.Visible == true)
			{
				panel6.Visible = false;
				panel8.Visible = false;
				panel9.Visible = false;
			}
		}

		private void UserItem()
		{
			flowLayoutPanel1.Controls.Clear();
			SqlDataAdapter adapter;
			adapter = new SqlDataAdapter("select * from login", constring);
			DataTable table = new DataTable();
			adapter.Fill(table);
			if (table != null)
			{
				if (table.Rows.Count > 0)
				{
					UserControl1[] userControls = new UserControl1[table.Rows.Count];
					for (int i = 0; i < 1; i++)
					{
						foreach (DataRow row in table.Rows)
						{
							userControls[i] = new UserControl1();
							MemoryStream stream = new MemoryStream((byte[])row["image"]);
							userControls[i].Icon = new Bitmap(stream);
							userControls[i].Title = row["firstname"].ToString();
							if (userControls[i].Title == guna2TextBox1.Text)
							{
								flowLayoutPanel1.Controls.Remove(userControls[i]);
							}
							else
							{
								flowLayoutPanel1.Controls.Add(userControls[i]);
							}
							userControls[i].Click += new System.EventHandler(this.userControl11_Load);
						}
					}
				}
			}
		}


		// Bu kod bloğu, bir kullanıcının bir diğerine gönderdiği bir mesajı alarak, bu mesajı SQL Server veritabanına ekliyor.
		private void guna2Button13_Click(object sender, EventArgs e)
		{
			flowLayoutPanel2.Controls.Clear();

			SqlConnection con = new SqlConnection(constring);
			string q = "insert into chat(userone,usertwo,message)values(@userone,@usertwo,@message)";
			SqlCommand cmd = new SqlCommand(q, con);
			cmd.Parameters.AddWithValue("@userone", guna2TextBox1.Text);
			cmd.Parameters.AddWithValue("@usertwo", label12.Text);
			cmd.Parameters.AddWithValue("@message", guna2TextBox11.Text);
			con.Open();
			cmd.ExecuteNonQuery();
			con.Close();

			MessageChat();

			guna2TextBox1.Clear();
		}

		public void MessageChat()
		{
			flowLayoutPanel2.Controls.Clear();

			SqlDataAdapter adapter;
			adapter = new SqlDataAdapter("select * from chat", constring);
			DataTable table = new DataTable();
			adapter.Fill(table);
			if (table != null)
			{
				if (table.Rows.Count > 0)
				{
					UserControl2[] userControl2s = new UserControl2[table.Rows.Count];
					UserControl3[] userControl3s = new UserControl3[table.Rows.Count];
					for (int i = 0; i < 1; i++)
					{
				
						foreach (DataRow row in table.Rows)
						{
							if (guna2TextBox1.Text == row["userone"].ToString() && label12.Text == row["usertwo"].ToString())
							{
								userControl2s[i] = new UserControl2();
								userControl2s[i].Dock = DockStyle.Top;
								userControl2s[i].BringToFront();
								userControl2s[i].Title = row["message"].ToString();
								flowLayoutPanel2.Controls.Add(userControl2s[i]);
								flowLayoutPanel2.ScrollControlIntoView(userControl2s[i]);
							}
							else if (label12.Text == row["userone"].ToString() && guna2TextBox1.Text == row["usertwo"].ToString())
							{
								userControl3s[i] = new UserControl3();
								userControl3s[i].Dock = DockStyle.Top;
								userControl3s[i].BringToFront();
								userControl3s[i].Title = row["message"].ToString();
								userControl3s[i].Icon = guna2CirclePictureBox4.Image;

								flowLayoutPanel2.Controls.Add(userControl3s[i]);
								flowLayoutPanel2.ScrollControlIntoView(userControl3s[i]);
							}
						}
					}
				}
			}
		}

		private void userControl11_Load(object sender, EventArgs e)
		{
			if (panel9.Visible == false && panel10.Visible == false && flowLayoutPanel2.Visible == false)
			{
				panel9.Visible = true;
				panel10.Visible = true;
				flowLayoutPanel2.Visible = true;
			}

			UserControl1 control = (UserControl1) sender;
			label12.Text = control.Title;
			guna2CirclePictureBox4.Image = control.Icon;
			MessageChat();
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			if (panel10.Visible == true && panel11.Visible == true && flowLayoutPanel2.Visible == true)
			{
				panel10.Visible = false;
				panel11.Visible = false;
				flowLayoutPanel2.Visible = false;
			}
		}

		private void timer3_Tick(object sender, EventArgs e)
		{
			MessageChat();
		}
	}
}