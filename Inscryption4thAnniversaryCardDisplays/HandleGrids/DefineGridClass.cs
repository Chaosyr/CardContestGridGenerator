using Inscryption4thAnniversaryCardDisplays.Configuration;
using Inscryption4thAnniversaryCardDisplays.Helpers;
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
	public class DefineGridClass
	{
		public static Assembly Assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(Assembly.Location);
		
		/// <summary>
		/// Creates the grids for each DisplayName.
		/// </summary>
		/// <param name="displayNames">A list of the display names.</param>
		/// <param name="entrys">A dictionary of a display name associated with a list of entry's.</param>
		/// <param name="socials">A dictionary of the display name associated with their social(s).</param>
		/// <param name="httpClient">The HttpClient in which the Font will be fetched from.</param>
		/// <returns>Saved Grids</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public static Dictionary<string, Image<Rgba32>> DefineGrids(List<string> displayNames, Dictionary<string, List<string>> entrys, Dictionary<string, string> socials, Config config)
		{
			Dictionary<string, Image<Rgba32>> filesToSendBack = new Dictionary<string, Image<Rgba32>>();

			MemoryStream fontStream = new(config.fontFile);

			FontCollection collection = new();
			FontFamily family = collection.Add(fontStream);
			Font displayNameSize = family.CreateFont(config.DisplayNameSize, FontStyle.Regular);
			Font socialSize = family.CreateFont(config.SocialNameSize, FontStyle.Regular);

			RichTextOptions optionsDisplayName = new(displayNameSize)
			{
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center,
				TextAlignment = TextAlignment.Center,
				Origin = new PointF(951, 124),
			};

			RichTextOptions optionsSocials = new(socialSize)
			{
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center,
				TextAlignment = TextAlignment.Center,
				Origin = new PointF(951, 957),
			};
			
			foreach (string displayName in displayNames) {
				Image<Rgba32> image = new Image<Rgba32>(1920, 1080);
				int entryNum = entrys[displayName].Count;
				
				image.Mutate(img =>
				{
					img.DrawText(optionsDisplayName, displayName, config.TextColor);
					img.DrawText(optionsSocials, socials[displayName].Replace("N/A", ""), config.TextColor);
					
					Image<Rgba32> entry1 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
					Image<Rgba32> entry2 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
					Image<Rgba32> entry3 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
					
					if (entryNum == 1)
					{
						entry1 = Image.Load<Rgba32>(Path.Combine(ReadFoldersClass.FolderRootPath + $"\\{displayName.Replace('/', '$')}" + "\\Entry_1.png"));
					} else if (entryNum == 2)
					{
						entry1 = Image.Load<Rgba32>(Path.Combine(ReadFoldersClass.FolderRootPath + $"\\{displayName.Replace('/', '$')}" + "\\Entry_1.png"));
						entry2 = Image.Load<Rgba32>(Path.Combine(ReadFoldersClass.FolderRootPath + $"\\{displayName.Replace('/', '$')}" + "\\Entry_2.png"));
					} else if (entryNum == 3)
					{
						entry1 = Image.Load<Rgba32>(Path.Combine(ReadFoldersClass.FolderRootPath + $"\\{displayName.Replace('/', '$')}" + "\\Entry_1.png"));
						entry2 = Image.Load<Rgba32>(Path.Combine(ReadFoldersClass.FolderRootPath + $"\\{displayName.Replace('/', '$')}" + "\\Entry_2.png"));
						entry3 = Image.Load<Rgba32>(Path.Combine(ReadFoldersClass.FolderRootPath + $"\\{displayName.Replace('/', '$')}" + "\\Entry_3.png"));
					}

					if (entryNum == 1)
					{
						entry1.Mutate(img2 =>
						{
							img2.Resize(414, 579, new TriangleResampler());
						});
						
						img.DrawImage(entry1, new Point(753, 251), 1.0f);
					} else if (entryNum == 2)
					{
						entry1.Mutate(img2 =>
						{
							img2.Resize(414, 579, new TriangleResampler());
						});
						
						entry2.Mutate(img2 =>
						{
							img2.Resize(414, 579, new TriangleResampler());
						});
						
						img.DrawImage(entry1, new Point(446, 251), 1.0f);
						img.DrawImage(entry2, new Point(1061, 251), 1.0f);
					} else if (entryNum == 3)
					{
						entry1.Mutate(img2 =>
						{
							img2.Resize(414, 579, new TriangleResampler());
						});
						
						entry2.Mutate(img2 =>
						{
							img2.Resize(414, 579, new TriangleResampler());
						});
						
						entry3.Mutate(img2 =>
						{
							img2.Resize(414, 579, new TriangleResampler());
						});
						
						img.DrawImage(entry1, new Point(138, 251), 1.0f);
						img.DrawImage(entry2, new Point(753, 251), 1.0f);
						img.DrawImage(entry3, new Point(1368, 251), 1.0f);
					}
				});
				
				Logging.Log("DefineGrid", "Info", $"Added Grid For; {displayName}");
				filesToSendBack.Add(displayName, image.Clone());
				image.Dispose();
			}
			return filesToSendBack;
		}
	}
}