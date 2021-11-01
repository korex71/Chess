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
                ChessParty party = new();

                Screen.ShowBoard(party.board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}