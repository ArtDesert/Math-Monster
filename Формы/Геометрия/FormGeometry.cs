using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using static Professional_GUI.Algebra;
using System.IO;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI
{
    public partial class FormGeometry : Form
    {
        //private Button curButton = null;
        public bool expance = false;
        // 0 - по фукнкции, 1 - прямая по 2 точкам / точке и направляющему вектору, 2 - окружность,
        // 3 - кривые и пов-ти 2-го порядка, 4 - углы, 5 - расстояние между прямыми, 6 - расстояние между точкой и прямой
        // 7 - угол между точкой и ... 3d, 8 - угол между прямые, плоскости 3d, 9 - векторы
        public int funcMode = 0;
        private double a, b, st;

        public FormGeometry()
        {
            InitializeComponent();
            topic_.Text = "Выберете функцию";
            radioButtonArea.Checked = true;
            groupBoxMain.Parent = this;
            reader.Visible = false;
        }

        public static double StringFunctionToDouble(double x, string s)
        {
            string specifier = "G";
            if (s == "x")
                s = s.Replace("x", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            if (s[0] == '-')
            {
                s = s.Remove(0, 1);
                s = "(-1)*" + s;
            }
            s = s.Replace("x)", x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("(x", "(" + x.ToString(specifier, CultureInfo.InvariantCulture));
            s = s.Replace("+x", "+" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("^x", "^" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("-x", "-" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("*x", "*" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("/x", "/" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");

            s = s.Replace("x+", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "+");
            s = s.Replace("x^", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "^");
            s = s.Replace("x-", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "-");
            s = s.Replace("x*", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "*");
            s = s.Replace("x/", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "/");
            s = s.Replace("(x)", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("π", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            var v = new CalcScript().Evaluate(s);
            return v;
        }

        public void clearField()
        {
            groupBoxMain.Enabled = true;
            groupBoxMain.Visible = true;
            this.chart1.Series[0].Points.Clear();
            topic_.Text = "Геометрический калькулятор";
            result.Text = "Результат";
            switch (funcMode)
            {
                case 0:
                    {
                        if (this.chart1.Series.FindByName("tangent") != null)
                            this.chart1.Series.Remove(this.chart1.Series.FindByName("tangent"));
                        chart1.Visible = false;
                        groupBoxGrFunc.Visible = false;
                        break;
                    }
                case 1:
                    {
                        panel2points.Visible = panelPointVec.Visible = false;
                        groupBoxGrLine.Visible = chart1.Visible = false;
                        break;
                    }
                case 2:
                    {
                        panel3rdPointsSur.Visible = false;
                        radioButton3PointsSur.Visible = radioButtonPointNormalSur.Visible = false;
                        radioButton3PointsSur.Checked = radioButtonPointNormalSur.Checked = false;
                        groupBoxPointNormalSur.Enabled = groupBox3PointsSur.Enabled = true;
                        groupBoxPointNormalSur.Visible = groupBoxCircle3Ps.Visible = chart1.Visible = false;
                        break;
                    }
                case 3:
                    {
                        panelSurThirdOrder.Visible = false;
                        groupBoxSecondOrder.Visible = false;
                        break;
                    }
                case 4:
                    {
                        groupBoxAngle2LinesExp.Visible = groupBoxAngleLineSurExp.Visible = groupBoxAngle2SursExp.Visible = true;
                        groupBoxAngleDistExp.Visible = groupBoxAngleLines.Visible = false;
                        this.chart1.Series[0].LegendText = "y(x)";
                        if (this.chart1.Series.Count > 1)
                            this.chart1.Series.RemoveAt(1);
                        chart1.Visible = false;
                        break;
                    }
                case 5:
                    {
                        groupBoxAngleLines.Visible = false;
                        break;
                    }
                case 6:
                    {
                        groupBoxDistPointLine.Visible = false;
                        break;
                    }
                case 7:
                    {
                        groupBoxDistPointExp.Visible = false;
                        break;
                    }
                case 8:
                    {
                        groupBoxAngleDistExp.Visible = false;
                        break;
                    }
                case 9:
                    {
                        groupBoxSubVector.Visible = groupBoxMixVectors.Visible = false;
                        radioButtonSubVector.Visible = radioButtonMixVectors.Visible = false;
                        panelScalarVectorsExp.Visible = panelAngleVectorsExp.Visible = false;
                        groupBoxVectorsFuncs.Visible = false;
                        break;
                    }
                default: break;
            }
        }

        private void radioButtonArea_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonArea.Checked)
            {
                expance = false;
                btnCircleEq.Text = "Уравнение окружности";
                btnSOC.Text = "Кривая 2-го порядка";
                btnAngleLines.Text = "Угол между прямыми";
                btnDistPointLine.Text = "Расстояние от точки до прямой";
                btnDistLineLine.Text = "Расстояние между прямыми";
            }
        }

        private void radioButtonSpace_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSpace.Checked)
            {
                expance = true;
                btnCircleEq.Text = "Уравнение плоскости";
                btnSOC.Text = "Поверхность 2-го порядка";
                btnAngleLines.Text = "Вычисление углов";
                btnDistPointLine.Text = "Расстояния от точки";
                btnDistLineLine.Text = "Расстояния ПП";
            }
        }

        private void btnVectors_Click(object sender, EventArgs e)
        {
            clearField();
            funcMode = 9;
            groupBoxVectorsFuncs.Visible = true;
            if (expance)
            {
                topic_.Text = "Операции с векторами в пространстве.";
                groupBoxSubVector.Visible = groupBoxMixVectors.Visible = true;
                radioButtonSubVector.Visible = radioButtonMixVectors.Visible = true;
                panelScalarVectorsExp.Visible = panelAngleVectorsExp.Visible = true;
                labelGeometryExpVector1.Text = labelGeometryExpVector2.Text = labelGeometryExpVector5.Text = labelGeometryExpVector6.Text = ";";
                reader.src = Directory.GetCurrentDirectory() + "\\Vectors_Exp.pdf";
            }
            else
            {
                topic_.Text = "Операции с векторами на плоскости.";
                labelGeometryExpVector1.Text = labelGeometryExpVector2.Text = labelGeometryExpVector5.Text = labelGeometryExpVector6.Text = "}";
                reader.src = Directory.GetCurrentDirectory() + "\\Vectors_Area.pdf";
            }
        }

        private void btnGraphFunc_Click(object sender, EventArgs e)
        {
            clearField();
            if (expance)
            {
                MessageBox.Show("Данная функция в разработке", "Внимание!");
            }
            else
            {
                topic_.Text = "График функции одной переменной.";
                funcMode = 0;
                groupBoxGrFunc.Visible = true;
                chart1.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\GraphicFunc.pdf";
            }
        }

        private void radioButtonLine2Ps_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLine2Ps.Checked)
            {
                groupBoxLine2Ps.Enabled = true;
                groupBoxLinePoint.Enabled = false;
            }
        }

        private void radioButtonLinePoint_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLinePoint.Checked)
            {
                groupBoxLinePoint.Enabled = true;
                groupBoxLine2Ps.Enabled = false;
            }
        }

        private void btnLineEq_Click(object sender, EventArgs e)
        {
            clearField();
            topic_.Text = "Уравнение прямой.";
            funcMode = 1;
            groupBoxGrLine.Visible = true;
            if (expance)
            {
                panel2points.Visible = panelPointVec.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\eqLine_Exp.pdf";
            }
            else
            {
                reader.src = Directory.GetCurrentDirectory() + "\\eqLine_Area.pdf";
                chart1.Visible = true;
            }
        }

        private void btnCircleEq_Click(object sender, EventArgs e)
        {
            clearField();
            funcMode = 2;
            groupBoxCircle3Ps.Visible = groupBox3PointsSur.Visible = true;
            if (expance)
            {
                topic_.Text = "Уравнение плоскости.";
                panel3rdPointsSur.Visible = true;
                groupBoxPointNormalSur.Visible = true;
                radioButton3PointsSur.Visible = radioButtonPointNormalSur.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\eqCircle_Exp.pdf";
            }
            else
            {
                reader.src = Directory.GetCurrentDirectory() + "\\eqCircle_Area.pdf";
                chart1.Visible = true;
                topic_.Text = "Уравнение окружности по 3-м точкам.";
            }
        }

        private void btnSOC_Click(object sender, EventArgs e)
        {
            clearField();
            funcMode = 3;
            if (expance)
            {
                topic_.Text = "Определение поверхности второго порядка.";
                panelSurThirdOrder.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\SSO_Exp.pdf";
            }
            else
            {
                reader.src = Directory.GetCurrentDirectory() + "\\LSO_Area.pdf";
                topic_.Text = "Определение кривой второго порядка.";
            }
            groupBoxSecondOrder.Visible = true;
        }

        private void btnAngleLines_Click(object sender, EventArgs e)
        {
            clearField();
            funcMode = 4;
            if (expance)
            {
                topic_.Text = "Углы между прямыми и плоскостями.";
                groupBoxAngleDistExp.Visible = true;
                radioButtonAngleDist2LinesExp.Visible = radioButtonAngleDistLineSurExp.Visible = radioButtonAngleDist2SursExp.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\angles_Exp.pdf";
            }
            else
            {
                topic_.Text = "Угол между прямыми.";
                groupBoxAngleLines.Visible = chart1.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\angleLines_Area.pdf";
            }
        }

        private void btnDistPointLine_Click(object sender, EventArgs e)
        {
            clearField();
            if (expance)
            {
                topic_.Text = "Расстояние от точки до прямой / плоскости.";
                funcMode = 7;
                groupBoxDistPointExp.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\distPoint_Exp.pdf";
            }
            else
            {
                topic_.Text = "Расстояние от точки до прямой.";
                funcMode = 6;
                groupBoxDistPointLine.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\distPointLine_Area.pdf";
            }
        }

        private void btnDistLineLine_Click(object sender, EventArgs e)
        {
            clearField();
            if (expance)
            {
                topic_.Text = "Расстояние между прямыми и плоскостями.";
                funcMode = 8;
                groupBoxAngleDistExp.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\dists_Exp.pdf";
            }
            else
            {
                topic_.Text = "Расстояние между двумя прямыми.";
                funcMode = 5;
                groupBoxAngleLines.Visible = true;
                reader.src = Directory.GetCurrentDirectory() + "\\distLines_Area.pdf";
            }
        }

        private string formatString(string str)
        {
            return str.Replace(",", ".").Replace("+ -", "-").Replace(" 0 ", "");
        }

        private void buildLine3d(double x1, double y1, double z1, double m, double n, double p)
        {
            string res = Math.Round((1 / m), 3).ToString() + "x + " + Math.Round((x1 / m), 3).ToString() + " = " +
                        Math.Round((1 / n), 3).ToString() + "y + " + Math.Round((y1 / n), 3).ToString() + " = " +
                        Math.Round((1 / p), 3).ToString() + "z + " + Math.Round((z1 / p), 3).ToString();
            result.Text = formatString(res);
        }

        private void buildSurface3d(double A, double B, double C, double D)
        {
            string res = Math.Round(A, 3).ToString() + "x + " + Math.Round(B, 3).ToString() + "y + " +
                        Math.Round(C, 3).ToString() + "z + " + Math.Round(D, 3).ToString() + " = 0";
            result.Text = formatString(res);
        }

        private void buildLine2d(double k, double b1)
        {
            string f = Math.Round(k, 3).ToString() + "*x + " + Math.Round(b1, 3).ToString();
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[0].LegendText = "y(x)";
            string f1 = formatString(f);
            result.Text = "у(х) = " + f1;

            DefaultParams();
            for (double x = a; x <= b; x += st)
                this.chart1.Series[0].Points.AddXY(x, StringFunctionToDouble(x, f1));
        }

        private string angleExp(double m1, double p1, double l1, double m2, double p2, double l2, bool f)
        {
            double sqrt1 = Math.Sqrt(m1 * m1 + p1 * p1 + l1 * l1);
            double sqrt2 = Math.Sqrt(m2 * m2 + p2 * p2 + l2 * l2);
            if (sqrt1 * sqrt2 == 0)
                return "Угол не может быть вычислен, \nт.к. есть одна нулевая нормаль";
            else
            {
                double angle;
                double cos = (m1 * m2 + p1 * p2 + l1 * l2) / (sqrt1 * sqrt2);

                angle = f ? Math.Asin(Math.Abs(cos)) : Math.Acos(cos);

                return "Угол = " + Math.Round((angle * 180.0 / Math.PI), 3).ToString() + "°";
            }
        }

        private string dist2SursExp(double[] arr1, double[] arr2, double D1, double D2, double norm)
        {
            double k = Math.Round((arr2[0] / arr1[0]), 3);
            if (k == Math.Round((arr2[1] / arr1[1]), 3) && k == Math.Round((arr2[2] / arr1[2]), 3))
            {
                return "Расстояние между S1 и S2: " + Math.Round(Math.Abs(D2 / k - D1) / norm, 3).ToString();
            }
            else
                return "Эти плоскости не параллельны";
        }

        private void writeDist(double d)
        {
            result.Text = "Расстояние: " + Math.Round(d, 3).ToString();
        }

        private void scalarVectors(double[] arr1, double[] arr2)
        {
            Vector n1 = new Vector(arr1);
            Vector n2 = new Vector(arr2);

            result.Text = "Скалярное произведение: " + Math.Round(OperationsOnVectors.Scalar(n1, n2), 3).ToString();
        }

        private void angleVectors(double[] arr1, double[] arr2)
        {
            Vector n1 = new Vector(arr1);
            Vector n2 = new Vector(arr2);

            result.Text = "Угол между векторами: " + Math.Round(OperationsOnVectors.Angle(n1, n2), 3).ToString() + "°";
        }

        private void built_Click(object sender, EventArgs e)
        {
            switch (funcMode)
            {
                case 0:
                    {
                        if (function.Text != "")
                        {
                            if (borderLeft.Text == "" || borderRight.Text == "" || step.Text == "")
                                DefaultParams();
                            else
                            {
                                try
                                {
                                    a = Convert.ToDouble(borderLeft.Text);
                                    b = Convert.ToDouble(borderRight.Text);
                                    st = Convert.ToDouble(step.Text);
                                }
                                catch (FormatException) { HandlingException("Введите число с запятой"); }
                                if (a >= b)
                                {
                                    MessageBox.Show("Левая граница должна быть меньше правой", "Внимание!");
                                    return;
                                }
                                if (st > Math.Abs(b - a))
                                {
                                    MessageBox.Show("Введите шаг поменьше", "Внимание!");
                                    return;
                                }
                            }
                            this.chart1.Series[0].Points.Clear();
                            if (this.chart1.Series.FindByName("tangent") != null)
                                this.chart1.Series.Remove(this.chart1.Series.FindByName("tangent"));
                            this.chart1.Series[0].LegendText = "y(x)";
                            result.Text = "у(х) = " + function.Text;
                            string f = function.Text.Replace(",", ".");
                            if (StringFunctionToDouble(1, f) == -99999999)
                            {
                                MessageBox.Show("Введите верную функцию", "Внимание!");
                                return;
                            }
                            for (double x = a; x <= b; x += st)
                                this.chart1.Series[0].Points.AddXY(x, StringFunctionToDouble(x, f));
                        }
                        else
                            MessageBox.Show("Введите функцию", "Внимание!");
                        break;
                    }
                case 1:
                    {
                        if (radioButtonLine2Ps.Checked)
                        {
                            if (textBoxGeometry1.Text == "" || textBoxGeometry2.Text == "" || textBoxGeometry3.Text == "" || textBoxGeometry4.Text == "")
                                MessageBox.Show("Введите параметры", "Внимание!");
                            else
                            {
                                try
                                {
                                    double x1 = Convert.ToDouble(textBoxGeometry1.Text);
                                    double x2 = Convert.ToDouble(textBoxGeometry3.Text);
                                    if (Math.Abs(x1 - x2) < 0.0001)
                                        MessageBox.Show("Введите разные x", "Внимание!");
                                    else
                                    {
                                        double y1 = Convert.ToDouble(textBoxGeometry2.Text);
                                        double y2 = Convert.ToDouble(textBoxGeometry4.Text);
                                        if (expance)
                                        {
                                            if (textBoxGeometry19.Text == "" || textBoxGeometry20.Text == "")
                                            {
                                                MessageBox.Show("Введите параметры", "Внимание!");
                                                return;
                                            }
                                            double z1 = Convert.ToDouble(textBoxGeometry20.Text);
                                            double z2 = Convert.ToDouble(textBoxGeometry19.Text);
                                            buildLine3d(x1, y1, z1, x2 - x1, y2 - y1, z2 - z1);
                                        }
                                        else
                                            buildLine2d((y2 - y1) / (x2 - x1), (x2 * y1 - x1 * y2) / (x2 - x1));
                                    }
                                }
                                catch (FormatException) { HandlingException("Введите число с запятой"); }
                            }
                        }
                        else if (radioButtonLinePoint.Checked)
                        {
                            if (textBoxGeometry5.Text == "" || textBoxGeometry6.Text == "" || textBoxGeometry7.Text == "" || textBoxGeometry8.Text == "")
                                MessageBox.Show("Введите параметры", "Внимание!");
                            else
                            {
                                try
                                {
                                    double x = Convert.ToDouble(textBoxGeometry5.Text);
                                    double y = Convert.ToDouble(textBoxGeometry6.Text);
                                    double xV = Convert.ToDouble(textBoxGeometry7.Text);
                                    double yV = Convert.ToDouble(textBoxGeometry8.Text);
                                    if (xV == 0)
                                    {
                                        MessageBox.Show("Введите ненулевой вектор", "Внимание!");
                                    }
                                    else
                                    {
                                        if (expance)
                                        {
                                            if (textBoxGeometry21.Text == "" || textBoxGeometry22.Text == "")
                                            {
                                                MessageBox.Show("Введите координаты", "Внимание!");
                                                return;
                                            }
                                            double z = Convert.ToDouble(textBoxGeometry21.Text);
                                            double zV = Convert.ToDouble(textBoxGeometry22.Text);
                                            buildLine3d(x, y, z, xV, yV, zV);
                                        }
                                        else
                                        {
                                            if (xV == -y)
                                                result.Text = "Не получилось построить график и составить уравнение прямой, \nт.к совпадают X вектора и координата Y точки";
                                            else
                                                buildLine2d((yV / xV), ((-x * yV) / xV + y));
                                        }
                                    }
                                }
                                catch (FormatException) { HandlingException("Введите число с запятой"); }
                            }
                        }
                        else
                            MessageBox.Show("Выберете формат ввода", "Внимание!");
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            if (expance)
                            {
                                if (radioButton3PointsSur.Checked)
                                {
                                    if (textBoxGeometry9.Text == "" || textBoxGeometry10.Text == "" || textBoxGeometry11.Text == "" ||
                                        textBoxGeometry12.Text == "" || textBoxGeometry13.Text == "" || textBoxGeometry14.Text == "" ||
                                        textBoxGeometry23.Text == "" || textBoxGeometry24.Text == "" || textBoxGeometry25.Text == "")
                                    {
                                        MessageBox.Show("Введите параметры", "Внимание!");
                                        return;
                                    }
                                    else
                                    {
                                        double x1 = Convert.ToDouble(textBoxGeometry9.Text);
                                        double x2 = Convert.ToDouble(textBoxGeometry11.Text);
                                        double x3 = Convert.ToDouble(textBoxGeometry13.Text);
                                        double y1 = Convert.ToDouble(textBoxGeometry10.Text);
                                        double y2 = Convert.ToDouble(textBoxGeometry12.Text);
                                        double y3 = Convert.ToDouble(textBoxGeometry14.Text);
                                        double z1 = Convert.ToDouble(textBoxGeometry24.Text);
                                        double z2 = Convert.ToDouble(textBoxGeometry25.Text);
                                        double z3 = Convert.ToDouble(textBoxGeometry23.Text);

                                        double A = y1 * (z2 - z3) + y2 * (z3 - z1) + y3 * (z1 - z2);
                                        double B = z1 * (x2 - x3) + z2 * (x3 - x1) + z3 * (x1 - x2);
                                        double C = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
                                        double D = -(x1 * (y2 * z3 - y3 * z2) + x2 * (y3 * z1 - y1 * z3) + x3 * (y1 * z2 - y2 * z1));

                                        buildSurface3d(A, B, C, D);
                                    }
                                }
                                else if (radioButtonPointNormalSur.Checked)
                                {
                                    if (textBoxGeometry26.Text == "" || textBoxGeometry27.Text == "" || textBoxGeometry28.Text == "" ||
                                        textBoxGeometry29.Text == "" || textBoxGeometry30.Text == "" || textBoxGeometry31.Text == "")
                                        MessageBox.Show("Введите параметры", "Внимание!");
                                    double x = Convert.ToDouble(textBoxGeometry30.Text);
                                    double y = Convert.ToDouble(textBoxGeometry31.Text);
                                    double z = Convert.ToDouble(textBoxGeometry27.Text);
                                    double n1 = Convert.ToDouble(textBoxGeometry28.Text);
                                    double n2 = Convert.ToDouble(textBoxGeometry29.Text);
                                    double n3 = Convert.ToDouble(textBoxGeometry26.Text);

                                    buildSurface3d(n1, n2, n3, -(x * n1 + y * n2 + z * n3));
                                }
                                else
                                    MessageBox.Show("Выберете формат ввода", "Внимание!");
                            }
                            else
                            {
                                if (textBoxGeometry9.Text == "" || textBoxGeometry10.Text == "" || textBoxGeometry11.Text == "" ||
                               textBoxGeometry12.Text == "" || textBoxGeometry13.Text == "" || textBoxGeometry14.Text == "")
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                else
                                {
                                    double x1 = Convert.ToDouble(textBoxGeometry9.Text);
                                    double x2 = Convert.ToDouble(textBoxGeometry11.Text);
                                    double x3 = Convert.ToDouble(textBoxGeometry13.Text);
                                    double y1 = Convert.ToDouble(textBoxGeometry10.Text);
                                    double y2 = Convert.ToDouble(textBoxGeometry12.Text);
                                    double y3 = Convert.ToDouble(textBoxGeometry14.Text);
                                    double A = x2 - x1;
                                    double B = y2 - y1;
                                    double c = x3 - x1;
                                    double d = y3 - y1;
                                    double E = A * (x1 + x2) + B * (y1 + y2);
                                    double f = c * (x1 + x3) + d * (y1 + y3);
                                    double g = 2 * (A * (y3 - y2) - B * (x3 - x2));
                                    if (g == 0)
                                    {
                                        MessageBox.Show("Введите другие точки, возможно точки лежат на одной линии или их координаты совпадают", "Внимание!");
                                        return;
                                    }
                                    double Cx = (d * E -  B * f) / g;
                                    double Cy = (A * f - c * E) / g;
                                    double R = Math.Sqrt(Math.Pow(x1 - Cx, 2) + Math.Pow(y1 - Cy, 2));
                                    string str = "(x - " + Math.Round(Math.Abs(Cx), 3).ToString() + ")² + " +
                                        "(y - " + Math.Round(Math.Abs(Cy), 3).ToString() + ")² = " + Math.Round((R * R), 3).ToString();
                                    result.Text = str.Replace(",", ".");
                                    this.chart1.Series[0].Points.Clear();
                                    this.chart1.Series[0].LegendText = "y(x)";
                                    a = Cx - R - 1;
                                    b = Cx + R + 1;
                                    st = 0.01;
                                    for (double i = a; i <= b; i += st)
                                        this.chart1.Series[0].Points.AddXY(i, Math.Sqrt((Math.Pow(R, 2) - Math.Pow((i - Cx), 2))) + Cy);
                                    for (double i = a; i <= b; i += st)
                                        this.chart1.Series[0].Points.AddXY(i, -Math.Sqrt((Math.Pow(R, 2) - Math.Pow((i - Cx), 2))) + Cy);
                                }
                            }
                        }
                        catch (FormatException) { HandlingException("Введите число с запятой"); }
                        break;
                    }
                case 3:
                    {
                        if (textBoxGeometry73.Text == "" || textBoxGeometry74.Text == "" || textBoxGeometry76.Text == "" ||
                                textBoxGeometry78.Text == "" || textBoxGeometry84.Text == "" || textBoxGeometry85.Text == "")
                            MessageBox.Show("Введите параметры", "Внимание!");
                        else
                        {
                            try
                            {
                                double a11 = Convert.ToDouble(textBoxGeometry78.Text);
                                double a22 = Convert.ToDouble(textBoxGeometry76.Text);
                                double a12 = Convert.ToDouble(textBoxGeometry74.Text) / 2;
                                double a1 = Convert.ToDouble(textBoxGeometry73.Text) / 2;
                                double a2 = Convert.ToDouble(textBoxGeometry85.Text) / 2;
                                double a0 = Convert.ToDouble(textBoxGeometry84.Text);

                                string res = "";
                                double sigma;
                                double delta;
                                if (expance)
                                {
                                    if (textBoxGeometry88.Text == "" || textBoxGeometry87.Text == "" || textBoxGeometry86.Text == "" || textBoxGeometry80.Text == "")
                                    {
                                        MessageBox.Show("Введите параметры", "Внимание!");
                                        return;
                                    }
                                    else
                                    {
                                        double a33 = Convert.ToDouble(textBoxGeometry88.Text);
                                        double a13 = Convert.ToDouble(textBoxGeometry87.Text) / 2;
                                        double a23 = Convert.ToDouble(textBoxGeometry86.Text) / 2;
                                        double a3 = Convert.ToDouble(textBoxGeometry80.Text) / 2;

                                        double t1 = a11 + a22 + a33;
                                        double t2 = a11 * a22 - a12 * a12 + a11 * a33 - a13 * a13 + a33 * a22 - a23 * a23;
                                        double[,] arr1 = { {a11, a12, a13 },
                                                      {a12, a22, a23 },
                                                      {a13, a23, a33 } };
                                        Matrix d1 = new Matrix(arr1);
                                        sigma = Matrix.Det(d1);

                                        double[,] arr2 = {{a11, a12, a13, a1 },
                                                      {a12, a22, a23, a2 },
                                                      {a13, a23, a33, a3 },
                                                      {a1, a2, a3, a0 } };
                                        Matrix d2 = new Matrix(arr2);
                                        delta = Matrix.Det(d2);
                                        double k1 = 0, k2 = 0;
                                        if (sigma != 0)
                                        {
                                            if (t2 > 0 && t1 * sigma > 0)
                                            {
                                                if (delta < 0)
                                                {
                                                    res = "Эллипсоид";
                                                }
                                                else if (delta > 0)
                                                {
                                                    res = "Мнимый эллипсоид";
                                                }
                                                else
                                                {
                                                    res = "Мнимый конус";
                                                }
                                            }
                                            else if (t2 <= 0 || t1 * sigma <= 0)
                                            {
                                                if (delta < 0)
                                                {
                                                    res = "Двуполостный гиперболоид";
                                                }
                                                else if (delta > 0)
                                                {
                                                    res = "Однополостный гиперболоид";
                                                }
                                                else
                                                {
                                                    res = "Конус";
                                                }
                                            }
                                            else
                                                res = "Не удалось определить поверхность";
                                        }
                                        else
                                        {
                                            if (delta < 0)
                                            {
                                                res = "Эллиптический параболоид";
                                            }
                                            else if (delta > 0)
                                            {
                                                res = "Гиперболический параболоид";
                                            }
                                            else
                                            {
                                                double[,] arr12 = { {a11, a12, a1 },
                                                                {a12, a22, a2 },
                                                                {a1, a2, a0 } };
                                                double[,] arr13 = { {a11, a13, a1 },
                                                                {a13, a33, a3 },
                                                                {a1, a3, a0 } };
                                                double[,] arr23 = { {a22, a23, a2 },
                                                                {a23, a33, a3 },
                                                                {a2, a3, a0 } };
                                                Matrix d12 = new Matrix(arr12);
                                                Matrix d13 = new Matrix(arr13);
                                                Matrix d23 = new Matrix(arr23);
                                                k2 = Matrix.Det(d12) + Matrix.Det(d13) + Matrix.Det(d23);
                                                if (t2 > 0)
                                                {
                                                    if (t1 * k2 < 0)
                                                    {
                                                        res = "Эллептический цилиндр";
                                                    }
                                                    else if (t1 * k2 > 0)
                                                    {
                                                        res = "Мнимый эллиптический цилиндр";
                                                    }
                                                    else if (k2 == 0)
                                                    {
                                                        res = "Пара мнимых пересекающихся плоскостей";
                                                    }
                                                    else
                                                        res = "Не удалось определить поверхность";
                                                }
                                                else if (t2 < 0)
                                                {
                                                    if (k2 != 0)
                                                    {
                                                        res = "Гиперболический цилиндр";
                                                    }
                                                    else
                                                    {
                                                        res = "Пара пересекающихся плоскостей";
                                                    }
                                                }
                                                else
                                                {
                                                    if (k2 != 0)
                                                    {
                                                        res = "Параболический цилиндр";
                                                    }
                                                    else
                                                    {
                                                        k1 = a11 * a0 - a1 * a1 + a22 * a0 - a2 * a2 + a33 * a0 - a3 * a3;
                                                        if (k1 < 0)
                                                        {
                                                            res = "Пара параллельных плоскостей";
                                                        }
                                                        else if (k1 > 0)
                                                        {
                                                            res = "Пара мнимых параллельных плоскостей";
                                                        }
                                                        else
                                                        {
                                                            res = "Пара совпадающих плоскостей";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        invariantsSecondOrder.Text = "τ1: " + Math.Round(t1, 3).ToString() + "\n" + "τ2: " + Math.Round(t2, 3).ToString() + "\n" +
                                                                       "κ1: " + Math.Round(k1, 3).ToString() + "\n" + "κ2: " + Math.Round(k2, 3).ToString() + "\n";
                                    }
                                }
                                else
                                {
                                    double t = a11 + a22;
                                    sigma = a11 * a22 - a12 * a12;
                                    double[,] arr = {{ a11, a12, a1 },
                                                  {a12, a22, a2 },
                                                  {a1, a2, a0 } };
                                    Matrix d = new Matrix(arr);
                                    delta = Matrix.Det(d);
                                    if (sigma > 0)
                                    {
                                        if (delta != 0)
                                        {
                                            if (t * delta < 0)
                                            {
                                                res = "Эллипс";
                                            }
                                            else if (t * delta > 0)
                                            {
                                                res = "Эллипс мнимый";
                                            }
                                            else
                                                res = "Не удалось определить кривую";
                                        }
                                        else
                                        {
                                            res = "Пара мнимых пересекающихся прямых";
                                        }
                                    }
                                    else if (sigma < 0)
                                    {
                                        if (delta != 0)
                                        {
                                            res = "Гипербола";
                                        }
                                        else
                                        {
                                            res = "Пара пересекающихся прямых";
                                        }
                                    }
                                    else
                                    {
                                        if (delta != 0)
                                        {
                                            res = "Парабола";
                                        }
                                        else
                                        {
                                            double k = a11 * a0 - a1 * a1 + a22 * a0 - a2 * a2;
                                            if (k < 0)
                                            {
                                                res = "Пара параллельных прямых";

                                            }
                                            else if (k > 0)
                                            {
                                                res = "Пара мнимых параллельных прямых";

                                            }
                                            else
                                            {
                                                res = "Пара совпадающих прямых";

                                            }
                                        }
                                    }
                                    invariantsSecondOrder.Text = "τ: " + t.ToString() + "\n";
                                }
                                invariantsSecondOrder.Text += "δ: " + Math.Round(sigma, 3).ToString() + "\n" + "Δ: " + Math.Round(delta, 3).ToString();
                                result.Text = res;
                            }
                            catch (FormatException) { HandlingException("Введите число с запятой"); }
                        }
                        break;
                    }
                case 4:
                    {
                        try
                        {
                            if (expance)
                            {
                                if (radioButtonAngleDist2LinesExp.Checked)
                                {
                                    if (textBoxGeometry39.Text == "" || textBoxGeometry40.Text == "" || textBoxGeometry41.Text == "" ||
                                        textBoxGeometry61.Text == "" || textBoxGeometry60.Text == "" || textBoxGeometry59.Text == "" ||
                                        textBoxGeometry62.Text == "" || textBoxGeometry63.Text == "" || textBoxGeometry64.Text == "" ||
                                        textBoxGeometry42.Text == "" || textBoxGeometry43.Text == "" || textBoxGeometry44.Text == "")
                                        MessageBox.Show("Введите параметры", "Внимание!");
                                    else
                                    {
                                        result.Text = angleExp(Convert.ToDouble(textBoxGeometry40.Text), Convert.ToDouble(textBoxGeometry41.Text),
                                            Convert.ToDouble(textBoxGeometry39.Text), Convert.ToDouble(textBoxGeometry43.Text),
                                            Convert.ToDouble(textBoxGeometry44.Text), Convert.ToDouble(textBoxGeometry42.Text), false);

                                    }
                                }
                                else if (radioButtonAngleDistLineSurExp.Checked)
                                {
                                    if (textBoxGeometry46.Text == "" || textBoxGeometry47.Text == "" || textBoxGeometry48.Text == "" ||
                                        textBoxGeometry49.Text == "" || textBoxGeometry50.Text == "" || textBoxGeometry51.Text == "" ||
                                        textBoxGeometry52.Text == "" || textBoxGeometry53.Text == "" || textBoxGeometry54.Text == "" || textBoxGeometry55.Text == "")
                                        MessageBox.Show("Введите параметры", "Внимание!");
                                    else
                                    {
                                        result.Text = angleExp(Convert.ToDouble(textBoxGeometry47.Text), Convert.ToDouble(textBoxGeometry48.Text),
                                            Convert.ToDouble(textBoxGeometry46.Text), Convert.ToDouble(textBoxGeometry55.Text),
                                            Convert.ToDouble(textBoxGeometry54.Text), Convert.ToDouble(textBoxGeometry53.Text), true);

                                    }
                                }
                                else if (radioButtonAngleDist2SursExp.Checked)
                                {
                                    if (textBoxGeometry34.Text == "" || textBoxGeometry35.Text == "" || textBoxGeometry32.Text == "" || textBoxGeometry33.Text == "" ||
                                        textBoxGeometry36.Text == "" || textBoxGeometry37.Text == "" || textBoxGeometry38.Text == "" || textBoxGeometry45.Text == "")
                                        MessageBox.Show("Введите параметры", "Внимание!");
                                    else
                                    {
                                        result.Text = angleExp(Convert.ToDouble(textBoxGeometry45.Text), Convert.ToDouble(textBoxGeometry32.Text),
                                            Convert.ToDouble(textBoxGeometry33.Text), Convert.ToDouble(textBoxGeometry38.Text),
                                            Convert.ToDouble(textBoxGeometry37.Text), Convert.ToDouble(textBoxGeometry36.Text), false);

                                    }
                                }
                                else
                                    MessageBox.Show("Выберете формат ввода", "Внимание!");
                            }
                            else
                            {
                                if (textBoxGeometryAngleLine1K.Text == "" || textBoxGeometryAngleLine2K.Text == "")
                                    MessageBox.Show("Введите угловые коэффициенты прямых", "Внимание!");
                                else
                                {
                                    double k1 = Convert.ToDouble(textBoxGeometryAngleLine1K.Text);
                                    double k2 = Convert.ToDouble(textBoxGeometryAngleLine2K.Text);
                                    double angle = 90;
                                    if (k1 != k2)
                                    {
                                        double b1, b2;
                                        if (textBoxGeometryAngleLine1B.Text == "")
                                            b1 = 0.0;
                                        else
                                            b1 = Convert.ToDouble(textBoxGeometryAngleLine1B.Text);
                                        if (textBoxGeometryAngleLine2B.Text == "")
                                            b2 = 0.0;
                                        else
                                            b2 = Convert.ToDouble(textBoxGeometryAngleLine2B.Text);

                                        if (this.chart1.Series.FindByName("y2") == null)
                                        {
                                            this.chart1.Series.Add("y2");
                                            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                                            this.chart1.Series[1].Color = Color.Red;
                                            this.chart1.Series[1].LegendText = "y2(x)";
                                        }

                                        this.chart1.Series[0].Points.Clear();
                                        this.chart1.Series[1].Points.Clear();
                                        this.chart1.Series[0].LegendText = "y1(x)";

                                        angle = Math.Abs(Math.Atan((k2 - k1) / (1 + k1 * k2)) * 180.0 / Math.PI);

                                        double x0 = (b2 - b1) / (k1 - k2);
                                        DefaultParams();
                                        a += x0;
                                        b += x0;

                                        for (double x = a; x <= b; x += st)
                                        {
                                            this.chart1.Series[0].Points.AddXY(x, x * k1 + b1);
                                            this.chart1.Series[1].Points.AddXY(x, x * k2 + b2);
                                        }
                                    }
                                    else
                                    {
                                        this.chart1.Series[0].Points.Clear();
                                        angle = 0;
                                    }

                                    result.Text = "Угол между у1 и у2: " + Math.Round(angle, 3).ToString() + "°";
                                }
                            }
                        }
                        catch (FormatException) { HandlingException("Введите число с запятой"); }
                        break;
                    }
                case 5:
                    {
                        if (textBoxGeometryAngleLine1K.Text == "" || textBoxGeometryAngleLine2K.Text == "")
                            MessageBox.Show("Введите угловые коэффициенты прямых", "Внимание!");
                        else
                        {
                            try
                            {
                                double k1 = Convert.ToDouble(textBoxGeometryAngleLine1K.Text);
                                double k2 = Convert.ToDouble(textBoxGeometryAngleLine2K.Text);

                                if (k1 == k2)
                                {
                                    double b1, b2;
                                    if (textBoxGeometryAngleLine1B.Text == "")
                                        b1 = 0.0;
                                    else
                                        b1 = Convert.ToDouble(textBoxGeometryAngleLine1B.Text);
                                    if (textBoxGeometryAngleLine2B.Text == "")
                                        b2 = 0.0;
                                    else
                                        b2 = Convert.ToDouble(textBoxGeometryAngleLine2B.Text);

                                    result.Text = "Расстояние: " + (Math.Sqrt(2) * Math.Abs(b1 - b2) / 2).ToString();
                                }
                                else
                                    result.Text = "Расстояние: 0. Прямые пересекаются";
                            }
                            catch (FormatException) { HandlingException("Введите число с запятой"); }
                        }
                        break;
                    }
                case 6:
                    {
                        if (textBoxGeometry15.Text == "" || textBoxGeometry16.Text == "" || textBoxGeometry18.Text == "")
                            MessageBox.Show("Недостаточно данных", "Внимание!");
                        else
                        {
                            try
                            {
                                double x0 = Convert.ToDouble(textBoxGeometry16.Text);
                                double y0 = Convert.ToDouble(textBoxGeometry18.Text);
                                double k = Convert.ToDouble(textBoxGeometry15.Text);
                                double b;
                                if (textBoxGeometry17.Text == "")
                                    b = 0;
                                else
                                    b = Convert.ToDouble(textBoxGeometry17.Text);

                                result.Text = "Расстояние: " + (Math.Abs(y0 - k * x0 - b) / Math.Sqrt(Math.Pow(k, 2) + 1)).ToString();
                            }
                            catch (FormatException) { HandlingException("Введите число с запятой"); }
                        }
                        break;
                    }
                case 7:
                    {
                        try
                        {
                            if (radioButtonDistPointLineExp.Checked)
                            {
                                if (textBoxGeometry56.Text == "" || textBoxGeometry66.Text == "" || textBoxGeometry67.Text == "" ||
                                    textBoxGeometry82.Text == "" || textBoxGeometry83.Text == "" || textBoxGeometry81.Text == "" ||
                                    textBoxGeometry79.Text == "" || textBoxGeometry77.Text == "" || textBoxGeometry75.Text == "")
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                else
                                {
                                    double[] s = { Convert.ToDouble(textBoxGeometry79.Text), Convert.ToDouble(textBoxGeometry77.Text), Convert.ToDouble(textBoxGeometry75.Text) };
                                    double[] m = { Convert.ToDouble(textBoxGeometry82.Text) - Convert.ToDouble(textBoxGeometry67.Text),
                                                Convert.ToDouble(textBoxGeometry83.Text) - Convert.ToDouble(textBoxGeometry66.Text),
                                                Convert.ToDouble(textBoxGeometry81.Text) - Convert.ToDouble(textBoxGeometry56.Text)};
                                    Vector vecS = new Vector(s);
                                    Vector vecM = new Vector(m);

                                    if (vecS.GetNorm() == 0)
                                        result.Text = "Введите ненулевую прямую";
                                    else
                                        writeDist(OperationsOnVectors.SubVector(vecM, vecS).GetNorm() / vecS.GetNorm());
                                }
                            }
                            else if (radioButtonDistPointSurExp.Checked)
                            {
                                if (textBoxGeometry65.Text == "" || textBoxGeometry58.Text == "" || textBoxGeometry57.Text == "" ||
                                    textBoxGeometry68.Text == "" || textBoxGeometry69.Text == "" || textBoxGeometry70.Text == "" || textBoxGeometry71.Text == "")
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                else
                                {
                                    double[] n = { Convert.ToDouble(textBoxGeometry71.Text), Convert.ToDouble(textBoxGeometry70.Text), Convert.ToDouble(textBoxGeometry69.Text) };
                                    double[] m = { Convert.ToDouble(textBoxGeometry65.Text), Convert.ToDouble(textBoxGeometry58.Text), Convert.ToDouble(textBoxGeometry57.Text) };
                                    double D = Convert.ToDouble(textBoxGeometry68.Text);
                                    Vector vecN = new Vector(n);
                                    Vector vecM = new Vector(m);

                                    if (vecN.GetNorm() == 0)
                                        result.Text = "Введите ненулевую плоскость";
                                    else
                                        writeDist(Math.Abs(OperationsOnVectors.Scalar(vecN, vecM) + D) / vecN.GetNorm());
                                }
                            }
                            else
                                MessageBox.Show("Выберете формат ввода", "Внимание!");
                        }
                        catch (FormatException) { HandlingException("Введите число с запятой"); }
                        break;
                    }
                case 8:
                    {
                        try
                        {
                            if (radioButtonAngleDist2LinesExp.Checked)
                            {
                                if (textBoxGeometry61.Text == "" || textBoxGeometry60.Text == "" || textBoxGeometry59.Text == "" ||
                                    textBoxGeometry39.Text == "" || textBoxGeometry40.Text == "" || textBoxGeometry41.Text == "" ||
                                    textBoxGeometry64.Text == "" || textBoxGeometry63.Text == "" || textBoxGeometry62.Text == "" ||
                                    textBoxGeometry42.Text == "" || textBoxGeometry43.Text == "" || textBoxGeometry44.Text == "")
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                else
                                {
                                    double[] vec1 = { Convert.ToDouble(textBoxGeometry40.Text), Convert.ToDouble(textBoxGeometry41.Text), Convert.ToDouble(textBoxGeometry39.Text) };
                                    double[] vec2 = { Convert.ToDouble(textBoxGeometry43.Text), Convert.ToDouble(textBoxGeometry44.Text), Convert.ToDouble(textBoxGeometry42.Text) };
                                    double[] m = { Convert.ToDouble(textBoxGeometry64.Text) - Convert.ToDouble(textBoxGeometry61.Text),
                                                Convert.ToDouble(textBoxGeometry63.Text) - Convert.ToDouble(textBoxGeometry60.Text),
                                                Convert.ToDouble(textBoxGeometry62.Text) - Convert.ToDouble(textBoxGeometry59.Text)};
                                    Vector n1 = new Vector(vec1);
                                    Vector n2 = new Vector(vec2);
                                    Vector vecM = new Vector(m);

                                    if (n1.GetNorm() == 0 || n2.GetNorm() == 0)
                                        result.Text = "Введите ненулевую прямую";
                                    else
                                    {
                                        if (Math.Round(OperationsOnVectors.Mix(n1, n2, vecM), 3) == 0)
                                            //прямые параллельны
                                            writeDist(OperationsOnVectors.SubVector(vecM, n1).GetNorm() / n1.GetNorm());
                                        else
                                            //прямые скрещиваются
                                            writeDist(Math.Abs(OperationsOnVectors.Mix(vecM, n1, n2)) /
                                                OperationsOnVectors.SubVector(n1, n2).GetNorm());
                                    }
                                }
                            }
                            else if (radioButtonAngleDistLineSurExp.Checked)
                            {
                                if (textBoxGeometry46.Text == "" || textBoxGeometry47.Text == "" || textBoxGeometry48.Text == "" ||
                                    textBoxGeometry49.Text == "" || textBoxGeometry50.Text == "" || textBoxGeometry51.Text == "" ||
                                    textBoxGeometry52.Text == "" || textBoxGeometry53.Text == "" || textBoxGeometry54.Text == "" || textBoxGeometry55.Text == "")
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                else
                                {
                                    double[] vecS = { Convert.ToDouble(textBoxGeometry47.Text), Convert.ToDouble(textBoxGeometry48.Text), Convert.ToDouble(textBoxGeometry46.Text) };
                                    double[] vecN = { Convert.ToDouble(textBoxGeometry55.Text), Convert.ToDouble(textBoxGeometry54.Text), Convert.ToDouble(textBoxGeometry53.Text) };
                                    double[] m = { Convert.ToDouble(textBoxGeometry51.Text), Convert.ToDouble(textBoxGeometry50.Text), Convert.ToDouble(textBoxGeometry49.Text) };
                                    double D = Convert.ToDouble(textBoxGeometry52.Text);
                                    Vector s = new Vector(vecS);
                                    Vector n = new Vector(vecN);
                                    Vector M = new Vector(m);

                                    if (n.GetNorm() == 0 || s.GetNorm() == 0)
                                        result.Text = "Введите ненулевую прямую или плоскость";
                                    else
                                    {
                                        writeDist(Math.Abs(OperationsOnVectors.Scalar(n, M) + D) / n.GetNorm());
                                    }
                                }
                            }
                            else if (radioButtonAngleDist2SursExp.Checked)
                            {
                                if (textBoxGeometry34.Text == "" || textBoxGeometry35.Text == "" || textBoxGeometry32.Text == "" || textBoxGeometry33.Text == "" ||
                                    textBoxGeometry36.Text == "" || textBoxGeometry37.Text == "" || textBoxGeometry38.Text == "" || textBoxGeometry45.Text == "")
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                else
                                {
                                    double A1 = Convert.ToDouble(textBoxGeometry45.Text);
                                    double B1 = Convert.ToDouble(textBoxGeometry32.Text);
                                    double C1 = Convert.ToDouble(textBoxGeometry33.Text);
                                    double D1 = Convert.ToDouble(textBoxGeometry34.Text);
                                    double A2 = Convert.ToDouble(textBoxGeometry38.Text);
                                    double B2 = Convert.ToDouble(textBoxGeometry37.Text);
                                    double C2 = Convert.ToDouble(textBoxGeometry36.Text);
                                    double D2 = Convert.ToDouble(textBoxGeometry35.Text);

                                    double norm = Math.Sqrt(A1 * A1 + B1 * B1 + C1 * C1);
                                    if (norm == 0 || Math.Sqrt(A2 * A2 + B2 * B2 + C2 * C2) == 0)
                                        result.Text = "Введите ненулевую плоскость";
                                    else
                                    {
                                        double[] arr1 = { A1, B1, C1 };
                                        double[] arr2 = { A2, B2, C2 };
                                        if (arr1[0] != 0 && arr1[1] != 0 && arr1[2] != 0)
                                        {
                                            result.Text = dist2SursExp(arr1, arr2, D1, D2, norm);
                                        }
                                        else
                                        {
                                            int i = 0;
                                            for (; i < 3; ++i)
                                            {
                                                if (arr1[i] != 0)
                                                    break;
                                            }
                                            for (int j = 0; j < 3; ++j)
                                            {
                                                if (arr1[j] == 0 && arr1[j] == arr2[j])
                                                {
                                                    arr1[j] = arr1[i];
                                                    arr2[j] = arr2[i];
                                                }
                                            }
                                            result.Text = dist2SursExp(arr1, arr2, D1, D2, norm);
                                        }
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Выберете формат ввода", "Внимание!");
                        }
                        catch (FormatException) { HandlingException("Введите число с запятой"); }
                        break;
                    }
                case 9:
                    {
                        try
                        {
                            if (radioButtonScalarVectors.Checked)
                            {
                                if (textBoxGeometry95.Text == "" || textBoxGeometry96.Text == "" || textBoxGeometry94.Text == "" || textBoxGeometry92.Text == "")
                                {
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                    return;
                                }
                                else
                                {
                                    if (expance)
                                    {
                                        if (textBoxGeometry90.Text == "" || textBoxGeometry91.Text == "")
                                            MessageBox.Show("Введите параметры", "Внимание!");
                                        else
                                        {
                                            double[] arr1 = { Convert.ToDouble(textBoxGeometry96.Text), Convert.ToDouble(textBoxGeometry95.Text), Convert.ToDouble(textBoxGeometry90.Text) };
                                            double[] arr2 = { Convert.ToDouble(textBoxGeometry94.Text), Convert.ToDouble(textBoxGeometry92.Text), Convert.ToDouble(textBoxGeometry91.Text) };
                                            scalarVectors(arr1, arr2);
                                        }
                                    }
                                    else
                                    {
                                        double[] arr1 = { Convert.ToDouble(textBoxGeometry96.Text), Convert.ToDouble(textBoxGeometry95.Text) };
                                        double[] arr2 = { Convert.ToDouble(textBoxGeometry94.Text), Convert.ToDouble(textBoxGeometry92.Text) };
                                        scalarVectors(arr1, arr2);
                                    }
                                }
                            }
                            else if (radioButtonSubVector.Checked)
                            {
                                if (textBoxGeometry109.Text == "" || textBoxGeometry108.Text == "" || textBoxGeometry103.Text == "" ||
                                    textBoxGeometry99.Text == "" || textBoxGeometry98.Text == "" || textBoxGeometry107.Text == "")
                                {
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                    return;
                                }
                                else
                                {
                                    double[] arr1 = { Convert.ToDouble(textBoxGeometry109.Text), Convert.ToDouble(textBoxGeometry108.Text), Convert.ToDouble(textBoxGeometry107.Text) };
                                    double[] arr2 = { Convert.ToDouble(textBoxGeometry103.Text), Convert.ToDouble(textBoxGeometry99.Text), Convert.ToDouble(textBoxGeometry98.Text) };
                                    Vector n1 = new Vector(arr1);
                                    Vector n2 = new Vector(arr2);

                                    result.Text = "Векторное произведение: " + OperationsOnVectors.SubVector(n1, n2).ToString();
                                }
                            }
                            else if (radioButtonAngleVectors.Checked)
                            {
                                if (textBoxGeometry106.Text == "" || textBoxGeometry105.Text == "" || textBoxGeometry104.Text == "" || textBoxGeometry102.Text == "")
                                {
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                    return;
                                }
                                else
                                {
                                    if (expance)
                                    {
                                        if (textBoxGeometry100.Text == "" || textBoxGeometry101.Text == "")
                                            MessageBox.Show("Введите параметры", "Внимание!");
                                        else
                                        {
                                            double[] arr1 = { Convert.ToDouble(textBoxGeometry106.Text), Convert.ToDouble(textBoxGeometry105.Text), Convert.ToDouble(textBoxGeometry100.Text) };
                                            double[] arr2 = { Convert.ToDouble(textBoxGeometry104.Text), Convert.ToDouble(textBoxGeometry102.Text), Convert.ToDouble(textBoxGeometry101.Text) };
                                            angleVectors(arr1, arr2);
                                        }
                                    }
                                    else
                                    {
                                        double[] arr1 = { Convert.ToDouble(textBoxGeometry106.Text), Convert.ToDouble(textBoxGeometry105.Text) };
                                        double[] arr2 = { Convert.ToDouble(textBoxGeometry104.Text), Convert.ToDouble(textBoxGeometry102.Text) };
                                        angleVectors(arr1, arr2);
                                    }
                                }
                            }
                            else if (radioButtonMixVectors.Checked)
                            {
                                if (textBoxGeometry122.Text == "" || textBoxGeometry121.Text == "" || textBoxGeometry120.Text == "" ||
                                    textBoxGeometry118.Text == "" || textBoxGeometry117.Text == "" || textBoxGeometry116.Text == "" ||
                                    textBoxGeometry97.Text == "" || textBoxGeometry93.Text == "" || textBoxGeometry89.Text == "")
                                    MessageBox.Show("Введите параметры", "Внимание!");
                                else
                                {
                                    double[] arr1 = { Convert.ToDouble(textBoxGeometry122.Text), Convert.ToDouble(textBoxGeometry121.Text), Convert.ToDouble(textBoxGeometry120.Text) };
                                    double[] arr2 = { Convert.ToDouble(textBoxGeometry118.Text), Convert.ToDouble(textBoxGeometry117.Text), Convert.ToDouble(textBoxGeometry116.Text) };
                                    double[] arr3 = { Convert.ToDouble(textBoxGeometry97.Text), Convert.ToDouble(textBoxGeometry93.Text), Convert.ToDouble(textBoxGeometry89.Text) };

                                    Vector n1 = new Vector(arr1);
                                    Vector n2 = new Vector(arr2);
                                    Vector n3 = new Vector(arr3);

                                    result.Text = "Смешанное произведение: " + Math.Round(OperationsOnVectors.Mix(n1, n2, n3), 3).ToString();
                                }
                            }
                            else
                                MessageBox.Show("Выберете формат ввода", "Внимание!");
                        }
                        catch (FormatException) { HandlingException("Введите число с запятой"); }
                        break;
                    }
                default: break;
            }
        }

        private void radioButton3PointsSur_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3PointsSur.Checked)
            {
                groupBox3PointsSur.Enabled = true;
                groupBoxPointNormalSur.Enabled = false;
            }
        }

        private void radioButtonPointNormalSur_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPointNormalSur.Checked)
            {
                groupBoxPointNormalSur.Enabled = true;
                groupBox3PointsSur.Enabled = false;
            }
        }

        private void radioButtonAngle2LinesExp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAngleDist2LinesExp.Checked)
                groupBoxAngle2LinesExp.Enabled = true;
            else
                groupBoxAngle2LinesExp.Enabled = false;
        }

        private void radioButtonAngleLineSurExp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAngleDistLineSurExp.Checked)
                groupBoxAngleLineSurExp.Enabled = true;
            else
                groupBoxAngleLineSurExp.Enabled = false;
        }

        private void radioButtonAngle2SursExp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAngleDist2SursExp.Checked)
                groupBoxAngle2SursExp.Enabled = true;
            else
                groupBoxAngle2SursExp.Enabled = false;
        }

        private void radioButtonDistPointLineExp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDistPointLineExp.Checked)
            {
                groupBoxDistPointLineExp.Enabled = true;
                groupBoxDistPointSurExp.Enabled = false;
            }
        }

        private void radioButtonDistPointSurExp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDistPointSurExp.Checked)
            {
                groupBoxDistPointLineExp.Enabled = false;
                groupBoxDistPointSurExp.Enabled = true;
            }
        }

        private void buttonEquationTangent_Click(object sender, EventArgs e)
        {
            if (function.Text != "")
            {
                try
                {
                    if (textBoxGeometry72.Text == "")
                        MessageBox.Show("Введите x₀", "Внимание!");
                    else
                    {
                        const double h = 1e-10;
                        string func = function.Text.Replace(",", ".");
                        if (StringFunctionToDouble(1, func) == -99999999)
                        {
                            MessageBox.Show("Введите верную функцию", "Внимание!");
                            return;
                        }
                        double x0 = Convert.ToDouble(textBoxGeometry72.Text);
                        double y0 = Math.Round(StringFunctionToDouble(x0, func), 3);
                        double diffY = Math.Round((StringFunctionToDouble((x0 + h), func) - StringFunctionToDouble((x0 - h), func)) /
                                        (2.0 * h), 3);

                        string eqTangent = diffY.ToString() + "*x - " + (diffY * x0 - y0).ToString();
                        eqTangent = eqTangent.Replace(",", ".");
                        string f = "Уравнение касательной: y = " + eqTangent + "\n" +
                                      "Урванение нормали: y = " + Math.Round((-1 / diffY), 3).ToString() + "x - " +
                                       Math.Round((-(diffY * y0 + x0) / diffY), 3).ToString();

                        if (this.chart1.Series.FindByName("tangent") == null)
                        {
                            this.chart1.Series.Add("tangent");
                            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                            this.chart1.Series[1].Color = Color.Red;
                            this.chart1.Series[1].LegendText = "tangent";
                        }
                        else
                            this.chart1.Series[1].Points.Clear();
                        if (borderLeft.Text == "" || borderRight.Text == "" || step.Text == "")
                            DefaultParams();
                        else
                        {
                            a = Convert.ToDouble(borderLeft.Text);
                            b = Convert.ToDouble(borderRight.Text);
                            st = Convert.ToDouble(step.Text);

                            if (a >= b)
                            {
                                MessageBox.Show("Левая граница должна быть меньше правой", "Внимание!");
                                return;
                            }
                            if (st > Math.Abs(b - a))
                            {
                                MessageBox.Show("Введите шаг поменьше", "Внимание!");
                                return;
                            }
                        }

                        if (x0 > b)
                        {
                            b = x0;
                        }
                        else if (x0 < a)
                        {
                            a = x0;
                        }
                        else
                        {
                            if (x0 > (b + a) / 2)
                            {
                                b = 2 * x0 - a;
                            }
                            else if (x0 < (b + a) / 2)
                            {
                                a = 2 * x0 - b;
                            }
                        }
                        this.chart1.Series[0].Points.Clear();
                        ; for (double x = a; x <= b; x += st)
                        {
                            this.chart1.Series[0].Points.AddXY(x, StringFunctionToDouble(x, func));
                            this.chart1.Series[1].Points.AddXY(x, StringFunctionToDouble(x, eqTangent));
                        }

                        result.Text = f.Replace("- -", "+").Replace("+ -", "-");
                    }
                }
                catch (FormatException) { HandlingException("Введите число с запятой"); }
            }
            else
                MessageBox.Show("Введите функцию", "Внимание!");
        }

        private void radioButtonScalarVectors_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonScalarVectors.Checked)
                groupBoxScalarVectors.Enabled = true;
            else
                groupBoxScalarVectors.Enabled = false;
        }

        private void radioButtonSubVector_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSubVector.Checked)
                groupBoxSubVector.Enabled = true;
            else
                groupBoxSubVector.Enabled = false;
        }

        private void radioButtonAngleVectors_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAngleVectors.Checked)
                groupBoxAngleVectors.Enabled = true;
            else
                groupBoxAngleVectors.Enabled = false;
        }

        private void radioButtonMixVectors_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMixVectors.Checked)
                groupBoxMixVectors.Enabled = true;
            else
                groupBoxMixVectors.Enabled = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Точно хотите выйти?", "Выход!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DefaultParams()
        {
            a = -5;
            b = 5;
            st = 0.01;
        }
    }
}