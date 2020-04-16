using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
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
            ControlTurns();
        }

        public void PlayerBoardSetup(Player player)
        {
            Console.WriteLine("Welcome to a new game, {0}!", player.name);
            player.field.Print(player, player.field);
            Console.WriteLine("Press Enter to place your ships");
            Console.ReadLine();
            Console.Clear();
            player.PlaceShips(player);
            player.field.Print(player, player.field);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void ControlTurns()
        {
            Player currentPlayer = playerOne;
            while (playerOne.shipCount > 0 && playerTwo.shipCount > 0)
            {
                Console.WriteLine(currentPlayer.name.ToUpper() + "'s Turn");
                string selection = DisplayMenu();
                while (selection != "3") {
                    switch (selection) {
                        case "1":
                            currentPlayer.field.Print(currentPlayer, currentPlayer.field);
                            Console.WriteLine("Press Enter to go back to the menu");
                            Console.ReadLine();
                            selection = DisplayMenu();
                            break;
                        case "2":
                            currentPlayer.referenceBoard.Print(currentPlayer, currentPlayer.referenceBoard);
                            Console.WriteLine("Press Enter to go back to the menu");
                            Console.ReadLine();
                            selection = DisplayMenu();
                            break;
                        case "3":
                            currentPlayer.Target();
                            break;
                    }
                }
                if (currentPlayer == playerOne)
                {
                    currentPlayer = playerTwo;
                }
                else
                {
                    currentPlayer = playerOne;
                }
            }
        }

        public string DisplayMenu()
        {
            Console.WriteLine("Select a number from the following choices: ");
            Console.WriteLine("1. View my board");
            Console.WriteLine("2. View enemy reference board");
            Console.WriteLine("3. View enemy reference board");
            int choice = int.Parse(Console.ReadLine());
            if (choice < 1 || choice > 3)
            {
                Console.WriteLine("Please enter a valid menu option number");
                DisplayMenu();
            }
            Console.Clear();
            return choice.ToString();
        }

    }
}
