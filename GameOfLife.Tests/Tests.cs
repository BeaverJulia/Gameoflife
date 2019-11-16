using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class Tests
    {
        private Board _board;

        [SetUp]
        public void Setup()
        {
            var board = new Board(10, 10);
            board.SetCellState(0, 0, CellState.Life);
            board.SetCellState(1, 0, CellState.Life);
            board.SetCellState(0, 1, CellState.Life);

            board.SetCellState(7, 6, CellState.Life);
            board.SetCellState(7, 7, CellState.Life);

            board.SetCellState(0, 6, CellState.Life);
            board.SetCellState(0, 7, CellState.Life);
            board.SetCellState(1, 6, CellState.Life);
            board.SetCellState(1, 7, CellState.Life);
            board.SetCellState(2, 6, CellState.Life);
            _board = board;
        }

        [Test]
        [TestCase(1, 1, CellState.Life)]
        [TestCase(7, 6, CellState.Dead)]
        [TestCase(1, 6, CellState.Dead)]
        public void WhenCallUpdate_CellChangeState(int col, int row, CellState state)
        {
            var game = new Game(_board);

            var resultBoard = game.Update();

            resultBoard.GetCellState(col, row).Should().Be(state);
        }
    }
}
