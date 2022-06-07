using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Алгебра_матриц
{
    public partial class OperationsForm : Form
    {
        private int size1, size2;

        public OperationsForm()
        {
            InitializeComponent();
            CreateMatrix();
            toolTip1.SetToolTip(btnInc1, "Увеличить размер");
            toolTip1.SetToolTip(btnInc2, "Увеличить размер");
            toolTip1.SetToolTip(btnDec1, "Уменьшить размер");
            toolTip1.SetToolTip(btnDec2, "Уменьшить размер");
            toolTip1.SetToolTip(btnClear1, "Очистить матрицу");
            toolTip1.SetToolTip(btnClear2, "Очистить матрицу");
        }

        private void CreateMatrix()
        {
            size1 = size2 = 2;

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
            dataGridView2.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            reader.src = Directory.GetCurrentDirectory() + "\\Algebra.pdf";
            reader.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (size2 != 1)
            {
                --size2;
                --dataGridView2.RowCount;
                --dataGridView2.ColumnCount;
                FillMatrix2();
                if (dataGridView3.Visible) dataGridView3.Visible = false;
            }
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (size1 != 1)
            {
                --size1;
                --dataGridView1.RowCount;
                --dataGridView1.ColumnCount;
                FillMatrix1();
                if (dataGridView3.Visible) dataGridView3.Visible = false;
            }
        }

        private void FillMatrix1()
        {
            double[,] arr = new double[size1, size1];
                for (int i = 0; i < size1; ++i)
                    for (int j = 0; j < size1; ++j)
                        dataGridView1.Rows[i].Cells[j].Value = 0;
        }

        private void FillMatrix2()
        {
            double[,] arr = new double[size2, size2];
            for (int i = 0; i < size2; ++i)
                for (int j = 0; j < size2; ++j)
                    dataGridView2.Rows[i].Cells[j].Value = 0;
        }
        private Matrix FillMatrixFromInput1()
        {
            double[,] arr = new double[size1, size1];
            for (int i = 0; i < size1; ++i)
                for (int j = 0; j < size1; ++j)
                    arr[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
            return new Matrix(arr);
        }

        private Matrix FillMatrixFromInput2()
        {
            double[,] arr = new double[size2, size2];
            try
            {
                for (int i = 0; i < size2; ++i)
                    for (int j = 0; j < size2; ++j)
                        arr[i, j] = Convert.ToDouble(dataGridView2.Rows[i].Cells[j].Value);
            }
            catch (ArgumentOutOfRangeException) { HandlingException("Некорректный ввод"); }
            catch (InvalidOperationException) { HandlingException("Некорректный ввод"); }
            return new Matrix(arr);
        }

        private void CreateAndFillResult(double[,] arr)
        {
            dataGridView3.RowCount = arr.GetLength(0);
            dataGridView3.ColumnCount = arr.GetLength(1);
            for (int i = 0; i < dataGridView3.RowCount; ++i)
                for (int j = 0; j < dataGridView3.ColumnCount; ++j)
                {
                    dataGridView3.Columns[i].Width = 50;
                    dataGridView3.Rows[i].Height = 40;
                    dataGridView3.Rows[i].Cells[j].Value = arr[i, j];
                }
            dataGridView3.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (size1 != 7)
            {
                ++size1;
                ++dataGridView1.RowCount;
                ++dataGridView1.ColumnCount;
                dataGridView1.Columns[size1 - 1].Width = 50;
                dataGridView1.Rows[size1 - 1].Height = 40;
                FillMatrix1();
                if (dataGridView3.Visible) dataGridView3.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (size2 != 7)
            {
                ++size2;
                ++dataGridView2.RowCount;
                ++dataGridView2.ColumnCount;
                dataGridView2.Columns[size2 - 1].Width = 50;
                dataGridView2.Rows[size2 - 1].Height = 40;
                FillMatrix2();
                if (dataGridView3.Visible) dataGridView3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillMatrix1();
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            try 
            {
                label5.Text = String.Empty;
                label5.Text = ((Button)sender).Text;
                CreateAndFillResult(Matrix.Sum(FillMatrixFromInput1(), FillMatrixFromInput2()).arr);
                dataGridView3.Visible = true;
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком маленькое или слишком большое число"); }
            catch (InvalidOperationException) { HandlingException("Некорректный ввод"); }
            catch (ArgumentOutOfRangeException) { HandlingException("Некорректный ввод"); }
            catch (MatrixException) { HandlingException("Матрицы разных размеров"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label5.Text = String.Empty;
                label5.Text = ((Button)sender).Text;
                CreateAndFillResult(Matrix.Diff(FillMatrixFromInput1(), FillMatrixFromInput2()).arr);
                dataGridView3.Visible = true;
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком маленькое или слишком большое число"); }
            catch (InvalidOperationException) { HandlingException("Некорректный ввод"); }
            catch (ArgumentOutOfRangeException) { HandlingException("Некорректный ввод"); }
            catch (MatrixException) { HandlingException("Матрицы разных размеров"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label5.Text = String.Empty;
                label5.Text = ((Button)sender).Text;
                CreateAndFillResult(Matrix.Mult(FillMatrixFromInput1(), FillMatrixFromInput2()).arr);
                dataGridView3.Visible = true;
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Слишком маленькое или слишком большое число"); }
            catch (InvalidOperationException) { HandlingException("Некорректный ввод"); }
            catch (ArgumentOutOfRangeException) { HandlingException("Некорректный ввод"); }
            catch (MatrixException) { HandlingException("Матрицы разных размеров"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FillMatrix2();
        }
    }
}
