using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Game
    {
        public Board board;
        public Player playerOne;
        public Player playerTwo;

        public Game()
        {
            board = new Board();
            playerOne = new Player("Player 1");
            playerTwo = new Player("Player 2");
        }

    }
}
