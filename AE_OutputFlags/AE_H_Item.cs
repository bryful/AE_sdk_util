using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace AE_OutputFlags
{
	public class AE_H_Item
	{
		public ulong value { get; set; } = 0;
		public int bit { get; set; } = 0;

		public string name { get; set; } = "";
		public string description { get; set; } = "";
		public string relevant_commands { get; set; } = "";
		public AE_H_Item() { }

		public void FromJson(JsonObject jo)
		{
			if (jo["value"] != null) this.value = (ulong)jo["value"]!;
			if (jo["bit"] != null) this.bit = (int)jo["bit"]!;
			if (jo["name"] != null) this.name = (string)jo["name"]!;
			if (jo["description"] != null) this.description = (string)jo["description"]!;
			if (jo["relevant_commands"] != null) this.relevant_commands = (string)jo["relevant_commands"]!;
		}
		public JsonObject ToJson()
		{
			var jo = new JsonObject();
			jo["value"] = this.value;
			jo["bit"] = this.bit;
			jo["name"] = this.name;
			jo["description"] = this.description;
			jo["relevant_commands"] = this.relevant_commands;
			return jo;
		}
		public override string ToString()
		{
			return $"{bit}:{this.name}";
		}
	}
}
