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
	public partial class UserControl2 : UserControl
	{
		public UserControl2()
		{
			InitializeComponent();
		}

		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; rjBlabel1.Text = value; AddHeighttext(); }
		}
		void AddHeighttext()
		{
			UserControl2 user = new UserControl2();
			user.BringToFront();
			rjBlabel1.Height = UiList.GeTTextHeight(rjBlabel1) + 10;
			user.Height = rjBlabel1.Top + rjBlabel1.Height;
			this.Height = user.Bottom + 10;
		}

		private void UserControl2_Load(object sender, EventArgs e)
		{
			AddHeighttext();
		}
	}
}