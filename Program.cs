// See https://aka.ms/new-console-template for more information
using System;

namespace GridApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[5, 5];
            InitializeGrid(grid);

            while (true)
            {
                Console.WriteLine("Enter command (e.g., 'command param1 param2 ...') or 'exit' to quit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                ProcessCommand(input, grid);
            }
        }

        static void InitializeGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = 0; // Initialize all cells to 0 or any default value
                }
            }

            PrintGrid(grid);
        }

        static void ProcessCommand(string input, int[,] grid)
        {
            string[] parts = input.Split(' ');

            if (parts.Length < 1)
            {
                Console.WriteLine("Invalid command. Please enter at least a command.");
                return;
            }

            string command = parts[0];
            int[] parameters = new int[parts.Length - 1];

            for (int i = 1; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out parameters[i - 1]))
                {
                    Console.WriteLine("Invalid parameters. Please enter numeric values for parameters.");
                    return;
                }
            }

            ExecuteCommand(command, parameters, grid);
        }

        static void ExecuteCommand(string command, int[] parameters, int[,] grid)
        {
            // Example command handling
            if (command.ToLower() == "setvalue" && parameters.Length >= 3)
            {
                int row = parameters[0];
                int col = parameters[1];
                int value = parameters[2];

                if (IsValidCell(row, col, grid))
                {
                    grid[row, col] = value; // Set the value at the specified cell
                    Console.WriteLine($"Value set at ({row}, {col}) to {value}");
                }
                else
                {
                    Console.WriteLine("Invalid cell coordinates.");
                }
            }
            else
            {
                Console.WriteLine("Unknown or improperly formatted command.");
            }

            PrintGrid(grid);
        }

        static bool IsValidCell(int row, int col, int[,] grid)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
        }

        static void PrintGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void PlaceRobot(int X, int Y, int[,] Grid, string Face)
        {

        }
        static void MoveRobot()
        {

        }
        static string ReportRobot()
        {
            return "this ";
        }
        static void changeDirection()
        {

        }
    }
}

