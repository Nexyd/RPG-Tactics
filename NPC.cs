// Daniel Morato Baudi.
using System.Collections.Generic;
using Resources.Enums;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the NPCs.
    /// </summary>
    class NPC
    {
        #region Attributes
        private string name;
        private NPCType type;
        private Image image;
        private Action specialAction;
        private List<Item> items;
        #endregion

        #region Constructors
        /// <summary>
        /// Initiallizes a new empty NPC.
        /// </summary>
        public NPC()
        {
            name = "NPC";
            type = NPCType.Normal;
            specialAction = Action.Unassigned;
            items = new List<Item>();
            image = new Image();
        }

        /// <summary>
        /// Initiallizes a new NPC with 3 parameters.
        /// </summary>
        /// <param name="name">NPC's name.</param>
        /// <param name="type">NPC's type.</param>
        /// <param name="image">NPC's image.</param>
        public NPC(string name, NPCType type, Image image)
        {
            this.name = name;
            this.type = type;
            this.image = image;
        }

        /// <summary>
        /// Initiallizes a new NPC with all parameters.
        /// </summary>
        /// <param name="name">NPC's name.</param>
        /// <param name="type">NPC's type.</param>
        /// <param name="image">NPC's image.</param>
        /// <param name="specialAction">NPC's action.</param>
        /// <param name="items">NPC's items to sell.</param>
        public NPC(string name, NPCType type, Image image, 
                   Action specialAction, List<Item> items)
            : this(name, type, image)
        {
            this.specialAction = specialAction;
            foreach (Item item in items)
                this.items.Add(item);
        }
        #endregion

        #region Methods

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the NPC.
        /// </summary>
        public string Name
        {
            get { return name;  }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the NPC type.
        /// </summary>
        public NPCType Type
        {
            get { return type;  }
            set { type = value; }
        }

        /// <summary>
        /// Gets or sets the image the NPC will display.
        /// </summary>
        public Image Texture
        {
            get { return image;  }
            set { image = value; }
        }

        /// <summary>
        /// Gets or sets the special action that caracterizes the NPC.
        /// </summary>
        public Action SpecialAction
        {
            get { return specialAction;  }
            set { specialAction = value; }
        }

        /// <summary>
        /// Gets or sets the list of items the NPC has to sell/give.
        /// </summary>
        public List<Item> Items
        {
            get { return items;  }
            set {
                foreach (Item item in value)
                    items.Add(item);
            }
        }
        #endregion
    }
}