using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_sdk_util
{
	public partial class OutflagList : CheckedListBox
	{
		public OutflagList()
		{
			InitializeComponent();
		}
		public int AddInfo(AE_out_flags_info info)
		{
			return this.Items.Add(info.Name);
		}
		public void SetInfo(int idx, AE_out_flags_info info)
		{
			if((idx>=0)&&(idx<Items.Count))
			{
				Items[idx] = info.Name;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="infos"></param>
		public void SetInfos(List<AE_out_flags_info> infos)
		{
			if (infos.Count <= 0) return;
			this.BeginUpdate();
			this.Items.Clear();
			foreach(AE_out_flags_info oi in infos)
			{
				AddInfo(oi);
			}
			this.EndUpdate();
		}
	}
}
