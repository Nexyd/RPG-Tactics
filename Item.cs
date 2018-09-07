// Daniel Morato Baudi.
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the items.
    /// </summary>
    class Item
    {
        #region Attributes
        protected string name;
        protected ItemType type;
        protected int requiredLevel;
        protected RequiresJob requiredJob;
        #endregion

        #region Constructors
        // Empty constructor
        /// <summary>
        /// Initiallizes an instance of the Item class with no parameters.
        /// </summary>
        public Item()
        {
            name = "";
            type = ItemType.Unassigned;
            requiredLevel = 0;
            requiredJob = RequiresJob
                .Unassigned;
        }

        // Parameterized constructor
        /// <summary>
        /// Initiallizes an instance of the Item class with all the parameters.
        /// </summary>
        /// <param name="name">(String) Item's name.</param>
        /// <param name="type">(ItemType) Item's type.</param>
        /// <param name="requiredLevel">(Integer) Item's required level.</param>
        /// <param name="requiredJob">(RequiresJob) Item's required job.</param>
        public Item(string name, ItemType type,
                    int requiredLevel,
                    RequiresJob requiredJob)
        {
            this.name = name;
            this.type = type;
            this.requiredLevel = requiredLevel;
            this.requiredJob = requiredJob;
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return name;  }
            set { name = value; }
        }
        
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public ItemType Type
        {
            get { return type;  }
            set { type = value; }
        }

        /// <summary>
        /// Gets or sets the required level.
        /// </summary>
        public int RequiredLevel
        {
            get { return requiredLevel;  }
            set { requiredLevel = value; }
        }

        /// <summary>
        /// Gets or sets the required job.
        /// </summary>
        public RequiresJob RequiredJob
        {
            get { return requiredJob;  }
            set { requiredJob = value; }
        }
        #endregion
    }
}