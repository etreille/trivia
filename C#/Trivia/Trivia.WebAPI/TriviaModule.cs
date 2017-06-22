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
        public TriviaModule()
        {
            Post["/newGame"] = NewGame;
        }
        //comme du JS ou du PHP en c#
        private dynamic NewGame(dynamic o)
        {
            var newGame = this.Bind<NewGame>();

            var questionUi = new WebUI();
            var players = new Players(questionUi);
            foreach (var userName in newGame.UserNames)
            {
                players.Add(userName);
            }

            var questions = new Questions(newGame.QuestionCategories, new GeneratedQuestionsRepository(), questionUi);

            var game = new Game(players, questions, questionUi);

            return questionUi.Message;
        }
    }

    internal class WebUI : IQuestionUI
    {
        public void Display(string message)
        {
            Message += message+"\n";
        }

        public string Message { get; private set; }
    }

    public class NewGame
    {
        public List<string> UserNames { get; set; }
        public List<string> QuestionCategories { get; set; }
    
    }
}
