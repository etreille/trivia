using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Players
    {
        private readonly List<Player> _players = new List<Player>();
        private readonly IQuestionUI _questionUi;

        public Players(IQuestionUI questionUi)
        {
            _questionUi = questionUi;
        }

        public Player Current { get; private set; }

        public void NextPlayer()
        {
            var nextPlayer = _players.IndexOf(Current) + 1;
            if (nextPlayer == _players.Count) nextPlayer = 0;
            Current = _players[nextPlayer];
        }

        public bool Add(string playerName)
        {
            var player = new Player(playerName, _questionUi);
            if (!_players.Any())
            {
                Current = player;
            }
            _players.Add(player);

            _questionUi.Display(playerName + " was added");
            _questionUi.Display("They are player number " + _players.Count);
            return true;
        }
    }
}
