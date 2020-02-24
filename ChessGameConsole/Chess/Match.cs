using System;
using ChessGameConsole.Board;
using ChessGameConsole.Board.Exceptions;

namespace ChessGameConsole.Chess
{
    class Match
    {
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
            StartPieces();
        }

        public void StartPieces()
        {
            Board.AddPiece(new ChessPosition('a', 1).ToPosition(), new Tower(Color.White, Board));
            Board.AddPiece(new ChessPosition('e', 1).ToPosition(), new King(Color.White, Board));
            Board.AddPiece(new ChessPosition('h', 1).ToPosition(), new Tower(Color.White, Board));

            Board.AddPiece(new ChessPosition('a', 8).ToPosition(), new Tower(Color.Black, Board));
            Board.AddPiece(new ChessPosition('e', 8).ToPosition(), new King(Color.Black, Board));
            Board.AddPiece(new ChessPosition('h', 8).ToPosition(), new Tower(Color.Black, Board));
        }

        private void MovePiece(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);
            if (piece != null)
            {
                Piece capturedPiece = Board.RemovePiece(to);
                piece.SetMoved();
                Board.AddPiece(to, piece);
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
    }
}
