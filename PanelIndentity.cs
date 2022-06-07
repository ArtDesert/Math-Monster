using System;
using System.Windows.Forms;
using System.Drawing;

namespace Professional_GUI
{
    class PanelIndentity : AbsPanel
    {

        private Adjacency_matr myAdj;
        public PanelIndentity(Panel p,Adjacency_matr m)
        {
            myAdj = m;
            graph = myAdj;
            solidBrush = new SolidBrush(highlightColorOfVer);
            panel = p;
            plot = panel.CreateGraphics();
        }


        private void drawFillElipse(Point p, Vertex<int> ver)
        {
            SizeF MySize = plot.MeasureString(Convert.ToString(ver.number + 1), new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular));

            plot.FillEllipse(solidBrush, p.X - sizeCircle / 2, p.Y - sizeCircle / 2, sizeCircle, sizeCircle);
            plot.DrawString(Convert.ToString(ver.number + 1), new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular), new SolidBrush(highlightColor), p.X - MySize.Width / 2, p.Y - MySize.Height / 2);//фикс фонт 

        }

        //public override void paintVer(Point p)//отрисовка вершин, связей,выделние вершины при нажатии на нее
        //{
        //    if (!pressVer)
        //    {
        //        for (int i = 0; i < graph.getRealSize(); ++i)
        //        {//проверка на то,чтобы одна вершина не перекрывала другую
        //            Point hlp = myAdj.GetVertex(i).GetPoint();
        //            if (Math.Abs((hlp.X - p.X)) < sizeCircle + 10 && Math.Abs((hlp.Y - p.Y)) < sizeCircle + 10)
        //            {
        //                if (Math.Abs((hlp.X - p.X)) > sizeCircle / 2 || Math.Abs((hlp.Y - p.Y)) > sizeCircle / 2)//условие,чтобы 
        //                    //при нажатии области рядом с вершиной,она не выделялась
        //                    return;
        //                numberOfpressVer = i;
        //                pressPoint = hlp;
        //                pressVer = true;
        //                plot.DrawEllipse(new Pen(highlightColor, widghtLines), hlp.X - sizeCircle / 2+ widghtLines/2, hlp.Y - sizeCircle / 2+ widghtLines/2, sizeCircle- widghtLines, sizeCircle- widghtLines);
        //                return;
        //            }
        //        }
        //        graph.addVertex(p);
        //        drawFillElipse(p, myAdj.GetVertex(graph.getRealSize() - 1));                                                                                                                                                        //if(graph.realsize==0)
        //        //       plot.DrawLine(new Pen(Color.Black, 2), prevpoint.X + 10, prevpoint.Y + 10, point.X, point.Y);
        //        // plot.Clear(Color.Pink);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < graph.getRealSize(); ++i)
        //        {//проверка на то,чтобы одна вершина не перекрывала другую
        //            Point hlp = myAdj.GetVertex(i).GetPoint();
        //            if (Math.Abs((hlp.X - p.X)) < sizeCircle / 2 && Math.Abs((hlp.Y - p.Y)) < sizeCircle / 2)
        //            {
        //                if (hlp == pressPoint)
        //                {
        //                    plot.DrawEllipse(new Pen(highlightColorOfVer, widghtLines), hlp.X - sizeCircle / 2 + widghtLines / 2, hlp.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
        //                    pressVer = false;
        //                }
        //                else
        //                {
        //                    myAdj.addCompound(numberOfpressVer, i);
        //                    if (graph.getSymm())
        //                    {
        //                        if (myAdj.GetVertex(numberOfpressVer).getEl(i) == 1)
        //                            plot.DrawCurve(new Pen(highlightColor, widghtLines), new Point[2] { findIntersectionLineWithCircle(pressPoint, hlp), findIntersectionLineWithCircle(hlp, pressPoint) });
        //                        else
        //                            plot.DrawCurve(new Pen(highlightColor, widghtLines), new Point[3] { findIntersectionLineWithCircle(pressPoint, hlp), pointForCurve(pressPoint, hlp, distanceBetweenLines * ((myAdj.GetVertex(numberOfpressVer).getEl(i)) / 2), myAdj.GetVertex(numberOfpressVer).getEl(i)), findIntersectionLineWithCircle(hlp, pressPoint) });
        //                        //рисуем линию
        //                    }
        //                    else {
        //                        Point outgoingPoint = findIntersectionLineWithCircle(pressPoint, hlp);
        //                        Point entryPoint = findIntersectionLineWithCircle(hlp, pressPoint);
        //                        Pen pen = new Pen(highlightColor, widghtLines);
        //                        pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(widghtLines, widghtLines);
        //                        if (myAdj.GetVertex(numberOfpressVer).getEl(i) == 1 && myAdj.GetVertex(i).getEl(numberOfpressVer) == int.MaxValue)
        //                        {
        //                            plot.DrawCurve(pen, new Point[2] { outgoingPoint, entryPoint });
        //                        }
        //                        else
        //                        {
        //                            int n = myAdj.GetVertex(numberOfpressVer).getEl(i) != int.MaxValue ? myAdj.GetVertex(numberOfpressVer).getEl(i) : 0;
        //                            int k = myAdj.GetVertex(i).getEl(numberOfpressVer) != int.MaxValue ? myAdj.GetVertex(i).getEl(numberOfpressVer) : 0;
        //                            plot.DrawCurve(pen, new Point[3] { findIntersectionLineWithCircle(pressPoint, hlp), pointForCurve(pressPoint, hlp, distanceBetweenLines * ((n + k) / 2), myAdj.GetVertex(numberOfpressVer).getEl(i)), findIntersectionLineWithCircle(hlp, pressPoint) });
        //                        }
        //                        //рисуем 
        //                    }
        //                }
        //                return;
        //            }
        //        }
        //    }
        //}
        public override void paintVer(Point p)//отрисовка вершин, связей,выделние вершины при нажатии на нее
        {
            if (!pressVer)
            {
                for (int i = 0; i < graph.getRealSize(); ++i)
                {//проверка на то,чтобы одна вершина не перекрывала другую
                    Point hlp = myAdj.GetVertex(i).GetPoint();
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
                drawFillElipse(p, myAdj.GetVertex(graph.getRealSize() - 1));                                                                                                                                                        //if(graph.realsize==0)
                //       plot.DrawLine(new Pen(Color.Black, 2), prevpoint.X + 10, prevpoint.Y + 10, point.X, point.Y);
                // plot.Clear(Color.Pink);
            }
            else
            {
                for (int i = 0; i < graph.getRealSize(); ++i)
                {//проверка на то,чтобы одна вершина не перекрывала другую
                    Point hlp = myAdj.GetVertex(i).GetPoint();
                    if (Math.Abs((hlp.X - p.X)) < sizeCircle / 2 && Math.Abs((hlp.Y - p.Y)) < sizeCircle / 2)
                    {
                        if (hlp == pressPoint)
                        {
                            plot.DrawEllipse(new Pen(highlightColorOfVer, widghtLines), hlp.X - sizeCircle / 2 + widghtLines / 2, hlp.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                            pressVer = false;
                        }
                        else
                        {
                            myAdj.addCompound(numberOfpressVer, i);
                            repaint();
                            
                        }
                        return;
                    }
                }
            }
        }
        public override void removeVertex(Point p) {
            Point hlp=pressPoint;
            for (int i = 0; i < graph.getRealSize(); ++i)
            {//проверка на то,чтобы одна вершина не перекрывала другую
                hlp = myAdj.GetVertex(i).GetPoint();
                if (Math.Abs((hlp.X - p.X)) < sizeCircle + 10 && Math.Abs((hlp.Y - p.Y)) < sizeCircle + 10)
                {
                    if (Math.Abs((hlp.X - p.X)) > sizeCircle / 2 || Math.Abs((hlp.Y - p.Y)) > sizeCircle / 2)//условие,чтобы 
                                                                                                             //при нажатии области рядом с вершиной,она не выделялась
                        return;
                    if (hlp == pressPoint)
                        pressVer = false;
                    myAdj.RemoveEl(i+1);
                    break;
                }
            }
            repaint();
            if (graph.getRealSize() != 0)
            {
                if (pressVer && hlp != pressPoint)
                {
                    plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
                }
                else
                if (pressVer && hlp == pressPoint) { pressVer = false; }
            }
            else
               if (pressVer) pressVer = false;
            
        }
        public override void removeCompoundVertex(Point p) {
            if (pressPoint != null)
            {
                for (int i = 0; i < graph.getRealSize(); ++i)
                {//проверка на то,чтобы одна вершина не перекрывала другую
                    Point hlp = myAdj.GetVertex(i).GetPoint();
                    if (Math.Abs((hlp.X - p.X)) < sizeCircle + 10 && Math.Abs((hlp.Y - p.Y)) < sizeCircle + 10)
                    {
                        if (Math.Abs((hlp.X - p.X)) > sizeCircle / 2 || Math.Abs((hlp.Y - p.Y)) > sizeCircle / 2)//условие,чтобы 
                                                                                                                 //при нажатии области рядом с вершиной,она не выделялась
                            return;
                        if (myAdj.GetVertex(numberOfpressVer).getCompound()[i] != int.MaxValue)
                        {
                            if (graph.getSymm())
                            {
                                if (myAdj.GetVertex(numberOfpressVer).getCompound()[i] != 1)
                                {
                                    --myAdj.GetVertex(numberOfpressVer).getCompound()[i];
                                    --myAdj.GetVertex(i).getCompound()[numberOfpressVer];
                                }
                                else
                                {
                                    myAdj.GetVertex(numberOfpressVer).getCompound()[i] = int.MaxValue;
                                    myAdj.GetVertex(i).getCompound()[numberOfpressVer] = int.MaxValue;
                                }
                            }
                            else
                            {
                                if (myAdj.GetVertex(numberOfpressVer).getCompound()[i] != 1)
                                    --myAdj.GetVertex(numberOfpressVer).getCompound()[i];
                                else
                                    myAdj.GetVertex(numberOfpressVer).getCompound()[i] = int.MaxValue;
                            }

                            repaint();
                            plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2+widghtLines/2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle-widghtLines, sizeCircle-widghtLines);
                            
                            break;
                        }
                    }
                }
            }

        }

        //public override void repaint()
        //{//можно оптимизировать
        //    plot.Clear(backGroungCoolor);
        //    for (int i = 0; i < graph.getRealSize(); i++)
        //    {
        //        drawFillElipse(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(i));
        //    }
        //    if (pressVer)
        //        plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);
        //    if (graph.getSymm())
        //    {

        //        for (int i = 0; i < graph.getRealSize(); i++)
        //        {
        //            for (int j = 0; j < graph.getRealSize(); j++)
        //            {
        //                if (myAdj.GetVertex(i).getCompound()[j] != int.MaxValue)
        //                {
        //                    for (int k = 0; k < myAdj.GetVertex(i).getCompound()[j]; k++)
        //                    {
        //                        if (k == 0)
        //                        {
        //                            plot.DrawCurve(new Pen(highlightColor, widghtLines), new Point[2] { findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()), findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()) });
        //                        }
        //                        else
        //                        {
        //                            plot.DrawCurve(new Pen(highlightColor, widghtLines), new Point[3] { findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()), pointForCurve(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint(), distanceBetweenLines * ((k + 1) / 2), k), findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()) });
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        paintOrientVer();
        //    }
        //}

        //void    paintOrientVer() {
        //    Pen pen = new Pen(highlightColor, widghtLines);
        //    pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);
        //    for (int i = 0; i < graph.getRealSize(); i++)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            int k = 0;
        //            if (myAdj.GetVertex(i).getCompound()[j] != int.MaxValue)
        //                for (; k < myAdj.GetVertex(i).getCompound()[j]; k++)
        //                {
        //                    if (k == 0)
        //                    {
        //                        plot.DrawCurve(pen, new Point[2] { findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()), findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()) });
        //                    }
        //                    else
        //                    {
        //                        plot.DrawCurve(pen, new Point[3] { findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()), pointForCurve(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint(), distanceBetweenLines * ((k + 1) / 2), k + 1), findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()) });
        //                    }
        //                }
        //            if (myAdj.GetVertex(j).getCompound()[i] != int.MaxValue)
        //            {
        //                int t = myAdj.GetVertex(i).getCompound()[j] != int.MaxValue ? myAdj.GetVertex(i).getCompound()[j] : 0;

        //                for (; k < myAdj.GetVertex(j).getCompound()[i] + t; k++)
        //                {
        //                    if (k == 0)
        //                    {
        //                        plot.DrawCurve(pen, new Point[2] { findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()), findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()) });
        //                    }
        //                    else
        //                    {
        //                        plot.DrawCurve(pen, new Point[3] { findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()), pointForCurve(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint(), distanceBetweenLines * ((k + 1) / 2), k + 1), findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()) });
        //                    }
        //                }
        //            }
        //        }
        //    }
        
        //}

        public override void repaint() {
            plot.Clear(backGroungCoolor);
            for (int i = 0; i < graph.getRealSize(); i++)
            {
                drawFillElipse(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(i));
            }
            if (pressVer)
                plot.DrawEllipse(new Pen(highlightColor, widghtLines), pressPoint.X - sizeCircle / 2 + widghtLines / 2, pressPoint.Y - sizeCircle / 2 + widghtLines / 2, sizeCircle - widghtLines, sizeCircle - widghtLines);

            for (int i = 0; i < graph.getRealSize(); i++)
            {
                for (int j = i; j < graph.getRealSize(); j++)
                {
                    if (myAdj.GetVertex(i).getEl(j) != int.MaxValue && myAdj.GetVertex(j).getEl(i) != int.MaxValue)
                    {
                        int n = Math.Min(myAdj.GetVertex(i).getEl(j), myAdj.GetVertex(j).getEl(i));
                        int k = repaintOrientLines(i,j,n);
                        if(myAdj.GetVertex(i).getEl(j)>myAdj.GetVertex(j).getEl(i))
                        reapaintNotOrientLines(j,i,k, myAdj.GetVertex(i).getEl(j));
                        if(myAdj.GetVertex(i).getEl(j) < myAdj.GetVertex(j).getEl(i))
                            reapaintNotOrientLines(i,j , k, myAdj.GetVertex(j).getEl(i));
                    }
                    else {
                        if (myAdj.GetVertex(i).getEl(j) != int.MaxValue)
                            reapaintNotOrientLines(j, i, 0, myAdj.GetVertex(i).getEl(j));
                        if (myAdj.GetVertex(j).getEl(i) != int.MaxValue)
                            reapaintNotOrientLines(i, j, 0, myAdj.GetVertex(j).getEl(i));

                    }
                }
            }
        }

        private int repaintOrientLines(int i,int j,int n)
        {
            int k = 0;
            for (; k < n; k++)
            {
                if (k == 0)
                {
                    plot.DrawCurve(new Pen(highlightColor, widghtLines), new Point[2] { findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()), findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()) });
                }
                else
                {
                    plot.DrawCurve(new Pen(highlightColor, widghtLines), new Point[3] { findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()), pointForCurve(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint(), distanceBetweenLines * ((k + 1) / 2), k), findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()) });
                }
            }
            return k;
        }

        private void reapaintNotOrientLines(int i,int j,int k,int n) {
            Pen pen = new Pen(highlightColor, widghtLines);
            pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(widghtLines, widghtLines);
            for (; k <n; k++)
            {
                if (k == 0)
                {
                    plot.DrawCurve(pen, new Point[2] { findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()), findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()) });
                }
                else
                {
                    plot.DrawCurve(pen, new Point[3] { findIntersectionLineWithCircle(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint()), pointForCurve(myAdj.GetVertex(j).GetPoint(), myAdj.GetVertex(i).GetPoint(), distanceBetweenLines * ((k + 1) / 2), k ), findIntersectionLineWithCircle(myAdj.GetVertex(i).GetPoint(), myAdj.GetVertex(j).GetPoint()) });
                }
            }

        }

    }
}
