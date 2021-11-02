using Board;

namespace Chess.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountOfMoves { get; protected set; }
        public BoardCF Board { get; protected set; }

        public Piece(BoardCF board, Color color)
        {
            Board = board;
            Color = color;
            Position = null;
            AmountOfMoves = 0;
        }

        public abstract bool[,] possibleMoves();

        public bool HavePossibleMovements()
        {
            bool[,] matriz = possibleMoves();

            for(int i = 0; i < Board.Lines; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if(matriz[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return possibleMoves()[pos.Line, pos.Column];
        }

        public void IncMoves() {
            AmountOfMoves++;
        }

    }
}
