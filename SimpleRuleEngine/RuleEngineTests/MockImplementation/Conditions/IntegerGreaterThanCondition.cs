using RuleEngine.Contracts;

namespace RuleEngineTests.MockImplementation.Conditions
{
    internal class IntegerGreaterThanCondition : ICondition
    {
        #region Fields

        private readonly int _actual;
        private readonly int _threshold;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualsCondition{T}"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        /// <param name="actual">The actual value.</param>
        public IntegerGreaterThanCondition(int threshold, int actual)
        {
            _threshold = threshold;
            _actual = actual;
        }

        #endregion

        #region ICondition methods

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public bool IsSatisfied
        {
            get { return _actual > _threshold; }
        }

        #endregion
    }
}
