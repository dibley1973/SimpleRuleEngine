using RuleEngine.Base;
using RuleEngineTests.MockImplementation.Conditions;
using RuleEngineTests.MockImplementation.Entities;

namespace RuleEngineTests.MockImplementation.Rules
{
    internal class StateTransitionRule : BaseRule<GameStateTransition>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StateTransitionRule"/> class.
        /// </summary>
        public StateTransitionRule() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateTransitionRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        /// <param name="actual">The actual.</param>
        public StateTransitionRule(GameStateTransition threshold, GameStateTransition actual)
            : this()
        {
            Initialize(threshold, actual);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the object with the specified threshold and value.
        /// </summary>
        /// <param name="threshold">The threshold value to check value against.</param>
        /// <param name="actual">The actualvalue to check.</param>
        public override void Initialize(GameStateTransition threshold, GameStateTransition actual)
        {
            // Clear any existing conditions
            Conditions.Clear();

            // Create our conditions
            var condition1 = new IntegerEqualToCondition((int)threshold.TransitionFrom, (int)actual.TransitionFrom);
            var condition2 = new IntegerEqualToCondition((int)threshold.TransitionTo, (int)actual.TransitionTo);

            // ...and add them to our collection of conditions
            Conditions.Add(condition1);
            Conditions.Add(condition2);
        }

        /// <summary>
        /// Matches the conditions.
        /// </summary>
        /// <returns></returns>
        public override bool MatchConditions()
        {
            return base.MatchAllConditions();
        }

        #endregion
    }
}
