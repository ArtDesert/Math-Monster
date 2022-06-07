using System;
using System.Drawing;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Комплексные_числа
{
    public partial class ComplexRootsForm : Form
    {
        public ComplexRootsForm()
        {
            InitializeComponent();
            HideResult();
        }

        private void HideResult()
        {
            if(textBox3.Visible) textBox3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                textBox3.Text = String.Empty;
                var c = new Complex(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                int n = Convert.ToInt32(textBox5.Text);
                var roots = c.Roots(n);
                textBox3.Size = new Size(textBox3.Size.Width, 24 * n);
                for (int i = 0; i < n; ++i) textBox3.Text += "(" + (i + 1).ToString() + ") " + roots[i].Round().ToString() + "\r\n";
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
            catch (IllegalArgumentException) { HandlingException("Степень должна быть целым положительным числом"); }
            catch (ArithmeticException) { HandlingException("Корней не существует"); }
        }
    }
}
