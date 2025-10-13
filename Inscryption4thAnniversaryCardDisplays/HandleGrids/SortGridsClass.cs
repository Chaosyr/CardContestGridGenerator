using Inscryption4thAnniversaryCardDisplays.Helpers.Loggers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Immutable;

namespace Inscryption4thAnniversaryCardDisplays.HandleGrids
{
	public class SortGridsClass
	{
		/// <summary>
		/// Sorts the grids and entry's.
		/// </summary>
		/// <param name="grids">A dictionary of a Display Name associated with a grid.</param>
		/// <param name="entrys">A dictionary of a Display Name associated with a List of entry's.</param>
		/// <returns>A sorted grid dictionary and sorted display names.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static (Dictionary<string, Image<Rgba32>> SortedGrids, List<string> SortedKeys) SortGrids(Dictionary<string,  Image<Rgba32>> grids, Dictionary<string, List<string>> entrys)
		{
			Dictionary<string, Image<Rgba32>> sorted = grids
				.OrderByDescending(g => entrys[g.Key].Count)
				.ToDictionary(g => g.Key, g => g.Value);
			
			List<string> sortedKeys = new List<string>();
			Logging.Log("SortGrids", "Info", $"Sorted Grids, The Order It Has Been Put Within;");
			
			foreach (var (key, value) in sorted)
			{
				Logging.Log("SortGrids", "Info", $"Grid {key} has {entrys[key].Count} entries.");
				sortedKeys.Add(key);
			}
			
			return (sorted, sortedKeys);
		}
	}
}