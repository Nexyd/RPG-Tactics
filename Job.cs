// Daniel Morato Baudi.
using System.Collections.Generic;
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides the different capacities of each job.
    /// </summary>
    class Job
    {
        #region Attributes
        private ChosenJob chosen;
        private PrimaryAttribute primaryStat;
        private Stats baseStats;
        private List<string> weapons;
        #endregion

        #region Constructors
        // Parameterized constructor with chosen job.
        /// <summary>
        /// Initiallizes an instance of the Job class with just the chosen job.
        /// </summary>
        /// <param name="chosen">Chosen job.</param>
        public Job(ChosenJob chosen)
        {
            this.chosen = chosen;   
            primaryStat = PrimaryAttribute.Unassigned;
            baseStats = new Stats();
            weapons = new List<string>();
        }

        // Parameterized constructor with all parameters.
        /// <summary>
        /// Initiallizes an instance of the Job class with all the parameters.
        /// </summary>
        /// <param name="chosen">Chosen job.</param>
        /// <param name="primaryStat">Job's primary stat.</param>
        /// <param name="baseStats">Job's base stats.</param>
        /// <param name="weapons">Job's list of weapons available.</param>
        public Job(ChosenJob chosen, PrimaryAttribute primaryStat, 
                   Stats baseStats, List<string> weapons)
        {
            this.chosen = chosen;
            this.primaryStat = primaryStat;

            this.baseStats.Strength  = baseStats.Strength;
            this.baseStats.Stamina   = baseStats.Stamina;
            this.baseStats.Agility   = baseStats.Agility;
            this.baseStats.Intelect  = baseStats.Intelect;
            this.baseStats.Defense   = baseStats.Defense;
            this.baseStats.Dexterity = baseStats.Dexterity;
            this.baseStats.Critical  = baseStats.Critical;

            this.weapons = new List<string>();
            foreach (string weapon in weapons)
                this.weapons.Add(weapon);
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the chosen job.
        /// </summary>
        public ChosenJob Chosen
        {
            get { return chosen;  }
            set { chosen = value; }
        }

        /// <summary>
        /// Gets or sets the primary stat.
        /// </summary>
        public PrimaryAttribute PrimaryStat
        {
            get { return primaryStat;  }
            set { primaryStat = value; }
        }

        /// <summary>
        /// Gets the base stats.
        /// </summary>
        public Stats Stats
        {
            get { return baseStats;  }
        }

        /// <summary>
        /// Gets the available weapons.
        /// </summary>
        public List<string> Weapons
        {
            get { return weapons; }
        }
        #endregion
    }
}