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

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);

            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] matriz = new bool[board.lines, board.columns]; // Matriz booleana de possíveis movimentos

            Position pos = new(0, 0);

            void validMove()
            {
                if (board.isValidPosition(pos) && canMove(pos))
                {
                    matriz[pos.line, pos.column] = true;
                }
            }

            // N
            pos.setValues(position.line - 1, position.column);
            
            if(board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            // NE
            pos.setValues(position.line - 1, position.column + 1);

            if(board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            // L
            pos.setValues(position.line, position.column + 1);

            if (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            // SE
            pos.setValues(position.line + 1, position.column + 1);

            if (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            // S
            pos.setValues(position.line + 1, position.column);

            if (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            // SO
            pos.setValues(position.line + 1, position.column - 1);

            if (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            // O
            pos.setValues(position.line, position.column - 1);

            if (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            // NO
            pos.setValues(position.line - 1, position.column - 1);

            if (board.isValidPosition(pos) && canMove(pos))
            {
                matriz[pos.line, pos.column] = true;
            }

            return matriz;
        }

    }
}
