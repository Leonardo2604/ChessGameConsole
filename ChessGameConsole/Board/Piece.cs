namespace ChessGameConsole.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }

        public Color Color { get; protected set; }
        
        public int MovesQuantity { get; protected set; }
        
        public ChessBoard Board { get; protected set; }

        public Piece(Color color, ChessBoard board)
        {
            Position = null;
            Color = color;
            Board = board;
            MovesQuantity = 0;
        }

        public void AddMovesQuantity()
        {
            MovesQuantity++;
        }

        public void RemoveMovesQuantity()
        {
            MovesQuantity--;
        }

        public bool ExistsPossibleMoves()
        {
            bool[,] positions = GetPossibleMoves();
            for (int row = 0; row < ChessBoard.columns; row++)
            {
                for (int column = 0; column < ChessBoard.rows; column++)
                {
                    if (positions[row, column])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return GetPossibleMoves()[position.Row, position.Column];
        }

        public abstract bool[,] GetPossibleMoves();
    }
}
