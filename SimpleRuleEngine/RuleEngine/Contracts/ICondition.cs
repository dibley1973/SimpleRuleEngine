
namespace RuleEngine.Contracts
{
    /// <summary>
    /// Defines the expected membeers of a Condition object
    /// </summary>
    public interface ICondition<T>
    {
        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        bool IsSatisfied { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        T Value { get; set;  }
    }
}