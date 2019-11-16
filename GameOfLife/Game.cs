using System.Threading;

namespace GameOfLife
{
    class Game
    {
        private Board _board;

        public Game(int width, int height)
        {
            _board = new Board(width, height);

            _board.InitLife((int)(width * height * 0.4));
        }


        public void Update()
        {
            _board.IterateThroughCells((int col, int row) =>
            {
                ProcessCell(col, row);
            });

            _board.Draw();
            Thread.Sleep(400);

        }

        private void ProcessCell(int col, int row)
        {
            var lifeSiblings = CountLifeSiblings(col, row);

            var state = _board.GetCellState(col, row);

            if (state == CellState.Life)
            {
                if(lifeSiblings <= 1 || lifeSiblings > 3)
                {
                    _board.SetCellState(col, row, CellState.Dead);
                    return;
                }
            }
            if (state == CellState.Dead)
            {
                if (lifeSiblings == 3)
                {
                    _board.SetCellState(col, row, CellState.Life);
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