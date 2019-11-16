using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(10, 10);
            
            while(true)
            {
                game.Update();
            }
        }
    }
}
