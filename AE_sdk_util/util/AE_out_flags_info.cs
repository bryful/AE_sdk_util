using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Codeplex.Data;

namespace AE_sdk_util
{
	public class AE_out_flags_info
	{
		public string Name = "";
		public int Value = 0;
		public string ValueS = "";
		public string Description = "";
		public string DescriptionJ = "";
		public string Use_PF_Cmds = "";
		public bool Checked = false;
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("name:{0}, v:{1}, vs:{2},\r\n{3}\r\n u:{4}\r\n", Name, Value, ValueS,Description, Use_PF_Cmds);
		}
		public string Info
		{
			get
			{
				return String.Format("{0}\tvaleu:{1}", Name, Value); 
			}
		}
		public string Detil
		{
			get
			{
				return String.Format(
					"{0} : valei:{1}\r\n" +
					"used:{2}\r\n\r\n" +
					"{3}",
					Name, Value, Use_PF_Cmds,Description
					);
			}
		}
		public string DetilJ
		{
			get
			{
				return String.Format(
					"{0} : valei:{1}\r\n" +
					"used:{2}\r\n\r\n" +
					"{3}",
					Name, Value, Use_PF_Cmds, DescriptionJ
					);
			}
		}
		public string ToJson()
		{
			string f =
				"{\"Name\":\"{0}\"" +
				"{\"Value\":\"{1}\"" +
				"{\"Use_PF_Cmds\":\"{2}\"" +
				"{\"Description\":\"{3}\"" +
				"{\"DescriptionJ\":\"{4}\"}"+
				"{\"Checkd\":\"{5}\"}";
			return String.Format(f, Name, Value, Use_PF_Cmds, Description, DescriptionJ, Checked);
		}
		public void FromJson(string s)
		{
			var ret = DynamicJson.Parse(s);
			if (ret.IsDefined("Name")) Name = ret["Name"];
			if (ret.IsDefined("Value")) Value = ret["Value"];
			if (ret.IsDefined("Use_PF_Cmds")) Use_PF_Cmds = ret["Use_PF_Cmds"];
			if (ret.IsDefined("Description")) Description = ret["Description"];
			if (ret.IsDefined("DescriptionJ")) DescriptionJ = ret["DescriptionJ"];
			if (ret.IsDefined("Checked")) Checked = ret["Checked"];

		}
	}
}
