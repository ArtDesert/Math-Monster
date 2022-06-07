using System;
using System.Drawing;
using System.Windows.Forms;
using static Professional_GUI.Algebra;
using static Professional_GUI.HandlingExceptions;

namespace Professional_GUI.Формы.Алгебра.Алгебра_матриц
{
    public partial class LUQRForm : Form
    {
        private int size;
        public LUQRForm()
        {
            InitializeComponent();
            CreateMatrix();
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
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = 0;
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
            dataGridView2.Visible = false;
            dataGridView2.DefaultCellStyle.Font = new Font("Tasoma", 10);
            dataGridView3.RowCount = 2;
            dataGridView3.ColumnCount = 2;
            for (int i = 0; i < 2; ++i)
            {
                dataGridView3.Columns[i].Width = 50;
                dataGridView3.Rows[i].Height = 40;
                for (int j = 0; j < 2; ++j) dataGridView3.Rows[i].Cells[j].Value = 0;
            }
            dataGridView3.Visible = false;
            dataGridView3.DefaultCellStyle.Font = new Font("Tasoma", 10);
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            if (size != 7)
            {
                ++size;
                ++dataGridView1.RowCount;
                ++dataGridView1.ColumnCount;
                dataGridView1.Columns[size - 1].Width = 50;
                dataGridView1.Rows[size - 1].Height = 40;
                ++dataGridView2.RowCount;
                ++dataGridView2.ColumnCount;
                dataGridView2.Columns[size - 1].Width = 50;
                dataGridView2.Rows[size - 1].Height = 40;
                ++dataGridView3.RowCount;
                ++dataGridView3.ColumnCount;
                dataGridView3.Columns[size - 1].Width = 50;
                dataGridView3.Rows[size - 1].Height = 40;
                FillMatrix();
                if (dataGridView2.Visible) dataGridView2.Visible = false;
                if (dataGridView3.Visible) dataGridView3.Visible = false;
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
                --dataGridView3.RowCount;
                --dataGridView3.ColumnCount;
                FillMatrix();
                if (dataGridView2.Visible) dataGridView2.Visible = false;
                if (dataGridView3.Visible) dataGridView3.Visible = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                    dataGridView2.Rows[i].Cells[j].Value = 0;
                    dataGridView3.Rows[i].Cells[j].Value = 0;
                }
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
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

        private void button4_Click(object sender, EventArgs e)
        {

            try 
            {
                var m = FillMatrixFromInput();
                var LU = m.LUFactorization();
                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = LU[0].arr[i, j];
                        dataGridView3.Rows[i].Cells[j].Value = LU[1].arr[i, j];
                    }
                if (!dataGridView2.Visible) dataGridView2.Visible = true;
                if (!dataGridView3.Visible) dataGridView3.Visible = true;
                label3.Text = ((Button)sender).Text;
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
            catch (MatrixException) { HandlingException("LU-разложения не существует, так как матрица вырождена"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var m = FillMatrixFromInput();
                var QR = m.QRFactorization();
                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = QR[0].arr[i, j];
                        dataGridView3.Rows[i].Cells[j].Value = QR[1].arr[i, j];
                    }
                if (!dataGridView2.Visible) dataGridView2.Visible = true;
                if (!dataGridView3.Visible) dataGridView3.Visible = true;
                label3.Text = ((Button)sender).Text;
            }
            catch (FormatException) { HandlingException("Введите число с запятой"); }
            catch (OverflowException) { HandlingException("Cлишком маленькое или слишком большое число"); }
            catch (MatrixException) { HandlingException("QR-разложения не существует, так как матрица вырождена"); }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
