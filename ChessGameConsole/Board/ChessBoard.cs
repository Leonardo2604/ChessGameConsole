using ChessGameConsole.Board.Exceptions;

namespace ChessGameConsole.Board
{
    class ChessBoard
    {
        private readonly Piece[,] _pieces;
        public const int rows = 8;
        public const int columns = 8;

        public ChessBoard()
        {
            _pieces = new Piece[8, 8];
        }

        public Piece Find(int row, int column)
        {
            return _pieces[row, column];
        }

        public Piece Find(Position position)
        {
            return _pieces[position.Row, position.Column];
        }

        public void PutPiece(Position position, Piece piece)
        {
            if (PieceExists(position))
            {
                throw new ChessBoardException($"Já existe uma peça nessa posição {position}");
            }
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool PieceExists(Position position)
        {
            ValidatePosition(position);
            return Find(position) != null;
        }

        public bool ValidPositon(Position position) 
        {
            return (
                position.Row < rows
                && position.Row >= 0
                && position.Column < columns
                && position.Column >= 0
            );
        }

        public void ValidatePosition(Position position)
        {
            if (ValidPositon(position) == false)
            {
                throw new ChessBoardException($"Posição inválida! {position}");
            }
        }
    }
}
