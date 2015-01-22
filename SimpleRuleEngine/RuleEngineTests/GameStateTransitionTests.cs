using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngineTests.MockImplementation.Entities;
using RuleEngineTests.MockImplementation.Rules;
using RuleEngine.Engine;

namespace RuleEngineTests
{
    [TestClass]
    public class GameStateTransitionTests
    {
        #region StateTransitionRule

        [TestMethod]
        public void CanChangeRule_WhenValid_ReturnsTrue()
        {
            // ARRANGE
            GameStateTransition nullToIntro = new GameStateTransition(GameState.NullState, GameState.Intro);
            GameStateTransition introToMainMenu = new GameStateTransition(GameState.Intro, GameState.MainMenu);
            GameStateTransition mainMenuToNewGame = new GameStateTransition(GameState.MainMenu, GameState.NewGame);
            GameStateTransition actualTransition = new GameStateTransition(GameState.Intro, GameState.MainMenu);

            // ACT
            var transitionNullToIntro = new StateTransitionRule(nullToIntro, actualTransition);
            var transitionIntroToMainMenu = new StateTransitionRule(introToMainMenu, actualTransition);
            var transitionMainMenuToNewGame = new StateTransitionRule(mainMenuToNewGame, actualTransition);
            
            // Create the rule engine and add the rules
            var stateTransitionRuleEngine = new RuleEngine<GameStateTransition>();
            stateTransitionRuleEngine.Add(transitionNullToIntro);
            stateTransitionRuleEngine.Add(transitionIntroToMainMenu);
            stateTransitionRuleEngine.Add(transitionMainMenuToNewGame);

            // Get the result
            var result = stateTransitionRuleEngine.MatchAny();

            // ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanChangeRule_WhenInvalid_ReturnsFalse()
        {
            // ARRANGE
            GameStateTransition nullToIntro = new GameStateTransition(GameState.NullState, GameState.Intro);
            GameStateTransition introToMainMenu = new GameStateTransition(GameState.Intro, GameState.MainMenu);
            GameStateTransition mainMenuToNewGame = new GameStateTransition(GameState.MainMenu, GameState.NewGame);
            GameStateTransition actualTransition = new GameStateTransition(GameState.NullState, GameState.MainMenu);

            // ACT
            var transitionNullToIntro = new StateTransitionRule(nullToIntro, actualTransition);
            var transitionIntroToMainMenu = new StateTransitionRule(introToMainMenu, actualTransition);
            var transitionMainMenuToNewGame = new StateTransitionRule(mainMenuToNewGame, actualTransition);

            // Create the rule engine and add the rules
            var stateTransitionRuleEngine = new RuleEngine<GameStateTransition>();
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
