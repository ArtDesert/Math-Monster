using System;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Теория_чисел
{
    public partial class GCDForm : Form
    {
        public GCDForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try 
            {
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                textBox3.Text = NumberTheory.GCD(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString();
            }
            catch (ArgumentException) { HandlingException("Некорректные аргументы"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
            catch (FormatException) { HandlingException("Введите целое число"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                textBox3.Text = NumberTheory.SCM(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString();
            }
            catch (ArgumentException) { HandlingException("Некорректные аргументы"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
            catch (FormatException) { HandlingException("Введите целое число"); }
        }

    }
}
