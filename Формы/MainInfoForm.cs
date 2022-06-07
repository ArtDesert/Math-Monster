using System;
using System.IO;
using System.Windows.Forms;

namespace Professional_GUI.Формы
{
    public partial class MainInfoForm : Form
    {
        public MainInfoForm()
        {
            InitializeComponent();
            reader.src = Directory.GetCurrentDirectory() + "\\Info.pdf";
            //reader.Visible = true;
        }

        private void reader_Enter(object sender, EventArgs e)
        {

        }
    }
}
