using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeOOP
{
    class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int Lenght, Direction _direction)
        {
            direction = _direction;
            pointList = new List<Point>();
            for(int i = 0; i < Lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pointList.Add(p);
            }
        }
        //******
        public void Move()
        {
            Point tail = pointList.First();
            pointList.Remove(tail);
            tail.Clear();

            Point head = GetNextPoint();
            pointList.Add(head);
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pointList.Last();
            Point NextPoint = new Point(head);
            NextPoint.Move(1, direction);
            return NextPoint;
        }

        public void HandleKeys(ConsoleKey key)
        {
            if(key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if(key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if(key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
            else if(key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if(head.IsHit(food))
            {
                food.symb = head.symb;
                pointList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHitTail()
        {
            Point head = pointList.Last();
            for(int i = 0; i < pointList.Count - 2; i++)
            {
                if(head.IsHit(pointList[i]))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
