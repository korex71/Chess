using Board;
using Chess.Board;
using Chess.Chess;
using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardCF board = new(8, 8);

            board.insertPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.insertPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.insertPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.ShowBoard(board);

            Console.ReadLine();
        }
    }
}