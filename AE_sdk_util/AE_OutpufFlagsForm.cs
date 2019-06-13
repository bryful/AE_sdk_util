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
			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
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

			pref.SetIntArray("IntArray", new int[] { 8, 9, 7 });
			pref.Save();

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
		public bool LoadFile(string str)
		{
			bool ret = aeh.Load(str);
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
	}
}
