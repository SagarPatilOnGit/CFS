using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CFSClient
{
	public class ApiModel
	{
		public string AppName { get; set; }
		public string ApiName { get; set; }
		public short ApiVersion { get; set; }
	}

	public static class RestApiUtility
	{
		public static IList<ApiModel> FillAppDetail(string[] lines)
		{
			var apps = new List<ApiModel>();
			foreach (var line in lines)
			{
				string[] app = line.Split(',');
				if (app.Length == 3)
				{
					apps.Add(new ApiModel() { AppName = app[0], ApiName = app[1], ApiVersion = Convert.ToInt16(app[2].Remove(0,1))});
				}
			}
			return apps;
		}
	}

	public class RestApi
	{
		public void DisplayOldApis()
		{
			var apiGroup = RestApiUtility.FillAppDetail(File.ReadAllLines(@"C:\input.txt")).GroupBy(x => x.ApiName);
			var oldApis = ( from apis in apiGroup
							from api in apis
							where api.ApiVersion != apis.Max(x => x.ApiVersion)
						 select api.AppName).Distinct();
			foreach(var apiname in oldApis)
			{
				Console.WriteLine(apiname);
			}
		}
	}

	public class Inner
	{
	}

	public sealed class Singleton
	{
		private Inner inner; // Assume Inner is defined elsewhere
		private static Singleton s = new Singleton();
		public Singleton()
		{
			inner = null;
			// other code goes here
		}
		public static Singleton getSingleton()
		{
			return s;
		}
		public Inner getInner()
		{
			return inner;
		}
		public void setInner(Inner i)
		{
			inner = i;
		}
	}
}
