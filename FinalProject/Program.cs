using System;
using System.Threading;
namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Minigame";
            GameMenu.MainMenu();
        }
    }
    class GameMenu
    {
        public static void MainMenu()
        {
            //1. Menu game
            Console.WriteLine("Select game you want to play!");
            Console.WriteLine("1.OX Game");
            Console.WriteLine("2.Guess the number");
            Console.WriteLine("3.Hig & hLow");
            Console.WriteLine("4.Exit");

            //2.Select game
            GameSelect();
            GoPage(gameNumber);
        }
        static bool gameSelectCheck;
        static int gameNumber = 0;
        static void GameSelect()
        {
            do
            {
                do
                {
                    Console.Write("Please enter game number (1,2,3,4) : ");
                    gameSelectCheck = Int32.TryParse(Console.ReadLine(), out gameNumber);
                    if (gameSelectCheck == false)
                    {
                        Console.WriteLine("You enter wrong type. Please Try again.");
                    }
                } while (gameSelectCheck != true);
                if (gameNumber < 0 || gameNumber > 5)
                {
                    Console.WriteLine("Please enter 1-4 ");
                }
            } while (gameNumber < 0 || gameNumber > 5);
        }
        static void GoPage(int gameNumber)
        {
            if (gameNumber == 1)
            {
                Console.WriteLine("Go to play OX Game");
                Thread.Sleep(2000);
                Console.Clear();
                GameOX.PlayGameOX();
            }
            else if (gameNumber == 2)
            {
                Console.WriteLine("Go to play Guess the number");
                Thread.Sleep(2000);
                Console.Clear();
                GameGuess.PlayGameGuess();
            }
            else if (gameNumber == 3)
            {
                Console.WriteLine("Go to play High & Low");
                Thread.Sleep(2000);
                Console.Clear();
                GameHighLow.PlayHighLow();
            }
            else if (gameNumber == 4)
            {
                return;
            }
        }
    }
    class GameOX
    {
        static char[] tableOXArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int playerTurn = 1;
        static int score = 0;
        static int selection = 0;
        static bool checkSelection;
        public static void PlayGameOX()
        {
            GameReset();
            do
            {
                Console.WriteLine("Player1 : O and Player 2 : X");
                Console.WriteLine();
                if (playerTurn % 2 != 0)
                {
                    Console.WriteLine("Player 1 Turn");
                }
                else
                {
                    Console.WriteLine("Player 2 Turn");
                }
                boardOX();
                do
                {
                    do
                    {
                        Console.Write("Enter your selection : ");
                        checkSelection = Int32.TryParse(Console.ReadLine(), out selection);
                        if (checkSelection == false)
                        {
                            Console.WriteLine("You enter wrong type. Please Try again.");
                        }
                    } while (checkSelection != true);
                    if (selection < 0 || selection > 10)
                    {
                        Console.WriteLine("Please enter 1-9 ");
                    }
                } while (selection < 0 || selection > 10);

                if (tableOXArray[selection] != 'O' && tableOXArray[selection] != 'X')
                {
                    if (playerTurn % 2 != 0)
                    {
                        tableOXArray[selection] = 'O';
                        playerTurn++;
                    }
                    else
                    {
                        tableOXArray[selection] = 'X';
                        playerTurn++;
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry the row {selection} is already marked with {tableOXArray[selection]}");
                    Console.WriteLine();
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                score = CheckWin();
                Console.Clear();
            } while (score == 0);
            boardOX();
            if (score == 1)
            {
                Console.WriteLine("Player {0} has won", (playerTurn % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            PlayerDoNext.pageCheck = 1;
            PlayerDoNext.PlayerSelect();
        }
        public static void boardOX()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tableOXArray[1]}  |  {tableOXArray[2]}  |  {tableOXArray[3]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tableOXArray[4]}  |  {tableOXArray[5]}  |  {tableOXArray[6]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {tableOXArray[7]}  |  {tableOXArray[8]}  |  {tableOXArray[9]}");
            Console.WriteLine("     |     |      ");
        }
        private static int CheckWin()
        {
            //Winning Condition For First Row
            if (tableOXArray[1] == tableOXArray[2] && tableOXArray[2] == tableOXArray[3])
            {
                return 1;
            }
            //Winning Condition For Second Row
            else if (tableOXArray[4] == tableOXArray[5] && tableOXArray[5] == tableOXArray[6])
            {
                return 1;
            }
            //Winning Condition For Third Row
            else if (tableOXArray[6] == tableOXArray[7] && tableOXArray[7] == tableOXArray[8])
            {
                return 1;
            }

            //Winning Condition For First Column
            else if (tableOXArray[1] == tableOXArray[4] && tableOXArray[4] == tableOXArray[7])
            {
                return 1;
            }
            //Winning Condition For Second Column
            else if (tableOXArray[2] == tableOXArray[5] && tableOXArray[5] == tableOXArray[8])
            {
                return 1;
            }
            //Winning Condition For Third Column
            else if (tableOXArray[3] == tableOXArray[6] && tableOXArray[6] == tableOXArray[9])
            {
                return 1;
            }

            else if (tableOXArray[1] == tableOXArray[5] && tableOXArray[5] == tableOXArray[9])
            {
                return 1;
            }
            else if (tableOXArray[3] == tableOXArray[5] && tableOXArray[5] == tableOXArray[7])
            {
                return 1;
            }

            // If all the cells or values filled with X or O then any player has won the match
            else if (tableOXArray[1] != '1' && tableOXArray[2] != '2' && tableOXArray[3] != '3' && tableOXArray[4] != '4' && tableOXArray[5] != '5' && tableOXArray[6] != '6' && tableOXArray[7] != '7' && tableOXArray[8] != '8' && tableOXArray[9] != '9')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
        public static void GameReset()
        {
            char[] tableReset = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int playerTurnReset = 1;
            int scoreReset = 0;

            playerTurnReset = playerTurn = 1;
            scoreReset = score = 0;
            tableOXArray = tableReset;
        }
    }
    class GameGuess
    {
        static int startRandomtNumber = 0;
        static int endRandomNumber = 0;
        public static void PlayGameGuess()
        {
            int playerTurn = 1;
            int selection;
            int changeSelect = 0;
            int startNumber;
            int endNumber;
            bool checkSelection;
            bool checkWin = false;

            Console.WriteLine("Guess the number");
            Console.WriteLine("Please Enter range of number to ramdom.");

            startNumber = Checkinput("start", false, startRandomtNumber);
            endNumber = Checkinput("end", false, endRandomNumber);

            Random rnd = new Random();
            int randomNumber = rnd.Next(startNumber, endNumber + 1);
            if (Math.Abs(startNumber - endNumber) < 10)
            {
                changeSelect = 4;
            }
            else if (Math.Abs(startNumber - endNumber) > 10 && Math.Abs(startNumber - endNumber) < 100)
            {
                changeSelect = 8;
            }
            else
            {
                changeSelect = 10;
            }
            int[] playerSelect = new int[changeSelect];
            do
            {
                Console.WriteLine($"You have {changeSelect} time.");
                if (playerTurn % 2 != 0)
                {
                    Console.WriteLine("Player 1 Turn");
                }
                else
                {
                    Console.WriteLine("Player 2 Turn");
                }
                do
                {
                    Console.Write("Enter your selection : ");
                    checkSelection = Int32.TryParse(Console.ReadLine(), out selection);
                    if (checkSelection != true)
                    {
                        Console.WriteLine("You enter wrong type.");
                    }
                } while (checkSelection != true);
                playerSelect[playerTurn - 1] = selection;
                if (selection != randomNumber)
                {
                    if (selection > randomNumber)
                    {
                        Console.WriteLine($"Your guess {selection}, is too High.");
                    }
                    else
                    {
                        Console.WriteLine($"Your guess {selection}, is too Low.");
                    }
                    playerTurn++;
                    changeSelect--;
                }
                else
                {
                    checkWin = true;
                    changeSelect = 0;
                }
                foreach (var number in playerSelect)
                {
                    Console.Write($"{number} ");
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            } while (changeSelect != 0);
            if (checkWin == true)
            {
                if (playerTurn % 2 != 0)
                {
                    Console.WriteLine("Player 1 Win!!!");
                }
                else if (playerTurn % 2 == 0)
                {
                    Console.WriteLine("Player 2 Win!!!");
                }
            }
            else
            {
                Console.WriteLine("Draw");
            }
            PlayerDoNext.pageCheck = 2;
            PlayerDoNext.PlayerSelect();
        }
        public static int Checkinput(string random, bool check, int input)
        {
            do
            {
                Console.Write($"Enter {random} Number : ");
                check = Int32.TryParse(Console.ReadLine(), out input);
                if (check != true)
                {
                    Console.WriteLine("You enter wrong type.");
                }
            } while (check != true);
            return input;
        }
    }
    class GameHighLow
    {
        static bool playerSelectCheck = false;
        static int player1Token;
        static int player2Token;
        static int player1Bet = 0;
        static int player2Bet = 0;
        public static void PlayHighLow()
        {
            GameReset();
            string player1Select;
            string player2Select;
            bool result = false;

            Console.WriteLine("High & Low Game");
            Console.WriteLine("Play with 2 player.");
            Console.WriteLine("You can select High or Low.");
            Console.WriteLine("3 - 10 is Low, 12 - 18 is High");
            Console.WriteLine("If random is 11 is High-Low your bet will lost");
            Console.WriteLine("Game will end when someone have 15 Token or 0 Token");
            Console.WriteLine($"Player 1 have {player1Token} Token");
            Console.WriteLine($"Player 2 have {player2Token} Token");
            Console.WriteLine();

            do
            {
                player1Select = PlayerCheck(1, "");
                player2Select = PlayerCheck(2, "");
                Random rnd = new Random();
                int randomNumber = rnd.Next(3, 19);
                Console.WriteLine("doing random.");
                Thread.Sleep(2000);
                Console.WriteLine("Random end please bet your Token");
                player1Bet = Checkinput(1, false, player1Bet, player1Token);
                player2Bet = Checkinput(2, false, player2Bet, player2Token);
                Console.WriteLine($"Random number is {randomNumber}");
                if (randomNumber < 11 && randomNumber >= 3)
                {
                    Console.WriteLine("Random is Low.");
                    if (player1Select.Equals("Low") || player1Select.Equals("low"))
                    {
                        Console.WriteLine($"Player 1 got {player1Bet}");
                        Console.WriteLine($"Player 1 have {player1Token += player1Bet}");
                    }
                    else if (player1Select.Equals("High") || player1Select.Equals("high"))
                    {
                        Console.WriteLine($"Player 1 lost {player1Bet}");
                        Console.WriteLine($"Player 1 have {player1Token -= player1Bet}");
                    }

                    if (player2Select.Equals("Low") || player2Select.Equals("low"))
                    {
                        Console.WriteLine($"Player 2 got {player2Bet}");
                        Console.WriteLine($"Player 2 have {player2Token += player2Bet}");
                    }
                    else if (player2Select.Equals("High") || player2Select.Equals("high"))
                    {
                        Console.WriteLine($"Player 2 got {player2Bet}");
                        Console.WriteLine($"Player 2 have {player2Token -= player2Bet}");
                    }
                }
                else if (randomNumber == 11)
                {
                    Console.WriteLine("Random is High - Low.");
                    Console.WriteLine($"Player 1 lost {player1Bet}");
                    Console.WriteLine($"Player 1 have {player1Token -= player1Bet}");
                    Console.WriteLine($"Player 2 lost {player2Bet}");
                    Console.WriteLine($"Player 2 have {player2Token -= player2Bet}");
                }
                else if (randomNumber < 19 || randomNumber >= 12)
                {
                    Console.WriteLine("Random is High.");
                    if (player1Select.Equals("High") || player1Select.Equals("high"))
                    {
                        Console.WriteLine($"Player 1 got {player1Bet}");
                        Console.WriteLine($"Player 1 have {player1Token += player1Bet}");
                    }
                    else if (player1Select.Equals("Low") || player1Select.Equals("low"))
                    {
                        Console.WriteLine($"Player 1 got {player1Bet}");
                        Console.WriteLine($"Player 1 have {player1Token -= player1Bet}");
                    }

                    if (player2Select.Equals("High") || player2Select.Equals("high"))
                    {
                        Console.WriteLine($"Player 2 got {player2Bet}");
                        Console.WriteLine($"Player 2 have {player2Token += player2Bet}");
                    }
                    else if (player2Select.Equals("Low") || player2Select.Equals("low"))
                    {
                        Console.WriteLine($"Player 2 got {player2Bet}");
                        Console.WriteLine($"Player 2 have {player2Token -= player2Bet}");
                    }
                }
                if (player1Token < 0 || player1Token >= 15 || player2Token < 0 || player2Token >= 15)
                {
                    if (player1Token > player2Token)
                    {
                        Console.WriteLine("Player 1 Win!!!");
                    }
                    else if (player1Token < player2Token)
                    {
                        Console.WriteLine("Player 2 Win!!!");
                    }
                    else
                    {
                        Console.WriteLine("Draw");
                    }
                    result = true;
                }
            } while (result != true);
            PlayerDoNext.pageCheck = 3;
            PlayerDoNext.PlayerSelect();
        }
        public static string PlayerCheck(int player, string selection)
        {
            do
            {
                Console.Write($"Player {player} please select : ");
                selection = Console.ReadLine();
                if (selection.Equals("High") || selection.Equals("high") || selection.Equals("Low") || selection.Equals("low"))
                {
                    Console.WriteLine($"Player {player} select {selection}");
                    playerSelectCheck = true;
                }
                else
                {
                    Console.WriteLine("You enter wrong word please selct again.");
                }
            } while (playerSelectCheck == false);
            return selection;
        }
        public static int Checkinput(int player, bool check, int input, int token)
        {
            do
            {
                Console.Write($"Player {player} bet : ");
                do
                {
                    check = Int32.TryParse(Console.ReadLine(), out input);
                    if (check != true)
                    {
                        Console.WriteLine("You enter wrong type.");
                    }
                } while (check != true);
                if (input > token)
                {
                    Console.WriteLine("you don't have enough Token.");
                }
            } while (input > token);
            return input;
        }
        public static void GameReset()
        {
            player1Token = 10;
            player2Token = 10;
        }
    }
    class PlayerDoNext
    {
        public static int pageCheck;
        public static bool checkSelect;
        public static int select;
        public static void PlayerSelect()
        {
            Console.WriteLine("What do you want to do next ?");
            Console.WriteLine("1.Play again.");
            Console.WriteLine("2.Play another game.");
            Console.WriteLine("3.Exit");
            do
            {
                do
                {
                    Console.Write("Please selected : ");
                    checkSelect = Int32.TryParse(Console.ReadLine(), out select);
                    if (checkSelect == false)
                    {
                        Console.WriteLine("You enter wrong type. Please Try again.");
                    }
                } while (checkSelect != true);
                if (select < 0 || select > 4)
                {
                    Console.WriteLine("Please enter 1-3 ");
                }
            } while (select < 0 || select > 4);

            if (select == 1)
            {
                Console.Clear();
                if (pageCheck == 1)
                {
                    GameOX.PlayGameOX();
                }
                else if (pageCheck == 2)
                {
                    GameGuess.PlayGameGuess();
                }
                else if (pageCheck == 3)
                {
                    GameHighLow.PlayHighLow();
                }
            }
            else if (select == 2)
            {
                Console.Clear();
                GameMenu.MainMenu();
            }
            else if (select == 3)
            {
                return;
            }
        }
    }
}
