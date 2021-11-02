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

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);

            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] matriz = new bool[board.lines, board.columns]; // Matriz booleana de possíveis movimentos

            Position pos = new(0, 0); // ~~ (7, 7) <- Max

            void validMove()
            {
                if (board.isValidPosition(pos) && canMove(pos))
                {
                    matriz[pos.line, pos.column] = true;
                }
            }

            // Up
            pos.setValues(position.line - 1, position.column);

            while(board.isValidPosition(pos) && canMove(pos)) {
                matriz[pos.line, pos.column] = true;

                if(board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.line = pos.line - 1;
            }

            // Down
            pos.setValues(position.line + 1, position.column);

            while (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.line = pos.line + 1;
            }

            // Right
            pos.setValues(position.line, position.column + 1);

            while (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.column = pos.column + 1;
            }

            // Left
            pos.setValues(position.line, position.column - 1);

            while (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;

                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.column = pos.column - 1;
            }


            return matriz;
        }
    }
}
