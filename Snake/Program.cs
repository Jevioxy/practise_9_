using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
            Console.ReadKey();
        }
    }
    class Game
    {
        public static int Width = (int)Walls.Width;
        public static int Height = (int)Walls.Height;

        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;

        Snake snake;
        Fruit fruit;

        bool IsLost;

        public Game()
        {
            Console.CursorVisible = false;
            snake = new Snake();
            fruit = new Fruit();
        }

        void StartGame()
        {
            Board.Write();
            Console.SetCursorPosition(Height / 6, Width / 3+1);
            Console.Write("Нажмите кнопку чтобы начать");
            Console.SetCursorPosition(40, Width / 3 + 1);
            Console.Write("Для перемещения используйте стрелочки");
            Console.ReadKey();
            Console.Clear();

            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();

            IsLost = false;
            
            snake.Restart();
            fruit.Restart();
            Board.Write();
            
        }
        void Control()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }

            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    snake.Run(Snake.Direction.Top);
                    break;
                case ConsoleKey.DownArrow:
                    snake.Run(Snake.Direction.Bottom);
                    break;
                case ConsoleKey.LeftArrow:
                    snake.Run(Snake.Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    snake.Run(Snake.Direction.Right);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
        void Logic()
        {
            Control();
            fruit.Logic(ref snake);
            snake.Logic(ref IsLost);
        }
        public void Play()
        {
            while (true)
            {
                StartGame();
                while (IsLost == false)
                {
                    Logic();
                    Thread.Sleep(100);
                }
                Console.SetCursorPosition(Height / 2, Width / 2);
                Console.Write("Игра закончена.");
                Console.SetCursorPosition(Height / 2, Width / 2+1);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Ваш счет: " + snake.Length);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
            }
        }
    }
}
