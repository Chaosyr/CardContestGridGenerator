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
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\MiniGrids");
		public static int fileCount = 0;
		
		/// <summary>
		/// Creates the grids for each DisplayName.
		/// </summary>
		/// <param name="displayNames">A list of the display names.</param>
		/// <param name="entrys">A dictionary of a display name associated with a list of entry's.</param>
		/// <param name="socials">A dictionary of the display name associated with their social(s).</param>
		/// <param name="config">The config in which will be used to fetch the font.</param>
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
				List<string> fileEntrys = entrys[displayName];
				if (config.FourGridDisplay == false)
				{
					int entryNum = (entrys[displayName].Count <= 3 ? entrys[displayName].Count : 3);
					image.Mutate<Rgba32>(img =>
					{
						img.DrawText(optionsDisplayName, displayName, config.TextColor);
						img.DrawText(optionsSocials, socials[displayName].Replace("N/A", ""), config.TextColor);

						Image<Rgba32> entry1 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
						Image<Rgba32> entry2 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
						Image<Rgba32> entry3 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
						bool entry1Boss = false;
						bool entry2Boss = false;
						bool entry3Boss = false;
						float bossRatio = 766f / 533f;

						if (entryNum == 1)
						{
							entry1 = Image.Load<Rgba32>(fileEntrys[0]);
							float entry1ratio = (float)entry1.Width / entry1.Height;
							if (Math.Abs(entry1ratio - bossRatio) < 0.01f) {
								entry1Boss = true;
							}
						}
						else if (entryNum == 2)
						{
							entry1 = Image.Load<Rgba32>(fileEntrys[0]);
							float entry1ratio = (float)entry1.Width / entry1.Height;
							if (Math.Abs(entry1ratio - bossRatio) < 0.01f) {
								entry1Boss = true;
							}
							entry2 = Image.Load<Rgba32>(fileEntrys[1]);
							float entry2ratio = (float)entry2.Width / entry2.Height;
							if (Math.Abs(entry2ratio - bossRatio) < 0.01f) {
								entry2Boss = true;
							}
						}
						else if (entryNum == 3)
						{
							entry1 = Image.Load<Rgba32>(fileEntrys[0]);
							float entry1ratio = (float)entry1.Width / entry1.Height;
							if (Math.Abs(entry1ratio - bossRatio) < 0.01f) {
								entry1Boss = true;
							}
							entry2 = Image.Load<Rgba32>(fileEntrys[1]);
							float entry2ratio = (float)entry2.Width / entry2.Height;
							if (Math.Abs(entry2ratio - bossRatio) < 0.01f) {
								entry2Boss = true;
							}
							entry3 = Image.Load<Rgba32>(fileEntrys[2]);
							float entry3ratio = (float)entry3.Width / entry3.Height;
							if (Math.Abs(entry3ratio - bossRatio) < 0.01f) {
								entry3Boss = true;
							}
						}

						if (entryNum == 1)
						{
							entry1.Mutate(img2 =>
							{
								if (entry1Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							img.DrawImage(entry1, new Point((entry1Boss ? 753 - 176 : 753), (entry1Boss ? 251 + 23 : 251)), 1.0f);
						}
						else if (entryNum == 2)
						{
							entry1.Mutate(img2 =>
							{
								if (entry1Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry2.Mutate(img2 =>
							{
								if (entry2Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							img.DrawImage(entry1, new Point((entry1Boss ? 446 - 176 : 446), (entry1Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry2, new Point((entry2Boss ? 1061 - 176 : 1061), (entry2Boss ? 251 + 23 : 251)), 1.0f);
						}
						else if (entryNum == 3)
						{
							entry1.Mutate(img2 =>
							{
								if (entry1Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry2.Mutate(img2 =>
							{
								if (entry2Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry3.Mutate(img2 =>
							{
								if (entry3Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							img.DrawImage(entry1, new Point((entry1Boss ? 138 - 176 : 138), (entry1Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry2, new Point((entry2Boss ? 753 - 176 : 753), (entry2Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry3, new Point((entry3Boss ? 1368 - 176 : 1368), (entry3Boss ? 251 + 23 : 251)), 1.0f);
						}
					});
				} else if (config.FourGridDisplay == true) {
					int entryNum = (entrys[displayName].Count <= 4 ? entrys[displayName].Count : 4);
					image = new Image<Rgba32>(2535, 1080);
					image.Mutate<Rgba32>(img =>
					{
						Image<Rgba32> background = Image.Load<Rgba32>(Path.Combine(DLLPath, "MiniGridBG.png"));
						img.DrawImage(background, new Point(0, 0), 1.0f);
						
						optionsDisplayName.Origin = new PointF(1267, 124);
						optionsSocials.Origin = new PointF(1267, 957);
						img.DrawText(optionsDisplayName, displayName, config.TextColor);
						img.DrawText(optionsSocials, socials[displayName].Replace("N/A", ""), config.TextColor);

						Image<Rgba32> entry1 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
						Image<Rgba32> entry2 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
						Image<Rgba32> entry3 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
						Image<Rgba32> entry4 = Image.Load<Rgba32>(Path.Combine(DLLPath, "Grids-1.png"));
						bool entry1Boss = false;
						bool entry2Boss = false;
						bool entry3Boss = false;
						bool entry4Boss = false;
						float bossRatio = 832f / 579f;

						if (entryNum == 1)
						{
							entry1 = Image.Load<Rgba32>(fileEntrys[0]);
							float entry1ratio = (float)entry1.Width / entry1.Height;
							if (Math.Abs(entry1ratio - bossRatio) < 0.01f) {
								entry1Boss = true;
							}
						}
						else if (entryNum == 2)
						{
							entry1 = Image.Load<Rgba32>(fileEntrys[0]);
							float entry1ratio = (float)entry1.Width / entry1.Height;
							if (Math.Abs(entry1ratio - bossRatio) < 0.01f) {
								entry1Boss = true;
							}
							entry2 = Image.Load<Rgba32>(fileEntrys[1]);
							float entry2ratio = (float)entry2.Width / entry2.Height;
							if (Math.Abs(entry2ratio - bossRatio) < 0.01f) {
								entry2Boss = true;
							}
						}
						else if (entryNum == 3)
						{
							entry1 = Image.Load<Rgba32>(fileEntrys[0]);
							float entry1ratio = (float)entry1.Width / entry1.Height;
							if (Math.Abs(entry1ratio - bossRatio) < 0.01f) {
								entry1Boss = true;
							}
							entry2 = Image.Load<Rgba32>(fileEntrys[1]);
							float entry2ratio = (float)entry2.Width / entry2.Height;
							if (Math.Abs(entry2ratio - bossRatio) < 0.01f) {
								entry2Boss = true;
							}
							entry3 = Image.Load<Rgba32>(fileEntrys[2]);
							float entry3ratio = (float)entry3.Width / entry3.Height;
							if (Math.Abs(entry3ratio - bossRatio) < 0.01f) {
								entry3Boss = true;
							}
						}
						else if (entryNum == 4)
						{
							entry1 = Image.Load<Rgba32>(fileEntrys[0]);
							float entry1ratio = (float)entry1.Width / entry1.Height;
							if (Math.Abs(entry1ratio - bossRatio) < 0.01f) {
								entry1Boss = true;
							}
							entry2 = Image.Load<Rgba32>(fileEntrys[1]);
							float entry2ratio = (float)entry2.Width / entry2.Height;
							if (Math.Abs(entry2ratio - bossRatio) < 0.01f) {
								entry2Boss = true;
							}
							entry3 = Image.Load<Rgba32>(fileEntrys[2]);
							float entry3ratio = (float)entry3.Width / entry3.Height;
							if (Math.Abs(entry3ratio - bossRatio) < 0.01f) {
								entry3Boss = true;
							}
							entry4 = Image.Load<Rgba32>(fileEntrys[3]);
							float entry4ratio = (float)entry4.Width / entry4.Height;
							if (Math.Abs(entry4ratio - bossRatio) < 0.01f) {
								entry4Boss = true;
							}
						}

						if (entryNum == 1)
						{
							entry1.Mutate(img2 =>
							{
								if (entry1Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							img.DrawImage(entry1, new Point((entry1Boss ? 1060 - 176 : 1060), (entry1Boss ? 251 + 23 : 251)), 1.0f);
						}
						else if (entryNum == 2)
						{
							entry1.Mutate(img2 =>
							{
								if (entry1Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry2.Mutate(img2 =>
							{
								if (entry2Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							img.DrawImage(entry1, new Point((entry1Boss ? 753 - 176 : 753), (entry1Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry2, new Point((entry2Boss ? 1368 - 176 : 1368), (entry2Boss ? 251 + 23 : 251)), 1.0f);
						}
						else if (entryNum == 3)
						{
							entry1.Mutate(img2 =>
							{
								if (entry1Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry2.Mutate(img2 =>
							{
								if (entry2Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry3.Mutate(img2 =>
							{
								if (entry3Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							img.DrawImage(entry1, new Point((entry1Boss ? 445 - 176 : 445), (entry1Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry2, new Point((entry2Boss ? 1060 - 176 : 1060), (entry2Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry3, new Point((entry3Boss ? 1675 - 176 : 1675), (entry3Boss ? 251 + 23 : 251)), 1.0f);
						} else if (entryNum == 4)
						{
							entry1.Mutate(img2 =>
							{
								if (entry1Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry2.Mutate(img2 =>
							{
								if (entry2Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							entry3.Mutate(img2 =>
							{
								if (entry3Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});
							
							entry4.Mutate(img2 =>
							{
								if (entry4Boss) {
									img2.Resize(766, 533, new TriangleResampler());
								}
								else {
									img2.Resize(414, 579, new TriangleResampler());
								}
							});

							img.DrawImage(entry1, new Point((entry1Boss ? 138 - 176 : 138), (entry1Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry2, new Point((entry2Boss ? 753 - 176 : 753), (entry2Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry3, new Point((entry3Boss ? 1368 - 176 : 1368), (entry3Boss ? 251 + 23 : 251)), 1.0f);
							img.DrawImage(entry4, new Point((entry4Boss ? 1983 - 176 : 1983), (entry4Boss ? 251 + 23 : 251)), 1.0f);
						}
					});
				}

				Logging.Log("DefineGrid", "Info", $"Added Grid For; {displayName}");
				if (config.SingularDisplay) {
					image.SaveAsPng(Path.Combine(FolderRootPath + $"\\image_{fileCount}.png"));
				}
				filesToSendBack.Add(displayName, image.Clone());
				image.Dispose();
				fileCount++;
			}
			return filesToSendBack;
		}
	}
}