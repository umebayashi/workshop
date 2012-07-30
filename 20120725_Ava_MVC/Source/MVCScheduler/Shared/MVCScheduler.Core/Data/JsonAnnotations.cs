using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVCScheduler.Data
{
	[AttributeUsage(AttributeTargets.Class)]
	public class JsonObjectAttribute : System.Attribute
	{
		public string Name { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class JsonFieldAttribute : System.Attribute
	{
		public string Name { get; set; }

		public string ForeignKey { get; set; }
	}

	public static class JsonObjectConverter
	{
		public static object ToJson(object obj)
		{
			var type = obj.GetType();
			return null;
		}
	}
}
