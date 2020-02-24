using System;
using ChessGameConsole.Board;
using ChessGameConsole.Board.Exceptions;
using ChessGameConsole.Chess;

namespace ChessGameConsole
{
    class Program
    {
        static void Main()
        {
            try
            {
                Match match = new Match();

                while(!match.Finished)
                {
                    Screen.Clear();
                    Screen.DrawBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position from = Screen.ReadChessPosition().ToPosition();

                    Piece piece = match.Board.Find(from);

                    if (piece != null)
                    {
                        Screen.Clear();
                        Screen.DrawBoard(match.Board, piece.GetPossibleMoves());
                    }

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position to = Screen.ReadChessPosition().ToPosition();

                    match.MovePiece(from, to);
                }
                
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);    
            }
        }
    }
}
