using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHashtag : Food
    {
        private const char foodSymbol = '#';
        private const int foodPoints = 3;
        private const ConsoleColor color = ConsoleColor.Red;
        public FoodHashtag(Field field) : base(field, foodSymbol, foodPoints, color)
        {
        }
    }
}
