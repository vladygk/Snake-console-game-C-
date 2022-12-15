

namespace SimpleSnake.GameObjects
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Linq;

    using Foods;
    using System.Security.Cryptography.X509Certificates;

    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';

        private Queue<Point> snakeElements;
        private Field field;
        private IList<Food> foodList;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        

        public int Score{ get; set; }
       
        public Snake(Field field)
        {
            this.field = field;
            this.snakeElements = new Queue<Point>();
            this.foodList = new List<Food>();
            this.GetFoods();
            this.Score = 0;
            this.CreateSnake();
        }
        private void CreateSnake()
        {

            for (int TopY = 1; TopY <= 6; TopY++)
            {
                Point snakeElem = new Point(2, TopY);
                snakeElements.Enqueue(snakeElem);
            }
            this.foodIndex = RandomFoodNumber();
            this.foodList[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetFoods()
        {
            Type[] foodTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.ToLower().StartsWith("food") && !x.IsAbstract).ToArray();


            foreach (Type foodType in foodTypes)
            {
                Food currFood = (Food)Activator.CreateInstance(foodType, new object[] { field });
                this.foodList.Add(currFood);
            }
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool CanMove(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);
            bool isPointOfsnake = snakeElements.Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (isPointOfsnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);
            if (this.field.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(snakeSymbol);

            if (foodList[foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);
            Console.BackgroundColor = ConsoleColor.White;


            return true;
        }

        public void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foodList[foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = RandomFoodNumber();
            this.foodList[foodIndex].SetRandomPosition(this.snakeElements);
            Score += length;
        }

        private int RandomFoodNumber() =>
           new Random().Next(0, foodList.Count);
        
       
    }
}
