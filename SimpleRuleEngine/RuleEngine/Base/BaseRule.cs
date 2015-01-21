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
        /// Gets (or privately sets) the conditions which applies to the rule.
        /// </summary>
        /// <value>
        /// The conditions.
        /// </value>
        public IList<ICondition> Conditions { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRule{T}"/> class.
        /// </summary>
        protected BaseRule()
        { 
            // Instantiate the conditions collection
            Conditions = new List<ICondition>();
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
        /// Initializes the object with the specified threshold and value.
        /// </summary>
        /// <param name="threshold">The threshold value to check value against.</param>
        /// <param name="actual">The actualvalue to check.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Initialize(T threshold, T actual)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Matches the conditions. 
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
        protected bool MatchAllConditions()
        {
            // We could use a lambda for ease, however in my case this project 
            // is to be used by Unity 3D so we will need to 
            //return Conditions.All(rule => rule.IsSatisfied);

            // Assume the conditions are all valid until proven otherwise
            bool isValid = true;

            // Start checking the conditions for any failures
            foreach (ICondition condition in Conditions)
            {
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
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected bool MatchesAnyCondition()
        {
            // We could use a lambda for ease, however in my case this project 
            // is to be used by Unity 3D so we will need to 
            //return Conditions.Any(rule => rule.IsSatisfied);

            // Assume the conditions are NOT valid until proven otherwise
            bool isValid = false;

            // Start checking the conditions for any failures
            foreach (ICondition condition in Conditions)
            {
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
