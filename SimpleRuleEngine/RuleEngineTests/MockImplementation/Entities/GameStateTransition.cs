
namespace RuleEngineTests.MockImplementation.Entities
{
    public class GameStateTransition
    {
        #region Properties

        /// <summary>
        /// Gets (or privately sets) the GameState that can be transitioned from.
        /// </summary>
        /// <value>From.</value>
        public GameState TransitionFrom { get; private set; }

        /// <summary>
        /// Gets (or privately sets) the GameState that can be transitioned to.
        /// </summary>
        /// <value>To.</value>
        public GameState TransitionTo { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="GameStateTransition"/> class from being created.
        /// </summary>
        private GameStateTransition() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateTransition"/> class.
        /// </summary>
        /// <param name="transitionFrom">The transition from.</param>
        /// <param name="transitionTo">The transition to.</param>
        public GameStateTransition(GameState transitionFrom, GameState transitionTo)
        {
            TransitionFrom = transitionFrom;
            TransitionTo = transitionTo;
        }

        #endregion
    }
}