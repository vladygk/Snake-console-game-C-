using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {

        public Point(int leftX,int TopY)
        {
                this.LeftX = leftX;
                this.TopY = TopY;
        }
        public int LeftX { get; set; }
        public int TopY { get; set; }


        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int leftY, char symbol)
        {
            Console.SetCursorPosition(leftX, leftY);
            Console.Write(symbol);
        }
    }
}
