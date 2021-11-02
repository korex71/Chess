using Chess.Board;
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

                while (!party.finished)
                {
                    Console.Clear();

                    Screen.ShowBoard(party.board);

                    Console.WriteLine();
                    Console.Write("Origem:");
                    Position origin = Screen.readPositionChess().toPosition();

                    bool[,] possiblePositions = party.board.piece(origin).possibleMoves();

                    Console.Clear();
                    Screen.ShowBoard(party.board, possiblePositions);

                    Console.Write("Destino:");
                    Position destiny = Screen.readPositionChess().toPosition();

                    party.MakeMovement(origin, destiny);

                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}