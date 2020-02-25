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
        public bool InCheck { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }

        public Match()
        {
            Board = new ChessBoard();
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            InCheck = false;
            VulnerableEnPassant = null;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            StartPieces();
        }

        private Piece MovePiece(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);
            piece.AddMovesQuantity();
            Piece capturedPiece = Board.RemovePiece(to);
            Board.AddPiece(to, piece);

            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

            //#jogadaespecial roque pequeno
            if (piece is King && to.Column == from.Column + 2)
            {
                Position rookPositionFrom = new Position(from.Row, from.Column + 3);
                Position rookPositionTo = new Position(from.Row, from.Column + 1);
                MovePiece(rookPositionFrom, rookPositionTo);
            }

            //#jogadaespecial roque grande
            if (piece is King && to.Column == from.Column - 2)
            {
                Position rookPositionFrom = new Position(from.Row, from.Column - 4);
                Position rookPositionTo = new Position(from.Row, from.Column - 1);
                MovePiece(rookPositionFrom, rookPositionTo);
            }

            //#jogadaespecial en passant
            if (piece is Pawn)
            {
                if (from.Column != to.Column && capturedPiece == null) 
                {
                    Position piecePosition;
                    if (piece.Color == Color.White)
                    {
                        piecePosition = new Position(to.Row + 1, to.Column);
                    }
                    else
                    {
                        piecePosition = new Position(to.Row - 1, to.Column);
                    }

                    capturedPiece = Board.RemovePiece(piecePosition);
                    _capturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
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

        private Color GetAdversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }

            return Color.White;
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece piece in GetPiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        public void AddNewPiece(char column, int row, Piece piece)
        {
            Board.AddPiece(new ChessPosition(column, row).ToPosition(), piece);
            _pieces.Add(piece);
        }

        public void StartPieces()
        {
            AddNewPiece('a', 1, new Rook(Color.White, Board));
            AddNewPiece('b', 1, new Knight(Color.White, Board));
            AddNewPiece('c', 1, new Bishop(Color.White, Board));
            AddNewPiece('d', 1, new Queen(Color.White, Board));
            AddNewPiece('e', 1, new King(Color.White, Board, this));
            AddNewPiece('f', 1, new Bishop(Color.White, Board));
            AddNewPiece('g', 1, new Knight(Color.White, Board));
            AddNewPiece('h', 1, new Rook(Color.White, Board));
            AddNewPiece('a', 2, new Pawn(Color.White, Board, this));
            AddNewPiece('b', 2, new Pawn(Color.White, Board, this));
            AddNewPiece('c', 2, new Pawn(Color.White, Board, this));
            AddNewPiece('d', 2, new Pawn(Color.White, Board, this));
            AddNewPiece('e', 2, new Pawn(Color.White, Board, this));
            AddNewPiece('f', 2, new Pawn(Color.White, Board, this));
            AddNewPiece('g', 2, new Pawn(Color.White, Board, this));
            AddNewPiece('h', 2, new Pawn(Color.White, Board, this));

            AddNewPiece('a', 8, new Rook(Color.Black, Board));
            AddNewPiece('b', 8, new Knight(Color.Black, Board));
            AddNewPiece('c', 8, new Bishop(Color.Black, Board));
            AddNewPiece('d', 8, new Queen(Color.Black, Board));
            AddNewPiece('e', 8, new King(Color.Black, Board, this));
            AddNewPiece('f', 8, new Bishop(Color.Black, Board));
            AddNewPiece('g', 8, new Knight(Color.Black, Board));
            AddNewPiece('h', 8, new Rook(Color.Black, Board));
            AddNewPiece('a', 7, new Pawn(Color.Black, Board, this));
            AddNewPiece('b', 7, new Pawn(Color.Black, Board, this));
            AddNewPiece('c', 7, new Pawn(Color.Black, Board, this));
            AddNewPiece('d', 7, new Pawn(Color.Black, Board, this));
            AddNewPiece('e', 7, new Pawn(Color.Black, Board, this));
            AddNewPiece('f', 7, new Pawn(Color.Black, Board, this));
            AddNewPiece('g', 7, new Pawn(Color.Black, Board, this));
            AddNewPiece('h', 7, new Pawn(Color.Black, Board, this));
        }

        public bool IsInCheck(Color color)
        {
            Piece king = GetKing(color);
            if(king == null)
            {
                throw new ChessBoardException($"Não tem o rei da cor {color} no tabuleiro!");
            }

            foreach(Piece piece in GetPiecesInGame(GetAdversary(color)))
            {
                bool[,] positions = piece.GetPossibleMoves();
                if (positions[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public void PeformMove(Position from, Position to) 
        {
            Piece pieceCaptured = MovePiece(from, to);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(from, to, pieceCaptured);
                throw new ChessBoardException("Você não pode se colocar em xeque!");
            }

            if (IsInCheck(GetAdversary(CurrentPlayer)))
            {
                InCheck = true;
            } 
            else
            {
                InCheck = false;
            }

            if (TestCheckmate(GetAdversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            Piece piece = Board.Find(to);
            // #jogadaespecial en passant
            if (piece is Pawn && (to.Row == from.Row - 2 || to.Row == from.Row + 2))
            {
                VulnerableEnPassant = piece;
            }
            else
            {
                VulnerableEnPassant = null;
            }
        }

        public bool TestCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in GetPiecesInGame(color))
            {
                bool[,] positions = piece.GetPossibleMoves();

                for (int row = 0; row < ChessBoard.columns; row++)
                {
                    for (int column = 0; column < ChessBoard.rows; column++)
                    {
                        if (positions[row, column])
                        {
                            Position from = piece.Position;
                            Position to = new Position(row, column);
                            Piece capturedPiece = MovePiece(from, to);
                            bool isCheckmate = IsInCheck(color);
                            UndoMove(from, to, capturedPiece);
                            if (!isCheckmate)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void UndoMove(Position from, Position to, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(to);
            piece.RemoveMovesQuantity();
            if (capturedPiece != null)
            {
                Board.AddPiece(to, capturedPiece);
                _capturedPieces.Remove(capturedPiece);
            }
            Board.AddPiece(from, piece);

            //#jogadaespecial roque pequeno
            if (piece is King && to.Column == from.Column + 2)
            {
                Position rookPositionFrom = new Position(from.Row, from.Column + 3);
                Position rookPositionTo = new Position(from.Row, from.Column + 1);
                UndoMove(rookPositionFrom, rookPositionTo, null);
            }

            //#jogadaespecial roque grande
            if (piece is King && to.Column == from.Column - 2)
            {
                Position rookPositionFrom = new Position(from.Row, from.Column - 4);
                Position rookPositionTo = new Position(from.Row, from.Column - 1);
                UndoMove(rookPositionFrom, rookPositionTo, null);
            }

            //#jogadaespecial en passant
            if (piece is Pawn)
            {
                if (from.Column != to.Column && capturedPiece == VulnerableEnPassant)
                {
                    Piece piece1 = Board.RemovePiece(to);
                    Position piecePosition;
                    if (piece.Color == Color.White)
                    {
                        piecePosition = new Position(3, to.Column);
                    }
                    else
                    {
                        piecePosition = new Position(4, to.Column);
                    }

                    Board.AddPiece(piecePosition, piece1);
                }
            }
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
            if (!Board.Find(from).IsPossibleMove(to))
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
