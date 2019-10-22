using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        List<Point> points =new List<Point>(){ new Point(100, 400), new Point(400, 400), new Point(250, 100) };
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawTriangle();
            Start();
        }
        private void Start()
        {
            Random rd = new Random();
            Point point1 = points[rd.Next(points.Count)];
            points.Remove(point1);
            Point point2 = points[rd.Next(points.Count)];
            Point centerPoint = GetCenter(point1, point2);
            points.Add(point1);
            DrawPoint(centerPoint);
            for (int i = 0; i < 10000; i++)
            {
                point1 = centerPoint;
                point2 = points[rd.Next(points.Count)];
                centerPoint = GetCenter(point1, point2);
                DrawPoint(centerPoint);
            }

        }

        private Point GetCenter(Point a,Point b)
        {
            Point point = new Point();
            point.X = (a.X + b.X) / 2;
            point.Y = (a.Y + b.Y) / 2;
            return point;
        }

        private void DrawTriangle()
        {
            foreach (var item in points)
            {
                DrawPoint(item);
            }
        }

        private void DrawPoint(Point point)
        {
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(new SolidBrush(Color.Red), point.X, point.Y, 5, 5);
        }
    }
}
