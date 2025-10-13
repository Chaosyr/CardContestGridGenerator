// See https://aka.ms/new-console-template for more information

using Inscryption4thAnniversaryCardDisplays.Configuration;
using Inscryption4thAnniversaryCardDisplays.Configuration.Helpers;
using Inscryption4thAnniversaryCardDisplays.HandleGrids;
using Inscryption4thAnniversaryCardDisplays.Helpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Inscryption4thAnniversaryCardDisplays
{
	public static class Program
	{
		public static HttpClient HttpClient = new();
		
		/// <summary>
		/// Sets up the Grids and saves them via reading the local folder in the build location.
		/// </summary>
		/// <returns>Saved Grids</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static void Main()
		{
			(List<string> displayNames, Dictionary<string, List<string>> entrys) = ReadFoldersClass.ReadFolders();
			Dictionary<string, string> socials = ParseSocialsClass.ParseSocials();
			
			HttpClient.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
			{
				NoCache = true,
				NoStore = true,
				MustRevalidate = true
			};
			Config config = ConfigClass.LoadConfig(HttpClient);
			
			Dictionary<string, Image<Rgba32>> grids = DefineGridClass.DefineGrids(displayNames, entrys, socials, config);
			(Dictionary<string, Image<Rgba32>> sortedGrids, List<string> sortedKeys) = SortGridsClass.SortGrids(grids, entrys);
			List<Image<Rgba32>> filesToSave = CreateGridClass.CreateGrids(sortedGrids, sortedKeys, config);
			SaveGridsToDiskClass.SaveGridsToDisk(filesToSave);
		}
	}
}