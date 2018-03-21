using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Snake snake = new Snake(Direction.East);
            snake.GenerateFruit();
            while (snake.alive)
            {

                ConsoleKey key = Console.ReadKey(true).Key;
                while (!Console.KeyAvailable)
                {
                    snake.Move();
                    if (!snake.alive)
                    {
                        break;
                    }
                    snake.Display();
                    System.Threading.Thread.Sleep(200);
                }
                
                snake.changeDirection(key);
                
            }
            Console.WriteLine("Vous avez perdu");

        }
    }
}
