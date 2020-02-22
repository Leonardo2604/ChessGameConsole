using ChessGameConsole.Board;
using ChessGameConsole.Chess;

namespace ChessGameConsole
{
    class Program
    {
        static void Main()
        {
            ChessBoard board = new ChessBoard();
            board.PutPiece(new Position(4, 0), new King(Color.Black, board));
            board.PutPiece(new Position(0, 0), new Tower(Color.White, board));
            board.PutPiece(new Position(7, 0), new Tower(Color.White, board));
            Screen.DrawBoard(board);
        }
    }
}
