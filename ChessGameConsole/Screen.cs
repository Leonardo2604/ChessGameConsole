using System;
using ChessGameConsole.Board;

namespace ChessGameConsole
{
    class Screen
    {
        public static void DrawBoard(ChessBoard board)
        {
            for(int column = 0; column < ChessBoard.rows; column++)
            {
                for(int row = 0; row < ChessBoard.columns; row++)
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
