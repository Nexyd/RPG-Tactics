// Daniel Morato Baudi.
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the miscellaneous items, inherits from Item.
    /// </summary>
    class MiscItem : Item
    {
        #region Attributes
        private string description;
        private bool usable;
        private ItemUses use;
        private int duration;
        private bool keyItem;
        private int maxStack;
        #endregion

        #region Constructors
        // Empty constructor
        /// <summary>
        /// Initiallizes a new empty MiscItem instance.
        /// </summary>
        public MiscItem() : base()
        {
            description = "";
            usable = false;
            use = ItemUses.Unusable;
            duration = 0;
            keyItem = false;
            maxStack = 0;
        }

        // Parameterized constructor
        /// <summary>
        /// Initializes an instance of the MiscItem class with all the parameters.
        /// </summary>
        /// <param name="name">MiscItem's name.</param>
        /// <param name="type">MiscItem's type.</param>
        /// <param name="requiredLevel">MiscItem's required level.</param>
        /// <param name="requiredJob">MiscItem's required job.</param>
        /// <param name="description">MiscItem's description.</param>
        /// <param name="usable">MiscItem's usable status.</param>
        /// <param name="use">MiscItem's use.</param>
        /// <param name="duration">MiscItem's duration.</param>
        /// <param name="keyItem">MiscItem's key item status.</param>
        /// <param name="maxStack">MiscItem's max stack.</param>
        public MiscItem(string name, ItemType type, int requiredLevel,
                        RequiresJob requiredJob, string description,
                        bool usable, ItemUses use, int duration,
                        bool keyItem, int maxStack) : base(
                        name, type, requiredLevel, requiredJob)
        {
            this.description = description;
            this.usable = usable;
            this.use = usable ? use : ItemUses.Unusable;
            this.duration = usable ? duration : 0;
            this.keyItem = false;
            this.maxStack = 0;
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get { return description;  }
            set { description = value; }
        }

        /// <summary>
        /// Gets or sets the usable status.
        /// </summary>
        public bool Usable
        {
            get { return usable;  }
            set { usable = value; }
        }

        /// <summary>
        /// Gets or sets the use.
        /// </summary>
        public ItemUses Use
        {
            get { return use;  }
            set { use = value; }
        }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public int Duration
        {
            get { return duration;  }
            set { duration = value; }
        }

        /// <summary>
        /// Gets or sets the key item status.
        /// </summary>
        public bool KeyItem
        {
            get { return keyItem;  }
            set { keyItem = value; }
        }

        /// <summary>
        /// Gets or sets the max stacks.
        /// </summary>
        public int MaxStacks
        {
            get { return maxStack;  }
            set { maxStack = value; }
        }
        #endregion
    }
}