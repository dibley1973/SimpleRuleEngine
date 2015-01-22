
namespace RuleEngineTests.MockImplementation.Entities
{
    public enum GameState
    {
        /// <summary>
        /// The state of null (Before the game is initialised).
        /// </summary>
        NullState,

        /// <summary>
        /// The intro state, where the splash screen could be shown.
        /// </summary>
        Intro,

        /// <summary>
        /// The state where the player can select their profile.
        /// </summary>
        SelectProfile,

        /// <summary>
        /// The state where the main menu should be displayed.
        /// </summary>
        MainMenu,

        /// <summary>
        /// The state where a new game is created.
        /// </summary>
        NewGame,

        /// <summary>
        /// The state where the game is played.
        /// </summary>
        PlayGame,

        /// <summary>
        /// The state where the game is saved.
        /// </summary>
        SaveGame,

        /// <summary>
        /// The state where the game is quitted.
        /// </summary>
        QuitGame
    }
}
