using System;
using System.Collections.Generic;
using Nancy.ModelBinding;
using Trivia.DataAccess;
using Trivia.Domain;
using Trivia.Presentation;

namespace Trivia.WebAPI
{
    public class TriviaModule : Nancy.NancyModule
    {

        private static Game _game;
        private static WebUI _questionUi;

        public TriviaModule()
        {
            Post["/newGame"] = NewGame;
            Post["/roll"] = Roll;
        }

        private dynamic Roll(dynamic o)
        {
            _questionUi.Clear();
            var random = new Random();
            _game.Roll(random.Next(5)+1);
            return _questionUi.Message;
        }

        //comme du JS ou du PHP en c#
        private dynamic NewGame(dynamic o)
        {
            var newGame = this.Bind<NewGame>();

            _questionUi = new WebUI();
            var players = new Players(_questionUi);
            foreach (var userName in newGame.UserNames)
            {
                players.Add(userName);
            }

            var questions = new Questions(newGame.QuestionCategories, new GeneratedQuestionsRepository(), _questionUi);

            _game = new Game(players, questions, _questionUi);

            return _questionUi.Message;
        }

    }

    internal class WebUI : IQuestionUI
    {
        public void Display(string message)
        {
            Message += message+"\n";
        }

        public string Message { get; private set; }

        public void Clear()
        {
            Message = string.Empty;
        }
    }

    public class NewGame
    {
        public List<string> UserNames { get; set; }
        public List<string> QuestionCategories { get; set; }
    
    }
}
