using Board;
using Chess.Board;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(BoardCF board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "Q";
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

            // Up-Left

            pos.SetValues(Position.Line - 1, Position.Column - 1);

            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line--;
                pos.Column--;
            }

            // Up

            pos.SetValues(Position.Line - 1, Position.Column);

            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line--;

            }

            // Up-Right

            pos.SetValues(Position.Line - 1, Position.Column + 1);


            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line--;
                pos.Column++;

            }

            // Right

            pos.SetValues(Position.Line, Position.Column + 1);

            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Column++;
            }

            // Down-Right

            pos.SetValues(Position.Line + 1, Position.Column + 1);

            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line++;
                pos.Column++;
            }

            // Down

            pos.SetValues(Position.Line + 1, Position.Column);

            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line++;

            }

            // Down-Left

            pos.SetValues(Position.Line + 1, Position.Column - 1);

            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line++;
                pos.Column--;
            }

            // Left

            pos.SetValues(Position.Line, Position.Column - 1);

            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Column--;
            }


            return matriz;
        }
    }
}
