using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class Pawn : Piece
    {

        private Match _match;

        public Pawn(Color color, ChessBoard board, Match match) : base(color, board)
        {
            _match = match;
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

                // #jogadaespecial en passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (
                        Board.ValidPositon(left) 
                        && ExisteEnemy(left)
                        && Board.Find(left) == _match.VulnerableEnPassant
                    )
                    {
                        positions[left.Row - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (
                        Board.ValidPositon(right)
                        && ExisteEnemy(right)
                        && Board.Find(right) == _match.VulnerableEnPassant
                    )
                    {
                        positions[right.Row - 1, right.Column] = true;
                    }
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

                // #jogadaespecial en passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (
                        Board.ValidPositon(left)
                        && ExisteEnemy(left)
                        && Board.Find(left) == _match.VulnerableEnPassant
                    )
                    {
                        positions[left.Row + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (
                        Board.ValidPositon(right)
                        && ExisteEnemy(right)
                        && Board.Find(right) == _match.VulnerableEnPassant
                    )
                    {
                        positions[right.Row + 1, right.Column] = true;
                    }
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
