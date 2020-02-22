using System;
using ChessGameConsole.Board;

namespace ChessGameConsole
{
    class Screen
    {
        public static void DrawBoard(ChessBoard board)
        {
            for(int row = 0; row < 8; row++)
            {
                for(int column = 0; column < 8; column++)
                {
                    Piece piece = board.Find(row, column);
                    if (piece == null)
                    {
                        Console.Write("- ");
                    } 
                    else
                    {
                        Console.Write($"{piece} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
