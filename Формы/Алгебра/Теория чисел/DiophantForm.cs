using System;
using System.IO;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Теория_чисел
{
    public partial class DiophantForm : Form
    {
        public DiophantForm()
        {
            InitializeComponent();
            reader.src = Directory.GetCurrentDirectory() + "\\Number.pdf";
            reader.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = string.Empty;
                textBox4.Text = NumberTheory.DiophantineEquation(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
            catch (FormatException) { HandlingException("Введите целое число"); }
            catch (ArgumentException) { HandlingException("Введите ненулевые целые числа"); }

        }
    }
}
