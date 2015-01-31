using System;
using System.IO;
using System.Net;

namespace MockServices
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Requesting...");

			// Note: Comment this line out to watch SSL fail.
			ServicePointManager.ServerCertificateValidationCallback = (a,b,c,d) => true;

			var webRequest = HttpWebRequest.Create (@"https://webservice.aspsms.com/aspsmsx2.asmx/VersionInfo");
			using (var response = webRequest.GetResponse())
			{
				using (var stream = response.GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						string result = streamReader.ReadToEnd();
						Console.WriteLine(result);
					}
				}
			}
		}
	}
}
