using System;
using System.Drawing;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Алгебра_матриц
{
    public partial class MainCharMatrixForm : Form
    {
        private int size;
        public MainCharMatrixForm()
        {
            InitializeComponent();
            CreateMatrix();
        }

        private void CreateMatrix()
        {
            size = 2;
            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 2;
            for (int i = 0; i < 2; ++i)
            {
                dataGridView1.Columns[i].Width = 50;
                dataGridView1.Rows[i].Height = 40;
                for (int j = 0; j < 2; ++j) dataGridView1.Rows[i].Cells[j].Value = 0;
            }
            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dataGridView2.RowCount = 2;
            dataGridView2.ColumnCount = 2;
            for (int i = 0; i < 2; ++i)
            {
                dataGridView2.Columns[i].Width = 50;
                dataGridView2.Rows[i].Height = 40;
                for (int j = 0; j < 2; ++j) dataGridView2.Rows[i].Cells[j].Value = 0;
            }
            dataGridView2.DefaultCellStyle.Font = new Font("Tasoma", 10);
            dataGridView2.Visible = false;
            textResult.Visible = false;
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            if (size != 7)
            {
                ++size;
                ++dataGridView1.RowCount;
                ++dataGridView1.ColumnCount;
                dataGridView1.Columns[size - 1].Width = 50;
                dataGridView1.Rows[size-1].Height = 40;
                ++dataGridView2.RowCount;
                ++dataGridView2.ColumnCount;
                dataGridView2.Columns[size - 1].Width = 50;
                dataGridView2.Rows[size - 1].Height = 40;
                FillMatrix();
                if (dataGridView2.Visible) dataGridView2.Visible = false;
            }
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            if (size != 1)
            {
                --size;
                --dataGridView1.RowCount;
                --dataGridView1.ColumnCount;
                --dataGridView2.RowCount;
                --dataGridView2.ColumnCount;
                FillMatrix();
                if (dataGridView2.Visible) dataGridView2.Visible = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                    dataGridView2.Rows[i].Cells[j].Value = 0;
                    dataGridView2.Visible = false;
                }   
        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    if (i == j) dataGridView1.Rows[i].Cells[j].Value = 1;
                    else dataGridView1.Rows[i].Cells[j].Value = 0;
                }
        }

        private Matrix FillMatrixFromInput()
        {
            double[,] arr = new double[size, size];

                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                        arr[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
            return new Matrix(arr);
        }

        private void FillMatrix()
        {
            double[,] arr = new double[size, size];
            try
            {
                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                        dataGridView1.Rows[i].Cells[j].Value = 0;
            } 
            catch (ArgumentOutOfRangeException) { HandlingException("Некорректный ввод"); }
            catch (InvalidOperationException) { HandlingException("Некорректный ввод"); }
        }

        private void FillResult(double[,] arr)
        {
            try
            {
                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                        dataGridView2.Rows[i].Cells[j].Value = arr[i, j];
            }
            catch (ArgumentOutOfRangeException) { HandlingException("Некорректный ввод"); }
            catch (InvalidOperationException) { HandlingException("Некорректный ввод"); }
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                var m = FillMatrixFromInput();
                textResult.Text = Matrix.Det(m).ToString();
                HideAndOpenText();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                var m = FillMatrixFromInput();
                textResult.Text = (m.GaussRank()).ToString();
                HideAndOpenText();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
        }

        private void HideAndOpenText()
        {
            if (!textResult.Visible) textResult.Visible = true;
            if (dataGridView2.Visible) dataGridView2.Visible = false;
        }

        private void HideAndOpenBlock()
        {
            if (textResult.Visible) textResult.Visible = false;
            if (!dataGridView2.Visible) dataGridView2.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                if (textResult.Text != String.Empty) textResult.Text = String.Empty;
                FillResult(FillMatrixFromInput().Inverse().arr);
                HideAndOpenBlock();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
            catch (MatrixException) { HandlingException("Матрица необратима"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = String.Empty;
                if (textResult.Text != String.Empty) textResult.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                var m = FillMatrixFromInput();
                m.GaussStepwise();
                FillResult(m.arr);
                HideAndOpenBlock();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                var m = FillMatrixFromInput();
                bool IsPos = m.IsPositivelyDefined(), IsNeg = m.IsNegativelyDefined();
                if (IsPos) textResult.Text = "Матрица положительно определена";
                else if (IsNeg) textResult.Text = "Матрица отрицательно определена";
                else textResult.Text = "Матрица не является ни положительно, ни отрицательно определённой";
                HideAndOpenText();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text;
                FillResult(FillMatrixFromInput().Transpose().arr);
                HideAndOpenBlock();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int deg = Convert.ToInt32(textDeg.Text);
                FillResult(FillMatrixFromInput().Deg(deg).arr);
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text + " " + deg.ToString();
                HideAndOpenBlock();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
            catch (IllegalArgumentException) { HandlingException("Степень должна быть целым положительным числом"); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try 
            {
                double value = Convert.ToDouble(textValue.Text);
                FillResult(FillMatrixFromInput().MultByScalar(value).arr);
                label3.Text = String.Empty;
                label3.Text += ((Button)sender).Text + " " + value.ToString();
                HideAndOpenBlock();
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком большое или слишком маленькое число"); }
        }
    }
}
