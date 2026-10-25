using System.Reflection;
using Inscryption4thAnniversaryCardDisplays.Helpers.Loggers;
using System.Linq;
namespace Inscryption4thAnniversaryCardDisplays.Helpers
{
	public static class ReadFoldersClass
	{
		public static Assembly Assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(Assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Cards");
		
		/// <summary>
		/// Reads the Local Card Folder for the Entry's and the Display Names.
		/// </summary>
		/// <returns>A List of Display Names, and a List of Entry's associated with the Display Names.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static (List<string> DisplayNames, Dictionary<string, List<string>> Entrys) ReadFolders()
		{
			List<string> displayNames = new List<string>();
			Dictionary<string, List<string>> entrys = new Dictionary<string, List<string>>();

			var sortedDirectories = Directory.GetDirectories(Path.GetFullPath(FolderRootPath))
				.OrderBy(path => 
				{
					string cleanName = Path.GetFileName(path).Replace('$', '/').Replace('⁚', ':');
					return System.Text.RegularExpressions.Regex.Replace(cleanName, @"\d+", match => match.Value.PadLeft(20, '0'));
				}, StringComparer.OrdinalIgnoreCase);

			foreach (string subPath in sortedDirectories)
			{
				displayNames.Add(Path.GetFileName(subPath).Replace('$', '/').Replace('⁚', ':'));
				Logging.Log("ReadFolders", "Info", $"Subfolder Found in {Path.GetFileName(FolderRootPath)}; {subPath}");
				List<string> files = new List<string>();
				var sortedFiles = Directory.GetFiles(Path.GetFullPath(subPath))
					.OrderBy(filePath => System.Text.RegularExpressions.Regex.Replace(Path.GetFileName(filePath), @"\d+", match => match.Value.PadLeft(20, '0')), StringComparer.OrdinalIgnoreCase)
					.ToList();

				foreach (string file in sortedFiles)
				{
					Logging.Log("ReadFolders", "Info", $"File Found in {Path.GetFileName(subPath)}; {file}");
				}
    
				entrys.Add(Path.GetFileName(subPath).Replace('$', '/').Replace('⁚', ':'), sortedFiles);
			}
			return (displayNames, entrys);
		}
	}
}