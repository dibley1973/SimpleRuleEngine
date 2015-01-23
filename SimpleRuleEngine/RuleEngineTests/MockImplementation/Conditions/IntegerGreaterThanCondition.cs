using RuleEngine.Base;
using RuleEngine.Contracts;

namespace RuleEngineTests.MockImplementation.Conditions
{
    internal class IntegerGreaterThanCondition : BaseCondition<int>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualsCondition{T}"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        /// <param name="actual">The actual value.</param>
        public IntegerGreaterThanCondition(int threshold)
            : base(threshold) { }

        #endregion

        #region ICondition<int> methods

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied
        {
            get { return Value > Threshold; }
        }

        #endregion
    }
}
