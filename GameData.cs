// Daniel Morato Baudi.
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Resources.Enums;

namespace RPG_Tactics
{
    class GameData
    {
        #region Attributes
        private List<Level> levels;
        private List<Hero> heroes;
        private List<Enemy> enemies;
        private List<NeutralCharacter> neutrals;
        private List<Image> movementDirections;
        private int actualImage;
        private LevelImages[] levelPaths;
        private CharacterImages[] heroPaths;
        private MovementDirectionImages[] directionPaths;
        private TMX[] tmxPaths;
        private Vector2[] heroesPositions;
        private Character actualCharacter;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new empty GameData object.
        /// </summary>
        public GameData()
        {
            levels = new List<Level>();
            heroes = new List<Hero>();
            enemies = new List<Enemy>();
            neutrals = new List<NeutralCharacter>();
            movementDirections = new List<Image>();
            actualImage = 0;
            tmxPaths = new TMX[Constraints.NUMBER_OF_LEVELS];
            levelPaths = new LevelImages[Constraints.NUMBER_OF_LEVELS]; 
            heroPaths = new CharacterImages[Constraints.NUMBER_OF_CHARACTERS];
            heroesPositions = new Vector2[Constraints.NUMBER_OF_CHARACTERS];
            directionPaths = new MovementDirectionImages[
                Constraints.NUMBER_OF_DIRECTIONS];

            #region Array / Lists filling
            // Level paths.
            levelPaths[0] = LevelImages.Level_1;
            tmxPaths[0] = TMX.Level_1;

            for (int i = 0; i < Constraints.NUMBER_OF_LEVELS; i++)
            {
                Level level = new Level();
                level.Number = i;
                level.LoadColliders(tmxPaths[i]);

                levels.Add(level);
            }

            // Movement direction paths.
            for (int i = 0; i < Constraints.NUMBER_OF_DIRECTIONS; i++)
                movementDirections.Add(new Image());

            directionPaths[0]  = MovementDirectionImages.InitialRight;
            directionPaths[1]  = MovementDirectionImages.InitialDown;
            directionPaths[2]  = MovementDirectionImages.InitialLeft;
            directionPaths[3]  = MovementDirectionImages.InitialUp;
            directionPaths[4]  = MovementDirectionImages.HorizontalDash;
            directionPaths[5]  = MovementDirectionImages.VerticalDash;
            directionPaths[6]  = MovementDirectionImages.BendedLeftDown;
            directionPaths[7]  = MovementDirectionImages.BendedUpLeft;
            directionPaths[8]  = MovementDirectionImages.BendedRightUp;
            directionPaths[9]  = MovementDirectionImages.BendedDownRight;
            directionPaths[10] = MovementDirectionImages.RightArrow;
            directionPaths[11] = MovementDirectionImages.DownArrow;
            directionPaths[12] = MovementDirectionImages.LeftArrow;
            directionPaths[13] = MovementDirectionImages.UpArrow;
            directionPaths[14] = MovementDirectionImages.EmptyMovableTile;
            directionPaths[15] = MovementDirectionImages.AttackableTile;

            // Hero paths.
            for (int i = 0; i < Constraints.NUMBER_OF_CHARACTERS; i++)
                heroes.Add(new Hero());

            // Delete on DB ready;
            heroesPositions[0] = new Vector2(11, 13); // 6 23
            heroPaths[0] = CharacterImages.Joe;
            actualCharacter = heroes[0];
            #endregion
        }
        #endregion

        #region Methods
        // public void LoadDataFromDB();
        // public void SaveDataToDB();

        /// <summary>
        /// Extracts the images of a list of objects.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="list">List of objects.</param>
        /// <returns>Images list.</returns>
        public List<Image> GetImageList<T>(List<T> list) where T : class
        {
            List<Image> imageList = new List<Image>();
            foreach (object element in list)
                if (list[0] is Character)
                    imageList.Add(((Character)element).Texture);
                
                else if (list[0] is Level)
                    imageList.Add(((Level)element).Map);

            return imageList;
        }

        /// <summary>
        /// Copies a list of images into a list of objects.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="imageList">List of images to copy.</param>
        /// <param name="original">List of objects.</param>
        public void CopyImagesToList<T>(List<Image> imageList,
            List<T> original) where T : class
        {
            int i = 0;
            foreach (object character in original)
            {
                ((Character)character).Texture = imageList[i];
                ((Character)character).Texture.RowFrames = 4;
                ((Character)character).Texture.ColumnFrames = 3;

                ((Character)character).Texture.Box = new BoundingBox(
                    new Vector3(((Character)character).Texture.Position, 0),
                    new Vector3(((Character)character).Texture.Position.X +
                        ((Character)character).Texture.Texture.Width,
                        ((Character)character).Texture.Position.Y + 
                        ((Character)character).Texture.Texture.Height, 0));

                i++;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the levels list.
        /// </summary>
        public List<Level> Levels
        {
            get { return levels;          }
            set { levels.AddRange(value); }
        }

        /// <summary>
        /// Gets or sets the characters list.
        /// </summary>
        public List<Hero> Heroes
        {
            get { return heroes;          }
            set { heroes.AddRange(value); }
        }

        /// <summary>
        /// Gets or sets the movement directions list.
        /// </summary>
        public List<Image> Directions
        {
            get { return movementDirections;          }
            set { movementDirections.AddRange(value); }
        }

        /// <summary>
        /// Gets or sets the actual image displaying.
        /// </summary>
        public int ActualImage
        {
            get { return actualImage;  }
            set { actualImage = value; }
        }

        /// <summary>
        /// Gets or sets the character's initial position.
        /// </summary>
        public Vector2[] CharacterPositions
        {
            get { return heroesPositions; }
            set { 
                for (int i = 0; i < value.Length; i++)
                    heroesPositions[i] = value[i];
            }
        }

        /// <summary>
        /// Gets or sets the levels path list.
        /// </summary>
        public LevelImages[] LevelsToLoad
        {
            get { return levelPaths; }
            set { 
                for (int i = 0; i < value.Length; i++)
                    levelPaths[i] = value[i];
            }
        }

        /// <summary>
        /// Gets or sets the characters path list.
        /// </summary>
        public CharacterImages[] CharactersToLoad
        {
            get { return heroPaths; }
            set { 
                for (int i = 0; i < value.Length; i++)
                    heroPaths[i] = value[i];
            }
        }

        /// <summary>
        /// Gets or sets the movement directions path list.
        /// </summary>
        public MovementDirectionImages[] DirectionsToLoad
        {
            get { return directionPaths; }
            set { 
                for (int i = 0; i < value.Length; i++)
                    directionPaths[i] = value[i];
            }
        }

        /// <summary>
        /// Gets or sets the actual selected character.
        /// </summary>
        public Character ActualCharacter
        {
            get { return actualCharacter;  }
            set { actualCharacter = value; }
        }
        #endregion
    }
}