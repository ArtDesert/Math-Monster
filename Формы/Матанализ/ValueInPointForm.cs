using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace Professional_GUI
{
    public partial class ValueInPointForm : Form
    {
        public ValueInPointForm()
        {
            InitializeComponent();
            reader.src = Directory.GetCurrentDirectory() + "\\Funktsia_Vtochke.pdf";
            reader.Visible = false;
        }
        List<string> operations = new List<string> { "+", "-", "*", "/", "^", "(", ")"};
        /// <summary>
        /// Метод, реализующий нахождение значения функции в точке, сперва реализующий подстановку числа вместо переменной x
        /// </summary>
        public static double StringFunctionToDouble(double x, string s)
        {
            string specifier = "G";
            if (s == "x")
                s = s.Replace("x", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            if(s[0] == '-')
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
        /// <summary>
        /// Нахождение значении функции в точке производится с помощью класса CalcScript, которому мы подаём на вход преобразованную в выражение функцию.
        /// Фактически, CalcScript это и есть обыкновенный калькулятор, куда мы без него!)
        /// </summary>
        private void Calculate_Click(object sender, EventArgs e)
        {
            string res;
            if (FunctionTextBox.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели часть требуемых данных", "Ошибка");
                res = "Input error";
                goto to_end;
            }
            //Int64 n = 1000; //Количество частей, на которые делим отрезок
            string S = FunctionTextBox.Text;
            string specifier = "G";
            textBox1.Text = textBox1.Text.Replace("π", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox1.Text = textBox1.Text.Replace("pi", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox1.Text = textBox1.Text.Replace("Pi", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox1.Text = textBox1.Text.Replace(".", ",");
            double x;
            try { 
            x = double.Parse(textBox1.Text); 
            }
            catch (Exception) {
                MessageBox.Show("Введите корректные данные!");
                res = "Input error";
                goto to_end;
            }

            double tmp = StringFunctionToDouble(x, S);

            if (tmp == -99999999)
            {
                res = "Input error";
                goto to_end;
            }

            res = tmp.ToString();
        to_end:
            DiffTextBox.Visible = true;
            label2.Visible = true;
            DiffTextBox.Text = res;
        }
        /// <summary>
        /// Реализация интерфейса панели ввода данных
        /// </summary>
        private void X_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "x";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*x";
            }
            else
                FunctionTextBox.Text += "x";
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "7";
        }

        private void Four_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "4";
        }

        private void One_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "1";
        }

        private void Opening_parenthesis_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "(";
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "8";
        }

        private void Five_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "5";
        }

        private void Two_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "2";
        }

        private void Closing_parenthesis_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += ")";
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "9";
        }

        private void Six_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "6";
        }

        private void Three_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "3";
        }

        private void Div_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "/";
        }

        private void Mul_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "*";
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "-";
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "+";
        }

        private void Exponentiation_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "^";
        }

        private void Ln_Click(object sender, EventArgs e)
        {
            if(FunctionTextBox.Text =="")
            FunctionTextBox.Text += "ln(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*ln(";
            }
            else
                FunctionTextBox.Text += "ln(";

        }

        private void Lg_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "lg(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*lg(";
            }
            else
                FunctionTextBox.Text += "lg(";
        }

        private void Sinus_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "sin(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*sin(";
            }
            else
                FunctionTextBox.Text += "sin(";
        }

        private void Cosinus_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "cos(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*cos(";
            }
            else
                FunctionTextBox.Text += "cos(";
        }

        private void Tg_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "tg(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*tg(";
            }
            else
                FunctionTextBox.Text += "tg(";
        }

        private void Ctg_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "ctg(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*ctg(";
            }
            else
                FunctionTextBox.Text += "ctg(";
        }

       
        private void Delete_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            FunctionTextBox.Text = "";
            DiffTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(FunctionTextBox.Text == "")
            {

            }
            else
            {
                FunctionTextBox.Text = FunctionTextBox.Text.Substring(0, FunctionTextBox.Text.Length - 1);
            }
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "0";
        }

        private void Point_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "";
            else if (Char.IsDigit(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1]))
            {
                FunctionTextBox.Text += ",";
            }
            else
                FunctionTextBox.Text += "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "π";
            else if (Char.IsDigit(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1]))
            {
                FunctionTextBox.Text += "*π";
            }
            else
                FunctionTextBox.Text += "π"; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate.Visible = true;
        }

    }
}