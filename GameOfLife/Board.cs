using System;

namespace GameOfLife
{
    public class Board
    {
        private Random _rnd = new Random(Guid.NewGuid().GetHashCode());

        private Cell[,] _cells;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new Cell[width, height];
            IterateThroughCells((int col, int row) =>
            {
                _cells[col, row] = new Cell(col, row, CellState.Dead);
            });
        }

        public int Width { get; }
        public int Height { get; }

        public void Draw()
        {
            IterateThroughCells((int col, int row) =>
            {
                Console.SetCursorPosition(col, row);
                _cells[col, row].Draw();
            });
        }

        public void SetCellState(int col, int row, CellState state)
        {
            _cells[col, row].State = state;
        }

        public CellState GetCellState(int col, int row)
        {
            return _cells[col, row].State;
        }

        public void InitLife(int lifeCellsCount)
        {
            while(lifeCellsCount > 0)
            {
                IterateThroughCells((int col, int row) =>
                {
                    if(lifeCellsCount == 0)
                    {
                        return;
                    }

                    var generateLife = _rnd.Next(1, 10) == 1;

                    if (generateLife)
                    {
                        SetCellState(col, row, CellState.Life);
                        lifeCellsCount--;
                    }
                });
            }
        }

        public void IterateThroughCells(Action<int, int> action)
        {
            for (int col = 0; col < Width; col++)
            {
                for (int row = 0; row < Height; row++)
                {
                    action(col, row);
                }
            }
        }

        public bool IsValidCell(int col, int row)
        {
            if (col < 0 || row < 0)
                return false;

            if (col > Width - 1 || row > Height - 1)
                return false;

            return true;
        }
    }
}
