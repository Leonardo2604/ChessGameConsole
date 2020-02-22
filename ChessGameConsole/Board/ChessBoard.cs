namespace ChessGameConsole.Board
{
    class ChessBoard
    {
        private Piece[,] _pieces;

        public ChessBoard()
        {
            _pieces = new Piece[8, 8];
        }

        public Piece Find(int row, int column)
        {
            return _pieces[row, column];
        }
    }
}
