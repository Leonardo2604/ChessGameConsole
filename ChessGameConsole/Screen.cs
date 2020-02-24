using System;
using System.Collections.Generic;
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
                    DrawPiece(piece);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        private static void DrawPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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

                Console.Write(" ");
            }
        }

        public static void DrawBoard(ChessBoard board, bool[,] possibleMoves)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            ConsoleColor otherColor = ConsoleColor.DarkGray;
            for (int row = 0; row < ChessBoard.columns; row++)
            {
                Console.Write($"{ChessBoard.rows - row} ");
                for (int column = 0; column < ChessBoard.rows; column++)
                {
                    if (possibleMoves[row, column]) 
                    {
                        Console.BackgroundColor = otherColor;
                    }

                    DrawPiece(board.Find(row, column));
                    Console.BackgroundColor = defaultColor;
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

        public static void DrawMatch(Match match)
        {
            DrawBoard(match.Board);
            Console.WriteLine();
            DrawCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Turno: {match.Turn}");

            if (!match.Finished)
            {
                Console.WriteLine($"Aguardando jogada: {match.CurrentPlayer}");
                if (match.InCheck)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: {match.CurrentPlayer}");
            }
        }

        public static void DrawCapturedPieces(Match match)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            DrawParts(match.GetCapturedPieces(Color.White));
            
            Console.WriteLine();

            Console.Write("Pretas: ");
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            DrawParts(match.GetCapturedPieces(Color.Black));
            Console.ForegroundColor = defaultColor;
            Console.WriteLine();
        }

        public static void DrawParts(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach(Piece piece in pieces)
            {
                Console.Write($"{piece} ");
            }
            Console.Write("]");
        }
    }
}
