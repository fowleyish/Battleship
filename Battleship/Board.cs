using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Board
    {
        // Member vars
        public string[,] board;

        // Constructor
        public Board()
        {
            board = new string[20, 20];
        }
    }
}
