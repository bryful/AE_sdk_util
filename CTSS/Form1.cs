using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


using BRY;

namespace CTSS
{
	public partial class Form1 : Form
	{
		private ResultForm rform = null;
		private RadioButton[] rbs = new RadioButton[4];
		public Form1()
		{
			InitializeComponent();

			rb0.Tag = OPT.SF;
			rb1.Tag = OPT.G;
			rb2.Tag = OPT.SOURCE;
			rb3.Tag = OPT.OBJFILE;
			rbs[0] = rb0;
			rbs[1] = rb1;
			rbs[2] = rb2;
			rbs[3] = rb3;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			JsonPref pref = new JsonPref();
			if (pref.Load())
			{
				bool ok = false;
				Size sz = pref.GetSize("Size", out ok);
				if (ok) this.Size = sz;
				Point p = pref.GetPoint("Point", out ok);
				if (ok) this.Location = p;
				int v = pref.GetInt("opt", out ok);
				if (ok)
				{
					ctsScomp1.Option = (OPT)v;
					rbs[v].Checked = true;
				}
				string s = pref.GetString("exe", out ok);
				if (ok) tbExe.Text = s;
				s = pref.GetString("pdb", out ok);
				if (ok) tbPdb.Text = s;
				s = pref.GetString("optFile", out ok);
				if (ok) tbAna.Text = s;
			}

		}
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref();
			pref.SetSize("Size", this.Size);
			pref.SetPoint("Point", this.Location);

			pref.SetInt("opt", (int)ctsScomp1.Option);
			pref.SetString("exe", ctsScomp1.CTSSPath);
			pref.SetString("pdb", ctsScomp1.PdbPath);
			pref.SetString("optFile", ctsScomp1.OptionFilePath);
			pref.Save();

			if(rform!=null)
			{
				rform.Close();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Ctrl_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void exe_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			foreach(string s in files)
			{
				if(File.Exists(s))
				{
					if (Path.GetFileName(s)== "CheckThreadSafeSymbols.exe")
					{
						tbExe.Text = s;
						break;
					}
				}
			}
		}

		private void Pdb_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			foreach (string s in files)
			{
				if (File.Exists(s))
				{
					if (Path.GetExtension(s).ToLower() == ".pdb")
					{
						tbPdb.Text = s;
						break;
					}
				}
			}
		}
		private void btnAna_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			foreach (string s in files)
			{
				if (File.Exists(s))
				{
					tbAna.Text = s;
					break;
				}
			}

		}

		private void rb_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;

			OPT op = (OPT)rb.Tag;

			ctsScomp1.Option = op;
			switch(op)
			{
				case OPT.G:
				case OPT.SF:
					btnAna.Enabled = false;
					tbAna.Enabled = false;
					break;
				case OPT.OBJFILE:
				case OPT.SOURCE:
					btnAna.Enabled = true;
					tbAna.Enabled = true;
					break;
			}
			ctsScomp1.CTSSPath = tbExe.Text;
			ctsScomp1.PdbPath = tbPdb.Text;
			ctsScomp1.OptionFilePath = tbAna.Text;
			tbCmd.Text = ctsScomp1.CmdLine;

		}

		private void tbExe_TextChanged(object sender, EventArgs e)
		{
			ctsScomp1.CTSSPath = tbExe.Text;
			ctsScomp1.PdbPath = tbPdb.Text;
			ctsScomp1.OptionFilePath = tbAna.Text;
			tbCmd.Text = ctsScomp1.CmdLine;
		}

		private void btnSelectExe_Click(object sender, EventArgs e)
		{
			SelectExe();
		}
		private void SelectExeMenu_Click(object sender, EventArgs e)
		{
			SelectExe();
		}
		public void SelectExe()
		{
			OpenFileDialog dlg = new OpenFileDialog();

			if (ctsScomp1.CTSSPath != "")
			{
				dlg.InitialDirectory = Path.GetDirectoryName(ctsScomp1.CTSSPath);
				dlg.FileName = Path.GetFileName(ctsScomp1.CTSSPath);
			}

			try
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					tbExe.Text = dlg.FileName;
				}
			}
			finally
			{
				dlg.Dispose();
			}
		}
		public void SelectPdb()
		{
			OpenFileDialog dlg = new OpenFileDialog();

			if (ctsScomp1.PdbPath != "")
			{
				dlg.InitialDirectory = Path.GetDirectoryName(ctsScomp1.PdbPath);
				dlg.FileName = Path.GetFileName(ctsScomp1.PdbPath);
			}

			try
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					tbPdb.Text = dlg.FileName;
				}
			}
			finally
			{
				dlg.Dispose();
			}
		}

		private void btnPdb_Click(object sender, EventArgs e)
		{
			SelectPdb();
		}

		private void SelectPdpMenu_Click(object sender, EventArgs e)
		{
			SelectPdb();
		}
		public void SelectAna()
		{
			OpenFileDialog dlg = new OpenFileDialog();

			if (ctsScomp1.OptionFilePath != "")
			{
				dlg.InitialDirectory = Path.GetDirectoryName(ctsScomp1.OptionFilePath);
				dlg.FileName = Path.GetFileName(ctsScomp1.OptionFilePath);
			}

			try
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					tbAna.Text = dlg.FileName;
				}
			}
			finally
			{
				dlg.Dispose();
			}
		}

		private void btnAna_Click(object sender, EventArgs e)
		{
			SelectAna();
		}

		private void SelectAnalysysMenu_Click(object sender, EventArgs e)
		{
			SelectAna();
		}

		private void btnExec_Click(object sender, EventArgs e)
		{
			ShowResult(ctsScomp1.Exec());
		}

		public void ShowResult(string s)
		{
			if(rform == null)
			{
				rform = new ResultForm();
				rform.Show();
				rform.TopMost = true;
				rform.TopMost = false;
			}
			rform.Show();
			rform.TopMost = true;
			rform.TopMost = false;

			rform.Mes = s;
		}
	}
}
