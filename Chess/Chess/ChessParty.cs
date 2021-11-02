using Board;
using Chess.Board;

namespace Chess
{
    class ChessParty {
        public BoardCF board { get; private set; }
        public int turn;
        public Color currentPlayer;
        public bool finished { get; private set; }



        public ChessParty()
        {
            board = new BoardCF(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            insertPieces();
        }

        public void MakeMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);

            p.incMoves();

            Piece capturedPiece = board.removePiece(destiny);

            board.insertPiece(p, destiny);
        }

        private void changePlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }else {
                currentPlayer = Color.White;
            }
        }

        public void makePlay(Position origin, Position destiny)
        {
            MakeMovement(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) {  
            if(board.piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida");
            }

            if(currentPlayer != board.piece(pos).color)
            {
                throw new BoardException($"É a vez de: {currentPlayer}");
            }

            if (!board.piece(pos).havePossibleMovements())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida.");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida");
            }
        }

        private void insertPieces()
        {
            //B
            board.insertPiece(new Tower(board, Color.Black), new PositionChess('c', 1).toPosition());
            board.insertPiece(new King(board, Color.Black), new PositionChess('d', 1).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new PositionChess('e', 1).toPosition());

            board.insertPiece(new Tower(board, Color.Black), new PositionChess('c', 2).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new PositionChess('d', 2).toPosition());
            board.insertPiece(new Tower(board, Color.Black), new PositionChess('e', 2).toPosition());

            //W
            board.insertPiece(new Tower(board, Color.White), new PositionChess('a', 7).toPosition());
            board.insertPiece(new Tower(board, Color.White), new PositionChess('b', 7).toPosition());
            board.insertPiece(new Tower(board, Color.White), new PositionChess('c', 7).toPosition());
            board.insertPiece(new Tower(board, Color.White), new PositionChess('d', 7).toPosition());
            board.insertPiece(new Tower(board, Color.White), new PositionChess('e', 7).toPosition());
            board.insertPiece(new Tower(board, Color.White), new PositionChess('f', 7).toPosition());
            board.insertPiece(new Tower(board, Color.White), new PositionChess('g', 7).toPosition());
            board.insertPiece(new Tower(board, Color.White), new PositionChess('h', 7).toPosition());


        }
    }
}
