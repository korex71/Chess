using System;
using Board;
using Chess.Board;

namespace Chess
{
    class Screen
    {
        public static void ShowBoard(BoardCF board)
        {
            //string[] cLabels = { "A", "B", "C", "D", "E", "F", "G", "H" }; // Column Labels

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.Columns; j++) {
                        ShowPiece(board.Piece(i, j));
                }

                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");

        }

        public static void ShowBoard(BoardCF board, bool[,] possiblePositions)
        {
            //string[] cLabels = { "A", "B", "C", "D", "E", "F", "G", "H" }; // Column Labels

            ConsoleColor originalBg = Console.BackgroundColor;

            ConsoleColor newBg = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) {
                    if(possiblePositions[i, j]) {
                        Console.BackgroundColor = newBg;
                    } else
                    {
                        Console.BackgroundColor = originalBg;
                    }

                    ShowPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBg;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = originalBg;

        }

        public static PositionChess ReadPositionChess()
        {
            string s = Console.ReadLine();

            if(s.Length != 2)
            {
                throw new BoardException("Posição inválida");
            }

            char column = s[0];

            int line = int.Parse(s[1] + "");

            return new PositionChess(column, line);

        }

        private static void ShowPiece(Piece piece)
        {

            if(piece == null)
            {
                Console.Write("- ");
            } else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write(piece);

                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }

            
        }
    }
}
