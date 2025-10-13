using Inscryption4thAnniversaryCardDisplays.Helpers.Loggers;
using System.Reflection;

namespace Inscryption4thAnniversaryCardDisplays.Helpers
{
	public class ParseSocialsClass
	{
		public static Assembly Assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(Assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Cards");
		public static string SocialsFile = Path.GetFullPath(FolderRootPath + "\\Socials.txt");
		
		/// <summary>
		/// Parses through 'Socials.txt' located in the DLLPath's executing directory under Cards for the Socials associated with an entry.
		/// </summary>
		/// <returns>A dictionary of Name, Social(s).</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static Dictionary<string, string> ParseSocials()
		{
			Dictionary<string, string> socials = new Dictionary<string, string>();
			foreach (string line in File.ReadAllLines(SocialsFile))
			{
				if (line == "Name;Social")
					continue;
				
				string displayName = line.Split(";")[0];
				string social = line.Split(";")[1];
				Logging.Log("PageSocials", "Info", $"Found Socials under {displayName} with {social}");
				socials.Add(displayName, social);
			}
			return socials;
		}
	}
}