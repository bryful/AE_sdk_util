using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AE_OutputFlags
{

    public class AE_Effect : Component
    {
        // ***********************************************************************
        #region Property
        private bool refFlag = false;
        private int ListIndex = 0;

        private string m_AE_EffectH = "";
        /// <summary>
        /// AE_Effect.hのフルパス
        /// </summary>
        public string AE_EffectH
        {
            get { return m_AE_EffectH; }
        }
        private AE_OutFlags m_out_flags = new AE_OutFlags();
        private AE_OutFlags m_out_flags2 = new AE_OutFlags();


        public int OutFlagsCount { get { return m_out_flags.Count; } }
        public int OutFlags2Count { get { return m_out_flags2.Count; } }
        public AE_OutFlag OutFlag(int idx)
        {
            if ((idx >= 0) && (idx < m_out_flags.Count))
            {
                return m_out_flags.Flags[idx];
            }
            else
            {
                return new AE_OutFlag();
            }
        }
        public AE_OutFlag OutFlag2(int idx)
        {
            if ((idx >= 0) && (idx < m_out_flags2.Count))
            {
                return m_out_flags2.Flags[idx];
            }
            else
            {
                return new AE_OutFlag();
            }
        }

        public AE_OutFlag[] OutFlags
        {
            get { return m_out_flags.Flags; }
        }
        public AE_OutFlag[] OutFlags2
        {
            get { return m_out_flags2.Flags; }
        }
        #endregion
        // ***********************************************************************
        #region Control

        private CheckedListBox m_ListBox1 = null;
        private CheckedListBox m_ListBox2 = null;
        public CheckedListBox ListBox1
        {
            get { return m_ListBox1; }
            set
            {
                m_ListBox1 = value;
                if (m_ListBox1 != null)
                {
                    m_ListBox1.Tag = 1;
                    m_ListBox1.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
                    m_ListBox1.SelectedValueChanged += M_ListBox_SelectedValueChanged;
                }
            }
        }


        public CheckedListBox ListBox2
        {
            get { return m_ListBox2; }
            set
            {
                m_ListBox2 = value;
                if (m_ListBox2 != null)
                {
                    m_ListBox2.Tag = 2;
                    m_ListBox2.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
                    m_ListBox2.SelectedValueChanged += M_ListBox_SelectedValueChanged;
                }
            }
        }
        private void M_ListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (refFlag) return;
            CalcFromListBox();
        }
        private void M_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox lst = (CheckedListBox)sender;

            int idx = lst.SelectedIndex;
            string s = "";
            string sj = "";
            if (idx >= 0)
            {
                if ((int)lst.Tag == 1)
                {
                    ListIndex = 1;
                    s = m_out_flags.Flags[idx].Description;
                    sj = m_out_flags.Flags[idx].DescriptionJ;

                    if (m_ComBox1 != null)
                    {
                        m_ComBox1.Text = m_out_flags.Flags[idx].Comment;
                    }
                }
                else if ((int)lst.Tag == 2)
                {
                    ListIndex = 2;
                    s = m_out_flags2.Flags[idx].Description;
                    sj = m_out_flags2.Flags[idx].DescriptionJ;
                    if (m_ComBox2 != null)
                    {
                        m_ComBox2.Text = m_out_flags2.Flags[idx].Comment;
                    }
                }

            }
            if (m_DescriptionBox != null)
            {
                m_DescriptionBox.Text = s;

            }
            if (m_DescriptionBoxJ != null)
            {
                m_DescriptionBoxJ.Text = sj;

            }
        }

        private NumericUpDown m_Num1 = null;
        private NumericUpDown m_Num2 = null;
        public NumericUpDown Num1
        {
            get { return m_Num1; }
            set
            {
                m_Num1 = value;
                if (m_Num1 != null)
                {
                    m_Num1.Tag = 1;
                    m_Num1.ValueChanged += M_Num_ValueChanged;
                }
            }
        }
        public NumericUpDown Num2
        {
            get { return m_Num2; }
            set
            {
                m_Num2 = value;
                if (m_Num2 != null)
                {
                    m_Num2.Tag = 2;
                    m_Num2.ValueChanged += M_Num_ValueChanged;

                }
            }
        }
        private void M_Num_ValueChanged(object sender, EventArgs e)
        {
            if (refFlag) return;
            refFlag = true;
            NumericUpDown num = (NumericUpDown)sender;

            long v = (long)num.Value;

            int idx = (int)num.Tag;

            if (idx == 1)
            {
                if (m_ListBox1.Items.Count > 0)
                {
                    for (int i = 0; i < m_ListBox1.Items.Count; i++)
                    {
                        bool b = ((v & m_out_flags.Flags[i].Value) == m_out_flags.Flags[i].Value);
                        m_ListBox1.SetItemChecked(i, b);
                    }
                }
            }
            else if (idx == 2)
            {
                if (m_ListBox2.Items.Count > 0)
                {
                    for (int i = 0; i < m_ListBox2.Items.Count; i++)
                    {
                        bool b = ((v & m_out_flags2.Flags[i].Value) == m_out_flags2.Flags[i].Value);
                        m_ListBox2.SetItemChecked(i, b);
                    }
                }

            }
            refFlag = false;
        }
        private TextBox m_DescriptionBox = null;
        public TextBox DescriptionBox
        {
            get { return m_DescriptionBox; }
            set
            {
                m_DescriptionBox = value;
                if (m_DescriptionBox != null)
                {

                }
            }
        }
        private TextBox m_DescriptionBoxJ = null;
        public TextBox DescriptionBoxJ
        {
            get { return m_DescriptionBoxJ; }
            set
            {
                m_DescriptionBoxJ = value;
                if (m_DescriptionBoxJ != null)
                {
                    m_DescriptionBoxJ.TextChanged += M_DescriptionBoxJ_TextChanged;
                }
            }
        }
        private TextBox m_ComBox1 = null;
        private TextBox m_ComBox2 = null;
        public TextBox ComBox1
        {
            get { return m_ComBox1; }
            set
            {
                m_ComBox1 = value;
                if (m_ComBox1 != null)
                {

                }
            }
        }
        public TextBox ComBox2
        {
            get { return m_ComBox2; }
            set
            {
                m_ComBox2 = value;
                if (m_ComBox2 != null)
                {

                }
            }
        }
        private void M_DescriptionBoxJ_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            string tx = tb.Text.Trim();

            int idx = -1;
            if (ListIndex == 1)
            {
                idx = m_ListBox1.SelectedIndex;
                if (idx >= 0)
                {
                    m_out_flags.Flags[idx].DescriptionJ = tx;
                }
            }
            else if (ListIndex == 2)
            {
                idx = m_ListBox2.SelectedIndex;
                if (idx >= 0)
                {
                    m_out_flags2.Flags[idx].DescriptionJ = tx;
                }
            }
        }
        #endregion
        // ***********************************************************************
        public AE_Effect()
        {

        }
        // ***********************************************************************
        private void CalcFromListBox()
        {
            if (refFlag) return;
            refFlag = true;
            long v = 0;
            if (m_ListBox1 != null)
            {
                if (m_ListBox1.Items.Count > 0)
                {
                    for (int i = 0; i < m_ListBox1.Items.Count; i++)
                    {

                        if (m_ListBox1.GetItemChecked(i) == true)
                        {
                            v += m_out_flags.Flags[i].Value;
                        }
                    }
                }
                if (m_Num1 != null)
                {
                    if (m_Num1.Value != (decimal)v) m_Num1.Value = (decimal)v;

                }
            }
            v = 0;
            if (m_ListBox2 != null)
            {
                if (m_ListBox2.Items.Count > 0)
                {
                    for (int i = 0; i < m_ListBox2.Items.Count; i++)
                    {

                        if (m_ListBox2.GetItemChecked(i) == true)
                        {
                            v += m_out_flags2.Flags[i].Value;
                        }
                    }
                }
                if (m_Num2 != null)
                {
                    if (m_Num2.Value != (decimal)v) m_Num2.Value = (decimal)v;

                }
            }
            refFlag = false;
        }
        // ***********************************************************************
        private string[] LoadFile(string p)
        {

            try
            {
                string[] lines = File.ReadAllLines(p, Encoding.GetEncoding("utf-8"));
                return lines;
            }
            catch
            {
                return new string[0];

            }
        }
        // ***********************************************************************
        private string[] FindTypeDef(string[] ary, string tag)
        {
            string[] ret = new string[0];
            int idx = -1;
            for (int i = 0; i < ary.Length; i++)
            {
                string line = ary[i].Trim();
                if (line.IndexOf(tag) == 0)
                {
                    idx = i;
                    break;
                }

            }
            if (idx < 0) return ret;
            int idx2 = -1;
            for (int i = idx - 1; i >= 0; i--)
            {
                string line = ary[i];
                if (line.Trim().IndexOf("enum") == 0)
                {
                    idx2 = i;
                    break;
                }

            }
            if (idx2 < 0) return ret;
            List<string> p = new List<string>();

            for (int i = idx2; i < idx; i++)
            {
                string line = ary[i];
                if (line.Trim().IndexOf("PF_Out") == 0)
                {
                    p.Add(line);
                }
            }
            ret = p.ToArray();

            return ret;
        }
        // ***********************************************************************
        private string[] SplitDescription(string[] ary)
        {
            string[] ret = new string[0];
            int idx = -1;
            for (int i = 0; i < ary.Length; i++)
            {
                string line = ary[i];
                if ((line.IndexOf("/**") == 0) && (line.IndexOf("- Output Flags -") > 0))
                {
                    idx = i;
                    break;
                }
            }
            if (idx < 0) return ret;

            string a = "";
            for (int i = idx + 1; i < ary.Length; i++)
            {
                string line = ary[i];
                if (line.IndexOf("**/") == 0) break;
                a += line + "\r\n";
            }

            string[] aa = a.Split("\tPF_Out");
            List<string> a3 = new List<string>();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i].IndexOf("Flag") == 0)
                {
                    string h = "PF_Out" + aa[i];

                    string[] ht = h.Split("\r\n");
                    h = "";
                    if (ht.Length >= 1)
                    {
                        h = ht[0] + "\r\n";
                    }
                    if (ht.Length >= 2)
                    {
                        for (int j = 1; j < ht.Length; j++)
                        {
                            string p = ht[j].Trim();
                            if (p == "")
                            {
                                h += "\r\n";
                            }
                            else
                            {
                                h += p + " ";
                                if (p[p.Length - 1] == '.')
                                {
                                    h += "\r\n";
                                }
                            }
                        }

                    }

                    a3.Add(h.Trim());
                }
            }
            ret = a3.ToArray();

            return ret;
        }
        // Description

        // ***********************************************************************
        private string FindDescription(string[] ary, string nm)
        {
            string ret = "";
            if (ary.Length > 0)
            {
                for (int i = 0; i < ary.Length; i++)
                {
                    if (ary[i].IndexOf(nm) == 0)
                    {
                        ret = ary[i];
                        break;
                    }
                }
            }
            return ret;
        }

        // ***********************************************************************
        public bool LoadAE_EffectH(string p)
        {
            bool ret = false;

            if (File.Exists(p) == false) return ret;

            string[] lines = LoadFile(p);
            if (lines.Length <= 0) return ret;

            string[] ofs1 = FindTypeDef(lines, "typedef A_long PF_OutFlags");
            string[] ofs2 = FindTypeDef(lines, "typedef A_long PF_OutFlags2");
            string[] cmt = SplitDescription(lines);

            m_out_flags.Clear();
            if (ofs1.Length > 0)
            {
                for (int i = 0; i < ofs1.Length; i++)
                {
                    AE_OutFlag of = new AE_OutFlag();
                    of.FromLine(ofs1[i]);
                    if (of.Name != "")
                    {
                        of.Description = FindDescription(cmt, of.Name);

                        m_out_flags.Add(of);

                    }
                }
            }
            m_out_flags2.Clear();
            if (ofs2.Length > 0)
            {
                for (int i = 0; i < ofs2.Length; i++)
                {
                    AE_OutFlag of = new AE_OutFlag();
                    of.FromLine(ofs2[i]);
                    if (of.Name != "")
                    {
                        of.Description = FindDescription(cmt, of.Name);

                        m_out_flags2.Add(of);

                    }
                }
            }
            ret = ((m_out_flags.Count > 0) && (m_out_flags2.Count > 0));
            if (ret)
            {
                m_AE_EffectH = p;
                CreateList();
            }

            return ret;
        }
        // ***********************************************************************
        public bool Export(string p)
        {
            bool ret = false;

            dynamic obj = new DynamicJson();

            obj["out_flags"] = m_out_flags.ToObj;
            obj["out_flags2"] = m_out_flags2.ToObj;

            var json = obj.ToString();

            try
            {
                File.WriteAllText(p, json, Encoding.GetEncoding("utf-8"));
                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
        // ***********************************************************************
        public bool Import(string p)
        {
            bool ret = false;
            m_out_flags.Clear();
            m_out_flags2.Clear();

            if (File.Exists(p) == false) return ret;

            string js = "";
            try
            {
                js = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
            }
            catch
            {
                return ret;
            }
            if (js == "") return ret;

            dynamic obj = DynamicJson.Parse(js);

            if (((DynamicJson)obj).IsDefined("out_flags") == true)
            {
                m_out_flags.FromObj(obj["out_flags"]);
            }
            if (((DynamicJson)obj).IsDefined("out_flags2") == true)
            {
                m_out_flags2.FromObj(obj["out_flags2"]);
            }

            ret = ((m_out_flags.Count > 0) && (m_out_flags2.Count > 0));
            if (ret)
            {
                CreateList();
            }

            return ret;
        }
        // ***********************************************************************
        public void CreateList()
        {
            if (m_ListBox1 != null)
            {
                m_ListBox1.Items.Clear();
                if (m_out_flags.Count > 0)
                {
                    for (int i = 0; i < m_out_flags.Count; i++)
                    {
                        int idx = m_ListBox1.Items.Add(m_out_flags.Flags[i].Name, false);
                    }
                }
            }
            if (m_ListBox2 != null)
            {
                m_ListBox2.Items.Clear();
                if (m_out_flags2.Count > 0)
                {
                    for (int i = 0; i < m_out_flags2.Count; i++)
                    {
                        int idx = m_ListBox2.Items.Add(m_out_flags2.Flags[i].Name, false);
                    }
                }
            }
        }
        // ***********************************************************************
    }
}
