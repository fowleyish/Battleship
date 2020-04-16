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
        public int shipCount;

        // Constructor
        public Player(string player)
        {
            name = GetName(player);
            destroyer = new Ship(2);
            submarine = new Ship(3);
            battleship = new Ship(4);
            aircraftCarrier = new Ship(5);
            shipCount = 4;
        }

        // Member methods

        // Get name on creation
        public string GetName(string player)
        {
            Console.Write("What is {0}'s name?: ", player);
            return Console.ReadLine();
        }

        public void Target()
        {

        }

    }
}
