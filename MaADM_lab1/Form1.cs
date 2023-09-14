using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaADM_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            g.Clip = new Region(new Rectangle(0, 0, this.Size.Width, this.Size.Height-100));
            g.FillRectangle(Brushes.White, 0,0, Size.Width,Size.Height - 100);
            MaxMin.OnChangeClasses += ChangeClasses;
            KMeans.OnChangeClasses += ChangeClasses;
        }

        public void ChangeClasses(object sender, ClassesChangedEvent e)
        {
            DrawClasses(e.Classes);
            System.Threading.Thread.Sleep(500);
        }
        public Color[] colors = new[]
        {
            Color.Black,
            Color.Red,
            Color.Yellow,
            Color.DeepSkyBlue,
            Color.Blue,
            Color.Fuchsia,
            Color.Indigo,
            Color.DarkGreen,
            Color.Gray,
            Color.Lime,
            Color.Brown,
            Color.Chartreuse,
            Color.Chocolate,
            Color.Teal,
            Color.Goldenrod,
            Color.DarkSlateGray,
            Color.DarkSalmon,
            Color.DarkGray,
            Color.DarkViolet,
            Color.LightGreen,
            
        };
        private static Graphics g;
        private List<Point> points;
        public int pCount;
        public int clCount;
        public KMeans kMeans = null;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        
        private static List<Point> GetRandomPoints(int pointsCount, int height, int width)
        {
            var result = new List<Point>(pointsCount);
            var random = new Random();
            for (var i = 0; i < pointsCount; i++)
            {
                result.Add(new Point(random.Next(width)+10, random.Next(height)+10));
            }
            return result;
        }

        private void DrawClasses(List<Class> classes)
        {
            g.FillRectangle(Brushes.White, 0,0, Size.Width, Size.Height - 100);
            for (int i = 0; i < classes.Count; i++)
            {
                Brush c = new SolidBrush(colors[i]);
                /*foreach (var p in classes[i].Points)
                {
                    g.FillRectangle(c, p.X-1,p.Y-1,2,2);
                    
                } */
                g.FillRectangles(c, MakeRectArray(classes[i].Points));
                g.FillRectangle(c, classes[i].Center.X-5,classes[i].Center.Y-5,10,10);
            }
        }

        private Rectangle[] MakeRectArray(List<Point> points)
        {
            Rectangle[] res = new Rectangle[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                res[i] = new Rectangle(points[i].X - 1, points[i].Y - 1, 2, 2);
            }

            return res;
        }

        private void bCalculate_Click(object sender, EventArgs e)
        {
            if (rbKMeans.Checked)
            {
                pCount = (int)nuPoints.Value;
                clCount = (int)nuClasses.Value;
                    if (clCount > 1 && clCount < 21 && pCount >= 1000 && pCount <= 100000)
                    {
                        points = new List<Point>(GetRandomPoints(pCount, Size.Height - 130, Size.Width-50));
                        kMeans = new KMeans(points, clCount);
                        DrawClasses(kMeans.FormClasses());
                        DrawClasses(kMeans.KMeansAlgorithm());
                    }
                    else
                    {
                        MessageBox.Show("Не верное число образов или классов");
                    }
            }else if (rbMaxMin.Checked)
            {
                pCount = (int)nuPoints.Value;
                if (pCount >= 1000 && pCount <= 100000)
                {
                    points = new List<Point>(GetRandomPoints(pCount, Size.Height - 130, Size.Width-50));
                    var mm = new MaxMin(points);
                    DrawClasses(mm.MaxMinAlgorithm());
                }
                else
                {
                    MessageBox.Show("Не верное число образов");
                }
            }else if (rbKM.Checked)
            {
                pCount = (int)nuPoints.Value;
                if (pCount >= 1000 && pCount <= 100000)
                {
                    points = new List<Point>(GetRandomPoints(pCount, Size.Height - 130, Size.Width-50));
                    var mm = new MaxMin(points);
                    var cl = mm.MaxMinAlgorithm();
                    DrawClasses(cl);
                    MessageBox.Show("Максимин закончил работу. Начинает k-средних");
                    kMeans = new KMeans(points, cl);
                    DrawClasses(kMeans.KMeansAlgorithm());
                }
                else
                {
                    MessageBox.Show("Не верное число образов");
                }
            }
        }

        private void rbKMeans_Click(object sender, EventArgs e)
        {
            nuClasses.Enabled = true;
        }

        private void rbMaxMin_Click(object sender, EventArgs e)
        {
            nuClasses.Enabled = false;
        }

        private void rbKM_Click(object sender, EventArgs e)
        {
            nuClasses.Enabled = false;
        }
    }
}