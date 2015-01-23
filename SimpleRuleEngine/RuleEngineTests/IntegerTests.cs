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
            var integerRule = new IntegerGreaterThanRule(threshold);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.ActualValue = actual;
            integerRuleEngine.Add(integerRule);

            // Get the result
            var result = integerRuleEngine.MatchAll();

            // ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanRule_WhenEqual_ResultsFalse()
        {
            // ARRANGE
            int threshold = 5;
            int actual = 5;

            // ACT
            var integerRule = new IntegerGreaterThanRule(threshold);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.ActualValue = actual;
            integerRuleEngine.Add(integerRule);

            // Get the result
            var result = integerRuleEngine.MatchAll();


            // ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GreaterThanRule_WhenLess_ResultsFalse()
        {
            // ARRANGE
            int threshold = 5;
            int actual = 3;

            // ACT
            var integerRule = new IntegerGreaterThanRule(threshold);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.ActualValue = actual;
            integerRuleEngine.Add(integerRule);

            // Get the result
            var result = integerRuleEngine.MatchAll();


            // ASSERT
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void GreaterThanRule_MultipleValuesWhenGreater_ResultsTrueForAll()
        {
            // ARRANGE
            int threshold = 5;
            int actual1 = 7;
            int actual2 = 10;

            // ACT
            var integerRule = new IntegerGreaterThanRule(threshold);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.Add(integerRule);

            // Set the first actual and get the result
            integerRuleEngine.ActualValue = actual1;
            var result1 = integerRuleEngine.MatchAll();

            // Set the second actual and get the result
            integerRuleEngine.ActualValue = actual2;
            var result2 = integerRuleEngine.MatchAll();

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
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
            var integerRule = new IntegerGreaterThanEqualToRule(threshold);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.ActualValue = actual;
            integerRuleEngine.Add(integerRule);

            // Get the result
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
            var integerRule = new IntegerGreaterThanEqualToRule(threshold);
            //integerRule.Initialize(threshold, actual);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.ActualValue = actual;
            integerRuleEngine.Add(integerRule);

            // Get the result
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
            var integerRule = new IntegerGreaterThanEqualToRule(threshold);

            var integerRuleEngine = new RuleEngine<int>();
            integerRuleEngine.ActualValue = actual;
            integerRuleEngine.Add(integerRule);

            // Get the result
            var result = integerRuleEngine.MatchAny();

            // ASSERT
            Assert.IsFalse(result);
        }

        #endregion
    }
}