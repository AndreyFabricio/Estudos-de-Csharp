using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Print the board on the console

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board =
            {
                {"   ", "|", "   ", "|", "   "},
                {" 1 ", "|", " 2 ", "|", " 3 "},
                {"___", "|", "___", "|", "___"},
                {"   ", "|", "   ", "|", "   "},
                {" 4 ", "|", " 5 ", "|", " 6 "},
                {"___", "|", "___", "|", "___"},
                {"   ", "|", "   ", "|", "   "},
                {" 7 ", "|", " 8 ", "|", " 9 "},
                {"   ", "|", "   ", "|", "   "}
            };

            bool win = false;

            while (false != true)
            {
                while (false != true)
                {
                    Board(board);
                    InputOfPlayer("Player 1", board, win);
                    Console.Clear();
                    if (win == true) break;
                    Board(board);
                    InputOfPlayer("Player 2", board, win);
                    Console.Clear();
                    if (win == true) break;
                }
                
            }           

        }

        public static void Board(string[,] board)
        {   
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void CheckInput(string playerInput, string player, string[,] board, bool win)
        {
            int test;
            if(Int32.TryParse(playerInput, out test))
            {
                if (test > 0 && test < 10)
                {
                    ChangeBoard(test, player, board, win);
                } else
                {
                    Console.WriteLine();
                    Console.Write("Position have to be between 1 and 9.");
                    Console.ReadKey();
                    Console.Clear();
                    Board(board);
                    InputOfPlayer(player, board, win);
                }
                    
            }
                
        }

        public static void ChangeBoard(int pos, string player, string[,] board, bool win)
        {
            string oX;

            if (player == "Player 1")
                oX = "O";
            else
                oX = "X";

            switch (pos)
            {
                case 1:
                    board[1, 0] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 2:
                    board[1, 2] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 3:
                    board[1, 4] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 4:
                    board[4, 0] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 5:
                    board[4, 2] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 6:
                    board[4, 4] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 7:
                    board[7, 0] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 8:
                    board[7, 2] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                case 9:
                    board[7, 4] = " " + oX + " ";
                    BoardCheck(player, oX, board, win);
                    break;
                default:
                    Console.WriteLine("Position value invalid somehow ._.");
                    break;
            }

        }

        public static string InputOfPlayer(string player, string[,] board, bool win)
        {
            Console.WriteLine("Write \"Exit\" to quit the game.");
            Console.Write("{0} choose the position: ", player);

            string input = Console.ReadLine();

            if (input == "Exit" || input == "exit")
                Environment.Exit(0);
            else
                CheckInput(input, player, board, win);

            return input;
        }

        public static string[,] BoardCheck(string player, string oX, string[,] board, bool win)
        {
            if(board[1, 0] == " " + oX + " " && board[1, 2] == " " + oX + " " 
                && board[1, 4] == " " + oX + " ")
            {
                Console.WriteLine();
                Console.WriteLine("Congratulations {0} on winning the game!", player);
                Console.WriteLine();
                Console.Write("Press \"Enter\" to play again.");
                Console.ReadKey();
                ResetBoard(board);
                win = true;
            }

            return board;
        }

        public static string[,] ResetBoard(string[,] board)
        {
            string[,] cleanBoard =
            {
                {"   ", "|", "   ", "|", "   "},
                {" 1 ", "|", " 2 ", "|", " 3 "},
                {"___", "|", "___", "|", "___"},
                {"   ", "|", "   ", "|", "   "},
                {" 4 ", "|", " 5 ", "|", " 6 "},
                {"___", "|", "___", "|", "___"},
                {"   ", "|", "   ", "|", "   "},
                {" 7 ", "|", " 8 ", "|", " 9 "},
                {"   ", "|", "   ", "|", "   "}
            };

            board = cleanBoard;
            return board;
        }

    }
}
