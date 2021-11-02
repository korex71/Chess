using Board;

namespace Chess.Board
{
    abstract class Piece
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

        public abstract bool[,] possibleMoves();

        public void incMoves() {
            AmountOfMoves++;
        }

    }
}
