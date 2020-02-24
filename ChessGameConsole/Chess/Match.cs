using System.Collections.Generic;
using ChessGameConsole.Board;
using ChessGameConsole.Board.Exceptions;

namespace ChessGameConsole.Chess
{
    class Match
    {
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public Color CurrentPlayer { get; private set; }
        public int Turn { get; private set; }
        public ChessBoard Board { get; private set; }
        public bool Finished { get; private set; }

        public Match()
        {
            Board = new ChessBoard();
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            StartPieces();
        }

        public void AddNewPiece(char column, int row, Piece piece)
        {
            Board.AddPiece(new ChessPosition(column, row).ToPosition(), piece);
            _pieces.Add(piece);
        }

        public void StartPieces()
        {
            AddNewPiece('a', 1, new Tower(Color.White, Board));
            AddNewPiece('e', 1, new King(Color.White, Board));
            AddNewPiece('h', 1, new Tower(Color.White, Board));

            AddNewPiece('a', 8, new Tower(Color.Black, Board));
            AddNewPiece('e', 8, new King(Color.Black, Board));
            AddNewPiece('h', 8, new Tower(Color.Black, Board));
        }

        private void MovePiece(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);
            piece.SetMoved();
            Piece capturedPiece = Board.RemovePiece(to);
            Board.AddPiece(to, piece);
            
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Black)
            {
                CurrentPlayer = Color.White;
            }
            else
            {
                CurrentPlayer = Color.Black;
            }
        }

        public void PeformMove(Position from, Position to) 
        {
            MovePiece(from, to);
            Turn++;
            ChangePlayer();
        }

        public void ValidatePositionFrom(Position position)
        {
            Piece piece = Board.Find(position);

            if (piece == null)
            {
                throw new ChessBoardException("Não existe peça na posição escolhida!");
            }

            if (piece.Color != CurrentPlayer)
            {
                throw new ChessBoardException("A peça de origem escolhida não é sua!");
            }

            if (!piece.ExistsPossibleMoves())
            {
                throw new ChessBoardException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidatePositionTo(Position from, Position to)
        {
            if (!Board.Find(from).CanMoveTo(to))
            {
                throw new ChessBoardException("Posição de destino inválida!");
            }
        }

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();

            foreach(Piece piece in _capturedPieces)
            {
                if (piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }

            return pieces;
        }

        public HashSet<Piece> GetPiecesInGame(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();

            foreach (Piece piece in _pieces)
            {
                if (piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }

            pieces.ExceptWith(GetCapturedPieces(color));

            return pieces;
        }
    }
}
