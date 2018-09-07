// Daniel Morato Baudi.
using System.Collections.Generic;
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the Neutral Characters.
    /// </summary>
    class NeutralCharacter : Character
    {
        #region Attributes
        private NeutralType type;
        #endregion

        #region Constructors
        /// <summary>
        /// Initiallizes a new empty NeutralCharacter instance.
        /// </summary>
        public NeutralCharacter() : base(){}

        /// <summary>
        /// Initiallizes a new NeutralCharacter with name, job, image.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="chosenJob"></param>
        /// <param name="image"></param>
        public NeutralCharacter(string name, ChosenJob chosenJob,
            Image image) : base(name, chosenJob, image) {}

        /// <summary>
        /// Initiallizes a new NeutralCharacter with all parameters.
        /// </summary>
        /// <param name = "name" > NeutralCharacter's name.</param>
        /// <param name="race">NeutralCharacter's race.</param>
        /// <param name="chosenJob">NeutralCharacter's job.</param>
        /// <param name="stats">NeutralCharacter's stats.</param>
        /// <param name="level">NeutralCharacter's level.</param>
        /// <param name="exp">NeutralCharacter's amount of experience.</param>
        /// <param name="remainingMovements">NeutralCharacter's amount of movements available.</param>
        /// <param name="inventory">List of items the character has in its inventory.</param>
        /// <param name="image">NeutralCharacter's image.</param>
        /// <param name="type">NeutralCharacter's type.</param>
        public NeutralCharacter(string name, Breed race, ChosenJob chosenJob,
            Stats stats, int level, int exp, int remainingMovements,
            List<Item> items, Image image, NeutralType type) :
            base(name, race, chosenJob, stats, level, exp,
            remainingMovements, items, image)
        {
            this.type = type;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Changes the type of the character.
        /// </summary>
        public override void TurnInto<T>()
        {
            ChangeType<T>(this, typeof(T));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the character type.
        /// </summary>
        public NeutralType Type
        {
            get { return type;  }
            set { type = value; }
        }
        #endregion
    }
}