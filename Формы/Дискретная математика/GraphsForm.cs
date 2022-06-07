using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Professional_GUI//добавить графы,по ним делать орисовку линий+ стрелки,добавить удаление и добавление прмых,добавить условие на несколько дуг
{
    public partial class GraphsForm : Form
    {
        private AbsPanel pForGraphics=null;
        private Graphs graph=null;
        private bool pressShift=false;
        private Button currentButton;
        private Color color = Color.FromArgb(107, 73, 143);
        private Color colorForChild = ThemeColor.ChangeColorBrightness(Color.FromArgb(107, 73, 143), -0.5);
       //поля для выделения вершин в Алгоритмах нахождения минимального пути
        private Point lastPressPoint=Point.Empty;
        private int numberHighlightsVertxs=0;
        private int[] points; 

        public GraphsForm() 
        {
            InitializeComponent();
            buttOrient.setState();
            points = new int[2];
            dataGridView1.ForeColor = ThemeColor.ChangeColorBrightness(Color.FromArgb(107, 73, 143), 0.5);
            panelForMatrix.ForeColor = ThemeColor.ChangeColorBrightness(Color.FromArgb(107, 73, 143), 0.5);
            reader.Visible = false;
            reader.src = Directory.GetCurrentDirectory()+ "\\Теория Проект Графы_compressed.pdf";
        }

        private void ActiveButton(Object btnSender)
        {
            if (btnSender != null) {
                    
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                 
            }
        }

        private void DisableButton(Control previousBtn) {
                if (previousBtn.GetType()==typeof(Button)) {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 60);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font= new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }

        private void butWaysSelected_Click(object sender, EventArgs e)
        {
            if (panelWaysSelected.Visible == true)
            {
                DisableButton((Button)sender);
                panelWaysSelected.Visible = false;
                if (panelMenuForMatrix.Visible)
                    panelMenuForMatrix.Visible = false;
            }
            else
            {
                panelWaysSelected.Visible = true;
                ActiveButton(sender);
            }
        }

        private void buttonTypeGraph_Click(object sender, EventArgs e)
        {
            if (panelTypeGraph.Visible == true)
            {
                DisableButton((Button)sender);
                panelTypeGraph.Visible = false;

            }
            else
            {
                panelTypeGraph.Visible = true;
                ActiveButton(sender);
            }
        }

        private void buttonOrient_Click(object sender, EventArgs e)
        {
            if (panelTypeOrient.Visible == true)
            {
                DisableButton((Button)sender);//
                panelTypeOrient.Visible = false;
                
            }
            else
            {
                panelTypeOrient.Visible = true;
                ActiveButton((Button)sender);
            }
           // buttonOrientMen.setState();
        }

        private void buttonAlghoritms_Click(object sender, EventArgs e)
        {
            if (panelAlghoritms.Visible || panelWightAlghoritms.Visible)
                {
                DisableButton(buttonAlghoritms);
                if (graph.GetType() == typeof(Weighted_matrix))
                {
                    repaintAfterFloifOrDeikstri();
                    panelWightAlghoritms.Visible = false;
                }
                else panelAlghoritms.Visible = false;
            }
                else
            {
                if (butMatrType.getState())
                    butSaveMatr_Click(sender, e);
                if (butMatrType.getState() || (graph != null && graph.getRealSize() != 0))
                {

                    if (graph.GetType() == typeof(Weighted_matrix))
                        panelWightAlghoritms.Visible = true;
                    else
                        panelAlghoritms.Visible = true;
                    ActiveButton(sender);
                }

            }
        }

        private void DisableButtonForChild(Panel panel)
        {
            foreach (Control previousBtn in panel.Controls)
            {
                if (previousBtn.GetType() == typeof(myButton)|| previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 60);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }
        private void ActiveButtonForChild(Object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButtonForChild(((Button)btnSender).Parent as Panel);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = colorForChild;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }

        private void setStateButtns(myButton bt1,myButton bt2) {
            if (!bt1.getState() && !bt2.getState())//начальное условие
            {
                bt1.setState();
            }
            else {//если одна из кнопок уже была нажата
                bt1.setState();
                bt2.setState();
            }
        }

        private void butGrpahicWay_Click(object sender, EventArgs e)
        {
            if(!butGrpahicWay.getState())
            setStateButtns(butGrpahicWay, butMatrType);
            ActiveButtonForChild(sender);
            panelMenuForMatrix.Visible = false;
            panelForMatrix.Visible = false;
            panelForGraphics.Visible = true;
            if (butWeightGraph.getState())//если выбрана кнопка Матрицы веса
            {
                repaintAfterFloifOrDeikstri();
                pForGraphics = new PanelWeight(panelForGraphics, new Weighted_matrix());
                graph = pForGraphics.GetGraph();
                pForGraphics.paint();
            }
                if (butEzGraph.getState())
            {//если выбрана кнопка Матрицы смежности

                pForGraphics = new PanelIndentity(panelForGraphics, new Adjacency_matr());
                graph = pForGraphics.GetGraph();
                pForGraphics.paint();
            }
            graph?.setSymm(buttOrient.getState());
        }

        private void createBegMatr() {
                dataGridView1.RowCount = 2;
                dataGridView1.ColumnCount = 2;
                for (int i = 0; i < 2; i++)
                {

                    dataGridView1.Columns[i].Width = 30;
                    dataGridView1.Columns[i].HeaderCell.Value = Convert.ToString(i + 1);
                    dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                }
           
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        dataGridView1.Rows[i].Cells[j].Value = null;
        }

        private void butMatrType_Click(object sender, EventArgs e)
        {
            if (!butMatrType.getState())
                setStateButtns(butMatrType,butGrpahicWay);
            if (panelMenuForMatrix.Visible)
            {
                panelMenuForMatrix.Visible = false;
            }
            else
            {
                panelMenuForMatrix.Visible = true;
                ActiveButtonForChild(sender);
                panelForGraphics.Visible = false;
                panelForMatrix.Visible = true;
                if(butWeightGraph.getState()||butEzGraph.getState())
                createBegMatr();
            }
            if (butWeightGraph.getState())//если выбрана кнопка Матрицы веса
                graph =new Weighted_matrix();
            if (butEzGraph.getState())//если выбрана кнопка Матрицы смежности
                graph =  new Adjacency_matr();
            graph?.setSymm(buttOrient.getState());
        }




        private void butEzGraph_Click(object sender, EventArgs e)
        {
            setStateButtns(butEzGraph, butWeightGraph);
            ActiveButtonForChild(sender);
            if (butGrpahicWay.getState())
            {
                graph = new Adjacency_matr();
                pForGraphics = new PanelIndentity(panelForGraphics, (Adjacency_matr)graph);
                pForGraphics.paint();
            }
            else
            {
                if (butMatrType.getState()|| butEzGraph.getState())
                {
                    createBegMatr();
                    graph = new Adjacency_matr(dataGridView1.ColumnCount);
                }
            }
            if (panelAlghoritms.Visible || panelWightAlghoritms.Visible)
            {
                if(butGrpahicWay.getState()&&graph.GetType()==typeof(Weighted_matrix))
                buttonAlghoritms_Click(sender, e);

                panelAlghoritms.Visible = false;
                panelWightAlghoritms.Visible = false;
                lastPressPoint = Point.Empty;
                numberHighlightsVertxs = 0;
            }
            graph?.setSymm(buttOrient.getState());
        }

        private void butWeightGraph_Click(object sender, EventArgs e)
        {
            setStateButtns(butWeightGraph, butEzGraph);
            ActiveButtonForChild(sender);
            graph = new Weighted_matrix();
            if ((butGrpahicWay.getState()))
            {
                pForGraphics = new PanelWeight(panelForGraphics, (Weighted_matrix)graph);
                pForGraphics.paint();
            }
            if (butMatrType.getState())
                {
                    createBegMatr();
            }
            if (panelAlghoritms.Visible || panelWightAlghoritms.Visible)
            {
                buttonAlghoritms_Click(sender, e);

                panelAlghoritms.Visible = false;
                panelWightAlghoritms.Visible = false;
            }
            graph?.setSymm(buttOrient.getState());
        }

        private void buttOrient_Click(object sender, EventArgs e)
        {
            setStateButtns(buttOrient, butNotOrient);
            graph?.setSymm(false);
            ActiveButtonForChild(sender);
        }

        private void butNotOrient_Click(object sender, EventArgs e)
        {
            setStateButtns(butNotOrient,buttOrient);
            graph?.setSymm(true);
            ActiveButtonForChild(sender);
        }

        private void butStronglyConponents_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            ActiveButtonForChild(sender);
           textBoxOutput.Text ="Компоненты сильной связности: "+graph.stronglyComponents();

        }

        //АЛГОРИТМЫ
        private void butEyler_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            ActiveButtonForChild(sender);
            textBoxOutput.Text = "Эйлеров путь/цикл: " + graph.Elrcycel();
        }

        private void butHumilton_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            ActiveButtonForChild(sender);
            textBoxOutput.Text = "Гамильтонов цикл: " + graph.humiltonCycle();
        }


        private void buttonPaintGraph_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            ActiveButtonForChild(sender);
            textBoxOutput.Text = "Раскраска гарфа: " + graph.colorTheGraph();
        }

        private void repaintAfterFloifOrDeikstri() {

            if(buttonDeikstri.getState())
           
            buttonDeikstri.setState();
            if (buttonFloida.getState())
                buttonFloida.setState();
            if (numberHighlightsVertxs == 2)
            {
                pForGraphics.getNumVerOnClick(((Weighted_matrix)graph).GetVertex(points[1]).GetPoint(), ref numberHighlightsVertxs, ref lastPressPoint);
                lastPressPoint = ((Weighted_matrix)graph).GetVertex(points[0]).GetPoint();
                pForGraphics.getNumVerOnClick(((Weighted_matrix)graph).GetVertex(points[0]).GetPoint(), ref numberHighlightsVertxs, ref lastPressPoint);
                lastPressPoint = Point.Empty;
            }
            if (numberHighlightsVertxs == 1) {
                lastPressPoint = ((Weighted_matrix)graph).GetVertex(points[0]).GetPoint();
                pForGraphics.getNumVerOnClick(((Weighted_matrix)graph).GetVertex(points[0]).GetPoint(), ref numberHighlightsVertxs, ref lastPressPoint);
                lastPressPoint = Point.Empty;
            }
        }

        private void butWStronglyComps_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            repaintAfterFloifOrDeikstri();
            butStronglyConponents_Click(sender, e);
        }

        private void butWEyler_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            repaintAfterFloifOrDeikstri();
            butEyler_Click(sender,e);
        }

        private void butWHumilton_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            repaintAfterFloifOrDeikstri();
            butHumilton_Click(sender, e);
        }

        private void butWPaint_Click(object sender, EventArgs e)
        {
            ActiveButtonForChild(sender);
            repaintAfterFloifOrDeikstri();
            buttonPaintGraph_Click(sender, e);
        }

        private void buttonDeikstri_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            if (butGrpahicWay.getState())
            {
                ActiveButtonForChild(sender);

                if (numberHighlightsVertxs == 2)
                {
                    textBoxOutput.Text = "Алгоритм Дейкстры: " + ((Weighted_matrix)graph).AlgorithmDeikstri(points[0], points[1]);

                }
            }
            if (butMatrType.getState()) {

                ActiveButtonForChild(sender);
                GraphsForm2 txtBox = new GraphsForm2();

                txtBox.setTxtLable("Введите номера двух вершины");
                txtBox.ShowDialog();
                if (txtBox.getLastPressBut())
                {
                    string str = txtBox.getStrTxtBox();
                   string[] mas= str.Split(' ');
                    if (mas.Length == 1) return;
                    int v1, v2;
                    if(int.TryParse(mas[1],out v2)&& int.TryParse(mas[0],out v1))
                        if(v1>0&&v2>0&&v1<=graph.getRealSize()&& v2 <= graph.getRealSize())
                            textBoxOutput.Text = "Алгоритм Дейкстры: " + ((Weighted_matrix)graph).AlgorithmDeikstri(v1-1,v2-1);
                }
            }
            if(sender!=null)
            setStateButtns(buttonDeikstri, buttonFloida);
        }

        private void buttonFloida_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            if (butGrpahicWay.getState())
            {
                ActiveButtonForChild(sender);
                if (numberHighlightsVertxs == 2)
                {
                    textBoxOutput.Text = "Алгоритм Флойда: " + ((Weighted_matrix)graph).algoritgmFloida(points[0], points[1]);
                }
            } 
            if (butMatrType.getState())
            {
                ActiveButtonForChild(sender);
                GraphsForm2 txtBox = new GraphsForm2();

                txtBox.setTxtLable("Введите номера двух вершины");
                txtBox.ShowDialog();
                if (txtBox.getLastPressBut())
                {
                    string str = txtBox.getStrTxtBox();
                    string[] mas = str.Split(' ');
                    if (mas.Length == 1) return;
                    int v1, v2;
                    if (int.TryParse(mas[1], out v2) && int.TryParse(mas[0], out v1))
                        if (v1 > 0 && v2 > 0 && v1 <= graph.getRealSize() && v2 <= graph.getRealSize())
                            textBoxOutput.Text = "Алгоритм Флойда " + ((Weighted_matrix)graph).algoritgmFloida(v1 - 1, v2 - 1);
                }
            }
            if (sender != null)
                setStateButtns(buttonFloida, buttonDeikstri);
        }


        private void buttonOstovTree_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            repaintAfterFloifOrDeikstri();
            buttonOstovTree.setState();
            ActiveButtonForChild(sender);
            textBoxOutput.Text = "Минимальное остовное дервео: " + ((Weighted_matrix)graph).minOstovTree();
        }


        private void butCenterAndEtc_Click(object sender, EventArgs e)
        {
            if (butMatrType.getState())
                butSaveMatr_Click(sender, e);
            repaintAfterFloifOrDeikstri();
            ActiveButtonForChild(sender);
            butCenterAndEtc.setState();
            textBoxOutput.Text = ((Weighted_matrix)graph).Center()+ ", " + ((Weighted_matrix)graph).Radius()+ ", " + ((Weighted_matrix)graph).Diametr()+ ", "+((Weighted_matrix)graph).MedianFloida();
        }

        private void butAddVerMatr_Click(object sender, EventArgs e)
        {
            if ((butWeightGraph.getState()||butEzGraph.getState()) && dataGridView1.RowCount<34) {
                dataGridView1.RowCount++;
                dataGridView1.ColumnCount++;
                int size = dataGridView1.RowCount;
                dataGridView1.Columns[size - 1].Width = 30;
                dataGridView1.Columns[size - 1].HeaderCell.Value = Convert.ToString(size);
                dataGridView1.Rows[size - 1].HeaderCell.Value = Convert.ToString(size);
            } 
        }


        private void butRemoveVerMatr_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                dataGridView1.RowCount--;
                dataGridView1.ColumnCount--;
            }
        }

        private void butSaveMatr_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount > graph?.getRealSize())
                for(int i = graph.getRealSize(); i< dataGridView1.ColumnCount;++i)
                graph.addVertex(Point.Empty);
            if (dataGridView1.ColumnCount < graph?.getRealSize())
                for (int i = graph.getRealSize(); graph.getRealSize() != dataGridView1.ColumnCount; ++i)
                    graph.RemoveEl(graph.getRealSize());
            if (butEzGraph.getState())
            {

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        ((Adjacency_matr)graph).GetVertex(i).getCompound()[j] = parseForIndjMatr( i,j);
                    }
                }
            }
            if (butWeightGraph.getState())
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        ((Weighted_matrix)graph).GetVertex(i).getCompound()[j] = parseForWeightMat(i, j);
                    }
                }
            }
            }


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        { 
            if (buttonDeikstri.getState() || buttonFloida.getState()) {
                if (numberHighlightsVertxs == 1)
                    lastPressPoint = ((Weighted_matrix)graph).GetVertex(points[0]).GetPoint();
                int hlp = pForGraphics.getNumVerOnClick(e.Location, ref numberHighlightsVertxs, ref lastPressPoint); ;
                if (hlp != -1)
                    points[numberHighlightsVertxs-1] = hlp;
                if (numberHighlightsVertxs == 2)
                {
                    if (buttonDeikstri.getState())
                    {
                        buttonDeikstri_Click(null, null);
                       // buttonDeikstri.setState();
                    }
                    else if (buttonFloida.getState())
                    {
                        buttonFloida_Click(null, null);
                       // buttonDeikstri.setState();
                    }
                }
            }
            else
            {
                if (!pressShift)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        pForGraphics?.paintVer(e.Location);
                    else
                    {
                        pForGraphics?.removeCompoundVertex(e.Location);
                    }
                }
                else
                {
                    pForGraphics?.removeVertex(e.Location);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        
        {
            pForGraphics?.repaint();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 16)
                pressShift = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 16)
                pressShift = false;
        }

        private void matrBut_Click(object sender, EventArgs e)//?
        {
            panelForMatrix.Visible = true;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45)
                e.Handled = true;
            if (butEzGraph.getState())
                if (e.KeyChar == 44 || e.KeyChar == 45)
                    e.Handled = true;
        }

        private int parseForIndjMatr(int i, int j)
        {
            if (dataGridView1.Rows[i].Cells[j].Value == null)//null это значение по умолчанию
            {
                return int.MaxValue;
            }
            int t;
            if(int.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), out t) )
            return t;
            return int.MaxValue;
        }

        private double parseForWeightMat(int i,int j) {
            if (dataGridView1.Rows[i].Cells[j].Value == null ||Convert.ToString(dataGridView1.Rows[i].Cells[j].Value)== "") {
                return double.PositiveInfinity;
            }
            double t;
            if (double.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), out t))
                return t;
            return double.PositiveInfinity;
        }

        private void reader_Enter(object sender, EventArgs e)
        {

        }

        private void GraphsForm_Load(object sender, EventArgs e)
        {

        }
    }
    

}

class myButton : Button {
    private bool statePress = false;
    public void setState(bool st)
    {
        statePress = st;
    }
    //private void OnButtonClick(object sender, EventArgs e)
    //{

    //}


public bool getState()
{
    return statePress;
}
public void setState()
{
    if (statePress)
        statePress = false;
    else
        statePress = true;
}

}