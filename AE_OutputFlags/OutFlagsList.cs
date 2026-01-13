using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

using System.Windows.Forms;

namespace AE_OutputFlags
{
	public  class OutFlagsList :CheckedListBox
	{
		private ulong m_outFlagBits1 = 0;
		private ulong m_outFlagBits2 = 0;

		private bool m_isOutflag1 = true;
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public bool IsOutflag1
		{
			get { return m_isOutflag1; }
			set
			{
				if (m_isOutflag1 != value)
				{
					m_isOutflag1 = value;
					this.Invalidate(); // 再描画
				}
			}
		}
		private List<AE_H_Item> m_outFlags1 = new List<AE_H_Item>();
		private List<AE_H_Item> m_outFlags2 = new List<AE_H_Item>();

		public OutFlagsList()
		{
			this.CheckOnClick = true;
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.ItemHeight = 40; // アイテムの高さを調整
			this.Items.Clear();
			Initialize();
		}
		
		public void Initialize()
		{
			this.Items.Clear();
			for (ulong i = 0; i < 32; i++)
			{
				string s = $"outFlag {i:D2}";
				this.Items.Add(s, false);
			}
		}
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if ((e.Index < 0)||(e.Index>=32)||(e.Index>=this.Items.Count)) return;

			e.DrawBackground();

			// チェックボックスの描画
			CheckBoxRenderer.DrawCheckBox(
				e.Graphics,
				new Point(e.Bounds.Left + 2, e.Bounds.Top + 2),
				GetItemChecked(e.Index) ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal
			);

			string str = "";
			if (m_isOutflag1)
			{
				if (e.Index < m_outFlags1.Count)
				{
					str = $"{e.Index:D2} : {m_outFlags1[e.Index].name}";
				}
			}
			else
			{
				if (e.Index < m_outFlags2.Count)
				{
					str = $"{e.Index:D2} : {m_outFlags2[e.Index].name}";
				}
			}
			int textLeft = e.Bounds.Left + 20;
			int textTop = e.Bounds.Top + 2;

			// アイテム名（太字）
			using (Font boldFont = new Font(e.Font, FontStyle.Bold))
			{
				e.Graphics.DrawString(
					str,
					boldFont,
					new SolidBrush(e.ForeColor),
					new PointF(textLeft, textTop)
				);
			}

			e.DrawFocusRectangle();
		}
		public void FromJsonStr(string json)
		{

			var jo = JsonNode.Parse(json) as JsonObject;
			if (jo == null) return;
			if (Items.Count >= 32) Initialize();
			m_outFlags1.Clear();
			m_outFlags2.Clear();
			if (jo["outFlags1"] != null && jo["outFlags1"] is JsonArray ja1)
			{
				foreach (var item in ja1)
				{
					if (item is JsonObject jItem)
					{
						AE_H_Item hItem = new AE_H_Item();
						hItem.FromJson(jItem);
						m_outFlags1.Add(hItem);
					}
				}
			}
			if (jo["outFlags2"] != null && jo["outFlags2"] is JsonArray ja2)
			{
				foreach (var item in ja2)
				{
					if (item is JsonObject jItem)
					{
						AE_H_Item hItem = new AE_H_Item();
						hItem.FromJson(jItem);
						m_outFlags2.Add(hItem);
					}
				}
			}
		}
	}
}

