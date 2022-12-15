using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.Enums;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private Point[] directions;
        private int direction;
        private Snake snake;
        private Field field;
        private double sleeptime;
        private int difficulty;
        private string difficultyLevel;
        public Engine(Field field, Snake snake, int difficulty)
        {
            this.field = field;
            this.snake = snake;
            this.directions = new Point[4];
            this.sleeptime = 100;
            this.difficulty = difficulty;
        }
        public void Run()
        {
            this.GetDirections();
            while (true)
            {
                DisplayScoreAndDifficulty();
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool canMove = snake.CanMove(directions[direction]);

                if (!canMove)
                {
                    AskUserForRestart();
                }

                switch (difficulty)
                {
                    case 1: sleeptime -= 0.01;
                        this.difficultyLevel="Easy";break;
                    case 2:
                        sleeptime -= 0.1; 
                        this.difficultyLevel = "Medium"; break;
                    case 3:
                        sleeptime -= 0.5;
                        this.difficultyLevel = "Hard"; break;
                    default: StartUp.Main();break;
                }
                
                Thread.Sleep((int)sleeptime);

            }
        }

        private void DisplayScoreAndDifficulty()
        {
            int leftX = this.field.LeftX + 1;
            int TopY = 2;
            Console.SetCursorPosition(leftX, TopY);
            Console.WriteLine($"Difficulty Level: {this.difficultyLevel}");
            leftX = this.field.LeftX + 1;
            TopY = 4;
            Console.SetCursorPosition(leftX, TopY);
            Console.Write($"Score: {snake.Score}");
        }
        private void AskUserForRestart()
        {
            int leftX = this.field.LeftX + 1;
            int TopY = 3;
            Console.SetCursorPosition(leftX, TopY);
            Console.Write("Do you wan to continue? y/n     ");
            
            string input = Console.ReadLine();

            if (input.Contains("y"))
            {
                Console.Clear();
                StartUp.Main();

            }
            else if(input.Contains("n"))
            {
                StopGame();
            }
            else
            {
                input = Console.ReadLine();
            }
        }

        private void StopGame()
        {
            int leftX = this.field.LeftX + 1;
            int TopY = 5;
            Console.SetCursorPosition(leftX, TopY);
            Console.Write("Game over");
            Environment.Exit(0);
        }

        private void GetDirections()
        {
            this.directions[0] = new Point(1, 0);
            this.directions[1] = new Point(-1, 0);
            this.directions[2] = new Point(0, 1);
            this.directions[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (direction != (int)Direction.Right)
                {
                    direction = (int)Direction.Left;
                }
            }else if(keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (direction != (int)Direction.Left)
                {
                    direction = (int)Direction.Right;
                }
            } else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (direction != (int)Direction.Up)
                {
                    direction = (int)Direction.Down;
                }
            }else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (direction != (int)Direction.Down)
                {
                    direction = (int)Direction.Up;
                }
            }
            Console.CursorVisible = false;
        }

       
    }
}
