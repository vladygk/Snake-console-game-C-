using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int foodPoints = 1;
        private const ConsoleColor color = ConsoleColor.Blue;
        public FoodAsterisk(Field field) : base(field, foodSymbol, foodPoints, color)
        {
        }
    }
}
