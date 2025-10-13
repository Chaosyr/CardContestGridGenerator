using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Reflection;

namespace Inscryption4thAnniversaryCardDisplays.HandleGrids
{
	public class SaveGridsToDiskClass
	{
		public static Assembly Assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(Assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Grids");
		
		/// <summary>
		/// Saves the mega grids.
		/// </summary>
		/// <param name="images">A list of grids in which to save.</param>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static void SaveGridsToDisk(List<Image<Rgba32>> images)
		{
			int fileCount = 0;
			foreach (Image<Rgba32> image in images)
			{
				image.SaveAsPng(Path.Combine(FolderRootPath + $"\\image_{fileCount}.png"));
				fileCount++;
			}
		}
	}
}