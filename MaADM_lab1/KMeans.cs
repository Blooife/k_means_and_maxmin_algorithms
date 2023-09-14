using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MaADM_lab1
{
    public class KMeans
    {
        private List<Class> Classes;
        private List<Point> Points;
        private int classesCount;
        private bool isCenterChanged;
        public static event EventHandler<ClassesChangedEvent> OnChangeClasses;
        
        public KMeans(List<Point> p, int cc)
        {
            Points = new List<Point>(p);
            classesCount = cc;
        }

        public KMeans(List<Point> p, List<Class> cl)
        {
            Points = p;
            Classes = new List<Class>(cl);
        }

        public List<Class> FormClasses()
        {
            Classes = new List<Class>(classesCount);
            List<Point> centers = GetRandomCenters(classesCount);
            for (int i = 0; i < classesCount; i++)
            {
                Classes.Add(new Class(centers[i]));
            }
            AddPointsToClasses();
            return Classes;
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

        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        
        private List<Point> GetRandomCenters(int classesCount)
        {
            var result = new List<Point>();
            var random = new Random();
            for (var i = 0; i < classesCount; i++)
            {
                Point centerCandidate;
                do
                {
                    centerCandidate = Points[random.Next(Points.Count)];
                    if (!result.Contains(centerCandidate))
                    {
                        result.Add(centerCandidate);
                    }
                } while (!result.Contains(centerCandidate));
            }
            return result;
        }

        public void UpdateClasses()
        {
            foreach (var cl in Classes)
            {
                cl.Clear();
                AddPointsToClasses();
            }
        }
        public List<Class> KMeansAlgorithm()
        {
            do
            {
                isCenterChanged = false;
                OnChangeClasses?.Invoke(null, new ClassesChangedEvent(Classes));
                UpdateClasses();
                RecalculateCenters();
            } while (isCenterChanged);
            return Classes;
        }

        private void RecalculateCenters()
        {
            foreach (var cl in Classes)
            {
                var newCenter = cl.GetNewClassCenter();
                if (newCenter == cl.Center)
                {
                    break;
                }
                cl.Center = newCenter;
                isCenterChanged = true;
            }
        }
    }
}