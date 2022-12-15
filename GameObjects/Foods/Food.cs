

using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Random random;
      
        private readonly Field field;
        private ConsoleColor color;


        protected Food(Field field, char foodSymbol, int foodPoints, ConsoleColor color) : base(field.LeftX, field.TopY)
        {
            random = new Random();
            this.field = field;
            this.FoodSymbol = foodSymbol;
            this.FoodPoints = foodPoints;
            this.color = color;
            
        }

        public char FoodSymbol { get; set; }

        public int FoodPoints { get; set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, field.LeftX - 2);
            this.TopY = random.Next(2, field.TopY - 2);

            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, field.LeftX - 2);
                this.TopY = random.Next(2, field.TopY - 2);

                 isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = color;
            this.Draw(FoodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }


        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
