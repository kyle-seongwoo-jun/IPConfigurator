using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Config_TCP_IP
{
	public partial class HelloForm : Form
	{
		public HelloForm()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LinkLabel linkLabel = sender as LinkLabel;

			Process.Start(linkLabel.Text);
		}
	}
}
