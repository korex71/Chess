using Board;
using Chess.Board;

namespace Chess.Chess
{
    class Tower : Piece
    {
        public Tower(BoardCF board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
