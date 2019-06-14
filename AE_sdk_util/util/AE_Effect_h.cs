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

using Codeplex.Data;

namespace AE_sdk_util
{
	public enum VMODE
	{
		OUT_FLAG=1,
		OUT_FLAG2
	}

	public class AE_Effect_h
	{

		#region property
		private bool RefFlag = false;

		private VMODE m_mode = VMODE.OUT_FLAG;
		/// <summary>
		/// 表示切替
		/// </summary>
		public VMODE Vmode
		{
			get { return m_mode; }
			set { SetMode(value); }
		}

		private int m_SelectedIndex = -1;
		private int m_SelectedIndex2 = -1;

		private OutflagList _InfoList= null;
		private TextBox m_TextBox = null;
		private TextBox m_TextBox2 = null;
		private NumericUpDown m_numericUpDown = null;

		public List<AE_out_flags_info> Info = new List<AE_out_flags_info>();
		public List<AE_out_flags_info> Info2= new List<AE_out_flags_info>();
		#endregion
		// **********************************************************************************
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AE_Effect_h()
		{

		}
		// **********************************************************************************
		#region Analysys
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
		// **********************************************************************************
		private int FindCommentEnd(List<string>lines, int start = 1)
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
		// **********************************************************************************
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
		// **********************************************************************************
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
		// **********************************************************************************
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
		// **********************************************************************************
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
		// **********************************************************************************
		/// <summary>
		/// 文字リストを解析する
		/// </summary>
		/// <param name="lines"></param>
		/// <returns></returns>
		private bool LinesAnalysis(List<string> lines)
		{
			bool ret = false;
			if (lines.Count <=0) return ret;
			//コメントエンドを探す
			int comEnd = FindCommentEnd(lines);
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
		#endregion

		// **********************************************************************************
		/// <summary>
		/// AE_Effect.hを読み込む
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public bool AE_Effect_H_Load(string p)
		{
			bool ret = false;
			List<string> lines = new List<string>();
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

						ret = LinesAnalysis(lines);
						if (ret)
						{
							ShowList();
							ShowInfo();
						}
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// **********************************************************************************
		public OutflagList InfoList
		{
			get { return _InfoList; }
			set
			{
				_InfoList = value;
				if(_InfoList!=null)
				{
					ShowList();
					_InfoList.SelectedIndexChanged += _InfoList_SelectedIndexChanged;
					_InfoList.ItemCheck += _InfoList_ItemCheck;
				}
			}
		}

		private void _InfoList_ItemCheck(object sender, ItemCheckEventArgs e)
		{

			int idx = e.Index;
			if (idx < 0) return;
			if(m_mode==VMODE.OUT_FLAG)
			{
				Info[idx].Checked = _InfoList.GetItemChecked(idx);
			}
			else
			{
				Info2[idx].Checked = _InfoList.GetItemChecked(idx);
			}
			Calc();
		}
		public void Calc()
		{
			int r = 0;
			if (m_mode==VMODE.OUT_FLAG)
			{
				foreach(AE_out_flags_info oi in Info)
				{
					if(oi.Checked==true)
					{
						r += oi.Value;
					}
				}
			}
			else
			{
				foreach (AE_out_flags_info oi in Info2)
				{
					if (oi.Checked == true)
					{
						r += oi.Value;
					}
				}
			}
			if(m_numericUpDown.Value!= (decimal)r)
			{
				m_numericUpDown.Value = (decimal)r;
			}
		}
		public TextBox TextBox
		{
			get { return m_TextBox; }
			set
			{
				m_TextBox = value;
				if(m_TextBox != null)
				{
					m_TextBox.ReadOnly = true;
					ShowInfo();
				}
			}
		}
		public TextBox TextBox2
		{
			get { return m_TextBox2; }
			set
			{
				m_TextBox2 = value;
				if (m_TextBox2 != null)
				{
					ShowInfo();
					m_TextBox2.TextChanged += M_TextBox2_TextChanged;
				}
			}
		}
		public NumericUpDown NumericUpDown
		{
			get { return m_numericUpDown; }
			set
			{
				m_numericUpDown = value;
				if(m_numericUpDown!=null)
				{
					m_numericUpDown.Maximum = int.MaxValue;
				}
			}
		}
		//-----------------------------------------------------------------------
		private void M_TextBox2_TextChanged(object sender, EventArgs e)
		{
			if (_InfoList == null) return;
			if (RefFlag == true) return;
			if(m_mode == VMODE.OUT_FLAG)
			{
				Info[m_SelectedIndex].DescriptionJ = m_TextBox2.Text;
			}
			else
			{
				Info2[m_SelectedIndex2].DescriptionJ = m_TextBox2.Text;
			}
		}
		//-----------------------------------------------------------------------
		private void PushCheked()
		{
			List<bool> cbl = new List<bool>();
			if ((_InfoList != null) && (_InfoList.Items.Count > 0))
			{
				for (int i = 0; i < _InfoList.Items.Count; i++)
				{
					cbl.Add(_InfoList.GetItemChecked(i));
				}
			}
			if (m_mode == VMODE.OUT_FLAG)
			{
				for (int i = 0; i < cbl.Count; i++)
				{
					Info[i].Checked = cbl[i];
				}
			}
			else
			{
				for (int i = 0; i < cbl.Count; i++)
				{
					Info2[i].Checked = cbl[i];
				}
			}
		}
		//-----------------------------------------------------------------------
		private void _InfoList_SelectedIndexChanged(object sender, EventArgs e)
		{
			OutflagList cb = (OutflagList)sender;
			PushCheked();
			if (m_mode == VMODE.OUT_FLAG)
			{
				m_SelectedIndex = cb.SelectedIndex;
			}
			else
			{
				m_SelectedIndex2 = cb.SelectedIndex;
			}
			ShowInfo();
			Calc();
		}
		private void ShowList()
		{
			if (_InfoList == null) return;
			if (m_mode==VMODE.OUT_FLAG)
			{
				//m_SelectedIndex = _InfoList.SelectedIndex;
				_InfoList.SetInfos(Info);
				if (m_SelectedIndex >= 0) _InfoList.SelectedIndex = m_SelectedIndex;
			}
			else
			{
				//m_SelectedIndex2 = _InfoList.SelectedIndex;
				_InfoList.SetInfos(Info2);
				if (m_SelectedIndex2 >= 0) _InfoList.SelectedIndex = m_SelectedIndex2;

			}
		}
		private void ShowInfo()
		{
			if ((_InfoList == null)||(m_TextBox==null)|| (m_TextBox2 == null)) return;
			string s = "";
			string j = "";
			if (m_mode == VMODE.OUT_FLAG)
			{
				if (m_SelectedIndex >= 0)
				{
					s = Info[m_SelectedIndex].DescriptionInfo;
					j = Info[m_SelectedIndex].DescriptionJInfo;
				}
			}
			else
			{
				if (m_SelectedIndex2 >= 0)
				{
					s = Info2[m_SelectedIndex2].DescriptionInfo;
					j = Info2[m_SelectedIndex2].DescriptionJInfo;
				}
			}
			m_TextBox.Text = s;
			RefFlag = true;
			m_TextBox2.Text = j;
			RefFlag = false;
		}
		public void SetMode(VMODE md)
		{
			VMODE bak = m_mode;
			PushCheked();
			m_mode = md;
			if(m_mode!=bak)
			{
				if (bak == VMODE.OUT_FLAG)
				{
					m_SelectedIndex = _InfoList.SelectedIndex;
				}
				else
				{
					m_SelectedIndex2 = _InfoList.SelectedIndex;
				}
				ShowList();
				ShowInfo();
				if (m_mode == VMODE.OUT_FLAG)
				{
					_InfoList.SelectedIndex = m_SelectedIndex;
				}
				else
				{
					_InfoList.SelectedIndex = m_SelectedIndex2;
				}
				Calc();
			}
		}
		private string InfoToJson()
		{
			string ret = "";
			if (Info.Count <= 0) return "[]";
			foreach(AE_out_flags_info oi in Info)
			{
				if (ret != "") ret += ",";
				ret += oi.ToJson();
			}
			return "[" + ret + "]";
		}
		private string Info2ToJson()
		{
			string ret = "";
			if (Info2.Count <= 0) return "[]";
			foreach (AE_out_flags_info oi in Info2)
			{
				if (ret != "") ret += ",";
				ret += oi.ToJson();
			}
			return "[" + ret + "]";
		}
		public string ToJson()
		{
			string ret = "{\r\n";
			ret += "\"Info\":" + InfoToJson() + ",\r\n";
			ret += "\"Info2\":" + Info2ToJson() + "\r\n";
			ret += "}\r\n";
			return ret;

		}
		public void Info1FromJson(string js)
		{
			dynamic obj = DynamicJson.Parse(js);
			if(obj.IsArray()==true)
			{
				Info.Clear();
				foreach (dynamic o in obj)
				{
					AE_out_flags_info oi = new AE_out_flags_info(o);
					Info.Add(oi);
				}
			}

		}
		public void Info2FromJson(string js)
		{
			dynamic obj = DynamicJson.Parse(js);
			if (obj.IsArray() == true)
			{
				Info.Clear();
				foreach (dynamic o in obj)
				{
					AE_out_flags_info oi = new AE_out_flags_info(o);
					Info2.Add(oi);
				}
			}

		}
		public void ReDraw()
		{
			ShowList();
			ShowInfo();
			Calc();
		}
		public void FromJson(string js)
		{
			dynamic obj = DynamicJson.Parse(js);
			if(obj.IsDefined("Info"))
			{
				if (obj["Info"].IsArray==true)
				{
					Info.Clear();
					foreach(dynamic o in obj["Info"])
					{
						AE_out_flags_info oi = new AE_out_flags_info(o);
						Info.Add(oi);
					}

				}
			}
			if (obj.IsDefined("Info2"))
			{
				if (obj["Info2"].IsArray == true)
				{
					Info2.Clear();
					foreach (dynamic o in obj["Info2"])
					{
						AE_out_flags_info oi = new AE_out_flags_info(o);
						Info2.Add(oi);
					}

				}
			}
			ShowList();
			ShowInfo();
			Calc();

		}
		public bool SaveJson(string p)
		{
			bool ret = false;
			string js = ToJson();

			try
			{
				File.WriteAllText(p, js, Encoding.GetEncoding("utf-8"));
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool LoadJson(string p)
		{
			bool ret = false;
			if (File.Exists(p) == false) return ret;
			try
			{
				string s = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
				FromJson(s);
			}
			catch
			{
				ret = false;
			}

			return ret;
		}
	}
}
