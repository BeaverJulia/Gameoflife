namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(30, 30);
            
            while(true)
            {
                game.Update();
            }
        }
    }
}
