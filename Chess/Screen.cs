using System;
using Board;

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
                        Console.Write(board.piece(i, j) + " ");
                    }

                }

                Console.WriteLine();
            }

            for(int b = 0; b < board.columns + 1; b++)
            {
                if(b == 0)
                {
                    Console.Write("  ");
                } else
                {
                    Console.Write(cLabels[b - 1] + " ");
                }
            }
        }
    }
}
