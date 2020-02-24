namespace ChessGameConsole.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }

        public Color Color { get; protected set; }
        
        public bool Moved { get; protected set; }
        
        public ChessBoard Board { get; protected set; }

        public Piece(Color color, ChessBoard board)
        {
            Position = null;
            Color = color;
            Board = board;
            Moved = false;
        }

        public void SetMoved()
        {
            Moved = true;
        }

        public abstract bool[,] GetPossibleMoves();
    }
}
