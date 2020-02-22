using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class Tower : Piece
    {
        public Tower(Color color, ChessBoard board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
