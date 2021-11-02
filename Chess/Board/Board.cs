using Chess.Board;

namespace Board
{
    class BoardCF
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private readonly Piece[,] pieces;

        public BoardCF(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;

            pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public bool ThereAPieceIn(Position pos)
        {
            ValidatePosition(pos);

            return Piece(pos) != null;
        }

        public void InsertPiece(Piece p, Position pos)
        {
            if (ThereAPieceIn(pos))
            {
                throw new BoardException($"Já existe uma peça nesta posição. LxC {pos.Line}x{pos.Column}");
            }

            pieces[pos.Line, pos.Column] = p;

            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(Piece(pos) == null)
            {
                return null;
            }

            Piece aux = Piece(pos);

            aux.Position = null;

            pieces[pos.Line, pos.Column] = null;

            return aux;
        }

        public bool IsValidPosition(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns) {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if(!IsValidPosition(pos)) {
                throw new BoardException("Posição inválida.");
            }
        }
    }
}
