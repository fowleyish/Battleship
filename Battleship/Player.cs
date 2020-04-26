using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
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
            field = new Board("battle field");
            referenceBoard = new Board("enemy reference board");
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

        public void Target(Player me, Player enemy)
        {
            ChooseSpace(me, enemy);
        }

        public void PlaceShips(Player player)
        {
            foreach (Ship ship in ships)
            {
                ShipUI(ship, player);
            }
            Console.Clear();
        }

        public void PlaceThisShip(string row, string col, string dir, Ship ship)
        {
            int row1 = int.Parse(row);
            int col1 = int.Parse(col);
            dir = dir.ToLower();
            switch (dir)
            {
                case "right":
                    for (int i = 0; i < ship.size; i++)
                    {
                        field.board[col1 - 1 + i, row1 - 1] = ship.name[0].ToString().ToUpper();
                    }
                    break;
                case "left":
                    for (int i = 0; i < ship.size; i++)
                    {
                        field.board[col1 - 1 - i, row1 - 1] = ship.name[0].ToString().ToUpper();
                    }
                    break;
                case "up":
                    for (int i = 0; i < ship.size; i++)
                    {
                        field.board[col1 - 1, row1 - 1 + i] = ship.name[0].ToString().ToUpper();
                    }
                    break;
                case "down":
                    for (int i = 0; i < ship.size; i++)
                    {
                        field.board[col1 - 1, row1 + 1 - i] = ship.name[0].ToString().ToUpper();
                    }
                    break;
            }
        }

        public void ShipUI(Ship ship, Player player)
        {
            Console.WriteLine("{0} SETUP", name.ToUpper());
            Console.WriteLine("Where will you place your {0}?", ship.name.ToUpper());
            field.Print(player, player.field);
            Console.Write("Row: ");
            string row = Console.ReadLine();
            Console.Write("Column: ");
            string col = Console.ReadLine();
            Console.Write("Which direction will the ship point? (Enter 'Up', 'Down', 'Left', or 'Right'): ");
            string dir = Console.ReadLine();
            try
            {
                bool isValid = ValidateSpot(row, col, dir, ship);
                if (isValid == true)
                {
                    PlaceThisShip(row, col, dir, ship);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("One or more spaces you chose overlaps with another ship. Press Enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    ShipUI(ship, player);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The coordinates you selected would put the ship off the grid. Please select new coordinates.");
                Console.WriteLine("Press Enter to retry");
                Console.ReadLine();
                Console.Clear();
                ShipUI(ship, player);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a numerical value.");
                Console.WriteLine("Press Enter to retry");
                Console.ReadLine();
                Console.Clear();
                ShipUI(ship, player);
            }
        }

        public void ChooseSpace(Player me, Player enemy)
        {
            Console.WriteLine("Which space will you target?");
            me.referenceBoard.Print(me, referenceBoard);
            Console.Write("Row: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Column: ");
            int col = int.Parse(Console.ReadLine());
            DetermineIfHit(row - 1, col - 1, me, enemy);
        }

        public void DetermineIfHit(int row, int col, Player me, Player enemy)
        {
            if (enemy.field.board[row, col] == ".")
            {
                me.referenceBoard.board[row, col] = "O";
                Console.WriteLine("Miss!");
            }
            else if (enemy.field.board[row, col] == "D" ||
                     enemy.field.board[row, col] == "S" ||
                     enemy.field.board[row, col] == "B" ||
                     enemy.field.board[row, col] == "A")
            {
                me.referenceBoard.board[row, col] = "X";
                switch (enemy.field.board[row, col])
                {
                    case "D":
                        enemy.destroyer.size -= 1;
                        if (enemy.destroyer.size == 0) {
                            enemy.shipCount -= 1;
                            Console.WriteLine("You sunk {0}'s DESTROYER!", enemy.name);
                        } 
                        else
                        {
                            Console.WriteLine("You hit {0}'s DESTROYER!", enemy.name);
                        }
                        break;
                    case "S":
                        enemy.submarine.size -= 1;
                        if (enemy.submarine.size == 0)
                        {
                            enemy.shipCount -= 1;
                            Console.WriteLine("You sunk {0}'s SUBMARINE!", enemy.name);
                        }
                        else
                        {
                            Console.WriteLine("You hit {0}'s SUBMARINE!", enemy.name);
                        }
                        break;
                    case "B":
                        enemy.battleship.size -= 1;
                        if (enemy.battleship.size == 0)
                        {
                            enemy.shipCount -= 1;
                            Console.WriteLine("You sunk {0}'s BATTLESHIP!", enemy.name);
                        }
                        else
                        {
                            Console.WriteLine("You hit {0}'s BATTLESHIP!", enemy.name);
                        }
                        break;
                    case "A":
                        enemy.aircraftCarrier.size -= 1;
                        if (enemy.aircraftCarrier.size == 0)
                        {
                            enemy.shipCount -= 1;
                            Console.WriteLine("You sunk {0}'s AIRCRAFT CARRIER!", enemy.name);
                        }
                        else
                        {
                            Console.WriteLine("You hit {0}'s AIRCRAFT CARRIER!", enemy.name);
                        }
                        break;
                }
                enemy.field.board[row, col] = "X";
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You've already hit this spot. Please select different coordinates.");
                ChooseSpace(me, enemy);
            }
        }

        public bool ValidateSpot(string row, string col, string dir, Ship ship)
        {
            int row1 = int.Parse(row);
            int col1 = int.Parse(col);
            dir = dir.ToLower();
            bool isLegit = true;
            switch (dir)
            {
                case "right":
                    for (int i = 0; i < ship.size; i++)
                    {
                        if (field.board[col1 - 1 + i, row1 - 1] == ".")
                        {
                            continue;
                        }
                        else
                        {
                            isLegit = false;
                            break;
                        }
                    }
                    break;
                case "left":
                    for (int i = 0; i < ship.size; i++)
                    {
                        if (field.board[col1 - 1 - i, row1 - 1] == ".")
                        {
                            continue;
                        }
                        else
                        {
                            isLegit = false;
                            break;
                        }
                    }
                    break;
                case "up":
                    for (int i = 0; i < ship.size; i++)
                    {
                        if (field.board[col1 - 1, row1 - 1 + i] == ".")
                        {
                            continue;
                        }
                        else
                        {
                            isLegit = false;
                            break;
                        }
                    }
                    break;
                case "down":
                    for (int i = 0; i < ship.size; i++)
                    {
                        if (field.board[col1 - 1, row1 + 1 - i] == ".")
                        {
                            continue;
                        }
                        else
                        {
                            isLegit = false;
                            break;
                        }
                    }
                    break;
            }
            if (isLegit == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
