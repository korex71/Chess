using Board;
using Chess.Board;

namespace Chess
{
    class ChessParty {
        public BoardCF Board { get; private set; }
        public int Turn;
        public Color CurrentPlayer;
        public bool Finished { get; private set; }



        public ChessParty()
        {
            Board = new BoardCF(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            InsertPieces();
        }

        public void MakeMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);

            p.IncMoves();

            Piece CapturedPiece = Board.RemovePiece(destiny);

            Board.InsertPiece(p, destiny);
        }

        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }else {
                CurrentPlayer = Color.White;
            }
        }

        public void MakePlay(Position origin, Position destiny)
        {
            //if (Check)
            //{
            //    throw new BoardException($"Seu rei está em xeque, mova o rei.");
            //}
            MakeMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos) {  
            if(Board.Piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida");
            }

            if(CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException($"É a vez de: {CurrentPlayer}");
            }

            if (!Board.Piece(pos).HavePossibleMovements())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida.");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            //if(Board.Piece(origin).ToString() == "R") {

            //}

            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida");
            }
        }

        private void InsertPieces()

        {
            //B
            Board.InsertPiece(new Tower(Board, Color.Black), new PositionChess('c', 1).ToPosition());
            Board.InsertPiece(new King(Board, Color.Black), new PositionChess('d', 1).ToPosition());
            Board.InsertPiece(new Tower(Board, Color.Black), new PositionChess('e', 1).ToPosition());

            Board.InsertPiece(new Tower(Board, Color.Black), new PositionChess('c', 2).ToPosition());
            Board.InsertPiece(new Tower(Board, Color.Black), new PositionChess('d', 2).ToPosition());
            Board.InsertPiece(new Tower(Board, Color.Black), new PositionChess('e', 2).ToPosition());

            //W
            //Board.InsertPiece(new Bishop(Board, Color.White), new PositionChess('d', 4).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('a', 7).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('b', 7).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('c', 7).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('d', 7).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('e', 7).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('f', 7).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('g', 7).ToPosition());
            //Board.InsertPiece(new Tower(Board, Color.White), new PositionChess('h', 7).ToPosition());

        }

        private void InsertPiecesDefaultGame()
        {
            char[] Houses = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            for(int i = 0; i < Houses.Length; i++)
            {
                char House = Houses[i];

                Board.InsertPiece(new Pawn(Board, Color.White), new PositionChess(House, 2).ToPosition()); // Insere todos os peões de a-h na segunda fileira ; Brancas
            };

        }
    }
}
