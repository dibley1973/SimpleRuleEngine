using RuleEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RuleEngine.Engine
{
    public class RuleEngine<T>
    {
        #region Properties

        /// <summary>
        /// Gets (or privately sets) the set of rules.
        /// </summary>
        /// <value>The rules.</value>
        protected List<IRule<T>> RuleSet { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateTransitionRuleEngine"/> class
        /// with an empty rule set.
        /// </summary>
        public RuleEngine()
            : this(new List<IRule<T>>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateTransitionRuleEngine"/> class
        /// with the specified rule set.
        /// </summary>
        /// <param name="ruleSet"> the rule set to initialise with.</param>
        public RuleEngine(List<IRule<T>> ruleSet)
        {
            this.RuleSet = ruleSet;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add the specified rule.
        /// </summary>
        /// <param name="rule">Rule.</param>
        public void Add(IRule<T> rule)
        {
            // Assertions
            Debug.Assert(rule != null);
            Debug.Assert(!RuleExists(rule));

            // Guard against a NULL rule
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            // Guard against the rule already existing
            if (RuleExists(rule))
            {
                throw new ArgumentException("rule");
            }

            // Add the rule
            RuleSet.Add(rule);
        }

        /// <summary>
        /// Clears the rule set.
        /// </summary>
        public void ClearRuleSet()
        {
            RuleSet.Clear();
        }

        /// <summary>
        /// Matches all rules.
        /// </summary>
        /// <returns></returns>
        public bool MatchAll()
        {
            // Set the default result to be a pass 
            bool result = true;

            // Check through all rules looking for a single failure
            for (int index = 0; index < RuleSet.Count; index += 1)
            {
                IRule<T> currentRule = RuleSet[index];
                if (!currentRule.MatchConditions())
                {
                    result = false;
                    break; // for performance 
                }
            }

            // return the result
            return result;
        }

        /// <summary>
        /// Matches any rules.
        /// </summary>
        /// <returns></returns>
        public bool MatchAny()
        {
            // Set the default result to be failure 
            bool result = false;

            // Check through all rules looking for a single pass
            for (int index = 0; index < RuleSet.Count; index += 1)
            {
                IRule<T> currentRule = RuleSet[index];
                if (currentRule.MatchConditions())
                {
                    result = true;
                    break; // for performance 
                }
            }

            // return the result
            return result;
        }

        /// <summary>
        /// Checks if the specified rule exists.
        /// </summary>
        /// <param name="rule">Rule.</param>
        public bool RuleExists(IRule<T> rule)
        {
            // Set the default result to be failure 
            bool result = false;

            // Check through all rules looking for a match
            for (int index = 0; index < RuleSet.Count; index += 1)
            {
                IRule<T> currentRule = RuleSet[index];
                if (currentRule.Equals(rule))
                {
                    result = true;
                    break; // for performance 
                }
            }

            // return the result
            return result;
        }

        #endregion
    }
}