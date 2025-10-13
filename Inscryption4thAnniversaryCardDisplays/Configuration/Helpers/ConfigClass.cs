using Inscryption4thAnniversaryCardDisplays.HandleGrids;
using Inscryption4thAnniversaryCardDisplays.Helpers.Loggers;
using System.Reflection;

namespace Inscryption4thAnniversaryCardDisplays.Configuration.Helpers
{
	public class ConfigClass
	{
		public static Assembly Assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(Assembly.Location);
		public static string ConfigFile = Path.GetFullPath(DLLPath + "\\Config.txt");
		
		/// <summary>
		/// Loads the Config
		/// </summary>
		/// <param name="httpClient">The HTTPClient in which is passed to set a value in the config.</param>
		/// <returns>The loaded config.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static Config LoadConfig(HttpClient httpClient)
		{
			List<string> arrayOfText = File.ReadAllLines(ConfigFile).ToList();
			string contestName = arrayOfText[0].Remove(0, 14);
			string horizontalAlignment = arrayOfText[1].Remove(0, 13);
			List<string> color = arrayOfText[2].Remove(0, 8).Replace('{', ' ').Replace('}', ' ').Split(',').ToList();
			(int r, int g, int b, int a) = (int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]), int.Parse(color[3]));
			List<string> pos = arrayOfText[3].Remove(0, 11).Replace('{', ' ').Replace('}', ' ').Split(',').ToList();
			(int width, int height) = (int.Parse(pos[0]),  int.Parse(pos[1]));
			string fontUrl = arrayOfText[4].Remove(0, 10);
			int displayNameSize = int.Parse(arrayOfText[5].Remove(0, 18));
			int socialNameSize = int.Parse(arrayOfText[6].Remove(0, 17));
			int eventNameSize = int.Parse(arrayOfText[7].Remove(0, 18));
			
			Config config = new Config(contestName, horizontalAlignment, r, g, b, a, width, height, fontUrl, httpClient, displayNameSize, socialNameSize, eventNameSize);
			return config;
		}
	}
}