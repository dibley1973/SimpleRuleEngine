using RuleEngine.Base;
using RuleEngine.Contracts;
using RuleEngineTests.MockImplementation.Entities;

namespace RuleEngineTests.MockImplementation.Conditions
{
    public class StateTransitionCondition : BaseCondition<GameStateTransition>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StateTransitionCondition"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        public StateTransitionCondition(GameStateTransition threshold)
            : base(threshold) { }

        #endregion

        #region ICondition<int> Members

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied
        {
            get { return Value.Equals(Threshold); }
        }

        #endregion
    }
}