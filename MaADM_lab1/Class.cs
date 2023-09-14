using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MaADM_lab1
{
    public class Class
    {
        public List<Point> Points;
        public Point Center;

        public Class(Point c)
        {
            Center = c;
            Points = new List<Point>() { Center };
        }

        public void Clear()
        {
            Points = new List<Point>() { Center };
        }
        
        public Point GetNewClassCenter()
        {
            var newCenter = new Point((int)Points.Average(p => p.X), (int)this.Points.Average(p => p.Y));
            var minDistance = double.MaxValue;
            var minDPoint = new Point();
            foreach (var centerCandidate in this.Points)
            {
                var distance = GetDistance(newCenter, centerCandidate);
                if (!(distance < minDistance)) continue;
                minDistance = distance;
                minDPoint = centerCandidate;
            }
            return minDPoint;
        }
        
        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }       

    }
}