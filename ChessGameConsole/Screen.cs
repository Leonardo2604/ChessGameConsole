using System;
using ChessGameConsole.Board;

namespace ChessGameConsole
{
    class Screen
    {
        public static void DrawBoard(ChessBoard board)
        {
            for(int column = 0; column < ChessBoard.columns; column++)
            {
                Console.Write($"{ChessBoard.rows - column} ");
                for(int row = 0; row < ChessBoard.rows; row++)
                {
                    Piece piece = board.Find(row, column);
                    if (piece == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        DrawPiece(piece);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        private static void DrawPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            } 
            else
            {
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = temp;
            }
        }
    }
}
