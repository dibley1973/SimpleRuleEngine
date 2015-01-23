
namespace RuleEngine.Contracts
{
    /// <summary>
    /// Defines the expected members of a Rule object
    /// </summary>
    public interface IRule<T>
    {
        /// <summary>
        /// Clears all of the conditions.
        /// </summary>
        void ClearConditions();

        /// <summary>
        /// Matches the conditions.
        /// </summary>
        /// <returns><c>true</c> if the conditions are met for the specified value</returns>
        bool MatchConditions();

        /// <summary>
        /// Gets or sets the value to apply the rule against.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        T Value { get; set; }
    }
}