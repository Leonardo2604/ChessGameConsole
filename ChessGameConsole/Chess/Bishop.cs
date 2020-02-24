using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, ChessBoard board) : base(color, board)
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

            // Noroeste
            position.Set(Position.Row - 1, Position.Column - 1);
            while(Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Set(position.Row - 1, position.Column - 1);
            }

            // Nordeste
            position.Set(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Set(position.Row - 1, position.Column + 1);
            }

            // Sudeste
            position.Set(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Set(position.Row + 1, position.Column + 1);
            }

            // Sudoeste
            position.Set(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Set(position.Row + 1, position.Column - 1);
            }

            return positions;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
