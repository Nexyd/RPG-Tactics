// Daniel Morato Baudi.
using System.Collections.Generic;
using System.IO;

namespace RPG_Tactics
{
    /// <summary>
    /// Saves and loads the configuration.
    /// </summary>
    class Configuration
    {
        #region Enums
        /// <summary>
        /// Provides the speed of the text and game.
        /// </summary>
        public enum Speed
        {
            Normal,
            Fast,
            Max
        }
        #endregion

        #region Attributes
        private int musicVolume;
        private int soundVolume;
        private bool musicEnabled;
        private bool soundEnabled;
        private bool miniMapEnabled;
        private Speed gameSpeed;
        private Speed textSpeed;

        private StreamReader reader;
        private StreamWriter writer;
        private List<string> readData;
        #endregion

        #region Constructor
        /// <summary>
        /// Initiallizes an instance of the Configuration class.
        /// </summary>
        public Configuration()
        {
            musicVolume = 0;
            soundVolume = 0;
            musicEnabled = false;
            soundEnabled = false;
            miniMapEnabled = false;
            gameSpeed = Speed.Normal;
            textSpeed = Speed.Normal;

            reader = new StreamReader("settings.ini");
            writer = new StreamWriter("settings.ini");
            readData = new List<string>();
        }

        /// <summary>
        /// Initiallizes an instance of the Constructor class with all parameters.
        /// </summary>
        /// <param name="musicVolume">Music volume.</param>
        /// <param name="soundVolume">Sound volume.</param>
        /// <param name="musicEnabled">Music enable state.</param>
        /// <param name="soundEnabled">Sound enable state.</param>
        /// <param name="miniMapEnabled">Mini map enable state.</param>
        /// <param name="gameSpeed">Game speed.</param>
        /// <param name="textSpeed">Text speed.</param>
        public Configuration(int musicVolume, int soundVolume, bool musicEnabled,
                             bool soundEnabled, bool miniMapEnabled, Speed gameSpeed,
                             Speed textSpeed)
        {
            this.musicVolume = musicVolume;
            this.soundVolume = soundVolume;
            this.musicEnabled = musicEnabled;
            this.soundEnabled = soundEnabled;
            this.miniMapEnabled = miniMapEnabled;
            this.gameSpeed = gameSpeed;
            this.textSpeed = textSpeed;

            reader = new StreamReader("settings.ini");
            writer = new StreamWriter("settings.ini");
            readData = new List<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves the data to a file.
        /// </summary>
        public void SaveToFile()
        {
            foreach (string line in readData)
                writer.WriteLine(line);
        }

        /// <summary>
        /// Loads the data from a file.
        /// </summary>
        public void LoadFromFile()
        {
            string line = "";
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                    readData.Add(line);
            }

            ParseReadedData();
        }

        /// <summary>
        /// Parses the data readed from file.
        /// </summary>
        public void ParseReadedData()
        {
            // Parses readData to
            // stablish the attributes.
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the music volume.
        /// </summary>
        public int MusicVolume
        {
            get { return musicVolume; }
            set { musicVolume = value; }
        }

        /// <summary>
        /// Gets or sets the sound volume.
        /// </summary>
        public int SoundVolume
        {
            get { return soundVolume; }
            set { soundVolume = value; }
        }

        /// <summary>
        /// Gets or sets the music enable state.
        /// </summary>
        public bool MusicEnabled
        {
            get { return musicEnabled; }
            set { musicEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the sound enable state.
        /// </summary>
        public bool SoundEnabled
        {
            get { return soundEnabled; }
            set { soundEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the mini map enable state.
        /// </summary>
        public bool MiniMapEnabled
        {
            get { return miniMapEnabled; }
            set { miniMapEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the game speed.
        /// </summary>
        public Speed GameSpeed
        {
            get { return gameSpeed; }
            set { gameSpeed = value; }
        }

        /// <summary>
        /// Gets or sets the text speed.
        /// </summary>
        public Speed TextSpeed
        {
            get { return textSpeed; }
            set { textSpeed = value; }
        }
        #endregion
    }
}