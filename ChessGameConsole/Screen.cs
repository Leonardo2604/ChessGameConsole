using System;
using ChessGameConsole.Board;
using ChessGameConsole.Chess;

namespace ChessGameConsole
{
    class Screen
    {
        public static void DrawBoard(ChessBoard board)
        {
            for(int row = 0; row < ChessBoard.columns; row++)
            {
                Console.Write($"{ChessBoard.rows - row} ");
                for(int column = 0; column < ChessBoard.rows; column++)
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

        public static void Clear()
        {
            Console.Clear();
        }

        public static ChessPosition ReadChessPosition()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int row = int.Parse(position[1].ToString());
            return new ChessPosition(column, row);
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
