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

        public void PutPiece(Position position, Piece piece)
        {
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}
