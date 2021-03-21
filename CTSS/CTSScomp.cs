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
using System.Diagnostics;

/*
 * usage: CheckThreadSafeSymbols.exe [ options ] <filename>
  -?                : print this help
  -sf               : dump all compilands with lists of contributing source files (very noisy)
  -g                : dump all of the global variables for the whole project.
  -source           : print symbols from all compilands of a source file
  -objfile          : print symbols from an object file

 */
namespace CTSS
{
	public enum OPT
	{
		SF,
		G,
		SOURCE,
		OBJFILE
	};

	public class CTSScomp :Component
	{
		private OPT m_Option = OPT.G;
		public OPT Option
		{
			get { return m_Option; }
			set
			{
				if (m_Option!=value)
				{
					m_Option = value;
				}
			}
		}

		private string m_CTSSPath = "";
		public string CTSSPath
		{
			get { return m_CTSSPath; }
			set
			{
				if (File.Exists(value))
				{
					m_CTSSPath = value;
				}
			}
		}
		private string m_OptionFilePath = "";
		public string OptionFilePath
		{
			get { return m_OptionFilePath; }
			set
			{
				if (File.Exists(value))
				{
					m_OptionFilePath = value;
				}
			}
		}
		private string m_PdbPath = "";
		public string PdbPath
		{
			get { return m_PdbPath; }
			set
			{
				if (File.Exists(value))
				{
					m_PdbPath = value;
				}
			}
		}
		public string CmdLine
		{
			get
			{
				string ret = "";

				ret += "\"" + m_CTSSPath + "\"";

				switch(m_Option)
				{
					case OPT.SF:
						ret += " -sf \"" + m_PdbPath + "\"";
						break;
					case OPT.G:
						ret += " -g \"" + m_PdbPath + "\"";
						break;
					case OPT.SOURCE:
						ret += " -source \"" + m_OptionFilePath + "\" \"" + m_PdbPath + "\"";
						break;
					case OPT.OBJFILE:
						ret += " -objfile \"" + m_OptionFilePath + "\" \"" + m_PdbPath + "\"";
						break;
				}
				return ret;
			}
		}
		public string Args
		{
			get
			{
				string ret = "";

				switch (m_Option)
				{
					case OPT.SF:
						ret += " -sf \"" + m_PdbPath + "\"";
						break;
					case OPT.G:
						ret += " -g \"" + m_PdbPath + "\"";
						break;
					case OPT.SOURCE:
						ret += " -source \"" + m_OptionFilePath + "\" \"" + m_PdbPath + "\"";
						break;
					case OPT.OBJFILE:
						ret += " -objfile \"" + m_OptionFilePath + "\" \"" + m_PdbPath + "\"";
						break;
				}
				return ret;
			}
		}
		public string Exec()
		{

			//Processオブジェクトを作成
			try
			{
				Process p = new Process();

				//ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
				p.StartInfo.FileName = m_CTSSPath;
				//出力を読み取れるようにする
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardInput = false;
				//ウィンドウを表示しないようにする
				p.StartInfo.CreateNoWindow = true;
				//コマンドラインを指定（"/c"は実行後閉じるために必要）
				p.StartInfo.Arguments = Args;

				//起動
				p.Start();

				//出力を読み取る
				string results = p.StandardOutput.ReadToEnd();

				//プロセス終了まで待機する
				//WaitForExitはReadToEndの後である必要がある
				//(親プロセス、子プロセスでブロック防止のため)
				p.WaitForExit();
				p.Close();
				return results;
			}
			catch
			{
				return "error";

			}
		}

	}
}
