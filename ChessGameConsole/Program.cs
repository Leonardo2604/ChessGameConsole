using System;
using ChessGameConsole.Board;

namespace ChessGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            Position position = new Position(0, 0);
            Console.WriteLine(position);
        }
    }
}
