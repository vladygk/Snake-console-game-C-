
namespace SimpleSnake.GameObjects
{
    public class Field : Point
    {
        private const char wallSymbol = '\u25A0';

        public Field(int leftX, int TopY) : base(leftX, TopY)
        {
            this.BuildField();
        }

        private void SetHorizontalWall(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                Point wallPoint = new Point(leftX, topY);
                wallPoint.Draw(wallSymbol);
            }
        }

        private void SetVerticalWall(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                Point wallPoint = new Point(leftX, topY);
                wallPoint.Draw(wallSymbol);
            }
        }

        public void BuildField()
        {
            SetHorizontalWall(0);
            SetHorizontalWall(TopY);
            SetVerticalWall(0);
            SetVerticalWall(LeftX - 1);
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.TopY == 0 
                   || snakeHead.LeftX == 0 
                   || snakeHead.TopY == this.TopY 
                   || snakeHead.LeftX == this.LeftX - 1;
        }
    }
}
