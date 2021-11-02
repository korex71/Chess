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
                    try
                    {
                        Console.Clear();

                        Screen.ShowBoard(party.board);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + party.turn);
                        Console.WriteLine("Aguardando jogada: " + party.currentPlayer);

                        Console.WriteLine();
                        Console.Write("Origem:");
                        Position origin = Screen.readPositionChess().toPosition();

                        party.validateOriginPosition(origin);

                        bool[,] possiblePositions = party.board.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.ShowBoard(party.board, possiblePositions);

                        Console.Write("Destino:");
                        Position destiny = Screen.readPositionChess().toPosition();

                        party.validateDestinyPosition(origin, destiny);

                        party.makePlay(origin, destiny);
                    }
                    catch (BoardException e)
                    {
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