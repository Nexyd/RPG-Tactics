// Daniel Morato Baudi.74
using System.Collections.Generic;
//using System.Reflection;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Input;
using Resources.Enums;

namespace RPG_Tactics
{
    class Character
    {
        #region Attributes
        protected string name;
        protected Breed race;
        protected Job chosenJob;
        protected Stats stats; // Think whose type would be the most suitable.
        protected int level;
        protected int exp;
        protected int remainingMovements;
        protected List<Item> inventory;
        protected Image image;
        #endregion

        #region Constructors
        /// <summary>
        /// Initiallizes a new empty Character instance.
        /// </summary>
        public Character()
        {
            name = "Character";
            race = Breed.Unassigned;
            chosenJob = new Job(ChosenJob.Unassigned);
            stats = new Stats();
            level = 1;
            exp = 0;
            remainingMovements = 0;
            inventory = new List<Item>();
            image = new Image();
        }

        /// <summary>
        /// Initiallizes a new Character with name, job and image.
        /// </summary>
        /// <param name="name">Character's name.</param>
        /// <param name="chosenJob">Character's job.</param>
        /// <param name="image">Character's image.</param>
        public Character(string name, ChosenJob chosenJob, Image image)
        {
            this.name = name;
            race = Breed.Unassigned;
            this.chosenJob = new Job(chosenJob);
            stats = new Stats();
            level = 1;
            exp = 0;
            remainingMovements = 0;
            inventory = new List<Item>();
            this.image = image;
        }

        /// <summary>
        /// Initiallizes a new Character with all parameters.
        /// </summary>
        /// <param name="name">Character's name.</param>
        /// <param name="race">Character's race.</param>
        /// <param name="chosenJob">Character's job.</param>
        /// <param name="stats">Character's stats.</param>
        /// <param name="level">Character's level.</param>
        /// <param name="exp">Character's amount of experience.</param>
        /// <param name="remainingMovements">Character's amount of movements available.</param>
        /// <param name="inventory">List of items the character has in its inventory.</param>
        /// <param name="image">Character's image.</param>
        public Character(string name, Breed race, ChosenJob chosenJob,
                         Stats stats, int level, int exp,
                         int remainingMovements, List<Item> inventory,
                         Image image)
        {
            this.name = name;
            this.race = race;
            this.chosenJob = new Job(chosenJob);
        
            this.stats.Strength  = this.chosenJob.Stats.Strength;
            this.stats.Stamina   = this.chosenJob.Stats.Stamina;
            this.stats.Agility   = this.chosenJob.Stats.Agility;
            this.stats.Intelect  = this.chosenJob.Stats.Intelect;
            this.stats.Defense   = this.chosenJob.Stats.Defense;
            this.stats.Dexterity = this.chosenJob.Stats.Dexterity;
            this.stats.Critical  = this.chosenJob.Stats.Critical;
        
            this.level = level;
            this.remainingMovements = remainingMovements;
            this.inventory = new List<Item>();
            this.image = image;
            foreach (Item item1 in inventory)
                inventory.Add(item1);
        }
        #endregion

        #region Methods
        // public void Move(Keys key, string align, 
        //      KeyboardState newState, KeyboardState oldState)
        // {
        //     Keys negativeKey = align == "Horizontal" ? Keys.Up : Keys.Left;
        //     Keys positiveKey = align == "Horizontal" ? Keys.Down : Keys.Right;
        //     Vector2 speed = align == "Horizontal" ? new Vector2(0, 1) : new Vector2(1, 0);
        //     Vector2 position = new Vector2(Texture.GamePosition.X, Texture.GamePosition.Y);
        // 
        //     if ((newState.IsKeyDown(key)) && !(oldState.IsKeyDown(key)))
        //     {
        //         this.Texture.ActualFrameRow = CheckDirection();
        // 
        //         if (this.Texture.ActualFrameColumn < 2)
        //             this.Texture.ActualFrameColumn += 1;
        //         else if (this.Texture.ActualFrameColumn == 2)
        //             this.Texture.ActualFrameColumn = 0;
        // 
        //         if (key == negativeKey && CanMoveTo(position))
        //             this.Texture.GamePosition -= speed;
        //         else if (key == positiveKey && CanMoveTo(position))
        //             this.Texture.GamePosition += speed;
        //     }
        // 
        //     oldState = newState;
        // }

        /// <summary>
        /// Checks if the character is colliding with another box.
        /// </summary>
        /// <returns>Collision status.</returns>
        public bool IsColliding()
        {
            GameData data = new GameData();
            for (int i = 0; i < 10; i++)
                System.Diagnostics.Debug.Write("------");

            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.Write("Character");
            System.Diagnostics.Debug.Write(" - Min X:" + Texture.Box.Min.X);
            System.Diagnostics.Debug.Write(" - Min Y:" + Texture.Box.Min.Y);
            System.Diagnostics.Debug.Write(" - Max X:" + Texture.Box.Max.X);
            System.Diagnostics.Debug.Write(" - Max Y:" + Texture.Box.Max.Y);
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");

            foreach (XNA.Tiled.CollisionParser.Collider
                collider in data.Levels[0].Colliders)
            {
                if (collider.Name == "BridgePilar2")
                {
                    System.Diagnostics.Debug.Write(collider.Name);
                    System.Diagnostics.Debug.Write(" - Min X:" + collider.Box.Min.X);
                    System.Diagnostics.Debug.Write(" - Min Y:" + collider.Box.Min.Y);
                    System.Diagnostics.Debug.Write(" - Max X:" + collider.Box.Max.X);
                    System.Diagnostics.Debug.Write(" - Max Y:" + collider.Box.Max.Y);

                    System.Diagnostics.Debug.WriteLine("");
                }

                if (Texture.Box.Intersects(collider.Box)
                    && collider.Type != "Trigger")
                {
                    // System.Diagnostics.Debug.Write(collider.Name);
                    // System.Diagnostics.Debug.Write(" - Min X:" + collider.Box.Min.X);
                    // System.Diagnostics.Debug.Write(" - Min Y:" + collider.Box.Min.Y);
                    // System.Diagnostics.Debug.Write(" - Max X:" + collider.Box.Max.X);
                    // System.Diagnostics.Debug.Write(" - Max Y:" + collider.Box.Max.Y);
                    // System.Diagnostics.Debug.WriteLine("");
                    
                    // System.Diagnostics.Debug.WriteLine(collider.Name);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Changes the type of the character.
        /// </summary>
        public virtual void TurnInto<T>() where T : class /*, new() */ { } 

        /// <summary>
        /// Changes the type of the character.
        /// </summary>
        /// <param name="character">Character to change type.</param>
        /// <param name="type">New type of the character. (Hero, Enemy, Neutral)</param>
        protected void ChangeType<T>(Character character,
            System.Type type) where T : class //, new()
        {
            Character aux = new Character();
            aux.CopyAttributesFrom(character);
            object newCharacter = new object();

            if (typeof(Character).IsAssignableFrom(type))
                newCharacter = System.Activator.CreateInstance(type);

            // Change newCharacter into "type" at run time using Reflection.
            // newCharacter.CopyAttributesFrom(aux);

            FindListAndRemove<T>(character);
            FindListAndAdd<T>(newCharacter);
        }

        /// <summary>
        /// Copies the character's attributes into the calling object.
        /// </summary>
        /// <param name="character">Character to copy attributes.</param>
        protected void CopyAttributesFrom(Character character)
        {
            Name = character.Name;
            Race = character.Race;
            JobChosen = character.JobChosen;
            Stats = character.Stats;
            Level = character.Level;
            RemainingMovements = character
                .RemainingMovements;
            Inventory = character.Inventory;
            Texture = character.Texture;
        }

        private void FindListAndRemove<T>(object character)
        {
            
        }

        private void FindListAndAdd<T>(object character)
        {
            
        }
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
        /// Gets or sets the race.
        /// </summary>
        public Breed Race
        {
            get { return race;  }
            set { race = value; }
        }

        /// <summary>
        /// Gets or sets the chosen job.
        /// </summary>
        public Job JobChosen
        {
            get { return chosenJob;  }
            set { chosenJob = value; }
        }

        /// <summary>
        /// Gets or sets the stats.
        /// </summary>
        public Stats Stats
        {
            get { return stats;  }
            set { stats = value; }
        }
        
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public int Level
        {
            get { return level;  }
            set { level = value; }
        }

        /// <summary>
        /// Gets or sets the exp.
        /// </summary>
        public int Exp
        {
            get { return exp;  }
            set { exp = value; }
        }

        /// <summary>
        /// Gets or sets the remaining movements.
        /// </summary>
        public int RemainingMovements
        {
            get { return remainingMovements;  }
            set { remainingMovements = value; }
        }

        /// <summary>
        /// Gets the inventory or adds a new item to it.
        /// </summary>
        public List<Item> Inventory
        {
            get { return inventory;          }
            set { inventory.AddRange(value); }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public Image Texture
        {
            get { return image;  }
            set { image = value; }
        }
        #endregion
    }
}