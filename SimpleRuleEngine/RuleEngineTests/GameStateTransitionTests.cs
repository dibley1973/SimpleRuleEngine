using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Engine;
using RuleEngineTests.MockImplementation.Entities;
using RuleEngineTests.MockImplementation.Rules;

namespace RuleEngineTests
{
    [TestClass]
    public class GameStateTransitionTests
    {
        #region StateTransitionRule

        [TestMethod]
        public void StateTransitionRule_WhenValid_ReturnsTrue()
        {
            // ARRANGE
            GameStateTransition nullToIntro = new GameStateTransition(GameState.NullState, GameState.Intro);
            GameStateTransition introToMainMenu = new GameStateTransition(GameState.Intro, GameState.MainMenu);
            GameStateTransition mainMenuToNewGame = new GameStateTransition(GameState.MainMenu, GameState.NewGame);
            GameStateTransition actualTransition = new GameStateTransition(GameState.Intro, GameState.MainMenu);

            // ACT
            var transitionNullToIntro = new StateTransitionRule(nullToIntro);
            var transitionIntroToMainMenu = new StateTransitionRule(introToMainMenu);
            var transitionMainMenuToNewGame = new StateTransitionRule(mainMenuToNewGame);
            
            // Create the rule engine and add the rules
            var stateTransitionRuleEngine = new RuleEngine<GameStateTransition>();
            stateTransitionRuleEngine.ActualValue = actualTransition;

            stateTransitionRuleEngine.Add(transitionNullToIntro);
            stateTransitionRuleEngine.Add(transitionIntroToMainMenu);
            stateTransitionRuleEngine.Add(transitionMainMenuToNewGame);

            // Get the result
            var result = stateTransitionRuleEngine.MatchAny();

            // ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StateTransitionRule_WhenInvalid_ReturnsFalse()
        {
            // ARRANGE
            GameStateTransition nullToIntro = new GameStateTransition(GameState.NullState, GameState.Intro);
            GameStateTransition introToMainMenu = new GameStateTransition(GameState.Intro, GameState.MainMenu);
            GameStateTransition mainMenuToNewGame = new GameStateTransition(GameState.MainMenu, GameState.NewGame);
            GameStateTransition actualTransition = new GameStateTransition(GameState.NullState, GameState.MainMenu);

            // ACT
            var transitionNullToIntro = new StateTransitionRule(nullToIntro);
            var transitionIntroToMainMenu = new StateTransitionRule(introToMainMenu);
            var transitionMainMenuToNewGame = new StateTransitionRule(mainMenuToNewGame);

            // Create the rule engine and add the rules
            var stateTransitionRuleEngine = new RuleEngine<GameStateTransition>();
            stateTransitionRuleEngine.ActualValue = actualTransition;

            stateTransitionRuleEngine.Add(transitionNullToIntro);
            stateTransitionRuleEngine.Add(transitionIntroToMainMenu);
            stateTransitionRuleEngine.Add(transitionMainMenuToNewGame);

            // Get the result
            var result = stateTransitionRuleEngine.MatchAny();

            // ASSERT
            Assert.IsFalse(result);
        }

        #endregion
    }
}
