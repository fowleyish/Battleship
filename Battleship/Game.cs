using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Game
    {

        public Player playerOne;
        public Player playerTwo;

        public Game()
        {
            playerOne = new Player("Player 1");
            playerTwo = new Player("Player 2");
        }

        public void Setup()
        {
            PlayerBoardSetup(playerOne);
            PlayerBoardSetup(playerTwo);
        }

        public void PlayerBoardSetup(Player player)
        {
            Console.WriteLine("Welcome to a new game, {0}!", player.name);
            Console.WriteLine("Your board is currently blank:");
            player.field.Print();
            Console.WriteLine("Press Enter to place your ships");
            Console.ReadLine();
            Console.Clear();
            player.PlaceShips();
            Console.WriteLine("Here is your field: ");
            player.field.Print();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void ControlTurns()
        {
            while (playerOne.shipCount > 0 && playerTwo.shipCount > 0)
            {
                //SelectTarget();
                //DetermineIfHit();
            }
        }

    }
}
