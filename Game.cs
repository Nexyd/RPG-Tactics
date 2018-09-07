// Daniel Morato Baudi.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Resources.Enums;
using System.Linq;
using System;

namespace RPG_Tactics
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class Game : Microsoft.Xna.Framework.Game
    {
        #region Attributes
        #region XNA_Attributes
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteDrawer;       
        private KeyboardState oldState;
        private KeyboardState newState;
        #endregion

        private MainMenu menu;
        private Image cursor;
        private GameData data;
        #endregion

        #region Constructor
        public Game()
        {
            menu = new MainMenu();
            cursor = new Image();
            data = new GameData();

            // XNA Inits.
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.Reach;
            graphics.PreferredBackBufferWidth  = menu.WIDTH;
            graphics.PreferredBackBufferHeight = menu.HEIGHT;
            Content.RootDirectory = "Content";
        }
        #endregion

        #region Methods
        #region Load & Draw
        /// <summary>
        /// Loads a list of textures.
        /// </summary>
        /// <param name="list">List of textures to fill.</param>
        /// <param name="positions">(Optional) Texture's positions.</param>
        /// <param name="gamePosition">(Optional) Drawing pattern 
        /// (true for tiles, false for pixels).</param>
        public void LoadTexture<T>(
            List<Image> list, Vector2[] positions = null, 
            bool gamePosition = false) where T : struct
        {
            int counter = 0;
            Texture2D textureAux;

            foreach (Enum image in Enum.GetValues(typeof(T)))
            {
                textureAux = Content.Load<Texture2D>(
                    Enums.GetDescription<T>(image));

                list[counter].Texture = textureAux;
                if (!(positions == null))
                    if (!gamePosition)
                        list[counter].Position = positions[counter];
                    else
                        list[counter].GamePosition = positions[counter];

                counter++;
            }
        }

        //public void LoadTexture(List<Image> list,
        //    ConfigMenuImages[] imagePath,
        //    Vector2[] positions = null,
        //    bool gamePosition = false)
        //{
        //    Texture2D textureAux;
        //    for (int i = 0; i < imagePath.Length; i++)
        //    {
        //        textureAux = Content.Load<Texture2D>(
        //            Enums.GetDescription<
        //                ConfigMenuImages>(imagePath[i]));

        //        list[i].Texture = textureAux;
        //        if (!(positions == null))
        //            if (!gamePosition)
        //                list[i].Position = positions[i];
        //            else
        //                list[i].GamePosition = positions[i];
        //    }
        //}

        //public void LoadTexture(List<Image> list,
        //    ConfigHighlightImages[] imagePath,
        //    Vector2[] positions = null,
        //    bool gamePosition = false)
        //{
        //    Texture2D textureAux;
        //    for (int i = 0; i < imagePath.Length; i++)
        //    {
        //        textureAux = Content.Load<Texture2D>(
        //            Enums.GetDescription<
        //                ConfigHighlightImages>(imagePath[i]));

        //        list[i].Texture = textureAux;
        //        if (!(positions == null))
        //            if (!gamePosition)
        //                list[i].Position = positions[i];
        //            else
        //                list[i].GamePosition = positions[i];
        //    }
        //}

        /// <summary>
        /// Draws a texture in the screen.
        /// </summary>
        /// <param name="sortMode">Sprite drawing order.</param>
        /// <param name="blendState">Blending options</param>
        /// <param name="image">Image to draw.</param>
        /// <param name="destinationRectangle">A rectangle that specifies (in 
        /// screen coordinates) the destination for drawing the sprite.</param>
        /// <param name="color">The color to tint a sprite. Use Color.White
        /// for full color with no tinting.</param>
        /// <param name="drawingCharacter">Drawing element (Character / Cursor).</param>
        /// <param name="startingRow">Row to pick the frame.</param>
        public void DrawTexture(
            SpriteSortMode sortMode, BlendState blendState,
            Image image, Vector2 destinationRectangle,
            Color color, bool drawingCharacter = false,
            int startingRow = 0)
        {
            spriteDrawer.Begin(sortMode, blendState);
            if (image.RowFrames > 0)
            {
                int frameHeight = image.Texture.Height / image.RowFrames;
                int frameWidth  = image.Texture.Width / image.ColumnFrames;
                int x = image.ColumnFrames > 1 ? frameWidth : 0;
                int frame = drawingCharacter ? image.ActualFrameColumn : image.ActualFrameRow;

                Rectangle source = new Rectangle();
                if (drawingCharacter)
                    source = new Rectangle(x * frame,
                        frameHeight * startingRow,
                        frameWidth, frameHeight);
                else
                    source = new Rectangle(x, 
                        frameHeight * frame,
                        frameWidth, frameHeight);

                spriteDrawer.Draw(image.Texture, 
                    destinationRectangle, source, Color.White);

            } else
                spriteDrawer.Draw(image.Texture, 
                    destinationRectangle, color);

            spriteDrawer.End();
        }
        #endregion

        #region LoadContent
        public void LoadMainMenuContent()
        {
            int cursorStartingX = 87;
            int cursorStartingY = 305;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteDrawer = new SpriteBatch(GraphicsDevice);
            LoadTexture<MainMenuImages>(menu.ScreenTextures);
            LoadTexture<ConfigMenuImages>(menu.ConfigTextures, menu.ConfigPositions);
            LoadTexture<ConfigHighlightImages>(menu.HighlightedConfig, menu.ConfigPositions);

            // LoadTexture(menu.ConfigTextures, menu.ConfigToLoad, menu.ConfigPositions, false);
            // LoadTexture(menu.HighlightedConfig, menu.HighlightToLoad, menu.ConfigPositions, true);

            // Remove when the LoadTexture<> is changed
            // to allow loading arrays of images.
            // Positions are incorrect.
            TemporaryConfigImageFix(menu.ConfigTextures);
            TemporaryConfigImageFix(menu.HighlightedConfig);

            // Main menu cursor.
            menu.ScreenTextures[3].RowFrames = 3;
            menu.ScreenTextures[3].ColumnFrames = 1;
            menu.ScreenTextures[3].Position = new Vector2(
                cursorStartingX, cursorStartingY);

            // Change index to "SpeedHL_1 / 2" when the List<>
            // has been replaced with SortedList<>.
            menu.HighlightedConfig[7].RowFrames = 3;
            menu.HighlightedConfig[8].RowFrames = 3;
        }

        public void LoadGameContent()
        {
            // this list will store all the character's images.
            List<Image> characterImages = data.GetImageList(data.Heroes);
            cursor.Texture = Content.Load<Texture2D>(
                Enums.GetDescription<GameImages>(GameImages.Cursor));

            // Initiallize the position and box collider of the cursor.
            cursor.GamePosition = new Vector2(6, 23);
            cursor.Box = new BoundingBox(
                new Vector3(cursor.Position, 0),
                new Vector3(cursor.Position.X * 32,
                    cursor.Position.Y * 32, 0));

            LoadTexture<LevelImages>(data.GetImageList(data.Levels));
            LoadTexture<MovementDirectionImages>(data.Directions);
            LoadTexture<CharacterImages>(characterImages,
                data.CharacterPositions, true);

            data.CopyImagesToList(characterImages, data.Heroes);

            // Temporary data of the 1st character. Delete when the DB is ready.
            data.Heroes[0].Name = "Joe";
            data.Heroes[0].RemainingMovements = 5;
            data.Heroes[0].Texture.GamePosition =
                new Vector2(6, 18); // x 6 y 23
        }

        /// <summary>
        /// This method serves to fix the loading of textures and positions of the 
        /// config menu images, reordenating and duplicating the values where needed.
        /// </summary>
        /// <param name="list">List of images to be fixed.</param>
        public void TemporaryConfigImageFix(List<Image> list)
        {
            Image soundSlideBar   = list[0];
            Image soundEnabled    = list[1];
            Image soundDisabled   = list[2];
            Image soundPointer    = list[3];
            Image speedNormal     = list[4];
            Image speedFast       = list[5];
            Image speedMax        = list[6];
            Image restoreDefault  = list[7];
            Image miniMapEnabled  = list[8];
            Image miniMapDisabled = list[9];

            list[1]  = soundPointer;
            list[2]  = soundEnabled;
            list[3]  = soundDisabled;
            list[4]  = soundSlideBar;
            list[5]  = soundPointer;
            list[6]  = soundEnabled;
            list[7]  = soundDisabled;
            list[8]  = miniMapEnabled;
            list[9]  = miniMapDisabled;
            list[10] = speedNormal;
            list[11] = speedFast;
            list[12] = speedMax;
            list[13] = speedNormal;
            list[14] = speedFast;
            list[15] = speedMax;
            list[16] = restoreDefault;

            for (int i = 0; i < menu.ConfigPositions.Count(); i++)
                list[i].Position = menu.ConfigPositions[i];
        }
        #endregion

        #region MenuMethods
        #region Screen
        /// <summary>
        /// Moves the cursor up or down.
        /// </summary>
        public void MoveMenuCursor()
        {
            bool keyUpCheck = newState.IsKeyDown(Keys.Up);
            int limit = keyUpCheck ? Constraints.MENU_UPPER_BOUND : Constraints.MENU_LOWER_BOUND;
            Keys key  = keyUpCheck ? Keys.Up : Keys.Down;

            if ((newState.IsKeyDown(key)) &&
               !(oldState.IsKeyDown(key)))
            {
                Vector2 speed = new Vector2(0, 50f);
                if (menu.ScreenTextures[3].ActualFrameRow > limit)
                {
                    menu.ScreenTextures[3].ActualFrameRow--;
                    menu.ScreenTextures[3].Position -= speed;

                } else if (menu.ScreenTextures[3].ActualFrameRow < limit) {

                    menu.ScreenTextures[3].ActualFrameRow++;
                    menu.ScreenTextures[3].Position += speed;
                }
            }

            oldState = newState; // Aplicar en los lugares necesarios que no este.
        }

        /// <summary>
        /// Changes the actual screen displayed.
        /// </summary>
        /// <param name="actualFrame">Actual cursor displayed.</param>
        public void ChangeScreen(MenuOption actualFrame)
        {
            if ((menu.ScreenTextures[3].ActualFrameRow == (int)actualFrame)
                && (newState.IsKeyDown(Keys.Enter)) &&
                (menu.ActualImage == (int)MainMenuImages.MainScreen))
            {
                if (actualFrame == MenuOption.Play)
                {
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                    menu.StartGame();
                }

                else if (actualFrame == MenuOption.Configuration)
                    menu.ActualImage = (int)MainMenuImages.ConfigScreen;

                else if (actualFrame == MenuOption.Help)
                    menu.ActualImage = (int)MainMenuImages.HelpScreen;
            }
        }

        /// <summary>
        /// Gets back to the main screen.
        /// </summary>
        public void BackToMainScreen()
        {
            if ((menu.ActualImage != (int)MainMenuImages.MainScreen)
                && (newState.IsKeyDown(Keys.Escape)))
            {
                menu.ActualImage = (int)MainMenuImages.MainScreen;

                // Reset config highlight options.
                menu.ActualHighlight = 1;
                foreach (Image image in menu.HighlightedConfig)
                    image.Highlighted = false;

                menu.HighlightedConfig[1].Highlighted = true;
            }
        }
        #endregion

        #region Config
        /// <summary>
        /// Draws all the configuration option's images.
        /// </summary>
        public void DrawConfigOptions()
        {
            // Draw options.
            for (int i = 0; i < menu.ConfigTextures.Count; i++)
                if (menu.ConfigTextures[i].Visible)
                    DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                        menu.ConfigTextures[i], menu.ConfigTextures[i].Position,
                        Color.White);

            // Draw option highlighted.
            DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                menu.HighlightedConfig[menu.ActualHighlight],
                menu.ConfigTextures[menu.ActualHighlight].Position,
                Color.White); // Exclude SoundDisabled and MiniMapEnabled.

            // This will be drawn only if the SoundSlidePointer is highlighted.
            if (menu.HighlightedConfig[1].Highlighted)
                DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                    menu.HighlightedConfig[0], menu.ConfigTextures[0].Position,
                    Color.White);

            // else if (this.menu.HighlightedConfig[4].Highlighted)
            //     DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
            //         menu.HighlightedConfig[3], menu.ConfigTextures[3].Position,
            //         Color.White);
        }

        /// <summary>
        /// Changes the actual highlighted option.
        /// </summary>
        public void ChangeOption()
        {
            if (newState.IsKeyDown(Keys.Tab))
                // if (!oldState.IsKeyDown(Keys.Tab)) // Seems not to be working.
                {
                    if (menu.ActualHighlight < menu.HighlightedConfig.Count - 1)
                    {
                        menu.ActualHighlight++;
                        menu.HighlightedConfig[
                            menu.ActualHighlight].
                            Highlighted = true;

                        menu.HighlightedConfig[
                            menu.ActualHighlight - 1]
                            .Highlighted = false;

                        System.Threading.Thread.Sleep(200); 
                        // Delete when the 2nd if (commented) work.
                    
                    } else {

                        menu.ActualHighlight = 0;
                        // this.menu.HighlightedConfig[1].Highlighted = true;
                        menu.HighlightedConfig[
                            menu.HighlightedConfig.Count - 1
                            ].Highlighted = false;
                    }
                }

            // else if (newState.IsKeyDown(Keys.LeftShift && Keys.Tab))
            //     // if (!oldState.IsKeyDown(Keys.LeftShift && Keys.Tab)) // Seems not to be working.
            //     {
            //         if (this.menu.ActualHighlight > 0)
            //         {
            //             this.menu.HighlightedConfig[
            //                 this.menu.ActualHighlight]
            //                 .Highlighted = false;
            // 
            //             this.menu.ActualHighlight--;
            //             this.menu.HighlightedConfig[
            //                 this.menu.ActualHighlight]
            //                 .Highlighted = true;
            // 
            //             System.Threading.Thread.Sleep(200); // Delete when the 2nd if work.
            //         
            //         } else {
            // 
            //             this.menu.ActualHighlight = 0;
            //             // this.menu.HighlightedConfig[1].Highlighted = true;
            //             this.menu.HighlightedConfig[
            //                 this.menu.HighlightedConfig.Count - 1
            //                 ].Highlighted = true;
            //         }
            //     }
        }
        #endregion

        #region Update & Draw
        /// <summary>
        /// Allows the game to run logic such as gathering input,
        /// playing audio and change between menus.
        /// </summary>
        public void UpdateMainMenu()
        {
            if (newState.IsKeyDown(Keys.Escape) &&
               (menu.ActualImage == (int)MainMenuImages.MainScreen))
            {
                if (!oldState.IsKeyDown(Keys.Escape))
                    Exit();
            }

            MoveMenuCursor();
            ChangeOption();

            ChangeScreen(MenuOption.Play);
            ChangeScreen(MenuOption.Configuration);
            ChangeScreen(MenuOption.Help);

            BackToMainScreen();
        }

        public void DrawMainMenu()
        {
            // Clear the screen.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the main menu screen.
            DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                menu.ScreenTextures[menu.ActualImage],
                menu.ScreenTextures[menu.ActualImage].Position,
                Color.White);

            // Draw the cursor.
            if (menu.ActualImage == (int)MainMenuImages.MainScreen)
                DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
                    menu.ScreenTextures[3], menu.ScreenTextures[3].Position, Color.White);

            // Draw configuration's options.
            if (menu.ActualImage == (int)MainMenuImages.ConfigScreen)
                DrawConfigOptions();
        }
        #endregion
        #endregion

        #region GameMethods
        #region Movement
        /// <summary>
        /// Checks what direction key has been pressed.
        /// </summary>
        /// <returns>Key pressed.</returns>
        public Keys CheckKeyPressed()
        {
            if (newState.IsKeyDown(Keys.Up))
                return Keys.Up;
            else if (newState.IsKeyDown(Keys.Left))
                return Keys.Left;
            else if (newState.IsKeyDown(Keys.Right))
                return Keys.Right;
            else if (newState.IsKeyDown(Keys.Down))
                return Keys.Down;

            return Keys.Kanji; // Porque sí, porque mola, porque quieres una batamanta.
        }

        /// <summary>
        /// Checks whether the alignment of the key is horizontal or vertical.
        /// </summary>
        /// <param name="key">Key pressed.</param>
        /// <returns>Direction's alignment.</returns>
        public string CheckAlignment(Keys key)
        {
            if (key == Keys.Up || key == Keys.Down)
                return "Horizontal";
            else if (key == Keys.Left || key == Keys.Right)
                return "Vertical";

            return "";
        }

        /// <summary>
        /// Moves the cursor in the direction pressed.
        /// </summary>
        public void MoveGameCursor()
        {
            Keys key = CheckKeyPressed();
            string align = CheckAlignment(key);

            Keys negativeKey = (align == "Horizontal") ? Keys.Up   : Keys.Left;
            Keys positiveKey = (align == "Horizontal") ? Keys.Down : Keys.Right;
            Vector2 speed =    (align == "Horizontal") ? new Vector2(0, 1) : new Vector2(1, 0);
            int minBound =     (align == "Horizontal") ? Constraints.GAME_UPPER_BOUND : Constraints.GAME_LEFT_BOUND;
            int maxBound =     (align == "Horizontal") ? Constraints.GAME_LOWER_BOUND : Constraints.GAME_RIGHT_BOUND;
            float axis =       (align == "Horizontal") ? Cursor.GamePosition.Y : Cursor.GamePosition.X;

            if ((newState.IsKeyDown(key)) && !(oldState.IsKeyDown(key)))
            {
                if (key == negativeKey && (axis > minBound))
                    Cursor.GamePosition -= speed;
                else if (key == positiveKey && (axis < maxBound))
                    Cursor.GamePosition += speed;
            }

            oldState = newState;
        }
        #endregion

        #region TestCharacterAnimationMovement
        /// <summary>
        /// Checks what direction is the character facing. 
        /// (Move when the real movement method has been implemented.)
        /// </summary>
        /// <returns>Key pressed.</returns>
        public int CheckDirection()
        {
            if      (newState.IsKeyDown(Keys.Down))  return 0;
            else if (newState.IsKeyDown(Keys.Left))  return 1;
            else if (newState.IsKeyDown(Keys.Right)) return 2;
            else if (newState.IsKeyDown(Keys.Up))    return 3;

            return -1;
        }

        /// <summary>
        /// Moves the character in the direction pressed.
        /// (Delete when the real movement method has been implemented.)
        /// </summary>
        /// <param name="character">Character that will move.</param>
        public void MoveCharacter(Character character)
        {
            Keys key = CheckKeyPressed();
            string align = CheckAlignment(key);

            Keys negativeKey = (align == "Horizontal") ? Keys.Up : Keys.Left;
            Keys positiveKey = (align == "Horizontal") ? Keys.Down : Keys.Right;
            Vector2 speed =    (align == "Horizontal") ? new Vector2(0, 1) : new Vector2(1, 0);
            int minBound =     (align == "Horizontal") ? Constraints.GAME_UPPER_BOUND : Constraints.GAME_LEFT_BOUND;
            int maxBound =     (align == "Horizontal") ? Constraints.GAME_LOWER_BOUND : Constraints.GAME_RIGHT_BOUND;
            float axis =       (align == "Horizontal") ? character.Texture.GamePosition.Y : 
                                                         character.Texture.GamePosition.X;

            if ((newState.IsKeyDown(key)) && !(oldState.IsKeyDown(key)))
            {
                character.Texture.ActualFrameRow = CheckDirection();

                if (character.Texture.ActualFrameColumn < 2)
                    character.Texture.ActualFrameColumn += 1;
                else if (character.Texture.ActualFrameColumn == 2)
                    character.Texture.ActualFrameColumn = 0;

                if (!character.IsColliding())
                    if (key == negativeKey && (axis > minBound))
                        character.Texture.GamePosition -= speed;
                    else if (key == positiveKey && (axis < maxBound))
                        character.Texture.GamePosition += speed;
            }

            oldState = newState;
        }
        #endregion

        #region Selection & Game menus
        /// <summary>
        /// Checks if a character has been selected.
        /// </summary>
        public bool IsCharacterSelected()
        {
            bool selected = false;
            Character selectedChar = 
                (from character in data.Heroes
                where cursor.Box.Intersects(
                    character.Texture.Box)
                select character).First();

            selected = true;
            data.ActualCharacter = selectedChar;

            if ((selectedChar != null) &&
                (newState.IsKeyDown(Keys.Enter)) &&
                !(oldState.IsKeyDown(Keys.Enter)))
                ShowCharacterMenu();

            oldState = newState;
            return selected;
        }

        public void ShowCharacterMenu(){}
        #endregion

        /// <summary>
        /// Check if possible to move to a surrounding tile.
        /// </summary>
        /// <param name="x">X coord.</param>
        /// <param name="y">Y coord.</param>
        /// <param name="movements">Movements available.</param>
        /// <returns>Movement possibility.</returns>
        public bool CheckPossibleMovement(float x, float y, int movements)
        {
            // Check collision with x, y.

            // Change Collision(x, y) to the real collision method.
            // Think where to put or how to do the tileChecked.

            // When this works, change the AvailableMovement.png
            // from every tile on the edge to AvailableAttack.



            // This will allow the control of the 4 boundaries.
            // int movementsUp    = movements;
            // int movementsRight = movements;
            // int movementsLeft  = movements;
            // int movementsDown  = movements;

            // if (!(Collision(x, y - 1)) && !(tileChecked (optional)))
            if (movements > 1)
            {
                // Draw AvailableMovement.png.
                Image image = data.Directions[(int)
                    MovementDirectionImages.EmptyMovableTile];

                spriteDrawer.Begin(
                    SpriteSortMode.BackToFront,
                    BlendState.AlphaBlend);

                spriteDrawer.Draw(image.Texture,
                    image.GamePosition, 
                    image.Texture.Bounds,
                    Color.White);

                spriteDrawer.End();
                CheckPossibleMovement(x, y - 1, movements);
                // tileChecked = true; // (optional)

            }// else {
            // 
            //     tileChecked = true; // (optional)
            // }

            // if (!(Collision(x - 1, y - 1)) && !(tileChecked (optional)))
            // if (movementsUp > 1)
            // {
            //     // Draw AvailableMovement.png.
            //     CheckPossibleMovement(x - 1, y - 1, movements);
            //     // tileChecked = true; // (optional)
            // 
            // }// else {
            // 
            //     tileChecked = true; // (optional)
            // }

            // if (!(Collision(x - 1, y)) && !(tileChecked (optional)))
            // {
            //     // Draw AvailableMovement.png.
            //     CheckPossibleMovement(x - 1, y, movements);
            //     tileChecked = true; // (optional)
            // 
            // } else {
            // 
            //     tileChecked = true; // (optional)
            // }

            // if (!(Collision(x - 1, y + 1)) && !(tileChecked (optional)))
            // {
            //     // Draw AvailableMovement.png.
            //     CheckPossibleMovement(x - 1, y + 1, movements);
            //     tileChecked = true; // (optional)
            // 
            // } else {
            // 
            //     tileChecked = true; // (optional)
            // }

            // if (!(Collision(x, y + 1)) && !(tileChecked (optional)))
            // {
            //     // Draw AvailableMovement.png.
            //     CheckPossibleMovement(x, y + 1, movements);
            //     tileChecked = true; // (optional)
            // 
            // } else {
            // 
            //     tileChecked = true; // (optional)
            // }

            // if (!(Collision(x + 1, y + 1)) && !(tileChecked (optional)))
            // {
            //     // Draw AvailableMovement.png.
            //     CheckPossibleMovement(x + 1, y + 1, movements);
            //     tileChecked = true; // (optional)
            // 
            // } else {
            // 
            //     tileChecked = true; // (optional)
            // }

            // if (!(Collision(x + 1, y)) && !(tileChecked (optional)))
            // {
            //     // Draw AvailableMovement.png.
            //     CheckPossibleMovement(x, y + 1, movements);
            //     tileChecked = true; // (optional)
            // 
            // } else {
            // 
            //     tileChecked = true; // (optional)
            // }

            // if (!(Collision(x + 1, y - 1)) && !(tileChecked (optional)))
            // {
            //     // Draw AvailableMovement.png.
            //     CheckPossibleMovement(x - 1, y + 1, movements);
            //     tileChecked = true; // (optional)
            // 
            // } else {
            // 
            //     tileChecked = true; // (optional)
            // }

            return false;
        }

        #region Update & Draw
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio. 
        /// </summary>
        public void UpdateGame()
        {
            // To Do.
            // MoveGameCursor();
            MoveCharacter(data.Heroes[0]);
            // IsCharacterSelected();
        }

        /// <summary>
        /// Draws the colliders to the map.
        /// </summary>
        public void DrawColliders()
        {
            Image image = data.Levels[
                data.ActualImage].Map;

            spriteDrawer.Begin(
                SpriteSortMode.BackToFront,
                BlendState.AlphaBlend);

            foreach (XNA.Tiled.CollisionParser.Collider
                collider in data.Levels[0].Colliders)
            {
                spriteDrawer.Draw(image.Texture,
                    collider.Bounds, collider.Bounds,
                    Color.Red);
            }

            spriteDrawer.End();
        }

        /// <summary>
        /// Draws the game on every frame.
        /// </summary>
        public void DrawGame()
        {
            // Clear the screen.
            GraphicsDevice.Clear(Color.AntiqueWhite);

            // Draw the level.
            DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
               data.Levels[data.ActualImage].Map, data.Levels[data.ActualImage]
               .Map.Position, Color.White);

            DrawColliders();

            // Draw the cursor.
            DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
               Cursor, Cursor.Position, Color.White);

            // Draw the available moves.
            // if (IsCharacterSelected())
            //     CheckPossibleMovement(
            //         data.ActualCharacter.Texture.Position.X,
            //         data.ActualCharacter.Texture.Position.Y,
            //         data.ActualCharacter.RemainingMovements);

            // Draw the characters. // Main character only.
            DrawTexture(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
               data.ActualCharacter.Texture, data.ActualCharacter.Texture.Position,
               Color.White, true, data.ActualCharacter.Texture.ActualFrameRow);

            // Draw units menu.
            // To Do.
        }
        #endregion

        #region Other
        /// <summary>
        /// Changes the resolution to fit the game's 736x800.
        /// </summary>
        public void ChangeGameResolution()
        {
            graphics.PreferredBackBufferWidth  = Constraints.SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = Constraints.SCREEN_HEIGHT;
            graphics.ApplyChanges();
            
            menu.ResolutionActive = false;
        }
        #endregion
        #endregion

        #region XNA Base Methods
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            oldState = Keyboard.GetState();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            newState = Keyboard.GetState();
            if (menu.Active)
                UpdateMainMenu();
            else {
                if (menu.ResolutionActive)
                    ChangeGameResolution();

                UpdateGame();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (menu.Active)
                DrawMainMenu();
            else
                DrawGame();

            base.Draw(gameTime);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            LoadMainMenuContent();
            LoadGameContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the cursor image.
        /// </summary>
        public Image Cursor
        {
            get { return cursor;  }
            set { cursor = value; }
        }
        #endregion
    }
}