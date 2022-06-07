using System;
using System.Windows.Forms;
using static Professional_GUI.Algebra.NumberTheory;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Теория_чисел
{
    public partial class ChainedForm : Form
    {
        public ChainedForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                var res = RationalToContinuedFraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                string str = "[ ";
                str += res[0].ToString() + "; ";
                for (int i = 1; i < res.Count; ++i) str += res[i].ToString() + ", ";
                str += "]";
                textResult.Text = str;
            }
            catch (ArgumentException) { HandlingException("Введите ненулевой знаменатель"); }
            catch (OverflowException) { HandlingException("Слишком большое число"); }
            catch (FormatException) { HandlingException("Введите целое число"); }
        }

        private void ChainedForm_Load(object sender, EventArgs e)
        {

        }
    }
}
