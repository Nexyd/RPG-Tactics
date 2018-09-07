// Daniel Morato Baudi.
using System.Collections.Generic;
using XNA.Tiled.CollisionParser;
using Resources.Enums;

namespace RPG_Tactics
{
    class Level
    {
        #region Attributes
        private string title;
        private int number;
        private Image map;
        private List<Collider> colliders;
        private WinCondition condition;
        private TiledParser parser;
        private int amountEnemies = 0;
        #endregion

        #region Constructors
        /// <summary>
        /// Initiallizes a new empty Level.
        /// </summary>
        public Level()
        {
            title = "";
            number = 0;
            map = new Image();
            colliders = new List<Collider>();
            condition = WinCondition.Undefined;
            amountEnemies = 0;

            parser = new TiledParser();
        }

        /// <summary>
        /// Initiallizes a new Level with title, map and a win condition.
        /// </summary>
        /// <param name="title">Level's title.</param>
        /// <param name="file">Map's tmx file path.</param>
        /// <param name="condition">Winning condition.</param>
        public Level(string title, TMX file, WinCondition condition)
        {
            this.title = title;
            number = 0;
            map = new Image();
            this.condition = condition;

            parser = new TiledParser();
            string path = Enums.GetDescription<TMX>(file);

            if (path.EndsWith(".tmx"))
                colliders = parser.Parse(path);

            path = null;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reads a determined level's TMX file to get the colliders.
        /// </summary>
        /// <param name="file">TMX file path.</param>
        public void LoadColliders(TMX file)
        {
            string path = Enums.GetDescription<TMX>(file);

            if (path.EndsWith(".tmx"))
                colliders = parser.Parse(path);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get { return title;  }
            set { title = value; }
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number
        {
            get { return number;  }
            set { number = value; }
        }

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        public Image Map
        {
            get { return map;  }
            set { map = value; }
        }

        /// <summary>
        /// Gets or sets the winning condition.
        /// </summary>
        public WinCondition Condition
        {
            get { return condition;  }
            set { condition = value; }
        }

        /// <summary>
        /// Returns the number of enemies in the level.
        /// </summary>
        public int Enemies
        {
            get { return amountEnemies;  }
        }

        public List<Collider> Colliders
        {
            get { return colliders; }
        }
        #endregion
    }
}