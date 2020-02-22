using System;
using ChessGameConsole.Board;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            Screen.DrawBoard(board);
        }
    }
}
