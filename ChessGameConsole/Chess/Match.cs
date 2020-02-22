using System;
using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class Match
    {
        private int _turn;
        private Color _currentPlayer;

        public ChessBoard Board { get; private set; }
        public bool Finished { get; private set; }

        public Match()
        {
            Board = new ChessBoard();
            _turn = 1;
            _currentPlayer = Color.White;
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

        public void MovePiece(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);
            if (piece != null)
            {
                Piece capturedPiece = Board.RemovePiece(to);
                piece.SetMoved();
                Board.AddPiece(to, piece);
            }
        }
    }
}
