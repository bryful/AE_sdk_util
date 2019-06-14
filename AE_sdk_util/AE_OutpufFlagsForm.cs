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

using Codeplex.Data;


/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace AE_sdk_util
{
	
	public partial class AE_OutpufFlagsForm : Form
	{
		private AE_VersionForm versionForm = null;
		private AE_Effect_h aeh = new AE_Effect_h();
		
		#region SkeltonCode
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AE_OutpufFlagsForm()
		{
			InitializeComponent();
		}
		/// <summary>
		/// コントロールの初期化はこっちでやる
		/// </summary>
		protected override void InitLayout()
		{
			base.InitLayout();
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォーム作成時に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
				int bd = pref.GetInt("Border", out ok);
				if (ok) this.splitContainer1.SplitterDistance = bd;

			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

			aeh.InfoList = outflagList1;
			aeh.TextBox = tbInfo;
			aeh.TextBox2 = tbInfoJ;
			aeh.TextBoxV = textBoxV;
			aeh.NumOutflags = numOutflags;

			string path = Path.Combine(Application.UserAppDataPath, Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".def");
			if (aeh.LoadJson(path)==false)
			{
				aeh.FromJson(AE_sdk_util.Properties.Resources.def);

			}
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォームが閉じられた時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref();
			pref.SetSize("Size", this.Size);
			pref.SetPoint("Point", this.Location);
			pref.SetInt("Border", splitContainer1.SplitterDistance);

			pref.SetIntArray("IntArray", new int[] { 8, 9, 7 });
			pref.Save();

			string path = Path.Combine(Application.UserAppDataPath, Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".def");
			aeh.SaveJson(path);

		}
		//-------------------------------------------------------------
		/// <summary>
		/// ドラッグ＆ドロップの準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragEnter(object sender, DragEventArgs e)
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
		/// <summary>
		/// ドラッグ＆ドロップの本体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			//ここでは単純にファイルをリストアップするだけ
			GetCommand(files);
		}
		//-------------------------------------------------------------
		/// <summary>
		/// ダミー関数
		/// </summary>
		/// <param name="cmd"></param>
		public void GetCommand(string[] cmd)
		{
			/*
			if (cmd.Length>0)
			{
				foreach (string s in cmd)
				{
					if(File.Exists(s))
					{
						LoadFile(s);
					}
				}
			}
			*/
		}
		/// <summary>
		/// メニューの終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//-------------------------------------------------------------
		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AppInfoDialog.ShowAppInfoDialog();
		}
		#endregion

		/// <summary>
		/// AE_Effect.hを読み込む
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public bool LoadAE_Effects_H_File(string str)
		{
			bool ret = aeh.AE_Effect_H_Load(str);
			return ret;
		}
		public void ShowVersionEditor()
		{
			if (versionForm == null) versionForm = new AE_VersionForm();
			versionForm.FormClosed += VersionForm_FormClosed;
			versionForm.Show();
		}

		private void VersionForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			versionForm = null;
		}

		private void showVersionMenu_Click(object sender, EventArgs e)
		{
			ShowVersionEditor();
		}

		private void rbMode1_CheckedChanged(object sender, EventArgs e)
		{
			if(rbMode1.Checked==true)
			{
				aeh.SetMode(VMODE.OUT_FLAG);
			}
			else
			{
				aeh.SetMode(VMODE.OUT_FLAG2);
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void importAEEffecsHToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fn = "AE_Effect.h";
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.FileName = fn;
				if(dlg.ShowDialog()==DialogResult.OK)
				{
					string p = dlg.FileName;
					string fn2 = Path.GetFileName(p);
					if(fn2!= fn)
					{
						MessageBox.Show(fn2 + " is not " + fn, "Warning", MessageBoxButtons.OK);
						return;
					}
					aeh.AE_Effect_H_Load(p);

				}
			}
		}
		public void SizeSet()
		{
			splitContainer1.Location = new Point(0, 90);
			int w = ClientSize.Width;
			int h = ClientSize.Height;
			splitContainer1.Size = new Size(w, h - 120);

			w = splitContainer1.Panel1.Width;
			h = splitContainer1.Panel1.Height;
			outflagList1.Location = new Point(5, 0);
			outflagList1.Size = new Size(w-15, h - 40);
			textBoxV.Location = new Point(5, h - 40 + 6);
			textBoxV.Width = w-10;
			w = splitContainer1.Panel2.Width;
			h = splitContainer1.Panel2.Height;
			tbInfo.Location = new Point(5, 0);
			tbInfo.Size = new Size(w-15, h / 2 - 5);
			tbInfoJ.Location = new Point(5, h / 2);
			tbInfoJ.Size = new Size(w-15, h / 2 - 5);


		}

		private void AE_OutpufFlagsForm_SizeChanged(object sender, EventArgs e)
		{
			SizeSet();
		}

		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			SizeSet();
		}

		private void btnPeast_Click(object sender, EventArgs e)
		{
			PeastValue();
		}
		public void PeastValue()
		{
			if(Clipboard.ContainsText())
			{
				ulong v;
				if (ulong.TryParse(Clipboard.GetText(),out v)==true)
				{
					numOutflags.Value = (decimal)v;
				}
			}
		}

		private void btnCopyValue_Click(object sender, EventArgs e)
		{
			CopyValue();
		}
		public void CopyValue()
		{
			Clipboard.SetText(String.Format("{0}", (ulong)numOutflags.Value));
		}

	}
}
