using System;

namespace HelloWorld
{
    class Program
    {
        #region Variables
         
        static Program program = new Program();
        static ConsoleColor consoleColor = ConsoleColor.Gray;
        static int input;
        static int player = 2;
        static bool isCorrectValue = false;
        static char playerCharacter;
        static int turns;
        static char[,] gridNumbers = new char[,]
        {
                {'1','2','3' }, //row 0
                {'4','5','6' }, //row 1
                {'7','8','9' }  //row 2
        };

        #endregion
 
        static void Main()
        {
            Console.WindowHeight = 38;
            Console.WindowWidth = 67;
            Console.Title = "Tic Tac Toe";
            consoleColor = ColorSelect();
            program.CoreGame();
        }

        void CoreGame()
        {
            player = 2;

            while (true)
            {
                Initialize();
                CheckInput();

                switch (input)
                {
                    case 1: gridNumbers[0, 0] = playerCharacter; break;
                    case 2: gridNumbers[0, 1] = playerCharacter; break;
                    case 3: gridNumbers[0, 2] = playerCharacter; break;
                    case 4: gridNumbers[1, 0] = playerCharacter; break;
                    case 5: gridNumbers[1, 1] = playerCharacter; break;
                    case 6: gridNumbers[1, 2] = playerCharacter; break;
                    case 7: gridNumbers[2, 0] = playerCharacter; break;
                    case 8: gridNumbers[2, 1] = playerCharacter; break;
                    case 9: gridNumbers[2, 2] = playerCharacter; break;
                }
                turns++;

                if (CheckWin())
                {
                    break;
                }

                if (turns >=  9)
                {
                    Console.Clear();
                    Console.WriteLine("Draw :) ");
                    Console.WriteLine("\nPress any key to reset game");
                    Console.ReadKey();
                    break;
                }
            }
            ResetGame();
        }

        void Initialize()
        {
            player = player == 1 ? player = 2 : player = 1;
            playerCharacter = player == 1 ? 'X' : 'O';
            isCorrectValue = false;
            DisplayValues();
            Console.WriteLine("\nplayer {0} : choose your field!", player);
        }

        bool CheckWin()
        {
            bool hasWon;
            
            playerCharacter = player == 1 ? 'X' : 'O';

            if ( 
                #region Win posibilities 
                ((gridNumbers[0, 0] == playerCharacter) && (gridNumbers[0, 1] == playerCharacter) && (gridNumbers[0, 2] == playerCharacter)) ||
                ((gridNumbers[1, 0] == playerCharacter) && (gridNumbers[1, 1] == playerCharacter) && (gridNumbers[1, 2] == playerCharacter)) ||
                ((gridNumbers[2, 0] == playerCharacter) && (gridNumbers[2, 1] == playerCharacter) && (gridNumbers[2, 2] == playerCharacter)) ||
                ((gridNumbers[0, 0] == playerCharacter) && (gridNumbers[1, 0] == playerCharacter) && (gridNumbers[2, 0] == playerCharacter)) ||
                ((gridNumbers[0, 1] == playerCharacter) && (gridNumbers[1, 1] == playerCharacter) && (gridNumbers[2, 1] == playerCharacter)) ||
                ((gridNumbers[0, 2] == playerCharacter) && (gridNumbers[1, 2] == playerCharacter) && (gridNumbers[2, 2] == playerCharacter)) ||
                ((gridNumbers[0, 0] == playerCharacter) && (gridNumbers[1, 1] == playerCharacter) && (gridNumbers[2, 2] == playerCharacter)) ||
                ((gridNumbers[0, 2] == playerCharacter) && (gridNumbers[1, 1] == playerCharacter) && (gridNumbers[2, 0] == playerCharacter))
                #endregion             
               )
            {
                hasWon = true;
                Console.Clear();
                Console.WriteLine("Congratulations! Player {0} has won!", player);
                Console.WriteLine("\nPress any key to reset game");
                Console.ReadKey();
            }
            else
            {
                hasWon = false;
            }

            return hasWon;
        }

        void ResetGame()
        {
            char[,] initialGrid = new char[,]
            {
                {'1','2','3' }, //row 0
                {'4','5','6' }, //row 1
                {'7','8','9' }  //row 2
            };

            turns = 0;
            player = 2;
            input = 0;
            gridNumbers = initialGrid;
            CoreGame();
        }

        void CheckInput()
        {
            do
            {         
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Error("\nERROR! Please type a numeber");
                    continue;
                }

                if ((input == 1 && gridNumbers[0, 0] == '1') || (input == 2 && gridNumbers[0, 1] == '2') ||
                    (input == 3 && gridNumbers[0, 2] == '3') || (input == 4 && gridNumbers[1, 0] == '4') ||
                    (input == 5 && gridNumbers[1, 1] == '5') || (input == 6 && gridNumbers[1, 2] == '6') ||
                    (input == 7 && gridNumbers[2, 0] == '7') || (input == 8 && gridNumbers[2, 1] == '8') ||
                    (input == 9 && gridNumbers[2, 2] == '9'))
                {
                    isCorrectValue = true; 
                }
                else
                {
                    Error("\nERROR! this field is not avilable, please choose another number");
                    Console.WriteLine();
                }


            } while (!isCorrectValue);


        }

        void Error(string errorCode)
        {
            isCorrectValue = false;
                
            if (consoleColor == ConsoleColor.Red)
            {                 
                Console.ForegroundColor = ConsoleColor.Cyan;
            }               
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorCode);               
            Console.ForegroundColor = consoleColor;
        }

        void DisplayValues()
        {
            #region Grid display

            Console.Clear();
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("           {0}          |          {1}          |          {2}          ", gridNumbers[0,0], gridNumbers[0, 1], gridNumbers[0, 2]);
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine(" _____________________|_____________________|_____________________");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("           {0}          |          {1}          |          {2}          ", gridNumbers[1, 0], gridNumbers[1, 1], gridNumbers[1, 2]);
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine(" _____________________|_____________________|_____________________");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("           {0}          |          {1}          |          {2}          ", gridNumbers[2, 0], gridNumbers[2, 1], gridNumbers[2, 2]);
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");
            Console.WriteLine("                      |                     |                     ");

            #endregion
        }

        static ConsoleColor ColorSelect()
        {
            Console.WriteLine("Type \"red\" for red color");
            Console.WriteLine("Type \"green\" for green color");
            Console.WriteLine("Type \"blue\" for blue color");
            Console.WriteLine("Type \"cyan\" for cyan color");
            Console.WriteLine("Type anything else for gray color");
            string colorInput = Console.ReadLine().ToLower();

            consoleColor = Console.ForegroundColor = colorInput == "red" ? ConsoleColor.Red : colorInput == "green" ? ConsoleColor.Green : colorInput == "blue" ? ConsoleColor.Blue : colorInput == "cyan" ? ConsoleColor.Cyan : ConsoleColor.Gray;
            Console.Clear();
            return consoleColor;
        }
    }
}