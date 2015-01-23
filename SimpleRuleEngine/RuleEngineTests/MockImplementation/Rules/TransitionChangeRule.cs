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
        /// <param name="threshold">The threshold.</param>
        /// <param name="actual">The actual.</param>
        public StateTransitionRule(GameStateTransition threshold)
            : base(threshold)
        {
            Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the instance.
        /// </summary>
        public override void Initialize()
        {
            // Clear any existing conditions
            Conditions.Clear();

            // Create our conditions
            var condition1 = new StateTransitionCondition(Threshold);

            // ...and add them to our collection of conditions
            Conditions.Add(condition1);
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
