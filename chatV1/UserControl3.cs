using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatV1
{
	public partial class UserControl3 : UserControl
	{
		public UserControl3()
		{
			InitializeComponent();
		}

		private string _title;

		public string Title
		{
			get 
			{
				return _title;
			}
			set 
			{
				_title = value;
				rjBlabel1.Text = value;
			}
		}

		private Image _icon;

		public Image Icon
		{
			get 
			{
				return _icon;
			}
			set
			{
				_icon = value;
				guna2CirclePictureBox1.Image = value;
				AddHeighttext();
			}
	}

		void AddHeighttext()
		{
			UserControl3 user = new UserControl3();
			user.BringToFront();
			rjBlabel1.Height = UiList.GeTTextHeight(rjBlabel1) + 10;
			user.Height = rjBlabel1.Top + rjBlabel1.Height;
			this.Height = user.Bottom + 10;
		}

		private void UserControl3_Load(object sender, EventArgs e)
		{
			AddHeighttext();
		}
	}
}
