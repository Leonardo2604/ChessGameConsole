using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class King : Piece
    {
        public King(Color color, ChessBoard board) : base(color, board)
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

            // Norte
            position.Set(Position.Row - 1, Position.Column);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            // Nordeste
            position.Set(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            // Leste
            position.Set(Position.Row, Position.Column + 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            // Sudeste
            position.Set(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            // Sul
            position.Set(Position.Row + 1, Position.Column);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            // Sudoeste
            position.Set(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            // Oeste
            position.Set(Position.Row, Position.Column - 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            // Noroeste
            position.Set(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
            }

            return positions;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
