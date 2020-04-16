using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Ship
    {
        // Member variables
        public int size;
        public int[,] placement;

        public Ship(int size)
        {
            this.size = size;
        }
    }
}
