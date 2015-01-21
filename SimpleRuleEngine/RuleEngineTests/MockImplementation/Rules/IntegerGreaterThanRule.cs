using RuleEngine.Base;
using RuleEngineTests.MockImplementation.Conditions;

namespace RuleEngineTests.MockImplementation.Rules
{
    internal class IntegerGreaterThanRule : BaseRule<int>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanRule"/> class.
        /// </summary>
        public IntegerGreaterThanRule() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        /// <param name="actual">The actual.</param>
        public IntegerGreaterThanRule(int threshold, int actual)
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
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Initialize(int threshold, int actual)
        {
            // Clear any existing conditions
            Conditions.Clear();

            // Create our conditions
            var condition1 = new IntegerGreaterThanCondition(threshold, actual);

            // ...and add them to our collection of conditions
            Conditions.Add(condition1);
        }

        /// <summary>
        /// Matches the conditions.
        /// </summary>
        /// <returns></returns>
        public override bool MatchConditions()
        {
            return base.MatchesAnyCondition();
        }

        #endregion
    }
}