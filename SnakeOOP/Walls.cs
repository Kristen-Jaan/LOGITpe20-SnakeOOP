using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeOOP
{
    class Walls
    {
        List<Figure> wallList;
         
        public Walls(int MapWidth, int MapHeight)
        {
            wallList = new List<Figure>();
            HorizontalLine top = new HorizontalLine(0, 80, 0, '#');
            VerticalLine Left = new VerticalLine(0, 25, 0, '#');
            VerticalLine Right = new VerticalLine(0, 25, 80, '#');
            HorizontalLine Bottom = new HorizontalLine(0, 80, 25, '#');

            VerticalLine obstacle = new VerticalLine(10, 13, 50, '%');
            VerticalLine obstacle2 = new VerticalLine(5, 9, 10, '%');
            HorizontalLine obstacle3 = new HorizontalLine(3, 9, 14, '%');
            HorizontalLine obstacle4 = new HorizontalLine(8, 41, 19, '%');

            wallList.Add(top);
            wallList.Add(Left);
            wallList.Add(Right);
            wallList.Add(Bottom);
            wallList.Add(obstacle);
            wallList.Add(obstacle2);
            wallList.Add(obstacle3);
            wallList.Add(obstacle4);
        }

        public void Draw()
        {
            foreach(var wall in wallList)
            {
                wall.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if(wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
