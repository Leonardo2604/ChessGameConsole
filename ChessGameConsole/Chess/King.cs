using ChessGameConsole.Board;

namespace ChessGameConsole.Chess
{
    class King : Piece
    {
        private Match _match;

        public King(Color color, ChessBoard board, Match match) : base(color, board)
        {
            _match = match;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Find(position);
            return (piece == null || piece.Color != Color);
        }

        private bool RookToCastleTest(Position position)
        {
            Piece piece = Board.Find(position);
            return (
                piece != null
                && piece is Rook
                && piece.Color == Color
                && piece.MovesQuantity == 0
            );
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

            // #jogadaespecial roque
            if (MovesQuantity == 0 && !_match.InCheck)
            {
                // #jogadaespecial roque pequeno
                Position rookPosition1 = new Position(Position.Row, Position.Column + 3);
                if (RookToCastleTest(rookPosition1))
                {
                    Position bishopPosition = new Position(Position.Row, Position.Column + 1);
                    Position knightPosition = new Position(Position.Row, Position.Column + 2);

                    if (Board.Find(bishopPosition) == null && Board.Find(knightPosition) == null)
                    {
                        positions[Position.Row, Position.Column + 2] = true;
                    }
                }

                // #jogadaespecial roque grande
                Position rookPosition2 = new Position(Position.Row, Position.Column - 4);
                if (RookToCastleTest(rookPosition2))
                {
                    Position queenPosition = new Position(Position.Row, Position.Column - 1);
                    Position bishopPosition = new Position(Position.Row, Position.Column - 2);
                    Position knightPosition = new Position(Position.Row, Position.Column - 3);

                    if (
                        Board.Find(queenPosition) == null
                        && Board.Find(bishopPosition) == null
                        && Board.Find(knightPosition) == null
                    )
                    {
                        positions[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return positions;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
