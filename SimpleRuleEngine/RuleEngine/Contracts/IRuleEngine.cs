
namespace RuleEngine.Contracts
{
    /// <summary>
    /// Defines the expected members of a RuleEngine
    /// </summary>
    public interface IRuleEngine
    {
        /// <summary>
        /// Matches all rules.
        /// </summary>
        /// <returns></returns>
        bool MatchAllRules();

        /// <summary>
        /// Matcheses any rule.
        /// </summary>
        /// <returns></returns>
        bool MatchesAnyRule();
    }
}