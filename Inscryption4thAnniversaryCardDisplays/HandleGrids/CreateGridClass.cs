using Inscryption4thAnniversaryCardDisplays.Helpers.Loggers;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Reflection;

namespace Inscryption4thAnniversaryCardDisplays.HandleGrids
{
	public class CreateGridClass
	{
		public static Assembly Assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(Assembly.Location);

		/// <summary>
		/// Sets up the end result mega grid.
		/// </summary>
		/// <param name="grids">The grids in which to place within the mega grids.</param>
		/// <param name="displayNames">A list of Display Names</param>
		/// <param name="httpClient">The HttpClient in which will be used to fetch the font.</param>
		/// <returns>A list of Images to save.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static List<Image<Rgba32>> CreateGrids(Dictionary<string, Image<Rgba32>> grids, List<string> displayNames, HttpClient httpClient)
		{
			List<Image<Rgba32>> filesToSendBack = new List<Image<Rgba32>>();

			Task<Stream> fontFile = httpClient.GetStreamAsync("https://github.com/Chaosyr/KamWerksPortraitsAndOtherAssets/raw/refs/heads/main/heavyweight.ttf");

			MemoryStream fontStream = new();
			fontFile.Result.CopyTo(fontStream);
			fontStream.Position = 0;

			FontCollection collection = new();
			FontFamily family = collection.Add(fontStream);
			Font contestSize = family.CreateFont(64, FontStyle.Regular);

			RichTextOptions optionsContest = new(contestSize)
			{
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Center,
				Origin = new PointF(2685, 2131),
			};

			Image<Rgba32> baseImage = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\backgroundBase.png"));

			int curr = 0;
			for (int iterator = 1; iterator < grids.Count + 1; iterator++)
			{
				curr = iterator - 1;
				if (iterator % 4 == 1)
				{
					baseImage.Mutate(img =>
					{
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(0, 0), 1.0f);
						img.DrawText(optionsContest, "Inscryption 4th Anniversary - Card Contest 2025", new Rgba32(255, 200, 0, 255));
					});
				}
				else if (iterator % 4 == 2)
				{
					baseImage.Mutate(img =>
					{
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(1921, 0), 1.0f);
					});
				}
				else if (iterator % 4 == 3)
				{
					baseImage.Mutate(img =>
					{
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(0, 1081), 1.0f);
					});
				}
				else if (iterator % 4 == 0)
				{
					baseImage.Mutate(img =>
					{
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(1921, 1081), 1.0f);
					});
					Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[iterator - 4]}, {displayNames[iterator - 3]}, {displayNames[iterator - 2]}, {displayNames[iterator - 1]} has been created and will be saved shortly.");
					filesToSendBack.Add(baseImage);
					baseImage = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\backgroundBase.png"));
				}
			}

			int leftover = grids.Count % 4;

			if (leftover == 1)
			{
				Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[curr]} has been created and will be saved shortly.");
				filesToSendBack.Add(baseImage);
			}
			else if (leftover == 2)
			{
				Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[curr - 1]}, {displayNames[curr]} has been created and will be saved shortly.");
				filesToSendBack.Add(baseImage);
			}
			else if (leftover == 3)
			{
				Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[curr - 2]}, {displayNames[curr - 1]}, {displayNames[curr]} has been created and will be saved shortly.");
				filesToSendBack.Add(baseImage);
			}

			return filesToSendBack;
		}
	}
}