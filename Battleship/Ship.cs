using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Ship
    {
        // Member variables
        public int size;
        public string name;
        public int[,] placement;

        public Ship(int size, string name)
        {
            this.size = size;
            this.name = name;
        }
    }
}
