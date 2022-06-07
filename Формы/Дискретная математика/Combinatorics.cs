using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Numerics;

namespace Professional_GUI.Формы.Дискретная_математика
{
    public partial class Combinatorics : Form
    {
        private Button currentButton;
        private Color color = Color.FromArgb(107, 73, 143);
        private Color colorForChild = ThemeColor.ChangeColorBrightness(Color.FromArgb(107, 73, 143), -0.5);
        public Combinatorics()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Width = 21;
            dataGridView1.Rows[0].Height = 41;
            reader.Visible = false;
            reader.src = Directory.GetCurrentDirectory() + "\\Kombinatorika_compressed.pdf";
        }


        private void ActiveButton(Object btnSender)
        {
            zeroingTxtsBox();
            if (btnSender != null)
            {
                hideSubPanels();
                DisableButton();
                currentButton = (Button)btnSender;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            }
        }


        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls){
                if (previousBtn.GetType() == typeof(Button)) {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 60);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }

        private void DisableButtonForChild(Panel panel)
        {
            foreach (Control previousBtn in panel.Controls)
            {
                if (previousBtn.GetType() == typeof(myButton))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 60);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }
        private void ActiveButtonForChild(Object btnSender)
        {
            zeroingTxtsBox();
            zeroingPresses();
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButtonForChild(((Button)btnSender).Parent as Panel);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = colorForChild;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }
        private void hideSubPanels() {
            panelAccommodation.Visible = false;
            panelCombinations.Visible = false;
            panelPermutations.Visible = false;
        }

        private void zeroingTxtsBox() {
            textBoxCombs.Text = "";
            textBoxPP.Text = "";
            textBoxPwith.Text = "";
        }

        private void combinations_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelCombinations.Visible = true;
        }

        private void combinationsWithRepetitions_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            panelForPermutationsWithoutRelations.Visible = false;
            panelForPermutationsWithRelations.Visible = false;
            panelForCombinations.Visible = true;
            combinationsWithRepetitions.setState();
            label1.Text = "С =";
        }

        private void combinationsWithoutRepetitions_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            panelForPermutationsWithoutRelations.Visible = false;
            panelForPermutationsWithRelations.Visible = false;
            panelForCombinations.Visible = true;
            combinationsWithoutRepetitions.setState();
            label1.Text = "С =";
        }

        private void accommodation_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelAccommodation.Visible = true;
        }

        private void accommodationWithoutRelations_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            panelForPermutationsWithoutRelations.Visible = false;
            panelForPermutationsWithRelations.Visible = false;
            accommodationWithoutRelations.setState();
            panelForCombinations.Visible = true;
            label1.Text = "A =";
        }

        private void accommodationWithRelations_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            panelForPermutationsWithoutRelations.Visible = false;
            panelForPermutationsWithRelations.Visible = false;
            accommodationWithRelations.setState();
            panelForCombinations.Visible = true;
            label1.Text = "A =";
        }

        private void permutations_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelPermutations.Visible = true;
        }

        private void permutationsWithoutRelations_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            panelForCombinations.Visible=false;
            panelForPermutationsWithRelations.Visible = false;
            panelForPermutationsWithoutRelations.Visible = true;
            permutationsWithoutRelations.setState();
        }

        private void permutationsWithRelations_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            panelForCombinations.Visible = false;
            panelForPermutationsWithoutRelations.Visible = false;
            panelForPermutationsWithRelations.Visible = true;
            permutationsWithRelations.setState();
        }

        private void zeroingPresses() {
            combinationsWithoutRepetitions.setState(false);
            combinationsWithRepetitions.setState(false);
            accommodationWithoutRelations.setState(false);
            accommodationWithRelations.setState(false);
            permutationsWithoutRelations.setState(false);
            permutationsWithRelations.setState(false);
        }

        //using System.Numerics;



        private BigInteger parseCheck(string str)
    {
        BigInteger n;
        if (BigInteger.TryParse(str, out n))
            return n;
        return -1;
    }
    private BigInteger P(BigInteger k)
    {
        if (k > 9000)
            return -1;
        if (k == 0)
            return (1);
        else
        {
            BigInteger res = new BigInteger(1);
            for (int i = 1; i <= k; i++)
            {
                res *= i;
            }
            return res;
        }

    }

    private BigInteger Aalt(BigInteger n, BigInteger k)
    {
        var res = n;
        BigInteger t = P(9000);
        for (int i = 1; i < k; i++)
        {
                res *= n;
                if (res > t)
                return -1;
        }
        return res;
    }
    private BigInteger A(BigInteger n, BigInteger k)
    {
        BigInteger t = P(9000);
        if (k > n)
            return 0;
        BigInteger res = 1;
        for (BigInteger i = n; i > n - k; --i)
        {
            res *= i;
            if (res > t)
                return -1;
        }
        return res;
    }

    private BigInteger Calt(BigInteger n, BigInteger k)
    {

        return C(n + k - 1, k);
    }
    private BigInteger C(BigInteger n, BigInteger k)
    {
        if (k > n)
            return 0;
        BigInteger p = P(k), a = A(n, k);

        if (p != -1 && a != -1)
            return a / p;
        return -1;

    }
    private BigInteger Palt(BigInteger[] K)
    {
        BigInteger sum = 0;
        for (int i = 0; i < K.Length; i++)
            sum += K[i];
        BigInteger res = P(sum);
        BigInteger t = P(9000);
        for (int i = 0; i < K.Length; ++i)
        {
            res /= P(K[i]);
            if (res < 0 || res > t)//??
                return -1;
        }
        return res;
    }

    private BigInteger[] parseGrid()
    {
        BigInteger[] mas = new BigInteger[dataGridView1.ColumnCount];
        for (int i = 0; i < dataGridView1.ColumnCount; ++i)
        {
            BigInteger hlp = parseCheck(Convert.ToString(dataGridView1.Rows[0].Cells[i].Value));
            if (hlp == int.MinValue || hlp <= 0)
                return null;
            else
                mas[i] = parseCheck(Convert.ToString(dataGridView1.Rows[0].Cells[i].Value));
        }
        return mas;
    }
    private void buttonSolve_Click(object sender, EventArgs e)
    {
        if (combinationsWithoutRepetitions.getState())
        {
            BigInteger n = parseCheck(textBoxCN.Text);
            BigInteger m = parseCheck(textBoxCM.Text);
            if (n >= m && n > 0 && m > 0)
            {//вывод сообщения о ошибке
                if (n != int.MinValue && n != int.MaxValue)
                {
                    BigInteger hlp = Calt(n, m);
                    if (hlp != -1)
                        textBoxCombs.Text = Convert.ToString(hlp);
                    else
                        textBoxCombs.Text = "Слишком большое число";
                }
            }
            else
                textBoxCombs.Text = "Ошибка";
        }
        if (combinationsWithRepetitions.getState())
        {
            BigInteger n = parseCheck(textBoxCN.Text);
            BigInteger m = parseCheck(textBoxCM.Text);
            if (n >= m && n > 0 && m > 0)
            {//вывод сообщения о ошибке
                BigInteger hlp = C(n, m);
                if (hlp != -1)
                    textBoxCombs.Text = Convert.ToString(hlp);
                else
                    textBoxCombs.Text = "Слишком большое число";
            }
            else
                textBoxCombs.Text = "Ошибка";
        }
        if (accommodationWithoutRelations.getState())
        {
            BigInteger n = parseCheck(textBoxCN.Text);
            BigInteger m = parseCheck(textBoxCM.Text);
            if (n >= m && n > 0 && m > 0)
            {//вывод сообщения о ошибке
                {
                    BigInteger hlp = A(n, m);
                    if (hlp != -1)
                        textBoxCombs.Text = Convert.ToString(hlp);
                    else
                        textBoxCombs.Text = "Слишком большое число";
                }
            }
            else
                textBoxCombs.Text = "Ошибка";
        }
        if (accommodationWithRelations.getState())
        {
            BigInteger n = parseCheck(textBoxCN.Text);
            BigInteger m = parseCheck(textBoxCM.Text);
            if (n >= m && n > 0 && m > 0)
            {//вы
                BigInteger hlp = Aalt(n, m);
                if (hlp != -1)
                    textBoxCombs.Text = Convert.ToString(hlp);
                else
                    textBoxCombs.Text = "Слишком большое число";
            }
            else
                textBoxCombs.Text = "Ошибка";
        }
        if (permutationsWithoutRelations.getState())
        {
            BigInteger n = parseCheck(textBoxP.Text);
            if (n > 0)
            {
                BigInteger hlp = P(n);
                if (hlp != -1)
                    textBoxPP.Text = Convert.ToString(hlp);
                else
                    textBoxPP.Text = "Слишком большое число";
            }
            else
                textBoxPP.Text = "Ошибка";
        }
        if (permutationsWithRelations.getState())
        {
            BigInteger[] K = parseGrid();
            if (K != null)//Здесь проверку надо бы))
            {
                BigInteger hlp = Palt(K);
                if (hlp != -1)
                    textBoxPwith.Text = Convert.ToString(hlp);
                else
                    textBoxPwith.Text = "Слишком большое число";
            }
            else
                textBoxPwith.Text = "Ошибка";
        }

    }

        private void plus_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount++;
            dataGridView1.Columns[dataGridView1.ColumnCount-1].Width = 21;
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount>1)
            dataGridView1.ColumnCount--;
        }

        private void reader_Enter(object sender, EventArgs e)
        {

        }

        private void panelForCombinations_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
