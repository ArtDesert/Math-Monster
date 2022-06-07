namespace Professional_GUI.Формы.Дискретная_математика
{
    partial class Combinatorics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Combinatorics));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.panelPermutations = new System.Windows.Forms.Panel();
            this.permutationsWithRelations = new myButton();
            this.permutationsWithoutRelations = new myButton();
            this.permutations = new System.Windows.Forms.Button();
            this.panelAccommodation = new System.Windows.Forms.Panel();
            this.accommodationWithRelations = new myButton();
            this.accommodationWithoutRelations = new myButton();
            this.accommodation = new System.Windows.Forms.Button();
            this.panelCombinations = new System.Windows.Forms.Panel();
            this.combinationsWithoutRepetitions = new myButton();
            this.combinationsWithRepetitions = new myButton();
            this.combinations = new System.Windows.Forms.Button();
            this.panelForCombinations = new System.Windows.Forms.Panel();
            this.textBoxCombs = new System.Windows.Forms.TextBox();
            this.textBoxCN = new System.Windows.Forms.TextBox();
            this.textBoxCM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelForPermutationsWithoutRelations = new System.Windows.Forms.Panel();
            this.textBoxPP = new System.Windows.Forms.TextBox();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.labelPWith = new System.Windows.Forms.Label();
            this.panelForPermutationsWithRelations = new System.Windows.Forms.Panel();
            this.minus = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxPwith = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reader = new AxAcroPDFLib.AxAcroPDF();
            this.panelMenu.SuspendLayout();
            this.panelPermutations.SuspendLayout();
            this.panelAccommodation.SuspendLayout();
            this.panelCombinations.SuspendLayout();
            this.panelForCombinations.SuspendLayout();
            this.panelForPermutationsWithoutRelations.SuspendLayout();
            this.panelForPermutationsWithRelations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reader)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(60)))));
            this.panelMenu.Controls.Add(this.buttonSolve);
            this.panelMenu.Controls.Add(this.panelPermutations);
            this.panelMenu.Controls.Add(this.permutations);
            this.panelMenu.Controls.Add(this.panelAccommodation);
            this.panelMenu.Controls.Add(this.accommodation);
            this.panelMenu.Controls.Add(this.panelCombinations);
            this.panelMenu.Controls.Add(this.combinations);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(185, 514);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSolve.FlatAppearance.BorderSize = 0;
            this.buttonSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSolve.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSolve.Location = new System.Drawing.Point(0, 474);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(185, 40);
            this.buttonSolve.TabIndex = 6;
            this.buttonSolve.Text = "Вычислить";
            this.buttonSolve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // panelPermutations
            // 
            this.panelPermutations.Controls.Add(this.permutationsWithRelations);
            this.panelPermutations.Controls.Add(this.permutationsWithoutRelations);
            this.panelPermutations.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPermutations.Location = new System.Drawing.Point(0, 310);
            this.panelPermutations.Name = "panelPermutations";
            this.panelPermutations.Size = new System.Drawing.Size(185, 80);
            this.panelPermutations.TabIndex = 5;
            this.panelPermutations.Visible = false;
            // 
            // permutationsWithRelations
            // 
            this.permutationsWithRelations.Dock = System.Windows.Forms.DockStyle.Top;
            this.permutationsWithRelations.FlatAppearance.BorderSize = 0;
            this.permutationsWithRelations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.permutationsWithRelations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.permutationsWithRelations.ForeColor = System.Drawing.Color.Gainsboro;
            this.permutationsWithRelations.Location = new System.Drawing.Point(0, 40);
            this.permutationsWithRelations.Name = "permutationsWithRelations";
            this.permutationsWithRelations.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.permutationsWithRelations.Size = new System.Drawing.Size(185, 40);
            this.permutationsWithRelations.TabIndex = 3;
            this.permutationsWithRelations.Text = "С повторениями";
            this.permutationsWithRelations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.permutationsWithRelations.UseVisualStyleBackColor = true;
            this.permutationsWithRelations.Click += new System.EventHandler(this.permutationsWithRelations_Click);
            // 
            // permutationsWithoutRelations
            // 
            this.permutationsWithoutRelations.Dock = System.Windows.Forms.DockStyle.Top;
            this.permutationsWithoutRelations.FlatAppearance.BorderSize = 0;
            this.permutationsWithoutRelations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.permutationsWithoutRelations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.permutationsWithoutRelations.ForeColor = System.Drawing.Color.Gainsboro;
            this.permutationsWithoutRelations.Location = new System.Drawing.Point(0, 0);
            this.permutationsWithoutRelations.Name = "permutationsWithoutRelations";
            this.permutationsWithoutRelations.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.permutationsWithoutRelations.Size = new System.Drawing.Size(185, 40);
            this.permutationsWithoutRelations.TabIndex = 2;
            this.permutationsWithoutRelations.Text = "Без повторений";
            this.permutationsWithoutRelations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.permutationsWithoutRelations.UseVisualStyleBackColor = true;
            this.permutationsWithoutRelations.Click += new System.EventHandler(this.permutationsWithoutRelations_Click);
            // 
            // permutations
            // 
            this.permutations.Dock = System.Windows.Forms.DockStyle.Top;
            this.permutations.FlatAppearance.BorderSize = 0;
            this.permutations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.permutations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.permutations.ForeColor = System.Drawing.Color.Gainsboro;
            this.permutations.Location = new System.Drawing.Point(0, 260);
            this.permutations.Name = "permutations";
            this.permutations.Size = new System.Drawing.Size(185, 50);
            this.permutations.TabIndex = 4;
            this.permutations.Text = "Перестановки";
            this.permutations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.permutations.UseVisualStyleBackColor = true;
            this.permutations.Click += new System.EventHandler(this.permutations_Click);
            // 
            // panelAccommodation
            // 
            this.panelAccommodation.Controls.Add(this.accommodationWithRelations);
            this.panelAccommodation.Controls.Add(this.accommodationWithoutRelations);
            this.panelAccommodation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAccommodation.Location = new System.Drawing.Point(0, 180);
            this.panelAccommodation.Name = "panelAccommodation";
            this.panelAccommodation.Size = new System.Drawing.Size(185, 80);
            this.panelAccommodation.TabIndex = 3;
            this.panelAccommodation.Visible = false;
            // 
            // accommodationWithRelations
            // 
            this.accommodationWithRelations.Dock = System.Windows.Forms.DockStyle.Top;
            this.accommodationWithRelations.FlatAppearance.BorderSize = 0;
            this.accommodationWithRelations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accommodationWithRelations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accommodationWithRelations.ForeColor = System.Drawing.Color.Gainsboro;
            this.accommodationWithRelations.Location = new System.Drawing.Point(0, 40);
            this.accommodationWithRelations.Name = "accommodationWithRelations";
            this.accommodationWithRelations.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.accommodationWithRelations.Size = new System.Drawing.Size(185, 40);
            this.accommodationWithRelations.TabIndex = 3;
            this.accommodationWithRelations.Text = "С повторениями";
            this.accommodationWithRelations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accommodationWithRelations.UseVisualStyleBackColor = true;
            this.accommodationWithRelations.Click += new System.EventHandler(this.accommodationWithRelations_Click);
            // 
            // accommodationWithoutRelations
            // 
            this.accommodationWithoutRelations.Dock = System.Windows.Forms.DockStyle.Top;
            this.accommodationWithoutRelations.FlatAppearance.BorderSize = 0;
            this.accommodationWithoutRelations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accommodationWithoutRelations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accommodationWithoutRelations.ForeColor = System.Drawing.Color.Gainsboro;
            this.accommodationWithoutRelations.Location = new System.Drawing.Point(0, 0);
            this.accommodationWithoutRelations.Name = "accommodationWithoutRelations";
            this.accommodationWithoutRelations.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.accommodationWithoutRelations.Size = new System.Drawing.Size(185, 40);
            this.accommodationWithoutRelations.TabIndex = 2;
            this.accommodationWithoutRelations.Text = "Без повторениями";
            this.accommodationWithoutRelations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accommodationWithoutRelations.UseVisualStyleBackColor = true;
            this.accommodationWithoutRelations.Click += new System.EventHandler(this.accommodationWithoutRelations_Click);
            // 
            // accommodation
            // 
            this.accommodation.Dock = System.Windows.Forms.DockStyle.Top;
            this.accommodation.FlatAppearance.BorderSize = 0;
            this.accommodation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accommodation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accommodation.ForeColor = System.Drawing.Color.Gainsboro;
            this.accommodation.Location = new System.Drawing.Point(0, 130);
            this.accommodation.Name = "accommodation";
            this.accommodation.Size = new System.Drawing.Size(185, 50);
            this.accommodation.TabIndex = 2;
            this.accommodation.Text = "Размещения";
            this.accommodation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accommodation.UseVisualStyleBackColor = true;
            this.accommodation.Click += new System.EventHandler(this.accommodation_Click);
            // 
            // panelCombinations
            // 
            this.panelCombinations.Controls.Add(this.combinationsWithoutRepetitions);
            this.panelCombinations.Controls.Add(this.combinationsWithRepetitions);
            this.panelCombinations.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCombinations.Location = new System.Drawing.Point(0, 50);
            this.panelCombinations.Name = "panelCombinations";
            this.panelCombinations.Size = new System.Drawing.Size(185, 80);
            this.panelCombinations.TabIndex = 1;
            this.panelCombinations.Visible = false;
            // 
            // combinationsWithoutRepetitions
            // 
            this.combinationsWithoutRepetitions.Dock = System.Windows.Forms.DockStyle.Top;
            this.combinationsWithoutRepetitions.FlatAppearance.BorderSize = 0;
            this.combinationsWithoutRepetitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combinationsWithoutRepetitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.combinationsWithoutRepetitions.ForeColor = System.Drawing.Color.Gainsboro;
            this.combinationsWithoutRepetitions.Location = new System.Drawing.Point(0, 40);
            this.combinationsWithoutRepetitions.Name = "combinationsWithoutRepetitions";
            this.combinationsWithoutRepetitions.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.combinationsWithoutRepetitions.Size = new System.Drawing.Size(185, 40);
            this.combinationsWithoutRepetitions.TabIndex = 3;
            this.combinationsWithoutRepetitions.Text = "С повторениями";
            this.combinationsWithoutRepetitions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.combinationsWithoutRepetitions.UseVisualStyleBackColor = true;
            this.combinationsWithoutRepetitions.Click += new System.EventHandler(this.combinationsWithoutRepetitions_Click);
            // 
            // combinationsWithRepetitions
            // 
            this.combinationsWithRepetitions.Dock = System.Windows.Forms.DockStyle.Top;
            this.combinationsWithRepetitions.FlatAppearance.BorderSize = 0;
            this.combinationsWithRepetitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combinationsWithRepetitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.combinationsWithRepetitions.ForeColor = System.Drawing.Color.Gainsboro;
            this.combinationsWithRepetitions.Location = new System.Drawing.Point(0, 0);
            this.combinationsWithRepetitions.Name = "combinationsWithRepetitions";
            this.combinationsWithRepetitions.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.combinationsWithRepetitions.Size = new System.Drawing.Size(185, 40);
            this.combinationsWithRepetitions.TabIndex = 2;
            this.combinationsWithRepetitions.Text = "Без повторений";
            this.combinationsWithRepetitions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.combinationsWithRepetitions.UseVisualStyleBackColor = true;
            this.combinationsWithRepetitions.Click += new System.EventHandler(this.combinationsWithRepetitions_Click);
            // 
            // combinations
            // 
            this.combinations.Dock = System.Windows.Forms.DockStyle.Top;
            this.combinations.FlatAppearance.BorderSize = 0;
            this.combinations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.combinations.ForeColor = System.Drawing.Color.Gainsboro;
            this.combinations.Location = new System.Drawing.Point(0, 0);
            this.combinations.Name = "combinations";
            this.combinations.Size = new System.Drawing.Size(185, 50);
            this.combinations.TabIndex = 1;
            this.combinations.Text = "Сочетания";
            this.combinations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.combinations.UseVisualStyleBackColor = true;
            this.combinations.Click += new System.EventHandler(this.combinations_Click);
            // 
            // panelForCombinations
            // 
            this.panelForCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForCombinations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.panelForCombinations.Controls.Add(this.textBoxCombs);
            this.panelForCombinations.Controls.Add(this.textBoxCN);
            this.panelForCombinations.Controls.Add(this.textBoxCM);
            this.panelForCombinations.Controls.Add(this.label1);
            this.panelForCombinations.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelForCombinations.Location = new System.Drawing.Point(186, 0);
            this.panelForCombinations.Name = "panelForCombinations";
            this.panelForCombinations.Size = new System.Drawing.Size(717, 208);
            this.panelForCombinations.TabIndex = 1;
            this.panelForCombinations.Visible = false;
            this.panelForCombinations.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForCombinations_Paint);
            // 
            // textBoxCombs
            // 
            this.textBoxCombs.BackColor = System.Drawing.Color.White;
            this.textBoxCombs.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCombs.Location = new System.Drawing.Point(279, 86);
            this.textBoxCombs.Name = "textBoxCombs";
            this.textBoxCombs.ReadOnly = true;
            this.textBoxCombs.Size = new System.Drawing.Size(253, 44);
            this.textBoxCombs.TabIndex = 4;
            this.textBoxCombs.WordWrap = false;
            // 
            // textBoxCN
            // 
            this.textBoxCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCN.Location = new System.Drawing.Point(191, 130);
            this.textBoxCN.Name = "textBoxCN";
            this.textBoxCN.Size = new System.Drawing.Size(26, 26);
            this.textBoxCN.TabIndex = 2;
            this.textBoxCN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCM
            // 
            this.textBoxCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCM.Location = new System.Drawing.Point(191, 57);
            this.textBoxCM.Name = "textBoxCM";
            this.textBoxCM.Size = new System.Drawing.Size(26, 26);
            this.textBoxCM.TabIndex = 1;
            this.textBoxCM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(123, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 98);
            this.label1.TabIndex = 0;
            this.label1.Text = "С =";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForPermutationsWithoutRelations
            // 
            this.panelForPermutationsWithoutRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForPermutationsWithoutRelations.Controls.Add(this.textBoxPP);
            this.panelForPermutationsWithoutRelations.Controls.Add(this.textBoxP);
            this.panelForPermutationsWithoutRelations.Controls.Add(this.labelPWith);
            this.panelForPermutationsWithoutRelations.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelForPermutationsWithoutRelations.ForeColor = System.Drawing.Color.Black;
            this.panelForPermutationsWithoutRelations.Location = new System.Drawing.Point(186, 0);
            this.panelForPermutationsWithoutRelations.Name = "panelForPermutationsWithoutRelations";
            this.panelForPermutationsWithoutRelations.Size = new System.Drawing.Size(717, 208);
            this.panelForPermutationsWithoutRelations.TabIndex = 5;
            this.panelForPermutationsWithoutRelations.Visible = false;
            // 
            // textBoxPP
            // 
            this.textBoxPP.BackColor = System.Drawing.Color.White;
            this.textBoxPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPP.Location = new System.Drawing.Point(279, 90);
            this.textBoxPP.Name = "textBoxPP";
            this.textBoxPP.ReadOnly = true;
            this.textBoxPP.Size = new System.Drawing.Size(231, 44);
            this.textBoxPP.TabIndex = 4;
            this.textBoxPP.WordWrap = false;
            // 
            // textBoxP
            // 
            this.textBoxP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxP.Location = new System.Drawing.Point(191, 124);
            this.textBoxP.Multiline = true;
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(26, 25);
            this.textBoxP.TabIndex = 2;
            this.textBoxP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPWith
            // 
            this.labelPWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPWith.Location = new System.Drawing.Point(123, 61);
            this.labelPWith.Name = "labelPWith";
            this.labelPWith.Size = new System.Drawing.Size(176, 98);
            this.labelPWith.TabIndex = 0;
            this.labelPWith.Text = "P =";
            this.labelPWith.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForPermutationsWithRelations
            // 
            this.panelForPermutationsWithRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForPermutationsWithRelations.Controls.Add(this.minus);
            this.panelForPermutationsWithRelations.Controls.Add(this.plus);
            this.panelForPermutationsWithRelations.Controls.Add(this.dataGridView1);
            this.panelForPermutationsWithRelations.Controls.Add(this.textBoxPwith);
            this.panelForPermutationsWithRelations.Controls.Add(this.label3);
            this.panelForPermutationsWithRelations.ForeColor = System.Drawing.Color.Black;
            this.panelForPermutationsWithRelations.Location = new System.Drawing.Point(186, 0);
            this.panelForPermutationsWithRelations.Name = "panelForPermutationsWithRelations";
            this.panelForPermutationsWithRelations.Size = new System.Drawing.Size(717, 208);
            this.panelForPermutationsWithRelations.TabIndex = 6;
            this.panelForPermutationsWithRelations.Visible = false;
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.Color.White;
            this.minus.Location = new System.Drawing.Point(279, 140);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(27, 23);
            this.minus.TabIndex = 7;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = false;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // plus
            // 
            this.plus.BackColor = System.Drawing.Color.White;
            this.plus.Location = new System.Drawing.Point(246, 140);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(27, 23);
            this.plus.TabIndex = 6;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = false;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(156, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(84, 41);
            this.dataGridView1.TabIndex = 5;
            // 
            // textBoxPwith
            // 
            this.textBoxPwith.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxPwith.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPwith.Location = new System.Drawing.Point(273, 90);
            this.textBoxPwith.Name = "textBoxPwith";
            this.textBoxPwith.ReadOnly = true;
            this.textBoxPwith.Size = new System.Drawing.Size(279, 44);
            this.textBoxPwith.TabIndex = 4;
            this.textBoxPwith.WordWrap = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(117, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 98);
            this.label3.TabIndex = 0;
            this.label3.Text = "P   =";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reader
            // 
            this.reader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reader.Enabled = true;
            this.reader.Location = new System.Drawing.Point(10, 0);
            this.reader.Name = "reader";
            this.reader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reader.OcxState")));
            this.reader.Size = new System.Drawing.Size(896, 514);
            this.reader.TabIndex = 7;
            // 
            // Combinatorics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(906, 514);
            this.Controls.Add(this.reader);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelForPermutationsWithRelations);
            this.Controls.Add(this.panelForPermutationsWithoutRelations);
            this.Controls.Add(this.panelForCombinations);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "Combinatorics";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Text = "Комбинаторика";
            this.panelMenu.ResumeLayout(false);
            this.panelPermutations.ResumeLayout(false);
            this.panelAccommodation.ResumeLayout(false);
            this.panelCombinations.ResumeLayout(false);
            this.panelForCombinations.ResumeLayout(false);
            this.panelForCombinations.PerformLayout();
            this.panelForPermutationsWithoutRelations.ResumeLayout(false);
            this.panelForPermutationsWithoutRelations.PerformLayout();
            this.panelForPermutationsWithRelations.ResumeLayout(false);
            this.panelForPermutationsWithRelations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button combinations;
        private System.Windows.Forms.Panel panelCombinations;
        private myButton combinationsWithoutRepetitions;
        private myButton combinationsWithRepetitions;
        private System.Windows.Forms.Panel panelPermutations;
        private myButton permutationsWithRelations;
        private myButton permutationsWithoutRelations;
        private System.Windows.Forms.Button permutations;
        private System.Windows.Forms.Panel panelAccommodation;
        private myButton accommodationWithRelations;
        private myButton accommodationWithoutRelations;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button accommodation;
        private System.Windows.Forms.Panel panelForCombinations;
        private System.Windows.Forms.Panel panelForPermutationsWithoutRelations;
        private System.Windows.Forms.TextBox textBoxPP;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.Label labelPWith;
        private System.Windows.Forms.TextBox textBoxCombs;
        private System.Windows.Forms.TextBox textBoxCN;
        private System.Windows.Forms.TextBox textBoxCM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelForPermutationsWithRelations;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxPwith;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button plus;
        private AxAcroPDFLib.AxAcroPDF reader;
    }
}