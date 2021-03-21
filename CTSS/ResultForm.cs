using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CTSS
{
	public partial class ResultForm : Form
	{
		public ResultForm()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
		public string Mes
		{
			get { return textBox1.Text; }
			set
			{
				textBox1.Text = value;
			}
		}
	}
}
