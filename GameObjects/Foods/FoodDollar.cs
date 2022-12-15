using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int foodPoints = 2;
        private const ConsoleColor color = ConsoleColor.Green;
        public FoodDollar(Field field) : base(field, foodSymbol, foodPoints, color)
        {
        }
    }
}
