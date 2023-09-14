using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MaADM_lab1
{
    public class MaxMin
    {
        private List<Point> Points;
        private List<Class> Classes;
        public delegate void DrawHandler(List<Class> classes);
        public event DrawHandler OnDraw;  
        public static event EventHandler<ClassesChangedEvent> OnChangeClasses;

        public MaxMin(List<Point> p)
        {
            Random rand = new Random();
            Points = new List<Point>(p);
            Classes = new List<Class>() { new Class(Points[rand.Next(Points.Count)]) };
        }

        public MaxDistPoint FindMaxDistancePoint(List<Point> points, Point center)
        {
            double maxDist = Double.MinValue;
            Point maxDistPoint = new Point();
            foreach (var p in points)
            {
                var newDist = GetDistance(p, center);
                if (newDist > maxDist)
                {
                    maxDist = newDist;
                    maxDistPoint = p;
                }
            }
            return new MaxDistPoint()
            {
                point = maxDistPoint,
                distance = maxDist,
            };
        }

        public MaxDistPoint FindBiggestDistance()
        {
            double mDist = Double.MinValue;
            MaxDistPoint mPoint = new MaxDistPoint();
            foreach (var cl in Classes)
            {
                MaxDistPoint nPoint = FindMaxDistancePoint(cl.Points, cl.Center);
                if (nPoint.distance > mDist)
                {
                    mDist = nPoint.distance;
                    mPoint = nPoint;
                }
            }

            return mPoint;
        }

        public double GetAverageDistanceCenters()
        {
            if (Classes.Count < 3)
            {
                return 0;
            }
            double distance = 0;
            for (int i = 0; i < Classes.Count; i++)
            {
                for (int j = i+1; j < Classes.Count; j++)
                {
                    distance += GetDistance(Classes[i].Center, Classes[j].Center);
                }
            }
            var count = Enumerable.Range(1, Classes.Count - 1).Sum();
            return distance / count;
        }
        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        
        public void AddPointsToClasses()
        {
            foreach (var p in Points)
            {
                var c = GetMinDistanceClass(p);
                c?.Points.Add(p);
            }
        }
        
        private Class GetMinDistanceClass(Point point)
        {
            var minDistance = double.MaxValue;
            Class minDistanceClass = null;

            foreach (var cl in Classes)
            {
                if (point == cl.Center) return null;
                var distance = GetDistance(cl.Center, point);
                if (!(distance < minDistance)) continue;
                minDistance = distance;
                minDistanceClass = cl;
            }
            return minDistanceClass;
        }
        
        public void UpdateClasses()
        {
            foreach (var cl in Classes)
            {
                cl.Clear();
                AddPointsToClasses();
            }
        }

        public void AddNewClass(Point? newCenter)
        {
            if (newCenter != null)
            {
                Classes.Add(new Class(newCenter.Value)); 
            }
        }

        public Point? FindNewCenter()
        {
            var averageDist = GetAverageDistanceCenters();
            var biggestDistPoint = FindBiggestDistance();
            if (biggestDistPoint.distance > averageDist / 2)
            {
                return biggestDistPoint.point;
            }
            
            return null;
        }

        public List<Class> MaxMinAlgorithm()
        {
            Point? newCenter = null;
            do
            {
                UpdateClasses();
                AddPointsToClasses();
                OnChangeClasses?.Invoke(null, new ClassesChangedEvent(Classes));
                newCenter = FindNewCenter();
                AddNewClass(newCenter);
            } while (newCenter != null);
            return Classes;
        }
        
        public class MaxDistPoint
        {
            public Point point;
            public double distance;
        }
    }
}