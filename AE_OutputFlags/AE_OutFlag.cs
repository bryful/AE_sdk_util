
using Codeplex.Data;

namespace AE_OutputFlags
{
    public class AE_OutFlag
    {
        public string Name = "";
        public long Value = 0;
        public int ShiftValue = 0;
        public string Description = "";
        public string Comment = "";
        public string DescriptionJ = "";
        public AE_OutFlag()
        {

        }
        public void Clear()
        {
            Name = "";
            Value = 0;
            ShiftValue = 0;
            Description = "";
            Comment = "";
            DescriptionJ = "";
        }
        public void FromLine(string s)
        {
            Clear();
            string s0 = s.Trim();
            if (s0 == "") return;
            string com = "";
            string nm = "";
            string vs = "";

            //コメントと分離
            string[] sa = s0.Split("//");
            if (sa.Length >= 2)
            {
                com = sa[1].Trim();
            }
            s0 = sa[0].Trim();

            sa = s0.Split("=");
            if (sa.Length >= 2)
            {
                nm = sa[0].Trim();
                vs = sa[1].Replace("1L <<", "").Replace(",", "").Trim();
            }
            if ((nm != "") && (vs != ""))
            {
                if (int.TryParse(vs, out int v))
                {
                    ShiftValue = v;
                    Value = 1L << v;
                    Comment = com;
                    Name = nm;
                }
            }
        }
        public object ToObj()
        {
            /*
			dynamic ret = new DynamicJson();

			ret["Name"] = Name;
			ret["Value"] = (double)Value;
			ret["ShiftValue"] = (double)ShiftValue;
			ret["Description"] = Description;
			ret["Comment"] = Comment;
			return ret;
			*/
            var obj = new
            {
                Name = this.Name,
                Value = (double)this.Value,
                ShiftValue = (double)this.ShiftValue,
                Description = this.Description,
                Comment = this.Comment,
                DescriptionJ = this.DescriptionJ
            };
            return obj;

        }
        public void FromObj(dynamic obj)
        {
            if (((DynamicJson)obj).IsDefined("Name") == true)
            {
                Name = obj["Name"];
            }
            if (((DynamicJson)obj).IsDefined("Value") == true)
            {
                Value = (long)obj["Value"];
            }
            if (((DynamicJson)obj).IsDefined("ShiftValue") == true)
            {
                ShiftValue = (int)obj["ShiftValue"];
            }
            if (((DynamicJson)obj).IsDefined("Description") == true)
            {
                Description = obj["Description"];
            }
            if (((DynamicJson)obj).IsDefined("DescriptionJ") == true)
            {
                DescriptionJ = obj["DescriptionJ"];
            }
            if (((DynamicJson)obj).IsDefined("Comment") == true)
            {
                Comment = obj["Comment"];
            }
        }
    }
}
