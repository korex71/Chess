using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int AmountOfMoves { get; protected set; }
        public BoardCF board { get; protected set; }

        public Piece(Position position, BoardCF board, Color color)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.AmountOfMoves = 0;
        }

    }
}
