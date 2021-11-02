using System;
using Board;
using Chess.Board;

namespace Chess
{
    class Screen
    {
        public static void ShowBoard(BoardCF board)
        {
            string[] cLabels = { "A", "B", "C", "D", "E", "F", "G", "H" }; // Column Labels

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.columns; j++)
                {
                    if(board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    } else
                    {
                        ShowPiece(board.piece(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }

            //Console.WriteLine("  A B C D E F G H");

            for (int b = 0; b < board.columns + 1; b++)
            {
                if(b == 0)
                {
                    Console.Write("  ");
                    continue;
                }
                
                Console.Write(cLabels[b - 1] + " ");
            }
            
        }

        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();

            char column = s[0];

            int line = int.Parse(s[1] + "");

            return new PositionChess(column, line);

        }

        private static void ShowPiece(Piece piece)
        {
            if (piece.color == Color.White)
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
        }
    }
}
