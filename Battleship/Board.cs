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

        public void Print()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[col, row] + "  ");
                }
                Console.WriteLine();
            }
        }

        public void SetBlankBoard(string[,] x)
        {
            for (int row = 0; row < x.GetLength(0); row++)
            {
                for (int col = 0; col < x.GetLength(1); col++)
                {
                    x[col, row] = ".";
                }
            }
        }

        //public int setRows()
        //{
        //    Console.Write("How many rows will the board have?: ");
        //    int rows = int.Parse(Console.ReadLine());
        //    return rows;
        //}

        //public int setCols()
        //{
        //    Console.Write("How many columns will the board have?: ");
        //    int cols = int.Parse(Console.ReadLine());
        //    return cols;
        //}
    }
}
