using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            //drawing a game field frame
            Console.ForegroundColor = ConsoleColor.Blue;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Console.ForegroundColor = ConsoleColor.Green;
            Point snakeTail = new Point(15, 15, 's');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            Console.ForegroundColor = ConsoleColor.Yellow;
            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '$');
            Point food = foodGenerator.GenerateFood();
            FoodGenerator badFoodGenerator = new FoodGenerator(80, 25, '!');
            Point Badfood = badFoodGenerator.GenerateBadFood();
            food.Draw();
            Badfood.Draw();
            
            while(true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }


                if(snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score++;
                }
                else if(snake.Eat(Badfood))
                {
                    Badfood = badFoodGenerator.GenerateBadFood();
                    Badfood.Draw();
                    score--;
                }
                else
                {
                    snake.Move();
                }

                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }

                Thread.Sleep(300);
                
            }

            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }

        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("=======================", xOffset, yOffset++);
            WriteText("      GAME OVER        ", xOffset+1, yOffset++);
            yOffset++;
            WriteText($"You scored {score} points.", xOffset + 2, yOffset++);
            WriteText("", xOffset+1, yOffset++);
            WriteText("=======================", xOffset, yOffset++);
        }

        public static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        
    }
}
