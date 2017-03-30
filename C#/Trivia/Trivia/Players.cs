using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Trivia
{
    internal class Players
    {
        public Player Current { get; private set; }
        private List<Player> ListPlayers { get; set; }

        public Players()
        {
            ListPlayers = new List<Player>();
        }

        public void Add(Player player)
        {
            ListPlayers.Add(player);

            if (Current == null)
            {
                Current = player;
            }
        }

        public int Count()
        {
            return ListPlayers.Count;
        }

        public void UpdateCurrent()
        {
            if (Current == ListPlayers[ListPlayers.Count-1] )
                Current = ListPlayers[0];
            else
                Current = ListPlayers[ListPlayers.IndexOf(Current) + 1];
        }


    }
}