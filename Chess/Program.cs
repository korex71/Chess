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

                while (!party.Finished)
                {
                    try
                    {
                        Console.Clear();

                        Screen.ShowBoard(party.Board);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: {party.Turn}");
                        Console.WriteLine($"Aguardando jogada: {party.CurrentPlayer}");

                        Console.WriteLine();
                        Console.Write("Origem:");
                        Position origin = Screen.ReadPositionChess().ToPosition();

                        party.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = party.Board.Piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.ShowBoard(party.Board, possiblePositions);

                        Console.Write("Destino:");
                        Position destiny = Screen.ReadPositionChess().ToPosition();

                        party.ValidateDestinyPosition(origin, destiny);

                        party.MakePlay(origin, destiny);
                    } catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

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