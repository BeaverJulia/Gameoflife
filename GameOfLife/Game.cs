using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        private Board _board;

        public Game(Board board)
        {
            _board = board;
        }


        public Board Update()
        {
            var board = _board.Clone();

            board.IterateThroughCells((int col, int row) =>
            {
                ProcessCell(board, col, row);
            });

            _board = board;

            return _board;
        }

        public void Draw()
        {
            _board.Draw();
        }

        private void ProcessCell(Board board, int col, int row)
        {
            var lifeSiblings = CountLifeSiblings(col, row);

            var state = board.GetCellState(col, row);

            if (state == CellState.Life)
            {
                if(lifeSiblings <= 1 || lifeSiblings > 3)
                {
                    board.SetCellState(col, row, CellState.Dead);
                    return;
                }
            }
            if (state == CellState.Dead)
            {
                if (lifeSiblings == 3)
                {
                    board.SetCellState(col, row, CellState.Life);
                    return;
                }
            }
        }

        private int CountLifeSiblings(int col, int row)
        {
            var lifeSiblings = 0;

            for (var xAxis = -1; xAxis <= 1; xAxis++)
            {
                for (var yAxis = -1; yAxis <= 1; yAxis++)
                {
                    if (xAxis == 0 && yAxis == 0) continue;

                    if (!_board.IsValidCell(col, row)) continue;

                    if (!_board.IsValidCell(col + xAxis, row + yAxis)) continue;

                    var siblingState = _board.GetCellState(col + xAxis, row + yAxis);

                    if (siblingState == CellState.Life)
                    {
                        lifeSiblings++;
                    }
                }
            }

            return lifeSiblings;
        }
    }
}