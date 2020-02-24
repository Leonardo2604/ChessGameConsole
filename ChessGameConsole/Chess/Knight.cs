using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class Knight : Piece
    {
        public Knight(Color color, ChessBoard board) : base(color, board)
        {

        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Find(position);
            return (piece == null || piece.Color != Color);
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] positions = new bool[ChessBoard.rows, ChessBoard.columns];
            Position position = new Position(0, 0);

            position.Set(Position.Row - 1, Position.Column - 2);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            position.Set(Position.Row - 2, Position.Column - 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            position.Set(Position.Row - 2, Position.Column + 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            position.Set(Position.Row - 1, Position.Column + 2);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            position.Set(Position.Row + 1, Position.Column + 2);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            position.Set(Position.Row + 2, Position.Column + 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            position.Set(Position.Row + 2, Position.Column - 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            position.Set(Position.Row + 1, Position.Column - 2);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            return positions;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
