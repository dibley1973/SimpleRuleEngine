using RuleEngine.Contracts;
using System.Collections.Generic;

namespace RuleEngine.Base
{
    /// <summary>
    /// This is the base that all Rule objectss should in herit from
    /// </summary>
    /// <typeparam name="T">The Type of the object that the rule applies to</typeparam>
    public abstract class BaseRule<T> : IRule<T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value to apply the rule against.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets (or privately sets) the conditions which applies to the rule.
        /// </summary>
        /// <value>
        /// The conditions.
        /// </value>
        public IList<ICondition<T>> Conditions { get; private set; }

        /// <summary>
        /// Gets (or privately sets) the threshold.
        /// </summary>
        /// <value>
        /// The threshold.
        /// </value>
        protected T Threshold { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRule{T}"/> class.
        /// </summary>
        protected BaseRule(T threshold)
        {
            // Set the threshold
            Threshold = threshold;

            // Instantiate the conditions collection
            Conditions = new List<ICondition<T>>();
        }

        #endregion

        #region IRule<T> Members

        /// <summary>
        /// Clears all of the conditions.
        /// </summary>
        public void ClearConditions()
        {
            Conditions.Clear();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Matches the conditions. 
        /// </summary>
        /// <returns><c>true</c> if the conditions are met for the specified value</returns>
        /// <remarks>Override this to call with rule specific implementation. 
        /// For example through to one of the protected methods "MatchAllConditions" 
        /// or "MatchesAnyCondition"
        /// </remarks>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool MatchConditions()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Matches all of the rules.
        /// </summary>
        /// <returns><c>true</c> if all of the conditions are met for the specified value</returns>
        protected bool MatchAllConditions()
        {
            // We could use a lambda for ease, however in my case this project 
            // is to be used by Unity 3D so we will need to be aware that some 
            // Linq features are not available in all target langauges.
            //return Conditions.All(rule => rule.IsSatisfied);

            // Assume the conditions are all valid until proven otherwise
            bool isValid = true;

            // Start checking the conditions for any failures
            foreach (ICondition<T> condition in Conditions)
            {
                // Set the value
                condition.Value = Value;

                if (!condition.IsSatisfied)
                {
                    // We have a failure so set flag...
                    isValid = false;

                    // ...and bug out of the loop for performance
                    break;
                }
            }

            // return the result
            return isValid;
        }

        /// <summary>
        /// Matcheses any of the rules.
        /// </summary>
        /// <returns><c>true</c> if any of the conditions are met for the specified value</returns>
        protected bool MatchesAnyCondition()
        {
            // We could use a lambda for ease, however in my case this project 
            // is to be used by Unity 3D so we will need to be aware that some 
            // Linq features are not available in all target langauges.
            //return Conditions.Any(rule => rule.IsSatisfied);

            // Assume the conditions are NOT valid until proven otherwise
            bool isValid = false;

            // Start checking the conditions for any failures
            foreach (ICondition<T> condition in Conditions)
            {
                // Set the value
                condition.Value = Value;

                if (condition.IsSatisfied)
                {
                    // We have a pass so set flag...
                    isValid = true;

                    // ...and bug out of the loop for performance
                    break;
                }
            }

            // return the result
            return isValid;
        }

        #endregion
    }
}
