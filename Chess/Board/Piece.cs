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

        public Piece(BoardCF board, Color color)
        {
            this.board = board;
            this.color = color;
            this.position = null;
            this.AmountOfMoves = 0;
        }

    }
}
