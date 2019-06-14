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
		/// <summary>
		/// 
		/// </summary>
		public AE_out_flags_info()
		{

		}
		public AE_out_flags_info(AE_out_flags_info info)
		{
			Clone(info);
		}
		public AE_out_flags_info(dynamic obj)
		{
			FromJson(obj);
		}

		public void Clone(AE_out_flags_info info)
		{
			Name = info.Name;
			Value = info.Value;
			ValueS = info.ValueS;
			Description = info.Description;
			DescriptionJ = info.DescriptionJ;
			Use_PF_Cmds = info.Use_PF_Cmds;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("name:{0}, v:{1}, vs:{2},\r\n{3}\r\n u:{4}\r\n", Name, Value, ValueS,Description, Use_PF_Cmds);
		}
		public string InfoE
		{
			get
			{
				return String.Format("{0}\tvaleu:{1}", Name, Value); 
			}
		}

		public string Use_Info
		{
			get
			{
				string ret = "";
				ret += String.Format("value:{0}", Value);
				ret += "\tUsed Command: " + Use_PF_Cmds; 
				return ret;
			}
		}

		private string enc(string s)
		{
			string ret = s;
			ret = ret.Replace("\r", "\\r");
			ret = ret.Replace("\n", "\\n");
			ret = ret.Replace("\t", "\\t");
			ret = ret.Replace("\"", "\\\"");
			return ret;
		}
		public string ToJson()
		{
			string f = "{";
			f += "\"Description\":\"" + enc(Description) + "\",";
			f += "\"DescriptionJ\":\"" + enc(DescriptionJ) + "\",";
			f += "\"Name\":\"" + Name + "\",";
			f += String.Format("\"Value\":{0},",Value);
			f += "\"Use_PF_Cmds\":\"" + Use_PF_Cmds + "\"";
			f += "}";
			return f;
		}
		public string DescriptionToJson()
		{
			string f = "{";
			f += "\"Description\":\"" + enc(Description) + "\",";
			f += "\"DescriptionJ\":\"" + enc(DescriptionJ) + "\",";
			f += "}";
			return f;
		}
		public void FromJson(dynamic ret)
		{
			if (ret.IsDefined("Name")) Name = ret["Name"];
			if (ret.IsDefined("Value")) Value = (int)ret["Value"];
			if (ret.IsDefined("Use_PF_Cmds")) Use_PF_Cmds = ret["Use_PF_Cmds"];
			if (ret.IsDefined("Description")) Description = ret["Description"];
			if (ret.IsDefined("DescriptionJ")) DescriptionJ = ret["DescriptionJ"];

		}
		public void DescriptionFromJson(dynamic ret)
		{
			if (ret.IsDefined("Description")) Description = ret["Description"];
			if (ret.IsDefined("DescriptionJ")) DescriptionJ = ret["DescriptionJ"];

		}
	}
}
