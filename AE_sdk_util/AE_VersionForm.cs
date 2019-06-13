using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_sdk_util
{
	public partial class AE_VersionForm : Form
	{
		private bool refFlag = false;
		public AE_VersionForm()
		{
			InitializeComponent();
			CalcVersion();
		}
		private void CalcVersion()
		{
			if (refFlag == true) return;
			refFlag = true;

			if (cmbStage.SelectedIndex < 0) cmbStage.SelectedIndex = 0;
			ulong ret = 0;
			ulong b = (ulong)numMajor.Value;
			ret += (((b >> 3) & 0xf) << 26) +((b & 0x7) << 19);
			b = (ulong)numMinor.Value;
			ret += (((b) & 0xf) << 15);
			b = (ulong)numBug.Value;
			ret += (((b) & 0xf) << 11);
			b = (ulong)cmbStage.SelectedIndex;
			if (b < 0) b = 0; else if (b > 3) b = 3;
			ret += (b & 0x3) << 9;
			b = (ulong)numBuild.Value;
			ret += ((b & 0x1ff) << 0);

			numVersion.Value = (decimal)ret;
			DispCode();
			refFlag = false;
		}

		private void numMajor_ValueChanged(object sender, EventArgs e)
		{
			CalcVersion();
		}
		private void DispCode()
		{
			string s =
			"#define MAJOR_VERSION	{0}\r\n"+
			"#define MINOR_VERSION	{1}\r\n" +
			"#define BUG_VERSION	{2}\r\n" +
			"#define STAGE_VERSION	{3}\r\n"+
			"#define BUILD_VERSION	{4}\r\n"+
			"\r\n" +
			"\r\n" +
			"//上の定数とVERSIONの値が違うとエラーになる\r\n" +
			"\r\n" +
			"#define VERSION {5}	//AE_Effects_Version.exeで上記計算して求める\r\n";

			if (cmbStage.SelectedIndex < 0) cmbStage.SelectedIndex = 0;
			textBox1.Text = String.Format(
				s,
				numMajor.Value,
				numMinor.Value,
				numBug.Value,
				cmbStage.SelectedIndex,
				numBuild.Value,
				numVersion.Value);
		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
