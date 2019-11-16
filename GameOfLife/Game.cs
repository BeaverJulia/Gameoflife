using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    class Game
    {
        private Board _board;

        public Game(int width, int height)
        {
            _board = new Board(width, height);

            _board.InitLife(10);
        }


        public void Update()
        {
            //todo 
            _board.Draw();
            Thread.Sleep(400);

        }
        
        public void 

    }
}
