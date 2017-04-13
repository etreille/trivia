using System;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players;

        private readonly Questions _questions = new Questions();

        private bool _isGettingOutOfPenaltyBox;


        public Game(Players players)
        {
            _players = players;
        }
        
        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players.Current.Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players.Current.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players.Current.Name + " is getting out of the penalty box");
                    _players.Current.Move(roll);

                    Console.WriteLine(_players.Current.Name
                            + "'s new location is "
                            + _players.Current.Place);
                    Console.WriteLine(_questions.AskQuestion(_players.Current.Place));
                }
                else
                {
                    Console.WriteLine(_players.Current.Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.Current.Move(roll);

                Console.WriteLine(_players.Current.Name
                        + "'s new location is "
                        + _players.Current.Place);
                Console.WriteLine(_questions.AskQuestion(_players.Current.Place));
            }

        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.Current.InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players.Current.WinAGoldCoin();

                    winner = _players.Current.IsWinner();
                    _players.NextPlayer();

                    return winner;
                }

                _players.NextPlayer();
                return false;
            }

            Console.WriteLine("Answer was corrent!!!!");
            _players.Current.WinAGoldCoin();

            winner = _players.Current.IsWinner();
            _players.NextPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players.Current.Name + " was sent to the penalty box");
            _players.Current.GoToPenaltyBox();

            _players.NextPlayer();
            return false;
        }
    }
}
