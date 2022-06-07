using System;
using System.Drawing;
using System.Windows.Forms;
namespace Professional_GUI//for gt
{
   abstract class AbsPanel
    {
        protected Graphs graph;
        public Graphics plot;
        protected Color backGroungCoolor=Color.FromArgb(181, 164, 199);
        protected Color highlightColorOfVer = Color.FromArgb(107, 73, 143);//
        protected Color highlightColor = Color.FromArgb(159, 206, 252);
        protected Point pressPoint;
        protected Panel panel;
        protected int distanceBetweenLines = 20;
        protected int numberOfpressVer;
        protected bool pressVer = false;
        protected SolidBrush solidBrush;
        protected int sizeCircle = 40;
        protected int widghtLines = 4;
        public void paint()
        {
            plot.Clear(backGroungCoolor);
        }

        abstract public void repaint();
        public int getNumVerOnClick(Point p, ref int countHughlights,ref Point lastPressPoint) {
            Point hlp = pressPoint;
            for (int i = 0; i < graph.getRealSize(); ++i)
            {//проверка на то,чтобы одна вершина не перекрывала другую
                int num=-1;
                if (graph.GetType() == typeof(Adjacency_matr))
                {
                    hlp = ((Adjacency_matr)graph).GetVertex(i).GetPoint();
                    num = ((Adjacency_matr)graph).GetVertex(i).number;
                }
                if (graph.GetType() == typeof(Weighted_matrix))
                {
                    hlp = ((Weighted_matrix)graph).GetVertex(i).GetPoint();
                    num = ((Weighted_matrix)graph).GetVertex(i).number;
                }
                if (Math.Abs((hlp.X - p.X)) < sizeCircle + 10 && Math.Abs((hlp.Y - p.Y)) < sizeCircle + 10)
                {
                    if (Math.Abs((hlp.X - p.X)) > sizeCircle / 2 || Math.Abs((hlp.Y - p.Y)) > sizeCircle / 2)//условие,чтобы 
                                                                                                             //при нажатии области рядом с вершиной,она не выделялась
                        return -1;
                    if (lastPressPoint == hlp )
                    {
                        Color c= highlightColorOfVer;
                        lastPressPoint = Point.Empty;
                        if (pressPoint == hlp)
                            c = highlightColor;
                        plot.DrawEllipse(new Pen(c, widghtLines), hlp.X - sizeCircle / 2 + widghtLines / 2, hlp.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                        --countHughlights;
                        return -1;
                    }
                    if (countHughlights < 2)
                    {
                        ++countHughlights;
                        lastPressPoint = hlp;
                        plot.DrawEllipse(new Pen(Color.Red, widghtLines), hlp.X - sizeCircle / 2 + widghtLines / 2, hlp.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                        return num;
                    }
                }
            }
            return -1;
        }

        protected void setPlot(Color clr)
        {
            plot.Clear(clr);
        }
        abstract public void removeVertex(Point p);
        abstract public void removeCompoundVertex(Point p);
        abstract public void paintVer(Point p);

        public Graphs GetGraph() {
            return graph;
        }

        protected Point findIntersectionLineWithCircle(Point p1,Point p2) {
            double radius = sizeCircle / 2;
            double k = Math.Pow(((double)p2.Y - p1.Y) / ((double)p2.X - p1.X),2);
            double a = (k + 1);
            double b = p1.X * (k + 1);
            double c = (k + 1);
            double x1 = (b + Math.Sqrt(Math.Pow(b,2)-a*(c* Math.Pow(p1.X,2)-Math.Pow(radius,2)))) / a;
            double x2 = (b - Math.Sqrt(Math.Pow(b, 2) - a * (c * Math.Pow(p1.X, 2) - Math.Pow(radius, 2)))) / a;
            double x;
            if (Math.Abs(p2.X - x1) < Math.Abs(p2.X - x2))
                x = x1;
            else
                x = x2;
            double y;
            double y1 = p1.Y + Math.Sqrt(Math.Pow(radius, 2)-Math.Pow(x - p1.X, 2)  );
            double y2 = p1.Y - Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(x - p1.X, 2));
            if (p1.Y - p2.Y > 0)
                y = y2;
            else
                y = y1;
            return new Point((int)x, (int)y);
        }


        protected Point pointForCurve(Point p1, Point p2,int d,int sign) {
            Point point = new Point((p2.X+p1.X)/2,(p2.Y+p1.Y)/2);
            double k = ((double)p2.Y - p1.Y) / ((double)p2.X - p1.X);
            //double f = 1 + 1 / (k * k);
            //double x = 1 + Math.Sqrt(f+ f*(point.X * point.X*f+d*d))/f;
            double x =point.X+d*k/Math.Sqrt(k*k+1)*Math.Pow(-1,sign);
            return new Point((int)x,(int)(-(x-point.X)/k+point.Y));
        }

    }
}
