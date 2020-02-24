using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, ChessBoard board) : base(color, board)
        {

        }

        private bool ExisteEnemy(Position position)
        {
            Piece piece = Board.Find(position);
            return (piece != null && piece.Color != Color);
        }

        private bool Free(Position position)
        {
            return Board.Find(position) == null;
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] positions = new bool[ChessBoard.rows, ChessBoard.columns];
            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.Set(Position.Row - 1, Position.Column);
                if (Board.ValidPositon(position) && Free(position))
                {
                    positions[position.Row, position.Column] = true;
                }

                position.Set(Position.Row - 2, Position.Column);
                if (
                    Board.ValidPositon(position) 
                    && Free(position)
                    && MovesQuantity == 0
                )
                {
                    positions[position.Row, position.Column] = true;
                }

                position.Set(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPositon(position) && ExisteEnemy(position))
                {
                    positions[position.Row, position.Column] = true;
                }

                position.Set(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPositon(position) && ExisteEnemy(position))
                {
                    positions[position.Row, position.Column] = true;
                }
            }
            else
            {
                position.Set(Position.Row + 1, Position.Column);
                if (Board.ValidPositon(position) && Free(position))
                {
                    positions[position.Row, position.Column] = true;
                }

                position.Set(Position.Row + 2, Position.Column);
                if (
                    Board.ValidPositon(position)
                    && Free(position)
                    && MovesQuantity == 0
                )
                {
                    positions[position.Row, position.Column] = true;
                }

                position.Set(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPositon(position) && ExisteEnemy(position))
                {
                    positions[position.Row, position.Column] = true;
                }

                position.Set(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPositon(position) && ExisteEnemy(position))
                {
                    positions[position.Row, position.Column] = true;
                }
            }

            return positions;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
