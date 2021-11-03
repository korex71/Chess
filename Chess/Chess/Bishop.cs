using Board;
using Chess.Board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(BoardCF board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
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

            void ValidMove()
            {
                if (Board.IsValidPosition(pos) && CanMove(pos))
                {
                    matriz[pos.Line, pos.Column] = true;
                }
            }

            // Up-Left

            pos.SetValues(Position.Line - 1, Position.Column - 1);

            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line--;
                pos.Column--;

            }

            // Up-Right

            pos.SetValues(Position.Line - 1, Position.Column + 1);


            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }

                pos.Line--;
                pos.Column++;

            }

            // Down-Left

            pos.SetValues(Position.Line + 1, Position.Column - 1);

            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line++;
                pos.Column--;
            }

            // Down-Right

            pos.SetValues(Position.Line + 1, Position.Column + 1);

            while(Board.IsValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;

                if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line++;
                pos.Column++;
            }

            return matriz;
        }
    }
}
