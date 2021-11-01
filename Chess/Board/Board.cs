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
    }
}
