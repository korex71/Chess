using Board;
using Chess.Board;

namespace Chess
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

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);

            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] matriz = new bool[Board.Lines, Board.Columns]; // Matriz booleana de possíveis movimentos

            Position pos = new(0, 0); // ~~ (7, 7) <- Max

            // Up
            pos.SetValues(Position.Line - 1, Position.Column);

            while(Board.IsValidPosition(pos) && CanMove(pos)) {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line--;
            }

            // Down
            pos.SetValues(Position.Line + 1, Position.Column);

            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line++;
            }

            // Right
            pos.SetValues(Position.Line, Position.Column + 1);

            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Column++;
            }

            // Left
            pos.SetValues(Position.Line, Position.Column - 1);

            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Column--;
            }


            return matriz;
        }
    }
}
