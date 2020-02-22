using System;

namespace ChessGameConsole.Board.Exceptions
{
    class ChessBoardException : ApplicationException
    {
        public ChessBoardException()
        {
        }

        public ChessBoardException(string message) : base(message)
        {

        }

        public ChessBoardException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
