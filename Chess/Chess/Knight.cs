using Board;
using Chess.Board;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(BoardCF board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "KN";
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

            // 2xUp Left

            pos.SetValues(Position.Line - 2, Position.Column - 1);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }


            // 2xUp Right
            pos.SetValues(Position.Line - 2, Position.Column + 1);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // 2xDown Left
            pos.SetValues(Position.Line + 2, Position.Column - 1);

            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // 2xDown Right
            pos.SetValues(Position.Line - 2, Position.Column + 1);

            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            return matriz;
        }

    }
}
