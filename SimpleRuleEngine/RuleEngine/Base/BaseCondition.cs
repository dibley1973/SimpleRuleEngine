using RuleEngine.Contracts;
using System;

namespace RuleEngine.Base
{
    /// <summary>
    /// This is the base condition that all conditions should inherit from.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseCondition<T> : ICondition<T>
    {
        #region Properties

        /// <summary>
        /// Gets the threshold.
        /// </summary>
        /// <value>
        /// The threshold.
        /// </value>
        protected T Threshold { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCondition{T}"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        protected BaseCondition(T threshold)
        {
            Threshold = threshold;
        }

        #endregion

        #region ICondition<int> Members

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSatisfied
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Concat(
                GetType(),
                " T:",
                Threshold,
                " V:",
                Value
            );
        }

        #endregion
    }
}
