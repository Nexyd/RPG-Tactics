// Daniel Morato Baudi.
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Provides the methods and attributes necessaries for the initial screen of the game.
    /// </summary>
    class MainMenu
    {
        #region Attributes
        private MenuOption option;
        private List<Image> screenTextures;
        private List<Image> configTextures;
        private List<Image> highlightConfig;
        public ConfigMenuImages[] ConfigToLoad { get; set; }
        public ConfigHighlightImages[] HighlightToLoad { get; set; }
        private Image cursors;
        private int actualImage;
        private int actualHighlight;
        private Vector2[] configPositions;
        private bool active;
        private bool changeResolution;

        private const int SCREEN_SIZE = 4;
        private const int CONFIG_SIZE = 17;
        private const int SCREEN_WIDTH  = 544;
        private const int SCREEN_HEIGHT = 544;
        #endregion

        #region Constructor
        /// <summary>
        /// Initiallizes an instance of the MainMenu class with its screen image.
        /// </summary>
        public MainMenu()
        {
            option = MenuOption.Play;
            screenTextures  = new List<Image>();
            configTextures  = new List<Image>();
            highlightConfig = new List<Image>();
            ConfigToLoad    = new ConfigMenuImages[CONFIG_SIZE];
            HighlightToLoad = new ConfigHighlightImages[CONFIG_SIZE];
            configPositions = new Vector2[CONFIG_SIZE];

            cursors = new Image();
            actualImage = 0;
            actualHighlight = 1;
            active = true;
            changeResolution = false;

            // Screen images.
            for (int i = 0; i < SCREEN_SIZE; i++)
                screenTextures.Add(new Image());

            // Config images.
            for (int i = 0; i < CONFIG_SIZE; i++)
                configTextures.Add(new Image());

            // Highlighted config images.
            for (int i = 0; i < CONFIG_SIZE; i++)
                highlightConfig.Add(new Image());

            highlightConfig[1].Highlighted = true;
            ConfigTextures[3].Visible = false;
            ConfigTextures[7].Visible = false;
            ConfigTextures[8].Visible = false;

            #region Config Preparations
            // Config images.
            ConfigToLoad[0]  = ConfigMenuImages.SoundSlideBar;
            ConfigToLoad[1]  = ConfigMenuImages.SoundPointer;
            ConfigToLoad[2]  = ConfigMenuImages.SoundEnabled;
            ConfigToLoad[3]  = ConfigMenuImages.SoundDisabled;
            ConfigToLoad[4]  = ConfigMenuImages.SoundSlideBar;
            ConfigToLoad[5]  = ConfigMenuImages.SoundPointer;
            ConfigToLoad[6]  = ConfigMenuImages.SoundEnabled;
            ConfigToLoad[7]  = ConfigMenuImages.SoundDisabled;
            ConfigToLoad[8]  = ConfigMenuImages.MiniMapEnabled;
            ConfigToLoad[9]  = ConfigMenuImages.MiniMapDisabled;
            ConfigToLoad[10] = ConfigMenuImages.SpeedNormal;
            ConfigToLoad[11] = ConfigMenuImages.SpeedFast;
            ConfigToLoad[12] = ConfigMenuImages.SpeedMax;
            ConfigToLoad[13] = ConfigMenuImages.SpeedNormal;
            ConfigToLoad[14] = ConfigMenuImages.SpeedFast;
            ConfigToLoad[15] = ConfigMenuImages.SpeedMax;
            ConfigToLoad[16] = ConfigMenuImages.RestoreDefault;

            HighlightToLoad[0]  = ConfigHighlightImages.SoundSlideBar;
            HighlightToLoad[1]  = ConfigHighlightImages.SoundPointer;
            HighlightToLoad[2]  = ConfigHighlightImages.SoundEnabled;
            HighlightToLoad[3]  = ConfigHighlightImages.SoundDisabled;
            HighlightToLoad[4]  = ConfigHighlightImages.SoundSlideBar;
            HighlightToLoad[5]  = ConfigHighlightImages.SoundPointer;
            HighlightToLoad[6]  = ConfigHighlightImages.SoundEnabled;
            HighlightToLoad[7]  = ConfigHighlightImages.SoundDisabled;
            HighlightToLoad[8]  = ConfigHighlightImages.MiniMapEnabled;
            HighlightToLoad[9]  = ConfigHighlightImages.MiniMapDisabled;
            HighlightToLoad[10] = ConfigHighlightImages.SpeedNormal;
            HighlightToLoad[11] = ConfigHighlightImages.SpeedFast;
            HighlightToLoad[12] = ConfigHighlightImages.SpeedMax;
            HighlightToLoad[13] = ConfigHighlightImages.SpeedNormal;
            HighlightToLoad[14] = ConfigHighlightImages.SpeedFast;
            HighlightToLoad[15] = ConfigHighlightImages.SpeedMax;
            HighlightToLoad[16] = ConfigHighlightImages.RestoreDefault;

            // Configuration image's positions.
            configPositions[0]  = new Vector2(110, 105); // SoundSlideBar;
            configPositions[1]  = new Vector2(200, 106); // SoundPointer;
            configPositions[2]  = new Vector2(315, 080); // SoundEnabled;
            configPositions[3]  = new Vector2(315, 080); // SoundDisabled;
            configPositions[4]  = new Vector2(110, 164); // SoundSlideBar;
            configPositions[5]  = new Vector2(200, 165); // SoundPointer;
            configPositions[6]  = new Vector2(315, 140); // SoundEnabled;
            configPositions[7]  = new Vector2(315, 140); // SoundDisabled;
            configPositions[8]  = new Vector2(315, 205); // MiniMapEnabled;
            configPositions[9]  = new Vector2(315, 205); // MiniMapDisabled;
            configPositions[10] = new Vector2(190, 265); // SpeedNormal;
            configPositions[11] = new Vector2(310, 265); // SpeedFast;
            configPositions[12] = new Vector2(380, 265); // SpeedMax;
            configPositions[13] = new Vector2(190, 325); // SpeedNormal;
            configPositions[14] = new Vector2(310, 325); // SpeedFast;
            configPositions[15] = new Vector2(380, 325); // SpeedMax;
            configPositions[16] = new Vector2(012, 375); // RestoreDefault;
            #endregion
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            active = false;
            changeResolution = true;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the menu's screen width.
        /// </summary>
        public int WIDTH
        {
            get { return SCREEN_WIDTH; }
        }

        /// <summary>
        /// Returns the menu's screen height.
        /// </summary>
        public int HEIGHT
        {
            get { return SCREEN_HEIGHT; }
        }

        /// <summary>
        /// Gets or sets the chosen menu option.
        /// </summary>
        public MenuOption Option
        {
            get { return option;  }
            set { option = value; }
        }

        /// <summary>
        /// Gets or sets the screen textures list.
        /// </summary>
        public List<Image> ScreenTextures
        {
            get { return screenTextures;          }
            set { screenTextures.AddRange(value); }
        }

        /// <summary>
        /// Gets or sets the config textures list.
        /// </summary>
        public List<Image> ConfigTextures
        {
            get { return configTextures;          }
            set { configTextures.AddRange(value); }
        }

        /// <summary>
        /// Gets or sets the highlighted config textures list..
        /// </summary>
        public List<Image> HighlightedConfig
        {
            get { return highlightConfig;          }
            set { highlightConfig.AddRange(value); }
        }

        /// <summary>
        /// Gets or sets the cursors frame image.
        /// </summary>
        public Image Cursors
        {
            get { return cursors;  }
            set { cursors = value; }
        }

        /// <summary>
        /// Gets or sets the actual image displaying.
        /// </summary>
        public int ActualImage
        {
            get { return actualImage;  }
            set { actualImage = value; }
        }

        /// <summary>
        /// Gets or sets the actual highlighted image index.
        /// </summary>
        public int ActualHighlight
        {
            get { return actualHighlight;  }
            set { actualHighlight = value; }
        }

        /// <summary>
        /// Gets or sets the config positions list.
        /// </summary>
        public Vector2[] ConfigPositions
        {
            get { return configPositions; }
            set {
                for (int i = 0; i < value.Length; i++)
                    configPositions[i] = value[i];
            }
        }

        /// <summary>
        /// Gets or sets the actual screen display status.
        /// </summary>
        public bool Active
        {
            get { return active;  }
            set { active = value; }
        }

        /// <summary>
        /// Gets or sets the actual screen resolution changing status.
        /// </summary>
        public bool ResolutionActive
        {
            get { return changeResolution;  }
            set { changeResolution = value; }
        }
        #endregion
    }
}