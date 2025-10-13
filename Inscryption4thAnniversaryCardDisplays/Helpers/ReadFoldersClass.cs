using System.Reflection;
using Inscryption4thAnniversaryCardDisplays.Helpers.Loggers;
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
			
			foreach (string subPath in Directory.GetDirectories(Path.GetFullPath(FolderRootPath)))
			{
				displayNames.Add(Path.GetFileName(subPath).Replace('$', '/'));
				Logging.Log("ReadFolders", "Info", $"Subfolder Found in {Path.GetFileName(FolderRootPath)}; {subPath}");
				List<string> files = new List<string>();
				foreach (string file in Directory.GetFiles(Path.GetFullPath(subPath)))
				{
					files.Add(file);
					Logging.Log("ReadFolders", "Info", $"File Found in {Path.GetFileName(subPath)}; {file}");
				}
				
				entrys.Add(Path.GetFileName(subPath).Replace('$', '/'), files);
			}
			return (displayNames, entrys);
		}
	}
}