using Chess.Board;

namespace Board
{
    class BoardCF
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public BoardCF(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;

            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public bool thereAPieceIn(Position pos)
        {
            validatePosition(pos);

            return piece(pos) != null;
        }

        public void insertPiece(Piece p, Position pos)
        {
            if (thereAPieceIn(pos))
            {
                throw new BoardException($"Já existe uma peça nesta posição. LxC {pos.line}x{pos.column}");
            }

            pieces[pos.line, pos.column] = p;

            p.position = pos;
        }

        public bool isValidPosition(Position pos)
        {
            if(pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }

            return true;
        }

        public void validatePosition(Position pos)
        {
            if(!isValidPosition(pos)) {
                throw new BoardException("Posição inválida.");
            }
        }
    }
}
