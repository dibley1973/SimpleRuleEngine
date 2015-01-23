using RuleEngine.Base;
using RuleEngineTests.MockImplementation.Conditions;

namespace RuleEngineTests.MockImplementation.Rules
{
    internal class IntegerGreaterThanEqualToRule : BaseRule<int>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        public IntegerGreaterThanEqualToRule(int threshold)
            : base(threshold)
        {
            Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            // Clear any existing conditions
            ClearConditions();

            // Create our conditions
            var condition1 = new IntegerGreaterThanCondition(Threshold);
            var condition2 = new IntegerEqualToCondition(Threshold);

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
            return base.MatchesAnyCondition();
        }

        #endregion
    }
}