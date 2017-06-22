using System;
using Trivia.DataAccess;
using Trivia.Domain;
using Trivia.Presentation;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _winner;

        public static void Main(String[] args)
        {
            IQuestionUI questionUi = new ConsoleUI();
            IQuestionsRepository questionsRepository = new GeneratedQuestionsRepository();
            for (var i = 0; i < 10; i++)
            {
                var players = new Players(questionUi);
                players.Add("Chet");
                players.Add("Pat");
                players.Add("Sue");


                var questions = new Questions(new[] {"Pop", "Science", "Sports", "Rock"},questionsRepository, questionUi);

                var aGame = new Game(players, questions, questionUi);

                Random rand = new Random(i);

                do
                {
                    aGame.Roll(rand.Next(5) + 1);

                    if (rand.Next(9) == 7)
                    {
                        _winner = aGame.WrongAnswer();
                    }
                    else
                    {
                        _winner = aGame.WasCorrectlyAnswered();
                    }
                } while (!_winner);
            }
        }
    }
}

