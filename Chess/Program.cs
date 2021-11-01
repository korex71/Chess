using Board;
using Chess.Board;
using Chess;
using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                BoardCF board = new(8, 8);

                board.insertPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.insertPiece(new Tower(board, Color.Black), new Position(1, 3));
                board.insertPiece(new King(board, Color.Black), new Position(2, 4));
                board.insertPiece(new King(board, Color.White), new Position(7, 1));

                Screen.ShowBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}