using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Engine;
using RuleEngineTests.MockImplementation.Rules;

namespace RuleEngineTests
{
    [TestClass]
    public class IntegerTests
    {
        #region GreaterThanRule

        [TestMethod]
        public void GreaterThanRule_WhenGreater_ResultsTrue()
        {
            // ARRANGE
            int threshold = 5;
            int actual = 10;

            // ACT
            var integerRule = new IntegerGreaterThanRule();
            integerRule.Initialize(threshold, actual);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.Add(integerRule);
            var result = integerRuleEngine.MatchAll();

            // ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanRule_WhenLess_ResultsFalse()
        {
            // ARRANGE
            int threshold = 5;
            int actual = 3;

            // ACT
            var integerRule = new IntegerGreaterThanRule();
            integerRule.Initialize(threshold, actual);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.Add(integerRule);
            var result = integerRuleEngine.MatchAll();


            // ASSERT
            Assert.IsFalse(result);
        }

        #endregion

        #region IntegerGreaterThanEqualToRule

        [TestMethod]
        public void IntegerGreaterThanEqualToRule_WhenGreater_ResultsTrue()
        {
            // ARRANGE
            int threshold = 5;
            int actual = 10;

            // ACT
            var integerRule = new IntegerGreaterThanEqualToRule();
            integerRule.Initialize(threshold, actual);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.Add(integerRule);
            var result = integerRuleEngine.MatchAny();

            // ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntegerGreaterThanEqualToRule_WhenEqualTo_ResultsTrue()
        {
            // ARRANGE
            int threshold = 5;
            int actual = 5;

            // ACT
            var integerRule = new IntegerGreaterThanEqualToRule();
            integerRule.Initialize(threshold, actual);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.Add(integerRule);
            var result = integerRuleEngine.MatchAny();

            // ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntegerGreaterThanEqualToRule_WhenLessThan_ResultsFalse()
        {
            // ARRANGE
            int threshold = 5;
            int actual = 3;

            // ACT
            var integerRule = new IntegerGreaterThanEqualToRule();
            integerRule.Initialize(threshold, actual);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.Add(integerRule);
            var result = integerRuleEngine.MatchAny();

            // ASSERT
            Assert.IsFalse(result);
        }

        #endregion
    }
}
