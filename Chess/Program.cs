using Board;
using Chess.Board;
using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionChess pos = new PositionChess('c', 7);

            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosition());

            Console.ReadLine();
        }
    }
}