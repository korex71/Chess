using Board;
using Chess.Board;

namespace Chess.Chess
{
    class King : Piece {
        public King(BoardCF board, Color color) : base(board, color) {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
