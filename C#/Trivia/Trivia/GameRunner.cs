using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool winner;

        public static void Main(String[] args)
        {
            IQuestionUI _questionUi = new ConsoleUI();
            IQuestionsRepository questionsRepository = new GeneratedQuestionsRepository();
            for (var i = 0; i < 10; i++)
            {
                var players = new Players(_questionUi);
                players.Add("Chet");
                players.Add("Pat");
                players.Add("Sue");


                var questions = new Questions(new[] {"Pop", "Science", "Sports", "Rock"},questionsRepository, _questionUi);

                var aGame = new Game(players, questions, _questionUi);

                Random rand = new Random(i);

                do
                {
                    aGame.Roll(rand.Next(5) + 1);

                    if (rand.Next(9) == 7)
                    {
                        winner = aGame.WrongAnswer();
                    }
                    else
                    {
                        winner = aGame.WasCorrectlyAnswered();
                    }
                } while (!winner);
            }
        }
    }
}

