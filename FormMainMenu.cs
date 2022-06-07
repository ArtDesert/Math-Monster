using Professional_GUI.Формы;
using Professional_GUI.Формы.Алгебра.Алгебра_матриц;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Professional_GUI.Формы.Алгебра.Комплексные_числа;
using Professional_GUI.Формы.Алгебра.Теория_чисел;
using AxAcroPDFLib;
using Professional_GUI.Формы.Дискретная_математика;

namespace Professional_GUI
{
    public partial class FormMainMenu : Form
    {
        private Button curMenuButton, curSubMenuButton, curBlockMenuButton;
        private Form activeForm;
        private Color curColor;
        private bool IsTheoryPressed, MenuIsHided;

        public FormMainMenu()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            IsTheoryPressed = false;
            MenuIsHided = false;
            this.Text = String.Empty;
            this.ControlBox = false; 
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            btnCloseChildForm.Visible = false;
            btnTheory.Visible = false;
            panelMA.Visible = false;
            panelAlgebra.Visible = false;
            panelDM.Visible = false;
            curMenuButton = null;
            curSubMenuButton = null;
            curBlockMenuButton = null;
            HideBlockMatrix();
            HideBlockComplex();
            HideBlockNumber();
            HideBlockFunction();
            panelMethods.Visible = false;
            btnMaximize_Click(new object(), new EventArgs());
            toolTip1.SetToolTip(btnCloseChildForm, "Выйти из текущего раздела");
            toolTip1.SetToolTip(btnRollUp, "Скрыть меню");
            toolTip1.SetToolTip(btnTheory, "Теоретическая справка");
        }

        //Hide blocks
        #region
        private void HideBlockMatrix()
        {
            btnMatrixAO.Visible = false;
            btnStepwise.Visible = false;
            btnLU.Visible = false;
        }

        private void HideBlockComplex()
        {
            btnComplexAO.Visible = false;
            btnMod.Visible = false;
            btnRoot.Visible = false;
            btnDegComplex.Visible = false;
        }
        private void HideBlockNumber()
        {
            btnChained.Visible = false;
            btnEuler.Visible = false;
            btnNumberGCD.Visible = false;
            btnDiophant.Visible = false;
            btnDivisors.Visible = false;
        }

        private void HideBlockFunction()
        {
            btnDer.Visible = false;
            btnSum.Visible = false;
            BtnIntegral.Visible = false;
            btnValueOnPoint.Visible = false;
            btnExtr.Visible = false;
        }

        #endregion 


        //Show blocks
        #region
        private void ShowBlockMatrix()
        {
            btnMatrixAO.Visible = true;
            btnStepwise.Visible = true;
            btnLU.Visible = true;
        }

        private void ShowBlockComplex()
        {
            btnComplexAO.Visible = true;
            btnMod.Visible = true;
            btnRoot.Visible = true;
            btnDegComplex.Visible = true;
        }
        private void ShowBlockNumber()
        {
            btnChained.Visible = true;
            btnEuler.Visible = true;
            btnNumberGCD.Visible = true;
            btnDiophant.Visible = true;
            btnDivisors.Visible = true;
        }
        private void ShowBlockFunction()
        {
            btnDer.Visible = true;
            btnSum.Visible = true;
            BtnIntegral.Visible = true;
            btnValueOnPoint.Visible = true;
            btnExtr.Visible = true;
        }

        #endregion 

        private void ShowCurrentBlock()
        {
            if (curSubMenuButton.Text == "  Алгебра матриц") ShowBlockMatrix();
            else if (curSubMenuButton.Text == "  Комплексные числа") ShowBlockComplex();
            else if (curSubMenuButton.Text == "  Теория чисел") ShowBlockNumber();
            else if (curSubMenuButton.Text == "  Функции одной \r\n  переменной\r\n") ShowBlockFunction();
        }

        private void HideCurrentBlock()
        {
            if (curSubMenuButton.Text == "  Алгебра матриц") HideBlockMatrix();
            else if (curSubMenuButton.Text == "  Комплексные числа") HideBlockComplex();
            else if (curSubMenuButton.Text == "  Теория чисел") HideBlockNumber();
            else if (curSubMenuButton.Text == "  Функции одной \r\n  переменной\r\n") HideBlockFunction();
        }

        private void HideSubMenu()
        {
            if (panelMA.Visible == true) panelMA.Visible = false;
            if (panelAlgebra.Visible == true) panelAlgebra.Visible = false;
            if (panelDM.Visible == true) panelDM.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ActivateButton(object sender)
        {
            curMenuButton = (Button)sender;
            if (curMenuButton.Text == "  Алгебра") curColor = Color.Teal;
            else if (curMenuButton.Text == "  Математический \r\n  анализ") curColor = Color.SeaGreen;
            else if (curMenuButton.Text == "  Геометрия") curColor = Color.DodgerBlue;
            else if (curMenuButton.Text == "  Дискретная \r\n  математика") curColor = Color.FromArgb(107, 73, 143);
            else if (curMenuButton.Text == "  Справка") curColor = Color.FromArgb(170, 210, 170);
            curMenuButton.BackColor = curColor;
            curMenuButton.ForeColor = Color.White;
            curMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panelTitleBar.BackColor = curColor;
            panelLogo.BackColor = ThemeColor.ChangeColorBrightness(curColor, -0.3);
            ThemeColor.PrimaryColor = curColor;
            ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(curColor, -0.3);
            lblTitle.Text = curMenuButton.Text;
        }
        private void ActivateSubButton(object sender)
        {
            curSubMenuButton = (Button)sender;
            curSubMenuButton.BackColor = curColor;
            curSubMenuButton.ForeColor = Color.White;
            curSubMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Text = curSubMenuButton.Text;
        }
        private void ActivateBlockButton(object sender)
        {
            curBlockMenuButton = (Button)sender;
            curBlockMenuButton.BackColor = curColor;
            curBlockMenuButton.ForeColor = Color.White;
            curBlockMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Text = curBlockMenuButton.Text;
        }

        private void DisableButton(object sender)
        {
            ((Button)sender).BackColor = Color.FromArgb(51, 51, 76);
            ((Button)sender).ForeColor = Color.Gainsboro;
            ((Button)sender).Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void DisableSubButton(object sender)
        {
            ((Button)sender).BackColor = Color.FromArgb(51, 51, 60);
            ((Button)sender).ForeColor = Color.Gainsboro;
            ((Button)sender).Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void DisableBlockButton(object sender)
        {
            curBlockMenuButton.BackColor = Color.FromArgb(51, 51, 60);
            curBlockMenuButton.ForeColor = Color.Gainsboro;
            ((Button)sender).Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void OpenChildForm(Form ChildForm, object sender)
        {
            btnCloseChildForm.Visible = true;
            if (activeForm != null) activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(ChildForm);
            this.panelDesktopPane.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            lblTitle.Text = ChildForm.Text;
            foreach (Control item in ChildForm.Controls)
                if (item.GetType() == typeof(Button))
                    item.ForeColor = curColor;
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null && !IsTheoryPressed) 
            {
                if (curBlockMenuButton == btnGeometry || curBlockMenuButton == btnInfo)
                {
                    DisableButton(curBlockMenuButton);
                    curMenuButton = null;
                    curBlockMenuButton = null;
                    activeForm.Close();
                    activeForm = null;
                    btnTheory.Visible = false;
                    Reset();
                }
                else if (curSubMenuButton == btnAP)
                {
                    DisableSubButton(curSubMenuButton);
                    DisableButton(curMenuButton);
                    HideSubMenu();
                    curSubMenuButton = null;
                    curMenuButton = null;
                    activeForm.Close();
                    activeForm = null;
                    btnTheory.Visible = false;
                    Reset();
                }
                else if (curBlockMenuButton != null)
                {
                    DisableBlockButton(curBlockMenuButton);
                    DisableButton(curMenuButton);
                    activeForm.Close();
                    curMenuButton = null;
                    activeForm = null;
                    btnCloseChildForm.Visible = false;
                    btnTheory.Visible = false;
                    if (curSubMenuButton != null) lblTitle.Text = curSubMenuButton.Text;
                    Reset();
                }
            }
        }

        private void Reset()
        {
            lblTitle.Text = "MATH MONSTER";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            btnCloseChildForm.Visible = false;
            if (curSubMenuButton != null)
            {
                DisableSubButton(curSubMenuButton);
                HideSubMenu();
                HideCurrentBlock();
            }
            curBlockMenuButton = null;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimaze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SelectButton(Panel panel, object sender)
        {
            if (curMenuButton == null)
            {
                ActivateButton(sender);
                if (panel != null) ShowSubMenu(panel);
                curMenuButton = (Button)sender;
            }
            else
            {
                if (curMenuButton == sender)
                {
                    DisableButton(sender);
                    HideSubMenu();
                    curMenuButton = null;
                    Reset();
                }
                else if (curMenuButton != sender)
                {
                    DisableButton(curMenuButton);
                    HideSubMenu();
                    curMenuButton = (Button)sender;
                    ActivateButton(sender);
                    ShowSubMenu(panel);
                }
                if (curSubMenuButton != null)
                {
                    DisableSubButton(curSubMenuButton);
                    HideCurrentBlock();
                    curSubMenuButton = null;
                }
            }
        }

        private void SelectSubButton(object sender)
        {
            if (curSubMenuButton == null)
            {
                ActivateSubButton(sender);
                ShowCurrentBlock();
                curSubMenuButton = (Button)sender;
            }
            else
            {
                if (curSubMenuButton == sender)
                {
                    DisableSubButton(sender);
                    HideCurrentBlock();
                    curSubMenuButton = null;
                }
                else
                {
                    HideCurrentBlock();
                    DisableSubButton(curSubMenuButton);
                    ActivateSubButton(sender);
                    ShowCurrentBlock();
                    curSubMenuButton = (Button)sender;
                }
            }
        }

        private void ShowMethods()
        {
            if (!panelMethods.Visible) panelMethods.Visible = true;
        }

        private void HideMethods()
        {
            if (panelMethods.Visible) panelMethods.Visible = false;
        }
        
        private void btnAlgebra_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                ShowMethods();
                SelectButton(panelAlgebra, sender);
            } 
        }

        private void btnMatrix_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                SelectSubButton(sender);
                ShowMethods();
            } 
        }

        private void btnAP_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                btnTheory.Visible = true;
                HideMethods();
                SelectSubButton(sender);
                OpenChildForm(new FormAlgebraPolynom(), sender);
            } 
        }

        private void btnVector_Click(object sender, EventArgs e)
        {
            if (activeForm == null) SelectSubButton(sender);
        }

        private void btnComplex_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                SelectSubButton(sender);
                ShowMethods();
            } 
        }

        private void btnNumberTheory_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                SelectSubButton(sender);
                ShowMethods();
            }
        }

        private void btnGeometry_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {

                btnTheory.Visible = true;
                if (panelMethods.Visible) panelMethods.Visible = false;
                curBlockMenuButton = (Button)sender;
                SelectButton(panelMA, sender);
                HideSubMenu();
                OpenChildForm(new FormGeometry(), sender);
            }
        }

        private void btnGPlane_Click(object sender, EventArgs e)
        {
            if (activeForm == null) SelectSubButton(sender);
        }

        private void btnGSpace_Click(object sender, EventArgs e)
        {
            if (activeForm == null) SelectSubButton(sender);
        }

        private void btnMA_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                ShowMethods();
                SelectButton(panelMA, sender);
            }
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                SelectSubButton(sender);
                ShowMethods();
            }
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            if (activeForm == null) SelectSubButton(sender);
        }

        private void btnDM_Click(object sender, EventArgs e)
        {

            if (activeForm == null)
            {
                HideMethods();
                SelectButton(panelDM, sender);
            }
        }

        private void btnGraphs_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {

                if (panelMethods.Visible) panelMethods.Visible = false;
                curBlockMenuButton = (Button)sender;
                try { SelectSubButton(sender); }
                catch (NullReferenceException) { }
                OpenChildForm(new GraphsForm(), sender);
                HideMethods();
                btnTheory.Visible = true;
            }
        }

        private void btnBoolean_Click(object sender, EventArgs e)
        {
            if (activeForm == null) SelectSubButton(sender);
        }

        private void btnCombinatory_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                curBlockMenuButton = (Button)sender;
                btnTheory.Visible = true;
                SelectSubButton(sender);
                HideMethods();
                OpenChildForm(new Combinatorics(), sender);
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (activeForm == null)
            {
                if (panelMethods.Visible) panelMethods.Visible = false;
                curBlockMenuButton = (Button)sender;
                try { SelectButton(null, sender); }
                catch (NullReferenceException) { }
                OpenChildForm(new MainInfoForm(), sender);
            }
        }


        private void HideFullMenu()
        {
            if (!MenuIsHided)
            {
                panelMenu.Visible = false;
                panelMethods.Visible = false;
                MenuIsHided = true;
            }
        }

        private void ShowFullMenu()
        {
            if (MenuIsHided)
            {
                panelMenu.Visible = true;
                panelMethods.Visible = true;
                MenuIsHided = false;
            }
        }
        private void btnRollUp_Click(object sender, EventArgs e)
        {
            if (MenuIsHided) ShowFullMenu();
            else HideFullMenu();
            if (curBlockMenuButton == btnGeometry || curBlockMenuButton == btnGraphs || curBlockMenuButton == btnCombinatory 
                || curSubMenuButton == btnAP || curBlockMenuButton == btnInfo) HideMethods();
        }

        private void btnMatrixAO_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                btnTheory.Visible = true;
                ActivateBlockButton(sender);
                OpenChildForm(new OperationsForm(), sender);
            } 
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
            }
        }

        private void btnStepwise_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new MainCharMatrixForm(), sender);
            }
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
            }
        }

        private void btnISLE_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
            }
        }

        private void btnLU_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new LUQRForm(), sender);
            }
        }

        private void btnTheory_Click(object sender, EventArgs e)
        {
            AxAcroPDF reader = new AxAcroPDF();
            foreach (Control item in activeForm.Controls)
                if (item.GetType() == typeof(AxAcroPDF)) reader = (AxAcroPDF)item;
            if (!IsTheoryPressed)
            {
                IsTheoryPressed = true;
                reader.Visible = true;
            }
            else 
            {
                IsTheoryPressed = false;
                reader.Visible = false;
            }
        }

        private void btnComplexAO_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                btnTheory.Visible = true;
                ActivateBlockButton(sender);
                OpenChildForm(new ComplexForm2(), sender);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            { 
                ActivateBlockButton(sender);
                OpenChildForm(new ComplexModForm(), sender);
            }
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new ComplexRootsForm(), sender);
            }
        }

        private void btnGraphic_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new ChainedForm(), sender);
            }
        }

        private void btnDegComplex_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new ComplexForm1(), sender);
            }
        }

        private void btnDer_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new DerForm(), sender);
                btnTheory.Visible = true;
            }
        }

        private void BtnIntegral_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new IntegralForm(), sender);
                btnTheory.Visible = true;
            }
        }

        private void btnNumberGCD_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new GCDForm(), sender);
            }
        }

        private void btnEuler_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new EulerForm(), sender);
            }
        }

        private void btnDiophant_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                btnTheory.Visible = true;
                ActivateBlockButton(sender);
                OpenChildForm(new DiophantForm(), sender);
            }
        }

        private void btnDivisors_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new DivisorsForm(), sender);
            }
        }

        private void btnValueOnPoint_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new ValueInPointForm(), sender);
                btnTheory.Visible = true;
            }
        }

        private void btnExtr_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new ExtrForm(), sender);
                btnTheory.Visible = true;
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
                OpenChildForm(new SumRowForm(), sender);
                btnTheory.Visible = true;
            }
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
            }
        }

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            if (curBlockMenuButton == null)
            {
                ActivateBlockButton(sender);
            }
        }
    }
}
