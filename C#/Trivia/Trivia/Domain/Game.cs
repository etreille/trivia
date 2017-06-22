namespace Trivia.Domain
{
    public class Game
    {

        private readonly Players _players;

        private readonly Questions _questions;

        private readonly IQuestionUI _questionUi;

        //private IDispatchEvent _eventDispatcher;

        bool _isGettingOutOfPenaltyBox;


        public Game(Players players, Questions questions, IQuestionUI questionUi)
        {
            _players = players;
            _questions = questions;
            _questionUi = questionUi;
        }

        public void Roll(int roll)
        {
            //_eventDispatcher.Dispatch(new CurrentPlayerRolledTheDice(_players.Current.Name, roll));
            _questionUi.Display(_players.Current.Name + " is the current player");
            _questionUi.Display("They have rolled a " + roll);

            if (_players.Current.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    _questionUi.Display(_players.Current.Name + " is getting out of the penalty box");
                    _players.Current.Move(roll);

                    _questionUi.Display(_players.Current.Name
                            + "'s new location is "
                            + _players.Current.Place);
                    _questions.AskQuestion(_players.Current.Place);
                }
                else
                {
                    _questionUi.Display(_players.Current.Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.Current.Move(roll);

                _questionUi.Display(_players.Current.Name
                        + "'s new location is "
                        + _players.Current.Place);
                _questions.AskQuestion(_players.Current.Place);
            }

        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.Current.InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    _questionUi.Display("Answer was correct!!!!");
                    _players.Current.WinAGoldCoin();

                    winner = _players.Current.IsWinner();
                    _players.NextPlayer();

                    return winner;
                }

                _players.NextPlayer();
                return false;
            }

            _questionUi.Display("Answer was corrent!!!!");
            _players.Current.WinAGoldCoin();

            winner = _players.Current.IsWinner();
            _players.NextPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            _questionUi.Display("Question was incorrectly answered");
            _questionUi.Display(_players.Current.Name + " was sent to the penalty box");
            _players.Current.GoToPenaltyBox();

            _players.NextPlayer();
            return false;
        }
    }
}
