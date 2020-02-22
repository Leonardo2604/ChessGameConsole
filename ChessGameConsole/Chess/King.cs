using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class King : Piece
    {
        public King(Color color, ChessBoard board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
