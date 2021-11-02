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

        public bool havePossibleMovements()
        {
            bool[,] matriz = possibleMoves();

            for(int i = 0; i < board.lines; i++)
            {
                for(int j = 0; j < board.columns; j++)
                {
                    if(matriz[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMoves()[pos.line, pos.column];
        }

        public void incMoves() {
            AmountOfMoves++;
        }

    }
}
