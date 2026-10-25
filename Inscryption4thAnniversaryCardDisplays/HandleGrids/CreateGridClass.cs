using Inscryption4thAnniversaryCardDisplays.Configuration;
using Inscryption4thAnniversaryCardDisplays.Helpers.Loggers;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Transforms;
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
		/// <param name="config">The config in which will be used to fetch the font.</param>
		/// <returns>A list of Images to save.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static List<Image<Rgba32>> CreateGrids(Dictionary<string, Image<Rgba32>> grids, List<string> displayNames, Config config)
		{
			List<Image<Rgba32>> filesToSendBack = new List<Image<Rgba32>>();
			MemoryStream fontStream = new MemoryStream();
			if (config.FontFile != null)
				fontStream = new(config.FontFile);
			else
			{
				byte[] fontBytes = File.ReadAllBytes(config.FontLocal);
				fontStream = new MemoryStream(fontBytes);
			}

			FontCollection collection = new();
			FontFamily family = collection.Add(fontStream);
			Font contestSize = family.CreateFont(config.EventNameSize, FontStyle.Regular);
			
			RichTextOptions optionsContest = new RichTextOptions(contestSize)
			{
				HorizontalAlignment = config.HorizontalAlignment,
				VerticalAlignment = VerticalAlignment.Center,
				Origin = config.TextPosition,
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
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(80, 340), 1.0f);
						img.DrawText(optionsContest, config.ContestName, config.TextColor);
					});
				}
				else if (iterator % 4 == 2)
				{
					baseImage.Mutate(img =>
					{
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(2000, 340), 1.0f);
					});
				}
				else if (iterator % 4 == 3)
				{
					baseImage.Mutate(img =>
					{
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(80, 1420), 1.0f);
					});
				}
				else if (iterator % 4 == 0)
				{
					baseImage.Mutate(img =>
					{
						img.DrawImage(grids[displayNames[iterator - 1]], new Point(2000, 1420), 1.0f);
					});
					
					if (config.CharityContest == true)
					{
						Image<Rgba32> stJude = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St.Judes.png"));
						Image<Rgba32> QR = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Inscryption 4 Year Anniversary Fundraiser-donate-qr-8c879829-e6be-4564-bb06-2ca0aec7aade (1).png"));
						Image<Rgba32> AnniversaryLogo = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\4thAnniversaryLogo.png"));
						Image<Rgba32> DMG = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\DMG.png"));
						Image<Rgba32> STJudeText = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St-Judes-Name.png"));
						Image<Rgba32> Fanscryption = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Fanscryption.png"));
						baseImage.Mutate(img =>
						{
							img.Resize(8000, 5000, new NearestNeighborResampler());
							img.DrawImage(stJude, new Point(3701, 2398), 1.0f);
							img.DrawImage(QR, new Point(3750, 2782), 1.0f);
							img.DrawImage(AnniversaryLogo, new Point(2422, 2), 1.0f);
							img.DrawImage(STJudeText, new Point(4566, 2), 1.0f);
							img.DrawImage(DMG, new Point(2, 2), 1.0f);
							img.DrawImage(Fanscryption, new Point(7194, 2), 1.0f);
							img.Resize(4000, 2500, new TriangleResampler());
						});
					}
					
					Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[iterator - 4]}, {displayNames[iterator - 3]}, {displayNames[iterator - 2]}, {displayNames[iterator - 1]} has been created and will be saved shortly.");
					filesToSendBack.Add(baseImage);
					baseImage = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\backgroundBase.png"));
				}
			}

			int leftover = grids.Count % 4;

			if (leftover == 1)
			{
				if (config.CharityContest == true)
				{
					Image<Rgba32> stJude = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St.Judes.png"));
					Image<Rgba32> QR = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Inscryption 4 Year Anniversary Fundraiser-donate-qr-8c879829-e6be-4564-bb06-2ca0aec7aade (1).png"));
					Image<Rgba32> AnniversaryLogo = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\4thAnniversaryLogo.png"));
					Image<Rgba32> DMG = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\DMG.png"));
					Image<Rgba32> STJudeText = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St-Judes-Name.png"));
					Image<Rgba32> Fanscryption = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Fanscryption.png"));
					baseImage.Mutate(img =>
					{
						img.Resize(8000, 5000, new NearestNeighborResampler());
						img.DrawImage(stJude, new Point(3701, 2398), 1.0f);
						img.DrawImage(QR, new Point(3750, 2782), 1.0f);
						img.DrawImage(AnniversaryLogo, new Point(2422, 2), 1.0f);
						img.DrawImage(STJudeText, new Point(4566, 2), 1.0f);
						img.DrawImage(DMG, new Point(2, 2), 1.0f);
						img.DrawImage(Fanscryption, new Point(7194, 2), 1.0f);
						img.Resize(4000, 2500, new TriangleResampler());
					});
				}
				Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[curr]} has been created and will be saved shortly.");
				filesToSendBack.Add(baseImage);
			}
			else if (leftover == 2)
			{
				if (config.CharityContest == true)
				{
					Image<Rgba32> stJude = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St.Judes.png"));
					Image<Rgba32> QR = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Inscryption 4 Year Anniversary Fundraiser-donate-qr-8c879829-e6be-4564-bb06-2ca0aec7aade (1).png"));
					Image<Rgba32> AnniversaryLogo = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\4thAnniversaryLogo.png"));
					Image<Rgba32> DMG = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\DMG.png"));
					Image<Rgba32> STJudeText = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St-Judes-Name.png"));
					Image<Rgba32> Fanscryption = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Fanscryption.png"));
					baseImage.Mutate(img =>
					{
						img.Resize(8000, 5000, new NearestNeighborResampler());
						img.DrawImage(stJude, new Point(3701, 2398), 1.0f);
						img.DrawImage(QR, new Point(3750, 2782), 1.0f);
						img.DrawImage(AnniversaryLogo, new Point(2422, 2), 1.0f);
						img.DrawImage(STJudeText, new Point(4566, 2), 1.0f);
						img.DrawImage(DMG, new Point(2, 2), 1.0f);
						img.DrawImage(Fanscryption, new Point(7194, 2), 1.0f);
						img.Resize(4000, 2500, new TriangleResampler());
					});
				}
				Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[curr - 1]}, {displayNames[curr]} has been created and will be saved shortly.");
				filesToSendBack.Add(baseImage);
			}
			else if (leftover == 3)
			{
				if (config.CharityContest == true)
				{
					Image<Rgba32> stJude = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St.Judes.png"));
					Image<Rgba32> QR = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Inscryption 4 Year Anniversary Fundraiser-donate-qr-8c879829-e6be-4564-bb06-2ca0aec7aade (1).png"));
					Image<Rgba32> AnniversaryLogo = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\4thAnniversaryLogo.png"));
					Image<Rgba32> DMG = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\DMG.png"));
					Image<Rgba32> STJudeText = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\St-Judes-Name.png"));
					Image<Rgba32> Fanscryption = Image.Load<Rgba32>(Path.Combine(DLLPath + "\\Icons\\Fanscryption.png"));
					baseImage.Mutate(img =>
					{
						img.Resize(8000, 5000, new NearestNeighborResampler());
						img.DrawImage(stJude, new Point(3701, 2398), 1.0f);
						img.DrawImage(QR, new Point(3750, 2782), 1.0f);
						img.DrawImage(AnniversaryLogo, new Point(2422, 2), 1.0f);
						img.DrawImage(STJudeText, new Point(4566, 2), 1.0f);
						img.DrawImage(DMG, new Point(2, 2), 1.0f);
						img.DrawImage(Fanscryption, new Point(7194, 2), 1.0f);
						img.Resize(4000, 2500, new TriangleResampler());
					});
				}
				Logging.Log("CreateGrids", "Info", $"Grid for {displayNames[curr - 2]}, {displayNames[curr - 1]}, {displayNames[curr]} has been created and will be saved shortly.");
				filesToSendBack.Add(baseImage);
			}
			
			return filesToSendBack;
		}
	}
}