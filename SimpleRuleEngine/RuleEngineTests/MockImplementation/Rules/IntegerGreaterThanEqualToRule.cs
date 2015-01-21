using RuleEngine.Base;
using RuleEngineTests.MockImplementation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineTests.MockImplementation.Rules
{
    internal class IntegerGreaterThanEqualToRule : BaseRule<int>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanRule"/> class.
        /// </summary>
        public IntegerGreaterThanEqualToRule() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        /// <param name="actual">The actual.</param>
        public IntegerGreaterThanEqualToRule(int threshold, int actual)
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
            var condition2 = new IntegerEqualToCondition(threshold, actual);

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