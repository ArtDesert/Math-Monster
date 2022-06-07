using System;
using System.IO;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI
{
    public partial class FormAlgebraPolynom : Form
    {
        private int mode = 0; // 0 - арифметческие операции, 1 - поиск корней

        public FormAlgebraPolynom()
        {
            InitializeComponent();
            reader.src = Directory.GetCurrentDirectory() + "\\arithOperations.pdf";
            reader.Visible = false;
        }

        private void btnOperationsPolynom_Click(object sender, EventArgs e)
        {
            mode = 0;
            panelOperationsPolynom.Visible = true;
            labelTopicPolynom.Text = "Операции c полиномами.";
            reader.src = Directory.GetCurrentDirectory() + "\\arithOperations.pdf";
        }

        private void btnRootsPolynom_Click(object sender, EventArgs e)
        {
            mode = 1;
            panelOperationsPolynom.Visible = false;
            labelTopicPolynom.Text = "Поиск корней полинома (2, 3, 4 степени).";
            reader.src = Directory.GetCurrentDirectory() + "\\findRoots.pdf";
        }

        private double inCoef(string str)
        {
                return str == "" ? 0 : Convert.ToDouble(str);
        }

        private int determDegree(double[] coefs)
        {
            int degree = -1;
            for (int i = 0; i<7; ++i)
                if (coefs[i] != 0)
                {
                    degree = 6-i;
                    break;
                }
            return degree;
        }

        private Polynom createPolynom(double a0, double a1, double a2, double a3, double a4, double a5, double a6)
        {
            double[] coefs = { a0, a1, a2, a3, a4, a5, a6 };
            int degree = determDegree(coefs);

            if (degree == -1)
            {
                MessageBox.Show("Введите ненулевой полином", "Внимание!");
                return null;
            }
            double[] arr = new double[degree+1];
            for (int i = 0; i<=degree; ++i)
                arr[i] = coefs[6-degree+i];
            return new Polynom(arr, degree);
        }

        private void buttonSolvePolynom_Click(object sender, EventArgs e)
        {
            try
            {
                Polynom poly1 = createPolynom(inCoef(textBoxPolynom1.Text), inCoef(textBoxPolynom2.Text), inCoef(textBoxPolynom3.Text), inCoef(textBoxPolynom4.Text),
                                                          inCoef(textBoxPolynom5.Text), inCoef(textBoxPolynom6.Text), inCoef(textBoxPolynom7.Text));
                if (poly1 == null) return;

                switch (mode)
                {
                    case 0:
                        {
                            Polynom poly2 = createPolynom(inCoef(textBoxPolynom8.Text), inCoef(textBoxPolynom9.Text), inCoef(textBoxPolynom10.Text), inCoef(textBoxPolynom11.Text),
                                              inCoef(textBoxPolynom12.Text), inCoef(textBoxPolynom13.Text), inCoef(textBoxPolynom14.Text));
                            if (poly2 == null) return;
                            switch (comboBoxOperationsPolynom.Text)
                            {
                                case "+":
                                    {
                                        labelResultPolynom.Text = (poly1 + poly2).ToString().Replace("+ -", "- ").Replace(" 1x", " x");
                                        break;
                                    }
                                case "-":
                                    {
                                        labelResultPolynom.Text = (poly1-poly2).ToString().Replace("+ -", "- ").Replace(" 1x", " x").Replace("+ -", "- ");
                                        break;
                                    }
                                case "×":
                                    {
                                        labelResultPolynom.Text = (poly1*poly2).ToString().Replace("+ -", "- ").Replace(" 1x", " x").Replace("+ -", "- ");
                                        break;
                                    }
                                case "÷":
                                    {
                                        double[] quotient;
                                        double[] remainder;

                                        OperationsOnPolinoms.Div(poly1, poly2, out quotient, out remainder);

                                        Polynom polyQ = new Polynom(quotient, quotient.Length-1);
                                        Polynom polyRem = new Polynom(remainder, remainder.Length-1);

                                        labelResultPolynom.Text = ("Частное: " + polyQ +'\n'+"Остаток: " + polyRem).Replace("+ -", "- ").Replace(" 1x", " x").Replace("+ -", "- ");
                                        break;
                                    }
                                case "НОД":
                                    {
                                        Polynom polyRes = OperationsOnPolinoms.Gcd(poly1, poly2);
                                        labelResultPolynom.Text = "НОД: "+((polyRes.degree == 0) ? "1" : polyRes.ToString().Replace("+ -", "- ").Replace(" 1x", " x").Replace("+ -", "- "));
                                        break;
                                    }
                                case "НОК":
                                    {
                                        double[] quotient;
                                        double[] remainder;
                                        OperationsOnPolinoms.Div((poly1 * poly2), OperationsOnPolinoms.Gcd(poly1, poly2), out quotient, out remainder);
                                        Polynom polyNOK = new Polynom(quotient, quotient.Length - 1);
                                        labelResultPolynom.Text = "НОК: " + polyNOK.ToString().Replace("+ -", "- ").Replace(" 1x", " x").Replace("+ -", "- ");
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Выберите операцию", "Внимание!");
                                        break;
                                    }
                            }

                            break;
                        }
                    case 1:
                        {
                            double[] roots;
                            switch (poly1.degree)
                            {
                                case 2:
                                    {
                                        roots = poly1.rootsSec();
                                        labelResultPolynom.Text = (roots == null) ? "Нет корней" :
                                                 poly1+"\n"+"x₁: " + Math.Round(roots[0], 3)+'\n'+"x₂: "+roots[1];
                                        break;
                                    }
                                case 3:
                                    {
                                        roots = poly1.Cardano();
                                        labelResultPolynom.Text = (roots == null) ? "Нет корней" :
                                                poly1+"\n"+"x₁: " + roots[0]+'\n'+"x₂: "+roots[1]+'\n'+"x₃: "+roots[2];
                                        break;
                                    }
                                case 4:
                                    {
                                        roots = poly1.Ferr();
                                        labelResultPolynom.Text = (roots == null) ? "Нет корней" :
                                                poly1+"\n"+"x₁: " + Math.Round(roots[0], 3)+'\n'+"x₂: "+Math.Round(roots[1], 3)+'\n'+
                                                "x₃: " + Math.Round(roots[2], 3)+'\n'+"x₄: "+Math.Round(roots[3], 3);

                                        break;
                                    }
                                default:
                                    {
                                        labelResultPolynom.Text = "полином должен быть 2, 3 или 4 степени";
                                        break;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Попробуйте ещё раз", "Ошибка!");
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                HandlingException("Введите число с запятой");
            }
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    }
}