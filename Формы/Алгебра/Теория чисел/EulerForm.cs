using System;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Теория_чисел
{

    public partial class EulerForm : Form
    {
        public EulerForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = NumberTheory.EulerFunction(Convert.ToUInt32(textBox1.Text)).ToString();
            }
            catch (FormatException)
            {
                HandlingException("Введите целое положительное число");
            }
            catch (OverflowException)
            {
                HandlingException("Слишком маленькое или слишком большое число");
            }
            catch (ArgumentException)
            {
                HandlingException("Введите целое положительное число");
            }

        }
    }
}
