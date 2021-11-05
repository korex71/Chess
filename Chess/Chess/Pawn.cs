using Board;
using Chess.Board;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(BoardCF board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "P";
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

            // UpLeft

            if(Color == Color.White)
            {
                pos.SetValues(Position.Line - 1, Position.Column + 1);

                if (Board.IsValidPosition(pos) && CanMove(pos)) {
                    if(Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                        matriz[pos.Line, pos.Column] = true;
                    }
                }


                // Up
                pos.SetValues(Position.Line, Position.Column);

                if(Board.IsValidPosition(pos) && CanMove(pos))
                {
                    pos.SetValues(Position.Line, Position.Column);


                }

                pos.SetValues(Position.Line - 1, Position.Column);

                if (Board.IsValidPosition(pos) && CanMove(pos))
                {
                    matriz[pos.Line, pos.Column] = true;
                }

                // UpRight
                pos.SetValues(Position.Line - 1, Position.Column + 1);

                if (Board.IsValidPosition(pos) && CanMove(pos)) {
                    if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    {
                        matriz[pos.Line, pos.Column] = true;
                    }
                }

            } else {
                // Down left
                pos.SetValues(Position.Line + 1, Position.Column - 1);

                if (Board.IsValidPosition(pos) && CanMove(pos))
                {
                    if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    {
                        matriz[pos.Line, pos.Column] = true;
                    }
                }


                // Down
                pos.SetValues(Position.Line + 1, Position.Column);

                if (Board.IsValidPosition(pos) && CanMove(pos))
                {
                    matriz[pos.Line, pos.Column] = true;
                }

                // Down Right
                pos.SetValues(Position.Line + 1, Position.Column + 1);

                if (Board.IsValidPosition(pos) && CanMove(pos)) {
                    if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    {
                        matriz[pos.Line, pos.Column] = true;
                    }
                }

            }


            return matriz;
        }

    }
}
