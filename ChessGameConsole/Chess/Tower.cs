using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class Tower : Piece
    {
        public Tower(Color color, ChessBoard board) : base(color, board)
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
            while(Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Row -= 1;
            }

            // Leste
            position.Set(Position.Row, Position.Column + 1);
            while (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Column += 1;
            }

            // Sul
            position.Set(Position.Row + 1, Position.Column);
            while (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Row += 1;
            }

            // Oeste
            position.Set(Position.Row, Position.Column - 1);
            while (Board.ValidPositon(position) && CanMove(position))
            {
                positions[position.Row, position.Column] = true;
                Piece piece = Board.Find(position);
                if (piece != null && piece.Color != Color)
                {
                    break;
                }
                position.Column -= 1;
            }

            return positions;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
