using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(20, 20);
            
            while(true)
            {
                game.Update();
            }
        }
    }
}
