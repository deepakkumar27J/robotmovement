// See https://aka.ms/new-console-template for more information
using System;

namespace GridApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            GridData gridData = new GridData();
            int maxGridValue = 5;
            while (true)
            {
                //Console keeps all the command until it get report on already placed robot
                Console.WriteLine("Enter command:");
                string input = Console.ReadLine();

                // Displays the current position of the robot and exits the application
                if (input.ToLower() == "report" && gridData.IsPlaced)
                {
                    Console.WriteLine($"{gridData.CurrentX},{gridData.CurrentY},{gridData.CurrentDirection.ToUpper()}");
                    break;
                }

                // input is converted into proper command including paramteres for PLACE command
                ProcessCommand(gridData, input, maxGridValue);
            }

        }

        static void ProcessCommand(GridData gridDataObj, string input, int maxGridValue)
        {
            string[] parts = input.Split(' ');

            if (parts.Length < 1)
            {
                Console.WriteLine("Invalid command");
                return;
            }

            // This is actual command Move, Left, Right, Place and Report
            string command = parts[0];

            // If it is Place command then it will have 3 more parameters x, y and direction otherwise
            // empty and not used 
            string[] parameterParts = (parts.Length > 1 && !string.IsNullOrEmpty(parts[1])) ? parts[1].Split(',') : new string[] { "", "", "" };

            // This calls the functions of GridData class to execute the respective command
            ExecuteThisCommand(gridDataObj, command, parameterParts, maxGridValue);
        }

        

        static void ExecuteThisCommand(GridData gridData, string command, string[] parameters, int maxGridValue)
        {
                switch (command.ToLower())
                {
                    case "place":
                        if (parameters.Length == 3 &&
                            int.TryParse(parameters[0], out int x) &&
                            int.TryParse(parameters[1], out int y))
                        {
                            if (x <= maxGridValue && y <= maxGridValue)
                            {
                                gridData.Place(x, y, parameters[2], maxGridValue);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid PLACE command. X and Y must be less than or equal to {maxGridValue}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid PLACE command. Format: PLACE X,Y,DIRECTION");
                        }
                        break;

                    case "move":
                        if (gridData.IsPlaced)
                        {
                            gridData.Move();
                        }
                        else
                        {
                            Console.WriteLine("Cannot MOVE. Robot is not placed on the grid.");
                        }
                        break;

                    case "left":
                        if (gridData.IsPlaced)
                        {
                            gridData.TurnLeft();
                        }
                        else
                        {
                            Console.WriteLine("Cannot turn LEFT. Robot is not placed on the grid.");
                        }
                        break;

                    case "right":
                        if (gridData.IsPlaced)
                        {
                            gridData.TurnRight();
                        }
                        else
                        {
                            Console.WriteLine("Cannot turn RIGHT. Robot is not placed on the grid.");
                        }
                        break;

                    case "report":
                        // Already Handled separately in main loop
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
    }

    public class GridData
    {
        public bool IsPlaced { get; private set; }
        public int CurrentX { get; private set; }
        public int CurrentY { get; private set; }
        public string CurrentDirection { get; private set; }

        public GridData()
        {
            IsPlaced = false;
            CurrentX = 0;
            CurrentY = 0;
            CurrentDirection = null;

        }

        // place the robot on table also varifies the max grid value before putting it
        public void Place(int x, int y, string direction, int maxGridValue)
        {
            if (x <= maxGridValue && y <= maxGridValue)
            {
                CurrentX = x;
                CurrentY = y;
                CurrentDirection = direction.ToLower();
                IsPlaced = true;
            } else
            {
                IsPlaced = false;
            }
        }

        // based on the direction the relevant value is either added or subtracted from
        // the respective cordinate
        public void Move()
        {
            switch (CurrentDirection)
            {
                case "east":
                    CurrentX = (CurrentX < 5) ? CurrentX + 1 : CurrentX;
                    break;
                case "west":
                    CurrentX = (CurrentX > 0) ? CurrentX - 1 : CurrentX;
                    break;
                case "north":
                    CurrentY = (CurrentY < 5) ? CurrentY + 1 : CurrentY;
                    break;
                case "south":
                    CurrentY = (CurrentY > 0) ? CurrentY - 1 : CurrentY;
                    break;
                default:
                    break;
            }
        }

        //changes direction based on current direction
        public void TurnLeft()
        {
            switch (CurrentDirection)
            {
                case "east":
                    CurrentDirection = "north";
                    break;
                case "west":
                    CurrentDirection = "south";
                    break;
                case "north":
                    CurrentDirection = "west";
                    break;
                case "south":
                    CurrentDirection = "east";
                    break;
                default:
                    break;
            }
        }

        //changes direction based on current direction
        public void TurnRight()
        {
            switch (CurrentDirection)
            {
                case "east":
                    CurrentDirection = "south";
                    break;
                case "west":
                    CurrentDirection = "north";
                    break;
                case "north":
                    CurrentDirection = "east";
                    break;
                case "south":
                    CurrentDirection = "west";
                    break;
                default:
                    break;
            }
        }


    }
}

