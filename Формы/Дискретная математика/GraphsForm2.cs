using System;
using System.Windows.Forms;

namespace Professional_GUI
{
    public partial class GraphsForm2 : Form
    {
        private bool lastPressOK;
        public GraphsForm2()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
                lastPressOK = false;
        else
            lastPressOK = true;
            this.Close();
        }

        public bool getLastPressBut() {
            return lastPressOK;
        }

        public double getDig() {

            return Convert.ToDouble(this.textBox1.Text);
        }

        public string getStrTxtBox() {
            return textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastPressOK = false;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 44&& e.KeyChar==45 && e.KeyChar==32)
                e.Handled = true;
        }

        public void setTxtLable(string str) {
            label1.Text = str;
        }
    }
}
