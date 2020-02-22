using ChessGameConsole.Board;
using ChessGameConsole.Chess;

namespace ChessGameConsole
{
    class Program
    {
        static void Main()
        {
            ChessPosition position = new ChessPosition('c', 7);
            System.Console.WriteLine(position.ToPosition());
        }
    }
}
