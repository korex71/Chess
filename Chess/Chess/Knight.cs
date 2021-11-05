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
            return "C";
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

            // 2xUp left

            pos.SetValues(Position.Line - 2, Position.Column - 1);

            if(Board.IsValidPosition(pos) && CanMove(pos)) {
                matriz[pos.Line, pos.Column] = true;
            }

            // 2xUp right

            pos.SetValues(Position.Line - 2, Position.Column + 1);

            if(Board.IsValidPosition(pos) && CanMove(pos)) {
                matriz[pos.Line, pos.Column] = true;
            }

            // Up 2xLeft

            pos.SetValues(Position.Line - 1, Position.Column - 2);

            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // Up 2xright

            pos.SetValues(Position.Line - 1, Position.Column + 2);

            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }


            // 2xDown left
            pos.SetValues(Position.Line + 2, Position.Column - 1);
            
            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // Down 2xleft
            pos.SetValues(Position.Line + 1, Position.Column - 2);

            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // 2xDown right
            pos.SetValues(Position.Line + 2, Position.Column + 1);

            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // 2x Right down
            pos.SetValues(Position.Line + 1, Position.Column + 2);

            if(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            return matriz;
        }

    }
}
