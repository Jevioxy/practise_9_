using System;
namespace Snake
{
    class Fruit
    {
        public static int Width = (int)Walls.Width;
        public static int Height = (int)Walls.Height;
        int X { set; get; }
        int Y { set; get; }
        Random rnd = new Random();

        public void Restart()
        {
            X = Game.Width / 2;
            Y = Game.Height / 2 - 5;
        }

        void Rand(Snake snake)
        {
            X = rnd.Next(1, Width);
            Y = rnd.Next(1, Height);

            for (int i = snake.Length; i >= 1; i--)
            {
                if (snake.X[i - 1] == X && snake.Y[i - 1] == Y)
                {
                    Rand(snake);
                }
            }
        }

        void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("o");
        }

        public void Logic(ref Snake snake)
        {
            Draw();
            if (snake.X[0] == X)
            {
                if (snake.Y[0] == Y)
                {
                    snake.Length++; 
                    Rand(snake);
                }
            }
        }
    }
}
