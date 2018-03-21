using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct Snake
    {
        public bool alive;
        public Direction direction;
        public List<SnakePart> body;
        Random rand;
        private Fruit fruit;

        public Snake(Direction dir)
        {
            fruit = new Fruit();
            rand = new Random();
            alive = true;
            direction = dir;
            body = new List<SnakePart> {
                    new SnakePart { posX=0,posY=0},
                    new SnakePart { posX=1,posY=0},
                    new SnakePart { posX=2,posY=0},

            };
        }

        public void Display()
        {
            Console.Clear();
            foreach (SnakePart sp  in body)
            {
                Console.SetCursorPosition(sp.posX, sp.posY);
                Console.WriteLine("0");
            }
            Console.SetCursorPosition(fruit.posX, fruit.posY);
            Console.WriteLine("♥");
        }

        public void changeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (direction != Direction.South)
                    {
                        direction = Direction.North;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != Direction.North)
                    {
                        direction = Direction.South;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.East)
                    {
                        direction = Direction.West;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.West)
                    {
                        direction = Direction.East;
                    }
                    break;
            }
        }

        public void Move()
        {
            Console.SetCursorPosition(body[0].posX, body[0].posY);
            Console.WriteLine(" ");
            for (int i = 0; i < body.Count - 1; i++)
            {
                body[i] = body[i + 1];
            }
            switch (direction)
            {
                case Direction.North:
                    body[body.Count - 1] = new SnakePart
                    {
                        posX = body[body.Count - 1].posX,
                        posY = body[body.Count - 1].posY - 1
                    };
                    break;
                case Direction.South:
                    body[body.Count - 1] = new SnakePart
                    {
                        posX = body[body.Count - 1].posX,
                        posY = body[body.Count - 1].posY + 1
                    };
                    break;
                case Direction.East:
                    body[body.Count - 1] = new SnakePart
                    {
                        posX = body[body.Count - 1].posX + 1,
                        posY = body[body.Count - 1].posY
                    };
                    break;
                case Direction.West:
                    body[body.Count - 1] = new SnakePart
                    {
                        posX = body[body.Count - 1].posX - 1,
                        posY = body[body.Count - 1].posY
                    };
                    break;
            }
            checkAlive();
            CheckFruit();
        }

        private void checkAlive()
        {
            if (body[body.Count - 1].posX < 0 || body[body.Count - 1].posY < 0)
            {
                alive = false;
            }
            for (int i = 0; i < body.Count-1; i++)
            {
                if (body[i].posX == body[body.Count-1].posX && body[i].posY == body[body.Count - 1].posY)
                {
                    alive = false;

                }
            }
        }

        private void CheckFruit()
        {
            if (fruit.posY == body[body.Count-1].posY && fruit.posX == body[body.Count-1].posX)
            {
                GenerateFruit();
                IsGrowing();
            }
        }

        private void IsGrowing()
        {
            body.Reverse();
            body.Add(body[0]);
            body.Reverse();
        }

        public void GenerateFruit()
        {
            bool flag = false;
            do
            {
                int x = rand.Next(0, 20);
                int y = rand.Next(0, 20);
                foreach (SnakePart sp in body)
                {
                    if (x == sp.posX && y == sp.posY)
                    {
                        flag = true;
                    }

                }
                fruit = new Fruit { posX = x, posY = y };
            } while (flag);
            
        }
    }
}
