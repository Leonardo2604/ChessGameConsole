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
                    try
                    {
                        Screen.Clear();
                        Screen.DrawMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position from = Screen.ReadChessPosition().ToPosition();

                        match.ValidatePositionFrom(from);

                        Screen.Clear();
                        Screen.DrawBoard(match.Board, match.Board.Find(from).GetPossibleMoves());

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position to = Screen.ReadChessPosition().ToPosition();

                        match.ValidatePositionTo(from, to);

                        match.PeformMove(from, to);
                    }
                    catch (ChessBoardException e) 
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);    
            }
        }
    }
}
