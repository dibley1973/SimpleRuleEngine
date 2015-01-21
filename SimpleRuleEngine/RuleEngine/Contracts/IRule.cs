
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
        /// Initializes the object with the specified threshold and value.
        /// </summary>
        /// <param name="threshold">The threshold to check value against.</param>
        /// <param name="value">The value to check.</param>
        void Initialize(T threshold, T value);

        /// <summary>
        /// Matches the conditions.
        /// </summary>
        /// <returns></returns>
        bool MatchConditions();
    }
}