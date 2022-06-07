using System;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Комплексные_числа
{
    public partial class ComplexModForm : Form
    {
        public ComplexModForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                var c = new Complex(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                textBox5.Text = c.Mod().ToString();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
        }
    }
}
