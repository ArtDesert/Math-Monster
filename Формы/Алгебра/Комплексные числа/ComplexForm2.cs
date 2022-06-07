using System;
using System.IO;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Комплексные_числа
{
    public partial class ComplexForm2 : Form
    {
        public ComplexForm2()
        {
            InitializeComponent();
            reader.src = Directory.GetCurrentDirectory() + "\\Complex.pdf";
            reader.Visible = false;
        }

        private Complex[] CreateComplexPair(object sender)
        {
            lblResult.Text = String.Empty;
            lblResult.Text = ((Button)sender).Text;
            Complex c1 = new Complex(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            Complex c2 = new Complex(Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox3.Text));
            return new Complex[] { c1, c2 };
        }
        private void BtnResult_Click(object sender, EventArgs e)
        {
            try 
            {
                var c = CreateComplexPair(sender);
                var res = c[0].Sum(c[1]);
                textBox5.Text = res.Round().ToString();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var c = CreateComplexPair(sender);
                var res = c[0].Diff(c[1]);
                textBox5.Text = res.Round().ToString();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                var c = CreateComplexPair(sender);
                var res = c[0].Mult(c[1]);
                textBox5.Text = res.Round().ToString();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
                var c = CreateComplexPair(sender);
                var res = c[0].Div(c[1]);
                textBox5.Text = res.Round().ToString();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
            catch (ArithmeticException) { HandlingException("Деление невозможно"); }
        }
    }
}
