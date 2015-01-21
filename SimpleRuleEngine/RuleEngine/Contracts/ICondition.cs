
namespace RuleEngine.Contracts
{
    /// <summary>
    /// Defines the expected membeers of a Condition object
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        bool IsSatisfied { get; }
    }
}