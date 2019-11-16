using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = 30;
            var height = 30;

            var board = new Board(width, height);
            board.InitRadomLife((int)(width * height * 0.4));

            var game = new Game(board);
            
            while(true)
            {
                game.Update();
                game.Draw();

                Thread.Sleep(400);
            }
        }
    }
}
