using System;
using System.Windows.Forms;
using static Professional_GUI.Algebra.NumberTheory;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Теория_чисел
{
    public partial class DivisorsForm : Form
    {
        public DivisorsForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try 
            {
                label2.Text = string.Empty;
                label2.Text = ((Button)sender).Text;
                textBox2.Text = CountOfDivisors(Convert.ToUInt32(textBox1.Text)).ToString();
            }
            catch (ArgumentException) { HandlingException("Делителей нет"); }
            catch (OverflowException) { HandlingException("Введите положительное число"); }
            catch (FormatException) { HandlingException("Введите положительное число"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Text = string.Empty;
                label2.Text = ((Button)sender).Text;
                string str = string.Empty;
                var list = PrimeFactorization(Convert.ToUInt32(textBox1.Text));
                foreach (Number num in list) str += num.value.ToString() + "^" + num.deg.ToString() + " * ";
                str = str.Remove(str.Length - 1);
                str = str.Remove(str.Length - 1);
                textBox2.Text = str;
            }
            catch (ArgumentException) { HandlingException("Единицу или ноль нельзя разложить на простые множители"); }
            catch (OverflowException) { HandlingException("Введите положительное число"); }
            catch (FormatException) { HandlingException("Введите положительное число"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
