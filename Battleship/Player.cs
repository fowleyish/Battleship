using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Player
    {
        // Member variables
        public string name;
        public Ship destroyer;
        public Ship submarine;
        public Ship battleship;
        public Ship aircraftCarrier;
        public Ship[] ships;
        public int shipCount;
        public Board field;
        public Board referenceBoard;

        // Constructor
        public Player(string player)
        {
            name = GetPlayer(player);
            destroyer = new Ship(2, "destroyer");
            submarine = new Ship(3, "submarine");
            battleship = new Ship(4, "battleship");
            aircraftCarrier = new Ship(5, "aircraft carrier");
            ships = new Ship[] { destroyer, submarine, battleship, aircraftCarrier};
            shipCount = 4;
            field = new Board();
            referenceBoard = new Board();
            field.SetBlankBoard(field.board);
            referenceBoard.SetBlankBoard(referenceBoard.board);
        }

        // Member methods

        // Get name on creation
        public string GetPlayer(string player)
        {
            Console.Write("What is {0}'s name?: ", player);
            return Console.ReadLine();
        }

        public void Target()
        {

        }

        public void PlaceShips()
        {
            foreach (Ship ship in ships)
            {
                Console.WriteLine("{0} SETUP", name.ToUpper());
                Console.WriteLine("Where will you place your {0}?", ship.name.ToUpper());
                field.Print();
                Console.Write("Row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Column: ");
                int col = int.Parse(Console.ReadLine());
                for (int i = 0; i < ship.size; i++)
                {
                    field.board[col + i, row] = ship.name[0].ToString().ToUpper();
                }
                Console.Clear();
            }
        }


    }
}
