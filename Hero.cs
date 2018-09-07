// Daniel Morato Baudi.
using System;
using System.Collections.Generic;
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the character.
    /// </summary>
    class Hero : Character
    {
        #region Attributes
        private bool locked; // ... what was this???
        private HeroType type;
        #endregion

        #region Constructors
        /// <summary>
        /// Initiallizes a new empty Hero instance.
        /// </summary>
        public Hero() : base(){}

        /// <summary>
        /// Initiallizes a new Hero with name, job, image, type and lock.
        /// </summary>
        /// <param name="name">Hero's name.</param>
        /// <param name="chosenJob">Hero's job.</param>
        /// <param name="image">Hero's image.</param>
        /// <param name="type">Hero's type.</param>
        /// <param name="locked"></param>
        public Hero(string name, ChosenJob chosenJob,
            Image image, HeroType type, bool locked) :
            base(name, chosenJob, image)
        {
            this.type = type;
            this.locked = locked;
        }

        /// <summary>
        /// Initiallizes a new Hero with all parameters.
        /// </summary>
        /// <param name = "name" > Hero's name.</param>
        /// <param name="race">Hero's race.</param>
        /// <param name="chosenJob">Hero's job.</param>
        /// <param name="stats">Hero's stats.</param>
        /// <param name="level">Hero's level.</param>
        /// <param name="exp">Hero's amount of experience.</param>
        /// <param name="remainingMovements">Hero's amount of movements available.</param>
        /// <param name="inventory">List of items the character has in its inventory.</param>
        /// <param name="image">Hero's image.</param>
        /// <param name="type">Hero's type.</param>
        /// <param name="locked"></param>
        public Hero(string name, Breed race, ChosenJob chosenJob,
            Stats stats, int level, int exp, int remainingMovements,
            List<Item> items, Image image, HeroType type, bool locked) :
            base(name, race, chosenJob, stats, level, exp,
                 remainingMovements, items, image)
        {
            this.type = type;
            this.locked = locked;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Changes the type of the hero.
        /// </summary>
        public override void TurnInto<T>()
        {
            ChangeType<T>(this, typeof(T));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the locked status.
        /// </summary>
        public bool Locked
        {
            get { return locked;  }
            set { locked = value; }
        }

        /// <summary>
        /// Gets or sets the hero type.
        /// </summary>
        public HeroType Type
        {
            get { return type;  }
            set { type = value; }
        }
        #endregion
    }
}