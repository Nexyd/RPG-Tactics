// Daniel Morato Baudi.
namespace RPG_Tactics
{
    /// <summary>
    /// Provides the primary attribute types.
    /// </summary>
    class Stats
    {
        #region Attributes
        private int strength;
        private int stamina;
        private int agility;
        private int intelect;
        private int defense;
        private int dexterity;
        private int critical;
        #endregion

        #region Constructor
        /// <summary>
        /// Initiallizes an instance of the Stats class with no parameters.
        /// </summary>
        public Stats()
        {
            strength  = 0;
            stamina   = 0;
            agility   = 0;
            intelect  = 0;
            defense   = 0;
            dexterity = 0;
            critical  = 0;
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the strength.
        /// </summary>
        public int Strength
        {
            get { return strength;  }
            set { strength = value; }
        }

        /// <summary>
        /// Gets or sets the stamina.
        /// </summary>
        public int Stamina
        {
            get { return stamina;  }
            set { stamina = value; }
        }

        /// <summary>
        /// Gets or sets the agility.
        /// </summary>
        public int Agility
        {
            get { return agility;  }
            set { agility = value; }
        }

        /// <summary>
        /// Gets or sets the intelect.
        /// </summary>
        public int Intelect
        {
            get { return intelect;  }
            set { intelect = value; }
        }

        /// <summary>
        /// Gets or sets the defense.
        /// </summary>
        public int Defense
        {
            get { return defense;  }
            set { defense = value; }
        }

        /// <summary>
        /// Gets or sets the dexterity.
        /// </summary>
        public int Dexterity
        {
            get { return dexterity;  }
            set { dexterity = value; }
        }

        /// <summary>
        /// Gets or sets the critical.
        /// </summary>
        public int Critical
        {
            get { return critical;  }
            set { critical = value; }
        }
        #endregion
    }
}