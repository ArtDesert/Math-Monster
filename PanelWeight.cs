using System;
using System.Windows.Forms;
using System.Drawing;

namespace Professional_GUI
{
    class PanelWeight : AbsPanel
    {
        private Weighted_matrix myWeight;

        public PanelWeight(Panel p, Weighted_matrix m) {
            myWeight = m;
            graph = myWeight;
            solidBrush = new SolidBrush(highlightColorOfVer);
            panel = p;
            plot = panel.CreateGraphics();
        }

        public override void removeVertex(Point p) {
            for (int i = 0; i < graph.getRealSize(); ++i)
            {//проверка на то,чтобы одна вершина не перекрывала другую
                Point hlp = myWeight.GetVertex(i).GetPoint();
                if (Math.Abs((hlp.X - p.X)) < sizeCircle + 10 && Math.Abs((hlp.Y - p.Y)) < sizeCircle + 10)
                {
                    if (Math.Abs((hlp.X - p.X)) > sizeCircle / 2 || Math.Abs((hlp.Y - p.Y)) > sizeCircle / 2)
                    {//условие,чтобы 
                     //при нажатии области рядом с вершиной,она не выделялась

                        return;
                    }
                    if (hlp == pressPoint)
                        pressVer = false;
                    myWeight.RemoveEl( i+1);
                    repaint();
                    if (pressVer && hlp != pressPoint)
                        plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                    else pressVer = false;
                    return;
                }
            }
        }
        public override void removeCompoundVertex(Point p) {
            for (int i = 0; i < graph.getRealSize(); ++i)
            {//проверка на то,чтобы одна вершина не перекрывала другую
                Point hlp = myWeight.GetVertex(i).GetPoint();
                if (Math.Abs((hlp.X - p.X)) < sizeCircle + 10 && Math.Abs((hlp.Y - p.Y)) < sizeCircle + 10)
                {
                    if (Math.Abs((hlp.X - p.X)) > sizeCircle / 2 || Math.Abs((hlp.Y - p.Y)) > sizeCircle / 2)
                    {//условие,чтобы 
                     //при нажатии области рядом с вершиной,она не выделялась
                       
                        return;
                    }
                    myWeight.removeCompound(numberOfpressVer, i);
                    repaint();
                    plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                    return;
                }
            }
        }
        private void drawFillElipse(Point p, Vertex<double> ver)
        {
            SizeF MySize = plot.MeasureString(Convert.ToString(ver.number + 1), new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular));
            plot.FillEllipse(solidBrush, p.X - sizeCircle / 2, p.Y - sizeCircle / 2, sizeCircle, sizeCircle);
            plot.DrawString(Convert.ToString(ver.number + 1), new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular), new SolidBrush(highlightColor), p.X - MySize.Width / 2, p.Y - MySize.Height / 2);//фикс фонт 

        }

        private void printCurveLineWithWeight(Point p1, Point p2, double vl, int sign)
        {


            Pen pen = new Pen(highlightColor, widghtLines);
            pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(widghtLines, widghtLines);
            SizeF MySize = plot.MeasureString(Convert.ToString(vl), panel.Font);
            Point p = pointForCurve(p1, p2, distanceBetweenLines, sign);
            plot.DrawCurve(pen, new Point[3] { findIntersectionLineWithCircle(p1, p2), p, findIntersectionLineWithCircle(p2, p1) });
            plot.FillRectangle(new SolidBrush(backGroungCoolor), (p.X - MySize.Width / 2), (p.Y - MySize.Height / 2), MySize.Width, MySize.Height);
            plot.DrawString(Convert.ToString(vl), new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular), new SolidBrush(highlightColorOfVer), p.X - MySize.Width / 2, p.Y - MySize.Height / 2);
        }

        private int intesectionWithWeight(Point p1, Point p2, double x)
        {
            return (int)((x - p1.X) * (p2.Y - p1.Y) / (p2.X - p1.X) + p1.Y);
        }
        private void printLineWithWeight(Point p1, Point p2, double vl)
        {
            SizeF MySize = plot.MeasureString(Convert.ToString(vl), panel.Font);
            plot.DrawCurve(new Pen(highlightColor, widghtLines), new Point[2] { findIntersectionLineWithCircle(p1, p2), findIntersectionLineWithCircle(p2, p1) });
            plot.FillRectangle(new SolidBrush(backGroungCoolor), (p2.X + p1.X - MySize.Width) / 2, (p2.Y + p1.Y - MySize.Height) / 2, MySize.Width, MySize.Height);
            plot.DrawString(Convert.ToString(vl), new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular), new SolidBrush(highlightColorOfVer), (p2.X + p1.X - MySize.Width) / 2, (p2.Y + p1.Y - MySize.Height) / 2);
            //plot.DrawLine(new Pen(highlightColor, widghtLines), findIntersectionLineWithCircle(p1,p2), new Point((int)((p2.X + p1.X- MySize.Width) / 2), intesectionWithWeight(p1,p2, (p2.X + p1.X- MySize.Width) / 2 )));
            //plot.DrawLine(new Pen(highlightColor, widghtLines), new Point((int)((p2.X + p1.X + MySize.Width) / 2), intesectionWithWeight(p1, p2, (p2.X + p1.X + MySize.Width) / 2)), findIntersectionLineWithCircle(p2, p1));
        }
        public override void paintVer(Point p) {
            if (!pressVer)
            {
                for (int i = 0; i < graph.getRealSize(); ++i)
                {//проверка на то,чтобы одна вершина не перекрывала другую
                    Point hlp = myWeight.GetVertex(i).GetPoint();
                    if (Math.Abs((hlp.X - p.X)) < sizeCircle + 10 && Math.Abs((hlp.Y - p.Y)) < sizeCircle + 10)
                    {
                        if (Math.Abs((hlp.X - p.X)) > sizeCircle / 2 || Math.Abs((hlp.Y - p.Y)) > sizeCircle / 2)//условие,чтобы 
                            //при нажатии области рядом с вершиной,она не выделялась
                            return;
                        numberOfpressVer = i;
                        pressPoint = hlp;
                        pressVer = true;
                        plot.DrawEllipse(new Pen(highlightColor, widghtLines), hlp.X - sizeCircle / 2 + widghtLines / 2, hlp.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                        return;
                    }
                }
                graph.addVertex(p);
                drawFillElipse(p, myWeight.GetVertex(graph.getRealSize() - 1));
            }
            else//если вершина выделена
            {
                for (int i = 0; i < graph.getRealSize(); ++i)
                {//проверка на то,чтобы одна вершина не перекрывала другую
                    Point hlp = myWeight.GetVertex(i).GetPoint();
                    if (Math.Abs((hlp.X - p.X)) < sizeCircle / 2 && Math.Abs((hlp.Y - p.Y)) < sizeCircle / 2)
                    {
                        if (hlp == pressPoint)//убираем выеделние
                        {
                            plot.DrawEllipse(new Pen(highlightColorOfVer, widghtLines), hlp.X - sizeCircle / 2 + widghtLines / 2, hlp.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                            pressVer = false;
                        }
                        else
                        {
                            GraphsForm2 txtBox = new GraphsForm2();
                            txtBox.ShowDialog();
                            if (txtBox.getLastPressBut())
                            {
                                if (myWeight.getSymm())
                                {
                                    if (myWeight.GetVertex(numberOfpressVer).getEl(i) == double.PositiveInfinity)
                                    {
                                        double vl = txtBox.getDig();
                                        myWeight.addCompound(numberOfpressVer,i, vl);
                                        printLineWithWeight(pressPoint, hlp, vl);
                                    }
                                    else
                                    {
                                        double vl = txtBox.getDig();
                                        myWeight.addCompound(numberOfpressVer, i, vl);
                                        repaint();
                                        plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                                    }
                                }
                                else {
                                    if (myWeight.GetVertex(numberOfpressVer).getEl(i) == double.PositiveInfinity)
                                    {
                                        if (myWeight.GetVertex(i).getEl(numberOfpressVer) == double.PositiveInfinity)
                                        {
                                            double vl = txtBox.getDig();
                                            myWeight.addCompound(numberOfpressVer, i, vl);
                                            printCurveLineWithWeight(pressPoint, hlp, vl, 1);
                                        }
                                        else {
                                            double vl = txtBox.getDig();
                                            myWeight.addCompound(numberOfpressVer, i, vl);
                                            printCurveLineWithWeight(pressPoint, hlp, vl, 2);
                                        }
                                    }
                                    else
                                    {
                                        double vl = txtBox.getDig();
                                        myWeight.addCompound(numberOfpressVer, i, vl);
                                        repaint();
                                        plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                                    }


                                }
                            }
                            return;
                        }
                    }
                }
            }
        }
        public override void repaint()
        {
            plot.Clear(backGroungCoolor);
            for (int i = 0; i < graph.getRealSize(); i++)
            {
                drawFillElipse(myWeight.GetVertex(i).GetPoint(), myWeight.GetVertex(i));
            }
            if (pressVer)
                plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);


            for (int i = 0; i < graph.getRealSize(); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (myWeight.GetVertex(i).getEl(j) != double.PositiveInfinity && myWeight.GetVertex(i).getEl(j) == myWeight.GetVertex(j).getEl(i))
                        printLineWithWeight(myWeight.GetVertex(i).GetPoint(), myWeight.GetVertex(j).GetPoint(), myWeight.GetVertex(i).getEl(j));
                }
            }
            for (int i = 0; i < graph.getRealSize(); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (myWeight.GetVertex(i).getEl(j) != double.PositiveInfinity && myWeight.GetVertex(i).getEl(j) != myWeight.GetVertex(j).getEl(i))
                        printCurveLineWithWeight(myWeight.GetVertex(i).GetPoint(), myWeight.GetVertex(j).GetPoint(), myWeight.GetVertex(i).getEl(j), j);
                    if (myWeight.GetVertex(j).getEl(i) != double.PositiveInfinity && myWeight.GetVertex(i).getEl(j) != myWeight.GetVertex(j).getEl(i))
                        printCurveLineWithWeight(myWeight.GetVertex(j).GetPoint(), myWeight.GetVertex(i).GetPoint(), myWeight.GetVertex(j).getEl(i), j + 1);
                }
            }
        }

    }
}
