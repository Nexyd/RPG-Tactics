// Daniel Morato Baudi.
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the weapons, inherits from Item.
    /// </summary>
    class Weapon : Item
    {
        #region Attributes
        private int damage;
        private int durability;
        private Image image;
        #endregion

        #region Constructors
        // Empty constructor
        /// <summary>
        /// Initiallizes a new empty Weapon instance.
        /// </summary>
        public Weapon() : base()
        {
            damage = 0;
            durability = 0;
            image = new Image();
        }

        // Parameterized constructor
        /// <summary>
        /// Initializes an instance of the Weapon class with the default parameters.
        /// </summary>
        /// <param name="name">(String) Weapon's name.</param>
        /// <param name="type">(ItemType) Weapon's type.</param>
        /// <param name="requiredLevel">(Integer) Weapon's required level.</param>
        /// <param name="requiredJob">(RequiresJob) Weapon's required job.</param>
        /// <param name="damage">(Integer) Weapon's damage.</param>
        /// <param name="durability">(Integer) Weapon's durability.</param>
        public Weapon(string name, ItemType type,
                      int requiredLevel, RequiresJob requiredJob,
                      int damage, int durability) : base(
                      name, type,requiredLevel, requiredJob)
        {
            this.damage = damage;
            this.durability = durability;
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        public int Damage
        {
            get { return damage;  }
            set { damage = value; }
        }

        /// <summary>
        /// Gets or sets the durability.
        /// </summary>
        public int Durability
        {
            get { return durability;  }
            set { durability = value; }
        }
        #endregion
    }
}