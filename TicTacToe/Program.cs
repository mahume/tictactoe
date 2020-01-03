using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] fieldOfPlay =
        {
            { '1', '2', '3'},
            { '4', '5', '6'},
            { '7', '8', '9'},
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    ReplacementCharacter('O', input);
                }
                else if (player == 1)
                {
                    player = 2;
                    ReplacementCharacter('X', input);
                }

                SetBoard();

                #region
                // Check winning condition
                char[] playersCharacters = { 'X', 'O' };
                foreach (char playerChar in playersCharacters)
                {
                    if (((fieldOfPlay[0,0] == playerChar) && (fieldOfPlay[0,1] == playerChar) && (fieldOfPlay[0,2] == playerChar))
                        || ((fieldOfPlay[1, 0] == playerChar) && (fieldOfPlay[1, 1] == playerChar) && (fieldOfPlay[1, 2] == playerChar))
                        || ((fieldOfPlay[2, 0] == playerChar) && (fieldOfPlay[2, 1] == playerChar) && (fieldOfPlay[2, 2] == playerChar))
                        || ((fieldOfPlay[0, 0] == playerChar) && (fieldOfPlay[1, 0] == playerChar) && (fieldOfPlay[2, 0] == playerChar))
                        || ((fieldOfPlay[0, 1] == playerChar) && (fieldOfPlay[1, 1] == playerChar) && (fieldOfPlay[2, 1] == playerChar))
                        || ((fieldOfPlay[0, 2] == playerChar) && (fieldOfPlay[1, 2] == playerChar) && (fieldOfPlay[2, 2] == playerChar))
                        || ((fieldOfPlay[0, 0] == playerChar) && (fieldOfPlay[1, 1] == playerChar) && (fieldOfPlay[2, 2] == playerChar))
                        || ((fieldOfPlay[0, 2] == playerChar) && (fieldOfPlay[1, 1] == playerChar) && (fieldOfPlay[2, 0] == playerChar)))
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 has won!");
                        }

                        // Reset Board
                        Console.WriteLine("Press any key to reset the game.");
                        Console.ReadKey();
                        ResetBoard();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("\nDraw!");
                        Console.WriteLine("Press any key to reset the game.");
                        Console.ReadKey();
                        ResetBoard();
                        break;
                    }
                }
                #endregion

                #region
                // Test if field is already taken
                do
                {
                    Console.WriteLine("\nPlayer {0}: Choose your field", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Please enter a number");
                    }

                    if ((input == 1) && (fieldOfPlay[0,0] == '1'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 2) && (fieldOfPlay[0,1] == '2'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 3) && (fieldOfPlay[0, 2] == '3'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 4) && (fieldOfPlay[1, 0] == '4'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 5) && (fieldOfPlay[1, 1] == '5'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 6) && (fieldOfPlay[1, 2] == '6'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 7) && (fieldOfPlay[2, 0] == '7'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 8) && (fieldOfPlay[2, 1] == '8'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 9) && (fieldOfPlay[2, 2] == '9'))
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Position already player. Choose again.");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
                #endregion
            } while (true);
        }

        public static void ResetBoard()
        {
            char[,] fieldOfPlayInitial =
            {
                { '1', '2', '3'},
                { '4', '5', '6'},
                { '7', '8', '9'},
            };

            fieldOfPlay = fieldOfPlayInitial;
            SetBoard();
            turns = 0;
        }

        public static void SetBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", fieldOfPlay[0,0], fieldOfPlay[0,1], fieldOfPlay[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", fieldOfPlay[1, 0], fieldOfPlay[1, 1], fieldOfPlay[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", fieldOfPlay[2, 0], fieldOfPlay[2, 1], fieldOfPlay[2, 2]);
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void ReplacementCharacter(char playerCharacter, int input)
        {
            switch (input)
            {
                case 1:
                    fieldOfPlay[0, 0] = playerCharacter;
                    break;
                case 2:
                    fieldOfPlay[0, 1] = playerCharacter;
                    break;
                case 3:
                    fieldOfPlay[0, 2] = playerCharacter;
                    break;
                case 4:
                    fieldOfPlay[1, 0] = playerCharacter;
                    break;
                case 5:
                    fieldOfPlay[1, 1] = playerCharacter;
                    break;
                case 6:
                    fieldOfPlay[1, 2] = playerCharacter;
                    break;
                case 7:
                    fieldOfPlay[2, 0] = playerCharacter;
                    break;
                case 8:
                    fieldOfPlay[2, 1] = playerCharacter;
                    break;
                case 9:
                    fieldOfPlay[2, 2] = playerCharacter;
                    break;
            }
        }
    }
}
