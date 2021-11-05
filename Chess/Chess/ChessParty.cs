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
            InsertPiecesDefaultGame();
        }

        private void InsertPiecesDefaultGame()
        {
            char[] Houses = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            for(int i = 0; i < Houses.Length; i++)
            {
                char House = Houses[i];

                Board.InsertPiece(new Pawn(Board, Color.White), new PositionChess(House, 2).ToPosition()); // Insere todos os peões de a-h na segunda fileira ; Brancas
                Board.InsertPiece(new Pawn(Board, Color.Black), new PositionChess(House, 7).ToPosition()); // Insere todos os peões de a-h na sétima fileira ; Pretas

                //// Insert pieces by default

                if (House == 'a')
                {
                    Board.InsertPiece(new Tower(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new Tower(Board, Color.White), new PositionChess(House, 1).ToPosition());
                } 
                
                if (House == 'h')
                {
                    Board.InsertPiece(new Tower(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new Tower(Board, Color.White), new PositionChess(House, 1).ToPosition());
                } 
                
                if (House == 'b')
                {
                    Board.InsertPiece(new Knight(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new Knight(Board, Color.White), new PositionChess(House, 1).ToPosition());
                } 
                
                if (House == 'g')
                {
                    Board.InsertPiece(new Knight(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new Knight(Board, Color.White), new PositionChess(House, 1).ToPosition());
                } 
                
                if (House == 'c')
                {
                    Board.InsertPiece(new Bishop(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new Bishop(Board, Color.White), new PositionChess(House, 1).ToPosition());

                } 
                
                if (House == 'f')
                {
                    Board.InsertPiece(new Bishop(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new Bishop(Board, Color.White), new PositionChess(House, 1).ToPosition());
                } 
                
                if (House == 'e')
                {
                    Board.InsertPiece(new King(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new King(Board, Color.White), new PositionChess(House, 1).ToPosition());
                } 
                
                if (House == 'd')
                {
                    Board.InsertPiece(new Queen(Board, Color.Black), new PositionChess(House, 8).ToPosition());
                    Board.InsertPiece(new Queen(Board, Color.White), new PositionChess(House, 1).ToPosition());
                }
            };

        }
    }
}
