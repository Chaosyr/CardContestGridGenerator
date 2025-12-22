using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Inscryption4thAnniversaryCardDisplays.Configuration
{
	/// <summary>
	/// An Object in which resembles the applications config.
	/// </summary>
	/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
	public class Config
	{
		public string ContestName { get; set; }
		public HorizontalAlignment HorizontalAlignment { get; set; }
		public Rgba32 TextColor { get; set; }
		public PointF TextPosition { get; set; }
		public byte[] fontFile { get; set; }
		public int DisplayNameSize { get; set; }
		public int SocialNameSize { get; set; }
		public int EventNameSize  { get; set; }
		public bool CharityContest { get; set; }
        public bool SingularDisplay { get; set; }
        public bool FourGridDisplay { get; set; }

		/// <summary>
		/// Sets up the config
		/// </summary>
		/// <param name="contestName">The name of the contest in which to show on the grid.</param>
		/// <param name="horizontalAlignment">This can be set to Right/Left/Center and will determine the contest name allignment to the grid.</param>
		/// <param name="r">The red value of the color.</param>
		/// <param name="g">The green value of the color.</param>
		/// <param name="b">The blue value of the color.</param>
		/// <param name="a">The alpha value of the color.</param>
		/// <param name="width">The X coordinate of the Contest Names position.</param>
		/// <param name="height">The Y coordinate of the Contest Names position.</param>
		/// <param name="fontUrl">The fonts URL</param>
		/// <param name="httpClient">The HTTPClient in which will be used to load the font.</param>
		/// <param name="displayNameSize">The font size for the displayed names.</param>
		/// <param name="socialNameSize">The font size for the socials.</param>
		/// <param name="eventNameSize">The font size of the Contest Name.</param>
		/// <param name="charity">A bool resembling whether the contest images should show 4th year anniversary logos</param>
		/// <param name="miniGrids">A bool resembling whether the contest images should display just the minigrid rather than the mega grids, this will stop the rest from happening to only save minigrids</param>
		/// <param name="fourGrids">A bool resembling whether the contest images should be of 4 entries, this goes with `miniGrids` only in present</param>
		/// <returns>A setup config.</returns>
		/// This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.
		public Config(string contestName, string horizontalAlignment, int r, int g, int b, int a, int width, int height, string fontUrl, HttpClient httpClient, int displayNameSize, int socialNameSize, int eventNameSize, bool charity = false, bool miniGrids = false, bool fourGrids = false)
		{
			ContestName = contestName;
			if (horizontalAlignment == "Right")
				HorizontalAlignment = HorizontalAlignment.Right;
			else if (horizontalAlignment == "Left")
				HorizontalAlignment = HorizontalAlignment.Left;
			else if (horizontalAlignment == "Center")
				HorizontalAlignment = HorizontalAlignment.Center;
			TextColor = new Rgba32(r, g, b, a);
			TextPosition = new PointF(width, height);
			fontFile = httpClient.GetByteArrayAsync(fontUrl).Result;
			DisplayNameSize = displayNameSize;
			SocialNameSize = socialNameSize;
			EventNameSize = eventNameSize;
			CharityContest = charity;
			SingularDisplay = miniGrids;
			FourGridDisplay = fourGrids;
		}
	}
}