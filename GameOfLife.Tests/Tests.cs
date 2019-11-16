using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(1,1, CellState.Life)]
        public void Should_CellGetAlive_When_HaveThreeSiblingsAlive(int col, int row, CellState state)
        {
            var board = new Board(3, 3);
            board.SetCellState(0, 0, CellState.Life);
            board.SetCellState(1, 0, CellState.Life);
            board.SetCellState(0, 1, CellState.Life);
            var game = new Game(board);

            var resultBoard = game.Update();

            resultBoard.GetCellState(col, row).Should().Be(state);
        }
    }
}
