using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace AE_sdk_util
{
	enum VMODE
	{
		OUT_FLAG=1,
		OUT_FLAG2
	}

	public class AE_Effect_h
	{

		#region property
		private VMODE m_mode = VMODE.OUT_FLAG;

		private int m_SelectedIndex = -1;
		private int m_SelectedIndex2 = -1;

		private CheckedListBox _InfoList= null;
		public List<string> lines = new List<string>();
		public string LineText
		{
			get
			{
				return String.Join("\r\n", lines);
			}
		}
		public List<AE_out_flags_info> Info = new List<AE_out_flags_info>();
		public string InfoText
		{
			get
			{
				string ret = "";
				foreach(AE_out_flags_info oi in Info)
				{
					if (ret != "") ret += "\r\n";
					ret += "**********************\r\n";
					ret += oi.ToString();
				}
				return ret;
			}
		}
		public List<AE_out_flags_info> Info2 = new List<AE_out_flags_info>();
		public string Info2Text
		{
			get
			{
				string ret = "";
				foreach (AE_out_flags_info oi in Info2)
				{
					if (ret != "") ret += "\r\n";
					ret += "**********************\r\n";
					ret += oi.ToString();
				}
				return ret;
			}
		}
		#endregion
		//-----------------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AE_Effect_h()
		{

		}
		//-----------------------------------------------------------------------
		/// <summary>
		/// 文字列から重複したTABを消す
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private string dupTab(string str)
		{
			string ret = "";
			if (str.Length <= 0) return ret;
			else if (str.Length == 0) return ret;
			for(int i=0; i<str.Length;i++)
			{
				ret += str[i];
				if (str[i] == '\t')
				{
					while(str[i]!='\t')
					{
						i++;
					}
				}

			}
			return ret;
		}
		//-----------------------------------------------------------------------
		private int IndexFromW(string[] sa, string s,int start = 0)
		{
			// /** -------------------- Output Flags --------------------
			// /** -------------------- Input Flags --------------------
			int ret = -1;
			if (start >= sa.Length) return ret;
			for (int i=start;i< sa.Length;i++)
			{
				string line = sa[i];
				if (line != "")
				{
					if ((line.IndexOf("/** -") == 0) && (line.IndexOf(s) >= 0))
					{
						ret = i;
						break;
					}

				}
			}
			return ret;
		}
		//-----------------------------------------------------------------------
		private int FindCommentEnd(int start = 1)
		{
			int ret = -1;
			if (lines.Count <= 0) return ret;
			for ( int i= start; i<lines.Count;i++)
			{
				if (lines[i].IndexOf("**/") >=0)
				{
					ret = i;
					break;
				}
			}
			return ret;
		}
		private int FindName(string s)
		{
			int ret = -1;
			if (Info.Count <= 0) return ret;
			for ( int i=0;i<Info.Count;i++)
			{
				if (Info[i].Name == s)
				{
					ret = i;
					break;
				}
			}
			return ret;
		}
		private int FindName2(string s)
		{
			int ret = -1;
			if (Info2.Count <= 0) return ret;
			for (int i = 0; i < Info2.Count; i++)
			{
				if (Info2[i].Name == s)
				{
					ret = i;
					break;
				}
			}
			return ret;
		}
		private int ValueParse(string s)
		{
			int r = 0;
			if ((s == "")||(s=="0")) return r;
			string[] sa = s.Replace("<<", "<").Split('<');
			if(sa.Length==2)
			{
				int v = int.Parse(sa[1]);

				r = (1 << v);

			}
			return r;
		}
		private string []  SplitLine(string s)
		{
			string[] ret = new string[3];
			ret[0] = "";
			ret[1] = "";
			ret[2] = "";
			if (s == "") return ret;

			int idxS = s.IndexOf("=");
			if (idxS < 0) return ret;
			int idxD = s.IndexOf(',', idxS + 1);
			if (idxD < 0) return ret;

			//AB=CDF,DD
			//012345678
			ret[0] = s.Substring(0, idxS).Trim();
			ret[1] = s.Substring(idxS+1, idxD - idxS-1).Replace("L","").Trim();
			ret[2] = s.Substring(idxD+1).Replace("//","").Trim();


			return ret;
		}
		private bool LinesAnalysis()
		{
			bool ret = false;
			if (lines.Count <=0) return ret;
			//コメントエンドを探す
			int comEnd = FindCommentEnd();
			if (comEnd <= 0) return ret;
			//最初にenumを
			Info.Clear();
			Info.Clear();
			for ( int i= comEnd; i<lines.Count;i++)
			{
				string[] sep = SplitLine(lines[i]);
				AE_out_flags_info oi = new AE_out_flags_info();
				if(sep[0]!="")
				{
					oi.Name = sep[0];
					oi.Value = ValueParse(sep[1]);
					oi.ValueS = sep[1];
					oi.Use_PF_Cmds = sep[2];
					if (sep[0].IndexOf("PF_OutFlag2")==0)
					{
						Info2.Add(oi);
					}
					else
					{
						Info.Add(oi);
					}
				}
			}
			List<int> PIDX = new List<int>();
			for ( int i=0; i<comEnd; i++)
			{
				string line = lines[i];
				if (line == "") continue;
				if(line.IndexOf("\tPF_OutFlag")==0)
				{
					PIDX.Add(i);
				}

			}
			PIDX.Add(comEnd);
			for(int i=0; i<PIDX.Count-1;i++)
			{
				string head = lines[PIDX[i]].Trim();
				string s = "";
				for ( int j= PIDX[i]+1; j< PIDX[i+1]; j++)
				{
					s += lines[j].Trim() + "\r\n";
				}
				int idx = FindName(head);
				if(idx>=0)
				{
					Info[idx].Description = s;
				}
				else
				{
					idx = FindName2(head);
					if(idx>=0)
					{
						Info2[idx].Description = s;
					}
				}
			}

			return ((Info.Count > 0) && (Info2.Count > 0));
		}
		//-----------------------------------------------------------------------
		/// <summary>
		/// AE_Effect.hを読み込む
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public bool Load(string p)
		{
			bool ret = false;
			lines.Clear();
			try
			{
				string[] orglines = File.ReadAllLines(p);
				if(orglines.Length>0)
				{
					int idxS = -1;
					int idxL = -1;

					idxS = IndexFromW(orglines, "- Output Flags -");
					if (idxS >= 0)
					{
						idxL = IndexFromW(orglines, "/** -------",idxS+1);
					}
					if((idxS<= idxL)&&(idxS!=-1) && (idxL != -1))
					{
						lines.Clear();
						for (int i = idxS; i < idxL; i++)
							lines.Add(orglines[i]);

						ret = LinesAnalysis();
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		//-----------------------------------------------------------------------
		public CheckedListBox InfoList
		{
			get { return _InfoList; }
			set
			{
				_InfoList = value;
				if(_InfoList!=null)
				{
					_InfoList.SelectedIndexChanged += _InfoList_SelectedIndexChanged;
				}
			}
		}
		//-----------------------------------------------------------------------
		private void _InfoList_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckedListBox cb = (CheckedListBox)sender;
			if (m_mode == VMODE.OUT_FLAG)
			{
				m_SelectedIndex = cb.SelectedIndex;
			}
			else
			{
				m_SelectedIndex2 = cb.SelectedIndex;
			}
		}
		private void ShowList()
		{
			if (_InfoList == null) return;
			_InfoList.SuspendLayout();
			_InfoList.Items.Clear();
			if(m_mode==VMODE.OUT_FLAG)
			{
				foreach(AE_out_flags_info oi in Info)
				{

				}
			}

		}
	}
}
