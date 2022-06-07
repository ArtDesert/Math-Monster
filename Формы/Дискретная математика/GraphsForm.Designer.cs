namespace Professional_GUI
{
    partial class GraphsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphsForm));
            this.buttonOrientMen = new System.Windows.Forms.Button();
            this.panelForGraphics = new System.Windows.Forms.Panel();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.panelForMatrix = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.panelWightAlghoritms = new System.Windows.Forms.Panel();
            this.butWPaint = new System.Windows.Forms.Button();
            this.butWHumilton = new System.Windows.Forms.Button();
            this.butWEyler = new System.Windows.Forms.Button();
            this.butWStronglyComps = new System.Windows.Forms.Button();
            this.panelAlghoritms = new System.Windows.Forms.Panel();
            this.buttonPaintGraph = new System.Windows.Forms.Button();
            this.butHumilton = new System.Windows.Forms.Button();
            this.butEyler = new System.Windows.Forms.Button();
            this.butStronglyConponents = new System.Windows.Forms.Button();
            this.buttonAlghoritms = new System.Windows.Forms.Button();
            this.panelTypeOrient = new System.Windows.Forms.Panel();
            this.panelTypeGraph = new System.Windows.Forms.Panel();
            this.buttonTypeGraph = new System.Windows.Forms.Button();
            this.panelMenuForMatrix = new System.Windows.Forms.Panel();
            this.butRemoveVerMatr = new System.Windows.Forms.Button();
            this.butAddVerMatr = new System.Windows.Forms.Button();
            this.panelWaysSelected = new System.Windows.Forms.Panel();
            this.butWaysSelected = new System.Windows.Forms.Button();
            this.reader = new AxAcroPDFLib.AxAcroPDF();
            this.buttonFloida = new myButton();
            this.buttonDeikstri = new myButton();
            this.butCenterAndEtc = new myButton();
            this.buttonOstovTree = new myButton();
            this.butNotOrient = new myButton();
            this.buttOrient = new myButton();
            this.butWeightGraph = new myButton();
            this.butEzGraph = new myButton();
            this.butMatrType = new myButton();
            this.butGrpahicWay = new myButton();
            this.panelForMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelMainMenu.SuspendLayout();
            this.panelWightAlghoritms.SuspendLayout();
            this.panelAlghoritms.SuspendLayout();
            this.panelTypeOrient.SuspendLayout();
            this.panelTypeGraph.SuspendLayout();
            this.panelMenuForMatrix.SuspendLayout();
            this.panelWaysSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reader)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOrientMen
            // 
            this.buttonOrientMen.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOrientMen.FlatAppearance.BorderSize = 0;
            this.buttonOrientMen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrientMen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrientMen.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonOrientMen.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOrientMen.Location = new System.Drawing.Point(0, 323);
            this.buttonOrientMen.Name = "buttonOrientMen";
            this.buttonOrientMen.Size = new System.Drawing.Size(256, 50);
            this.buttonOrientMen.TabIndex = 2;
            this.buttonOrientMen.Text = "Ориентированность";
            this.buttonOrientMen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOrientMen.UseVisualStyleBackColor = true;
            this.buttonOrientMen.Click += new System.EventHandler(this.buttonOrient_Click);
            // 
            // panelForGraphics
            // 
            this.panelForGraphics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(164)))), ((int)(((byte)(199)))));
            this.panelForGraphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForGraphics.Location = new System.Drawing.Point(0, 0);
            this.panelForGraphics.Name = "panelForGraphics";
            this.panelForGraphics.Size = new System.Drawing.Size(1002, 663);
            this.panelForGraphics.TabIndex = 0;
            this.panelForGraphics.Visible = false;
            this.panelForGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panelForGraphics.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.textBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBoxOutput.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxOutput.Location = new System.Drawing.Point(0, 1149);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.Size = new System.Drawing.Size(256, 178);
            this.textBoxOutput.TabIndex = 1;
            // 
            // panelForMatrix
            // 
            this.panelForMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForMatrix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(164)))), ((int)(((byte)(199)))));
            this.panelForMatrix.Controls.Add(this.dataGridView1);
            this.panelForMatrix.Location = new System.Drawing.Point(0, 0);
            this.panelForMatrix.Name = "panelForMatrix";
            this.panelForMatrix.Size = new System.Drawing.Size(1001, 621);
            this.panelForMatrix.TabIndex = 0;
            this.panelForMatrix.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(164)))), ((int)(((byte)(199)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 20;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(279, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "00";
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.Size = new System.Drawing.Size(711, 569);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMainMenu.AutoScroll = true;
            this.panelMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(60)))));
            this.panelMainMenu.Controls.Add(this.panelWightAlghoritms);
            this.panelMainMenu.Controls.Add(this.textBoxOutput);
            this.panelMainMenu.Controls.Add(this.panelAlghoritms);
            this.panelMainMenu.Controls.Add(this.buttonAlghoritms);
            this.panelMainMenu.Controls.Add(this.panelTypeOrient);
            this.panelMainMenu.Controls.Add(this.buttonOrientMen);
            this.panelMainMenu.Controls.Add(this.panelTypeGraph);
            this.panelMainMenu.Controls.Add(this.buttonTypeGraph);
            this.panelMainMenu.Controls.Add(this.panelMenuForMatrix);
            this.panelMainMenu.Controls.Add(this.panelWaysSelected);
            this.panelMainMenu.Controls.Add(this.butWaysSelected);
            this.panelMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(273, 663);
            this.panelMainMenu.TabIndex = 6;
            // 
            // panelWightAlghoritms
            // 
            this.panelWightAlghoritms.Controls.Add(this.buttonFloida);
            this.panelWightAlghoritms.Controls.Add(this.buttonDeikstri);
            this.panelWightAlghoritms.Controls.Add(this.butCenterAndEtc);
            this.panelWightAlghoritms.Controls.Add(this.buttonOstovTree);
            this.panelWightAlghoritms.Controls.Add(this.butWPaint);
            this.panelWightAlghoritms.Controls.Add(this.butWHumilton);
            this.panelWightAlghoritms.Controls.Add(this.butWEyler);
            this.panelWightAlghoritms.Controls.Add(this.butWStronglyComps);
            this.panelWightAlghoritms.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWightAlghoritms.Location = new System.Drawing.Point(0, 675);
            this.panelWightAlghoritms.Name = "panelWightAlghoritms";
            this.panelWightAlghoritms.Size = new System.Drawing.Size(256, 353);
            this.panelWightAlghoritms.TabIndex = 2;
            this.panelWightAlghoritms.Visible = false;
            // 
            // butWPaint
            // 
            this.butWPaint.Dock = System.Windows.Forms.DockStyle.Top;
            this.butWPaint.FlatAppearance.BorderSize = 0;
            this.butWPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butWPaint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butWPaint.ForeColor = System.Drawing.Color.Gainsboro;
            this.butWPaint.Location = new System.Drawing.Point(0, 133);
            this.butWPaint.Name = "butWPaint";
            this.butWPaint.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butWPaint.Size = new System.Drawing.Size(256, 40);
            this.butWPaint.TabIndex = 10;
            this.butWPaint.Text = "Раскраска графа";
            this.butWPaint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWPaint.UseVisualStyleBackColor = true;
            this.butWPaint.Click += new System.EventHandler(this.butWPaint_Click);
            // 
            // butWHumilton
            // 
            this.butWHumilton.Dock = System.Windows.Forms.DockStyle.Top;
            this.butWHumilton.FlatAppearance.BorderSize = 0;
            this.butWHumilton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butWHumilton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butWHumilton.ForeColor = System.Drawing.Color.Gainsboro;
            this.butWHumilton.Location = new System.Drawing.Point(0, 93);
            this.butWHumilton.Name = "butWHumilton";
            this.butWHumilton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butWHumilton.Size = new System.Drawing.Size(256, 40);
            this.butWHumilton.TabIndex = 9;
            this.butWHumilton.Text = "Гамильтонов цикл";
            this.butWHumilton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWHumilton.UseVisualStyleBackColor = true;
            this.butWHumilton.Click += new System.EventHandler(this.butWHumilton_Click);
            // 
            // butWEyler
            // 
            this.butWEyler.Dock = System.Windows.Forms.DockStyle.Top;
            this.butWEyler.FlatAppearance.BorderSize = 0;
            this.butWEyler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butWEyler.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butWEyler.ForeColor = System.Drawing.Color.Gainsboro;
            this.butWEyler.Location = new System.Drawing.Point(0, 53);
            this.butWEyler.Name = "butWEyler";
            this.butWEyler.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butWEyler.Size = new System.Drawing.Size(256, 40);
            this.butWEyler.TabIndex = 8;
            this.butWEyler.Text = "Эйлеров путь/эйлеров цикл";
            this.butWEyler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWEyler.UseVisualStyleBackColor = true;
            this.butWEyler.Click += new System.EventHandler(this.butWEyler_Click);
            // 
            // butWStronglyComps
            // 
            this.butWStronglyComps.Dock = System.Windows.Forms.DockStyle.Top;
            this.butWStronglyComps.FlatAppearance.BorderSize = 0;
            this.butWStronglyComps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butWStronglyComps.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butWStronglyComps.ForeColor = System.Drawing.Color.Gainsboro;
            this.butWStronglyComps.Location = new System.Drawing.Point(0, 0);
            this.butWStronglyComps.Name = "butWStronglyComps";
            this.butWStronglyComps.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butWStronglyComps.Size = new System.Drawing.Size(256, 53);
            this.butWStronglyComps.TabIndex = 7;
            this.butWStronglyComps.Text = "Компоненты сильной связности";
            this.butWStronglyComps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWStronglyComps.UseVisualStyleBackColor = true;
            this.butWStronglyComps.Click += new System.EventHandler(this.butWStronglyComps_Click);
            // 
            // panelAlghoritms
            // 
            this.panelAlghoritms.Controls.Add(this.buttonPaintGraph);
            this.panelAlghoritms.Controls.Add(this.butHumilton);
            this.panelAlghoritms.Controls.Add(this.butEyler);
            this.panelAlghoritms.Controls.Add(this.butStronglyConponents);
            this.panelAlghoritms.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAlghoritms.Location = new System.Drawing.Point(0, 503);
            this.panelAlghoritms.Name = "panelAlghoritms";
            this.panelAlghoritms.Size = new System.Drawing.Size(256, 172);
            this.panelAlghoritms.TabIndex = 7;
            this.panelAlghoritms.Visible = false;
            // 
            // buttonPaintGraph
            // 
            this.buttonPaintGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPaintGraph.FlatAppearance.BorderSize = 0;
            this.buttonPaintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPaintGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPaintGraph.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonPaintGraph.Location = new System.Drawing.Point(0, 127);
            this.buttonPaintGraph.Name = "buttonPaintGraph";
            this.buttonPaintGraph.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonPaintGraph.Size = new System.Drawing.Size(256, 42);
            this.buttonPaintGraph.TabIndex = 5;
            this.buttonPaintGraph.Text = "Раскраска графа";
            this.buttonPaintGraph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPaintGraph.UseVisualStyleBackColor = true;
            this.buttonPaintGraph.Click += new System.EventHandler(this.buttonPaintGraph_Click);
            // 
            // butHumilton
            // 
            this.butHumilton.Dock = System.Windows.Forms.DockStyle.Top;
            this.butHumilton.FlatAppearance.BorderSize = 0;
            this.butHumilton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butHumilton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butHumilton.ForeColor = System.Drawing.Color.Gainsboro;
            this.butHumilton.Location = new System.Drawing.Point(0, 87);
            this.butHumilton.Name = "butHumilton";
            this.butHumilton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butHumilton.Size = new System.Drawing.Size(256, 40);
            this.butHumilton.TabIndex = 4;
            this.butHumilton.Text = "Гамильтонов цикл";
            this.butHumilton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHumilton.UseVisualStyleBackColor = true;
            this.butHumilton.Click += new System.EventHandler(this.butHumilton_Click);
            // 
            // butEyler
            // 
            this.butEyler.Dock = System.Windows.Forms.DockStyle.Top;
            this.butEyler.FlatAppearance.BorderSize = 0;
            this.butEyler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEyler.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEyler.ForeColor = System.Drawing.Color.Gainsboro;
            this.butEyler.Location = new System.Drawing.Point(0, 47);
            this.butEyler.Name = "butEyler";
            this.butEyler.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butEyler.Size = new System.Drawing.Size(256, 40);
            this.butEyler.TabIndex = 3;
            this.butEyler.Text = "Эйлеров путь/эйлеров цикл";
            this.butEyler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEyler.UseVisualStyleBackColor = true;
            this.butEyler.Click += new System.EventHandler(this.butEyler_Click);
            // 
            // butStronglyConponents
            // 
            this.butStronglyConponents.Dock = System.Windows.Forms.DockStyle.Top;
            this.butStronglyConponents.FlatAppearance.BorderSize = 0;
            this.butStronglyConponents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butStronglyConponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStronglyConponents.ForeColor = System.Drawing.Color.Gainsboro;
            this.butStronglyConponents.Location = new System.Drawing.Point(0, 0);
            this.butStronglyConponents.Name = "butStronglyConponents";
            this.butStronglyConponents.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butStronglyConponents.Size = new System.Drawing.Size(256, 47);
            this.butStronglyConponents.TabIndex = 2;
            this.butStronglyConponents.Text = "Компоненты сильной связности";
            this.butStronglyConponents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butStronglyConponents.UseVisualStyleBackColor = true;
            this.butStronglyConponents.Click += new System.EventHandler(this.butStronglyConponents_Click);
            // 
            // buttonAlghoritms
            // 
            this.buttonAlghoritms.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAlghoritms.FlatAppearance.BorderSize = 0;
            this.buttonAlghoritms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlghoritms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAlghoritms.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonAlghoritms.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAlghoritms.Location = new System.Drawing.Point(0, 453);
            this.buttonAlghoritms.Name = "buttonAlghoritms";
            this.buttonAlghoritms.Size = new System.Drawing.Size(256, 50);
            this.buttonAlghoritms.TabIndex = 3;
            this.buttonAlghoritms.Text = "Алгоритмы";
            this.buttonAlghoritms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAlghoritms.UseVisualStyleBackColor = true;
            this.buttonAlghoritms.Click += new System.EventHandler(this.buttonAlghoritms_Click);
            // 
            // panelTypeOrient
            // 
            this.panelTypeOrient.Controls.Add(this.butNotOrient);
            this.panelTypeOrient.Controls.Add(this.buttOrient);
            this.panelTypeOrient.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTypeOrient.Location = new System.Drawing.Point(0, 373);
            this.panelTypeOrient.Name = "panelTypeOrient";
            this.panelTypeOrient.Size = new System.Drawing.Size(256, 80);
            this.panelTypeOrient.TabIndex = 6;
            this.panelTypeOrient.Visible = false;
            // 
            // panelTypeGraph
            // 
            this.panelTypeGraph.Controls.Add(this.butWeightGraph);
            this.panelTypeGraph.Controls.Add(this.butEzGraph);
            this.panelTypeGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTypeGraph.Location = new System.Drawing.Point(0, 243);
            this.panelTypeGraph.Name = "panelTypeGraph";
            this.panelTypeGraph.Size = new System.Drawing.Size(256, 80);
            this.panelTypeGraph.TabIndex = 4;
            this.panelTypeGraph.Visible = false;
            // 
            // buttonTypeGraph
            // 
            this.buttonTypeGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTypeGraph.FlatAppearance.BorderSize = 0;
            this.buttonTypeGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTypeGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTypeGraph.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonTypeGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTypeGraph.Location = new System.Drawing.Point(0, 193);
            this.buttonTypeGraph.Name = "buttonTypeGraph";
            this.buttonTypeGraph.Size = new System.Drawing.Size(256, 50);
            this.buttonTypeGraph.TabIndex = 1;
            this.buttonTypeGraph.Text = "Тип графа";
            this.buttonTypeGraph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTypeGraph.UseVisualStyleBackColor = true;
            this.buttonTypeGraph.Click += new System.EventHandler(this.buttonTypeGraph_Click);
            // 
            // panelMenuForMatrix
            // 
            this.panelMenuForMatrix.Controls.Add(this.butRemoveVerMatr);
            this.panelMenuForMatrix.Controls.Add(this.butAddVerMatr);
            this.panelMenuForMatrix.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuForMatrix.Location = new System.Drawing.Point(0, 130);
            this.panelMenuForMatrix.Name = "panelMenuForMatrix";
            this.panelMenuForMatrix.Size = new System.Drawing.Size(256, 63);
            this.panelMenuForMatrix.TabIndex = 8;
            this.panelMenuForMatrix.Visible = false;
            // 
            // butRemoveVerMatr
            // 
            this.butRemoveVerMatr.Dock = System.Windows.Forms.DockStyle.Top;
            this.butRemoveVerMatr.FlatAppearance.BorderSize = 0;
            this.butRemoveVerMatr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRemoveVerMatr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.butRemoveVerMatr.ForeColor = System.Drawing.Color.Gainsboro;
            this.butRemoveVerMatr.Location = new System.Drawing.Point(0, 30);
            this.butRemoveVerMatr.Name = "butRemoveVerMatr";
            this.butRemoveVerMatr.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.butRemoveVerMatr.Size = new System.Drawing.Size(256, 30);
            this.butRemoveVerMatr.TabIndex = 1;
            this.butRemoveVerMatr.Text = "Уменьшить";
            this.butRemoveVerMatr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRemoveVerMatr.UseVisualStyleBackColor = true;
            this.butRemoveVerMatr.Click += new System.EventHandler(this.butRemoveVerMatr_Click);
            // 
            // butAddVerMatr
            // 
            this.butAddVerMatr.Dock = System.Windows.Forms.DockStyle.Top;
            this.butAddVerMatr.FlatAppearance.BorderSize = 0;
            this.butAddVerMatr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddVerMatr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.butAddVerMatr.ForeColor = System.Drawing.Color.Gainsboro;
            this.butAddVerMatr.Location = new System.Drawing.Point(0, 0);
            this.butAddVerMatr.Name = "butAddVerMatr";
            this.butAddVerMatr.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.butAddVerMatr.Size = new System.Drawing.Size(256, 30);
            this.butAddVerMatr.TabIndex = 0;
            this.butAddVerMatr.Text = "Увеличить";
            this.butAddVerMatr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAddVerMatr.UseVisualStyleBackColor = true;
            this.butAddVerMatr.Click += new System.EventHandler(this.butAddVerMatr_Click);
            // 
            // panelWaysSelected
            // 
            this.panelWaysSelected.Controls.Add(this.butMatrType);
            this.panelWaysSelected.Controls.Add(this.butGrpahicWay);
            this.panelWaysSelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWaysSelected.Location = new System.Drawing.Point(0, 50);
            this.panelWaysSelected.Name = "panelWaysSelected";
            this.panelWaysSelected.Size = new System.Drawing.Size(256, 80);
            this.panelWaysSelected.TabIndex = 5;
            this.panelWaysSelected.Visible = false;
            // 
            // butWaysSelected
            // 
            this.butWaysSelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.butWaysSelected.FlatAppearance.BorderSize = 0;
            this.butWaysSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butWaysSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butWaysSelected.ForeColor = System.Drawing.Color.Gainsboro;
            this.butWaysSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butWaysSelected.Location = new System.Drawing.Point(0, 0);
            this.butWaysSelected.Name = "butWaysSelected";
            this.butWaysSelected.Size = new System.Drawing.Size(256, 50);
            this.butWaysSelected.TabIndex = 0;
            this.butWaysSelected.Text = "Способ задания";
            this.butWaysSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWaysSelected.UseVisualStyleBackColor = true;
            this.butWaysSelected.Click += new System.EventHandler(this.butWaysSelected_Click);
            // 
            // reader
            // 
            this.reader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reader.Enabled = true;
            this.reader.Location = new System.Drawing.Point(0, 0);
            this.reader.Name = "reader";
            this.reader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reader.OcxState")));
            this.reader.Size = new System.Drawing.Size(1002, 663);
            this.reader.TabIndex = 7;
            this.reader.Enter += new System.EventHandler(this.reader_Enter);
            // 
            // buttonFloida
            // 
            this.buttonFloida.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFloida.FlatAppearance.BorderSize = 0;
            this.buttonFloida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFloida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFloida.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonFloida.Location = new System.Drawing.Point(0, 314);
            this.buttonFloida.Name = "buttonFloida";
            this.buttonFloida.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonFloida.Size = new System.Drawing.Size(256, 37);
            this.buttonFloida.TabIndex = 4;
            this.buttonFloida.Text = "Алгоритм Флойда";
            this.buttonFloida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFloida.UseVisualStyleBackColor = true;
            this.buttonFloida.Click += new System.EventHandler(this.buttonFloida_Click);
            // 
            // buttonDeikstri
            // 
            this.buttonDeikstri.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDeikstri.FlatAppearance.BorderSize = 0;
            this.buttonDeikstri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeikstri.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeikstri.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonDeikstri.Location = new System.Drawing.Point(0, 274);
            this.buttonDeikstri.Name = "buttonDeikstri";
            this.buttonDeikstri.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonDeikstri.Size = new System.Drawing.Size(256, 40);
            this.buttonDeikstri.TabIndex = 3;
            this.buttonDeikstri.Text = "Алгоритм Дейкстры";
            this.buttonDeikstri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeikstri.UseVisualStyleBackColor = true;
            this.buttonDeikstri.Click += new System.EventHandler(this.buttonDeikstri_Click);
            // 
            // butCenterAndEtc
            // 
            this.butCenterAndEtc.Dock = System.Windows.Forms.DockStyle.Top;
            this.butCenterAndEtc.FlatAppearance.BorderSize = 0;
            this.butCenterAndEtc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCenterAndEtc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCenterAndEtc.ForeColor = System.Drawing.Color.Gainsboro;
            this.butCenterAndEtc.Location = new System.Drawing.Point(0, 227);
            this.butCenterAndEtc.Name = "butCenterAndEtc";
            this.butCenterAndEtc.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butCenterAndEtc.Size = new System.Drawing.Size(256, 47);
            this.butCenterAndEtc.TabIndex = 6;
            this.butCenterAndEtc.Text = "Центр, радиус, диаметр\r\n и медиана ";
            this.butCenterAndEtc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCenterAndEtc.UseVisualStyleBackColor = true;
            this.butCenterAndEtc.Click += new System.EventHandler(this.butCenterAndEtc_Click);
            // 
            // buttonOstovTree
            // 
            this.buttonOstovTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOstovTree.FlatAppearance.BorderSize = 0;
            this.buttonOstovTree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOstovTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOstovTree.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonOstovTree.Location = new System.Drawing.Point(0, 173);
            this.buttonOstovTree.Name = "buttonOstovTree";
            this.buttonOstovTree.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonOstovTree.Size = new System.Drawing.Size(256, 54);
            this.buttonOstovTree.TabIndex = 5;
            this.buttonOstovTree.Text = "Минимальное остовное дерево у неорграфа";
            this.buttonOstovTree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOstovTree.UseVisualStyleBackColor = true;
            this.buttonOstovTree.Click += new System.EventHandler(this.buttonOstovTree_Click);
            // 
            // butNotOrient
            // 
            this.butNotOrient.Dock = System.Windows.Forms.DockStyle.Top;
            this.butNotOrient.FlatAppearance.BorderSize = 0;
            this.butNotOrient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNotOrient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butNotOrient.ForeColor = System.Drawing.Color.Gainsboro;
            this.butNotOrient.Location = new System.Drawing.Point(0, 40);
            this.butNotOrient.Name = "butNotOrient";
            this.butNotOrient.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butNotOrient.Size = new System.Drawing.Size(256, 40);
            this.butNotOrient.TabIndex = 2;
            this.butNotOrient.Text = "Неориентированный";
            this.butNotOrient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNotOrient.UseVisualStyleBackColor = true;
            this.butNotOrient.Click += new System.EventHandler(this.butNotOrient_Click);
            // 
            // buttOrient
            // 
            this.buttOrient.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttOrient.FlatAppearance.BorderSize = 0;
            this.buttOrient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttOrient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttOrient.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttOrient.Location = new System.Drawing.Point(0, 0);
            this.buttOrient.Name = "buttOrient";
            this.buttOrient.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttOrient.Size = new System.Drawing.Size(256, 40);
            this.buttOrient.TabIndex = 1;
            this.buttOrient.Text = "Ориентированный";
            this.buttOrient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttOrient.UseVisualStyleBackColor = true;
            this.buttOrient.Click += new System.EventHandler(this.buttOrient_Click);
            // 
            // butWeightGraph
            // 
            this.butWeightGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.butWeightGraph.FlatAppearance.BorderSize = 0;
            this.butWeightGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butWeightGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butWeightGraph.ForeColor = System.Drawing.Color.Gainsboro;
            this.butWeightGraph.Location = new System.Drawing.Point(0, 40);
            this.butWeightGraph.Name = "butWeightGraph";
            this.butWeightGraph.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butWeightGraph.Size = new System.Drawing.Size(256, 40);
            this.butWeightGraph.TabIndex = 2;
            this.butWeightGraph.Text = "Взвешенный";
            this.butWeightGraph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWeightGraph.UseVisualStyleBackColor = true;
            this.butWeightGraph.Click += new System.EventHandler(this.butWeightGraph_Click);
            // 
            // butEzGraph
            // 
            this.butEzGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.butEzGraph.FlatAppearance.BorderSize = 0;
            this.butEzGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEzGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEzGraph.ForeColor = System.Drawing.Color.Gainsboro;
            this.butEzGraph.Location = new System.Drawing.Point(0, 0);
            this.butEzGraph.Name = "butEzGraph";
            this.butEzGraph.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butEzGraph.Size = new System.Drawing.Size(256, 40);
            this.butEzGraph.TabIndex = 1;
            this.butEzGraph.Text = "Простой";
            this.butEzGraph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEzGraph.UseVisualStyleBackColor = true;
            this.butEzGraph.Click += new System.EventHandler(this.butEzGraph_Click);
            // 
            // butMatrType
            // 
            this.butMatrType.Dock = System.Windows.Forms.DockStyle.Top;
            this.butMatrType.FlatAppearance.BorderSize = 0;
            this.butMatrType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMatrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butMatrType.ForeColor = System.Drawing.Color.Gainsboro;
            this.butMatrType.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMatrType.Location = new System.Drawing.Point(0, 40);
            this.butMatrType.Name = "butMatrType";
            this.butMatrType.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butMatrType.Size = new System.Drawing.Size(256, 40);
            this.butMatrType.TabIndex = 1;
            this.butMatrType.Text = "Матричный";
            this.butMatrType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMatrType.UseVisualStyleBackColor = true;
            this.butMatrType.Click += new System.EventHandler(this.butMatrType_Click);
            // 
            // butGrpahicWay
            // 
            this.butGrpahicWay.Dock = System.Windows.Forms.DockStyle.Top;
            this.butGrpahicWay.FlatAppearance.BorderSize = 0;
            this.butGrpahicWay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butGrpahicWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butGrpahicWay.ForeColor = System.Drawing.Color.Gainsboro;
            this.butGrpahicWay.Location = new System.Drawing.Point(0, 0);
            this.butGrpahicWay.Name = "butGrpahicWay";
            this.butGrpahicWay.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.butGrpahicWay.Size = new System.Drawing.Size(256, 40);
            this.butGrpahicWay.TabIndex = 0;
            this.butGrpahicWay.Text = "Графический";
            this.butGrpahicWay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGrpahicWay.UseVisualStyleBackColor = true;
            this.butGrpahicWay.Click += new System.EventHandler(this.butGrpahicWay_Click);
            // 
            // GraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(164)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(1002, 663);
            this.Controls.Add(this.reader);
            this.Controls.Add(this.panelMainMenu);
            this.Controls.Add(this.panelForMatrix);
            this.Controls.Add(this.panelForGraphics);
            this.KeyPreview = true;
            this.Name = "GraphsForm";
            this.Text = "Теория графов";
            this.Load += new System.EventHandler(this.GraphsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panelForMatrix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelMainMenu.ResumeLayout(false);
            this.panelMainMenu.PerformLayout();
            this.panelWightAlghoritms.ResumeLayout(false);
            this.panelAlghoritms.ResumeLayout(false);
            this.panelTypeOrient.ResumeLayout(false);
            this.panelTypeGraph.ResumeLayout(false);
            this.panelMenuForMatrix.ResumeLayout(false);
            this.panelWaysSelected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Panel panelForGraphics;
        private System.Windows.Forms.Panel panelForMatrix;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.Button butWaysSelected;
        private System.Windows.Forms.Button buttonAlghoritms;
        private System.Windows.Forms.Button buttonOrientMen;
        private System.Windows.Forms.Button buttonTypeGraph;
        private System.Windows.Forms.Panel panelTypeGraph;
        private System.Windows.Forms.Panel panelWaysSelected;
        private System.Windows.Forms.Panel panelAlghoritms;
        private System.Windows.Forms.Panel panelTypeOrient;
        private myButton butNotOrient;
        private myButton buttOrient;
        private myButton butWeightGraph;
        private myButton butEzGraph;
        private myButton butMatrType;
        private myButton butGrpahicWay;
        private System.Windows.Forms.Button butStronglyConponents;
        private System.Windows.Forms.Panel panelMenuForMatrix;
        private System.Windows.Forms.Button butAddVerMatr;
        private System.Windows.Forms.Button butRemoveVerMatr;
        private System.Windows.Forms.Button butHumilton;
        private System.Windows.Forms.Button butEyler;
        private System.Windows.Forms.Panel panelWightAlghoritms;
        private myButton buttonOstovTree;
        private myButton buttonFloida;
        private myButton buttonDeikstri;
        private System.Windows.Forms.Button buttonPaintGraph;
        private System.Windows.Forms.TextBox textBoxOutput;
        private myButton butCenterAndEtc;
        private System.Windows.Forms.Button butWPaint;
        private System.Windows.Forms.Button butWHumilton;
        private System.Windows.Forms.Button butWEyler;
        private System.Windows.Forms.Button butWStronglyComps;
        private AxAcroPDFLib.AxAcroPDF reader;
    }
}

