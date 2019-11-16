using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Cell
    {
        public Cell(int x, int y, CellState state)
        {
            X = x;
            Y = y;
            State = state;
        }

        public int X { get; }
        public int Y { get; }
        public CellState State { get; set; }

        public void Draw()
        {
            if(State == CellState.Dead)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
