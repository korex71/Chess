using Board;
using Chess.Board;

namespace Chess
{
    class King : Piece {
        public King(BoardCF board, Color color) : base(board, color) {

        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);

            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] matriz = new bool[Board.Lines, Board.Columns]; // Matriz booleana de possíveis movimentos

            Position pos = new(0, 0);

            // N
            pos.SetValues(Position.Line - 1, Position.Column);
            
            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // NE
            pos.SetValues(Position.Line - 1, Position.Column + 1);

            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // L
            pos.SetValues(Position.Line, Position.Column + 1);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // SE
            pos.SetValues(Position.Line + 1, Position.Column + 1);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // S
            pos.SetValues(Position.Line + 1, Position.Column);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // SO
            pos.SetValues(Position.Line + 1, Position.Column - 1);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // O
            pos.SetValues(Position.Line, Position.Column - 1);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // NO
            pos.SetValues(Position.Line - 1, Position.Column - 1);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            return matriz;
        }

    }
}
