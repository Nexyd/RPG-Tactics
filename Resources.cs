// Daniel Morato Baudi.
using System.ComponentModel;
using System.Reflection;

namespace Resources.Enums
{
    #region Enums

    #region BasicEnums
    /// <summary>
    /// Provides all the possible options for the MainMenu.
    /// </summary>
    enum MenuOption
    {
        Play,
        Configuration,
        Help,
    }

    /// <summary>
    /// Provides all the available races.
    /// </summary>
    enum Breed
    {
        Unassigned
    }

    /// <summary>
    /// Provides all the available jobs for a character.
    /// </summary>
    enum ChosenJob
    {
        Unassigned,
        Mage,
        Swordsman,
    }

    /// <summary>
    /// Provides all the jobs for an item.
    /// </summary>
    enum RequiresJob
    {
        Unassigned
    }

    /// <summary>
    /// Provides all the available stats to choose the primary stat.
    /// </summary>
    enum PrimaryAttribute
    {
        Unassigned,
        Strength,
        Stamina,
        Agility,
        Intelect,
        Defense,
        Dexterity,
        Critical
    }

    /// <summary>
    /// Provides all the hero types.
    /// </summary>
    enum HeroType
    {
        Undefined,
        Normal,
        Special,
        Leader
    }

    /// <summary>
    /// Provides all the enemy types.
    /// </summary>
    enum EnemyType
    {
        Undefined,
        Normal,
        Elite,
        Boss
    }

    /// <summary>
    /// Provides all the npc types.
    /// </summary>
    enum NPCType
    {
        Undefined,
        Normal,
        Special,
        Merchant
    }

    /// <summary>
    /// Provides all the neutral character types.
    /// </summary>
    enum NeutralType
    {
        Undefined,
        Ally,
        Unlockable,
        Special
    }

    /// <summary>
    /// Provides all the item types.
    /// </summary>
    enum ItemType
    {
        Unassigned
    }

    /// <summary>
    /// Provides all possible uses for an item.
    /// </summary>
    enum ItemUses
    {
        Unusable
    }

    /// <summary>
    /// Provides all the NPC's available actions.
    /// </summary>
    enum Action
    {
        Unassigned,
        Sell,
        Talk
    }

    /// <summary>
    /// Provides all the conditions to pass a level.
    /// </summary>
    enum WinCondition
    {
        Undefined,
        Take,
        KillAll,
        Survive
    }

    #endregion

    #region StringEnums
    /// <summary>
    /// Provides all the images relative to the game's UI.
    /// </summary>
    enum GameImages
    {
        [Description("GameImages/Cursor")]                        Cursor,
     }

    /// <summary>
    /// Provides all the movement direction tile images.
    /// </summary>
    enum MovementDirectionImages
    {
        [Description("GameImages/Directions/InitialUp")]          InitialUp,
        [Description("GameImages/Directions/InitialDown")]        InitialDown,
        [Description("GameImages/Directions/InitialLeft")]        InitialLeft,
        [Description("GameImages/Directions/InitialRight")]       InitialRight,
        [Description("GameImages/Directions/Vertical")]           VerticalDash,
        [Description("GameImages/Directions/Horizontal")]         HorizontalDash,
        [Description("GameImages/Directions/UpArrow")]            UpArrow,
        [Description("GameImages/Directions/DownArrow")]          DownArrow,
        [Description("GameImages/Directions/LeftArrow")]          LeftArrow,
        [Description("GameImages/Directions/RightArrow")]         RightArrow,
        [Description("GameImages/Directions/BendedLeftDown")]     BendedLeftDown,
        [Description("GameImages/Directions/BendedUpLeft")]       BendedUpLeft,
        [Description("GameImages/Directions/BendedRightUp")]      BendedRightUp,
        [Description("GameImages/Directions/BendedDownRight")]    BendedDownRight,
        [Description("GameImages/MovableTile")]                   EmptyMovableTile,
        [Description("GameImages/AttackableTile")]                AttackableTile,
    }

    /// <summary>
    /// Provides all the images relative to the main menu.
    /// </summary>
    enum MainMenuImages
    {
        [Description("MainMenuImages/MainScreen")]                MainScreen,
        [Description("MainMenuImages/ConfigScreen")]              ConfigScreen,
        [Description("MainMenuImages/HelpScreen")]                HelpScreen,
        [Description("MainMenuImages/Cursors")]                   Cursors,
    }

    /// <summary>
    /// Provides the normal images relative to the configuration menu.
    /// </summary>
    enum ConfigMenuImages
    {
        [Description("MainMenuImages/SoundSlideBar")]             SoundSlideBar,
        [Description("MainMenuImages/SoundEnabled")]              SoundEnabled,
        [Description("MainMenuImages/SoundDisabled")]             SoundDisabled,
        [Description("MainMenuImages/SoundSlidePointer")]         SoundPointer,
        [Description("MainMenuImages/SpeedNormal")]               SpeedNormal,
        [Description("MainMenuImages/SpeedFast")]                 SpeedFast,
        [Description("MainMenuImages/SpeedMax")]                  SpeedMax,
        [Description("MainMenuImages/RestoreDefaults")]           RestoreDefault,
        [Description("MainMenuImages/CB_Checked")]                MiniMapEnabled,
        [Description("MainMenuImages/CB_Unchecked")]              MiniMapDisabled,
    }

    /// <summary>
    /// Provides the highlighted images relative to the configuration menu.
    /// </summary>
    enum ConfigHighlightImages
    {
        [Description("MainMenuImages/SoundSlideBar_HL")]          SoundSlideBar,
        [Description("MainMenuImages/SoundEnabled_HL")]           SoundEnabled,
        [Description("MainMenuImages/SoundDisabled_HL")]          SoundDisabled,
        [Description("MainMenuImages/SoundSlidePointer_HL")]      SoundPointer,
        [Description("MainMenuImages/SpeedNormal_HL")]            SpeedNormal,
        [Description("MainMenuImages/SpeedFast_HL")]              SpeedFast,
        [Description("MainMenuImages/SpeedMax_HL")]               SpeedMax,
        [Description("MainMenuImages/RestoreDefaults_HL")]        RestoreDefault,
        [Description("MainMenuImages/CB_Checked_HL")]             MiniMapEnabled,
        [Description("MainMenuImages/CB_Unchecked_HL")]           MiniMapDisabled,
    }

    /// <summary>
    /// Provides all level's map image.
    /// </summary>
    enum LevelImages
    {
        [Description("GameImages/Levels/Level_1")]                Level_1,
    }

    /// <summary>
    /// Provides all character's avatar image.
    /// </summary>
    enum CharacterImages
    {
        [Description("GameImages/Characters/Joe")]                Joe,
    }

    /// <summary>
    /// Provides all character's face image.
    /// </summary>
    enum CharacterFaceImages
    {
        [Description("GameImages/Characters/Faces/Joe")]          Joe_Face,
    }

    /// <summary>
    /// Game level's TMX file locations.
    /// </summary>
    enum TMX
    {
        [Description("../../../TMX/Level_1.tmx")]                 Level_1
    }
    #endregion
    #endregion

    #region Structs
    struct Constraints
    {
        public const int MENU_UPPER_BOUND = 0;
        public const int MENU_LOWER_BOUND = 2;
        public const int SCREEN_WIDTH  = 736;
        public const int SCREEN_HEIGHT = 800;
        public const int NUMBER_OF_LEVELS = 1;         // Amount may possibly be changed. (20 desired)
        public const int NUMBER_OF_CHARACTERS = 1;     // Amount may possibly be changed. (15 desired)
        public const int NUMBER_OF_DIRECTIONS = 16;
        public const int GAME_UPPER_BOUND = 0;
        public const int GAME_RIGHT_BOUND = 22;
        public const int GAME_LOWER_BOUND = 24;
        public const int GAME_LEFT_BOUND  = 0;
    }
    #endregion

    #region Classes
    /// <summary>
    /// Provides image name and extension to any 'StringEnum' enum.
    /// </summary>
    static class Enums
    {
        #region Methods
        /// <summary>
        /// Gets the assigned description of any 'StringEnum' enum element.
        /// </summary>
        /// <param name="image">Enum whose description is needed.</param>
        /// <returns>Enum element's description.</returns>
        public static string GetDescription<T>(System.Enum image)
        {
            // From the Enum type we obtain the member given by parameters.
            // GetMember receives a string and returns its members array.
            MemberInfo[] memberInfo = typeof(T).GetMember(image.ToString());

            // From the 1st member obtained we get its user-defined descriptions.
            // and we set that they're not inherited.
            object[] attributes = memberInfo[0].GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            DescriptionAttribute attribute = (
                (DescriptionAttribute)attributes[0]);

            return attribute.Description;
        }
        #endregion
    }
    #endregion
}