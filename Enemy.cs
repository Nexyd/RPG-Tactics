// Daniel Morato Baudi.
using System.Collections.Generic;
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the enemy.
    /// </summary>
    class Enemy : Character
    {
        #region Attributes
        private EnemyType type;
        #endregion

        #region Constructors
        /// <summary>
        /// Initiallizes a new empty Enemy instance.
        /// </summary>
        public Enemy() : base(){}

        /// <summary>
        /// Initiallizes a new Enemy with name, job, image and type.
        /// </summary>
        /// <param name="name">Enemy's name.</param>
        /// <param name="chosenJob">Enemy's job.</param>
        /// <param name="image">Enemy's image.</param>
        /// <param name="type">Enemy's type.</param>
        public Enemy(string name, ChosenJob chosenJob,
                     Image image, EnemyType type) :
                     base(name, chosenJob, image)
        {
            this.type = type;
        }

        /// <summary>
        /// Initiallizes a new Enemy with all parameters.
        /// </summary>
        /// <param name = "name" > Enemy's name.</param>
        /// <param name="race">Enemy's race.</param>
        /// <param name="chosenJob">Enemy's job.</param>
        /// <param name="stats">Enemy's stats.</param>
        /// <param name="level">Enemy's level.</param>
        /// <param name="exp">Enemy's amount of experience.</param>
        /// <param name="remainingMovements">Enemy's amount of movements available.</param>
        /// <param name="inventory">List of items the character has in its inventory.</param>
        /// <param name="image">Enemy's image.</param>
        /// <param name="type">Enemy's type.</param>
        public Enemy(string name, Breed race, ChosenJob chosenJob,
            Stats stats, int level, int exp, int remainingMovements,
            List<Item> items, Image image, EnemyType type) :
            base(name, race, chosenJob, stats, level, exp,
            remainingMovements, items, image)
        {
            this.type = type;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Changes the type of the enemy.
        /// </summary>
        public override void TurnInto<T>()
        {
            ChangeType<T>(this, typeof(T));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the enemy type.
        /// </summary>
        public EnemyType Type
        {
            get { return type;  }
            set { type = value; }
        }
        #endregion
    }
}