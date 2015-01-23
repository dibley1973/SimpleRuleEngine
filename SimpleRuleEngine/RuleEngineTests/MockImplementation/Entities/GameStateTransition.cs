using System;

namespace RuleEngineTests.MockImplementation.Entities
{
    public class GameStateTransition : IEquatable<GameStateTransition>
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

        #region IEquatable<GameStateTransition> Members

        /// <summary>
        /// Determines whether the specified <see cref="GameStateTransition"/> is equal to the current <see cref="GameStateTransition"/>.
        /// </summary>
        /// <param name="rule">The <see cref="GameStateTransition"/> to compare with the current <see cref="GameStateTransition"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="GameStateTransition"/> is equal to the current
        /// <see cref="GameStateTransition"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(GameStateTransition gameStateTransition)
        {
            return (TransitionFrom == gameStateTransition.TransitionFrom) &&
                    (TransitionTo == gameStateTransition.TransitionTo);
        }

        #endregion
    }
}