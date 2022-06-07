namespace Professional_GUI
{
    partial class DerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DerForm));
            this.FunctionTextBox = new System.Windows.Forms.TextBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.DiffTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Button();
            this.Opening_parenthesis = new System.Windows.Forms.Button();
            this.Closing_parenthesis = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.One = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Div = new System.Windows.Forms.Button();
            this.Mul = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.Exponentiation = new System.Windows.Forms.Button();
            this.Sinus = new System.Windows.Forms.Button();
            this.Cosinus = new System.Windows.Forms.Button();
            this.Tg = new System.Windows.Forms.Button();
            this.Ctg = new System.Windows.Forms.Button();
            this.Arcsin = new System.Windows.Forms.Button();
            this.Arccos = new System.Windows.Forms.Button();
            this.Arctg = new System.Windows.Forms.Button();
            this.Arcctg = new System.Windows.Forms.Button();
            this.Sh = new System.Windows.Forms.Button();
            this.Ch = new System.Windows.Forms.Button();
            this.Arcsh = new System.Windows.Forms.Button();
            this.Arcch = new System.Windows.Forms.Button();
            this.Ln = new System.Windows.Forms.Button();
            this.Lg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.Point = new System.Windows.Forms.Button();
            this.reader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.reader)).BeginInit();
            this.SuspendLayout();
            // 
            // FunctionTextBox
            // 
            this.FunctionTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FunctionTextBox.Location = new System.Drawing.Point(170, 146);
            this.FunctionTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.FunctionTextBox.Name = "FunctionTextBox";
            this.FunctionTextBox.Size = new System.Drawing.Size(419, 28);
            this.FunctionTextBox.TabIndex = 0;
            // 
            // Calculate
            // 
            this.Calculate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Calculate.Location = new System.Drawing.Point(510, 247);
            this.Calculate.Margin = new System.Windows.Forms.Padding(5);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 35);
            this.Calculate.TabIndex = 1;
            this.Calculate.Text = "Calc";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // DiffTextBox
            // 
            this.DiffTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DiffTextBox.Location = new System.Drawing.Point(170, 206);
            this.DiffTextBox.Name = "DiffTextBox";
            this.DiffTextBox.ReadOnly = true;
            this.DiffTextBox.Size = new System.Drawing.Size(419, 28);
            this.DiffTextBox.TabIndex = 4;
            this.DiffTextBox.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите функцию";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Результат";
            this.label2.Visible = false;
            // 
            // X
            // 
            this.X.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.X.Location = new System.Drawing.Point(170, 251);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(35, 35);
            this.X.TabIndex = 7;
            this.X.Text = "x";
            this.X.UseVisualStyleBackColor = true;
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // Opening_parenthesis
            // 
            this.Opening_parenthesis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Opening_parenthesis.Location = new System.Drawing.Point(210, 251);
            this.Opening_parenthesis.Name = "Opening_parenthesis";
            this.Opening_parenthesis.Size = new System.Drawing.Size(35, 35);
            this.Opening_parenthesis.TabIndex = 8;
            this.Opening_parenthesis.Text = "(";
            this.Opening_parenthesis.UseVisualStyleBackColor = true;
            this.Opening_parenthesis.Click += new System.EventHandler(this.Opening_parenthesis_Click);
            // 
            // Closing_parenthesis
            // 
            this.Closing_parenthesis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Closing_parenthesis.Location = new System.Drawing.Point(250, 251);
            this.Closing_parenthesis.Name = "Closing_parenthesis";
            this.Closing_parenthesis.Size = new System.Drawing.Size(35, 35);
            this.Closing_parenthesis.TabIndex = 9;
            this.Closing_parenthesis.Text = ")";
            this.Closing_parenthesis.UseVisualStyleBackColor = true;
            this.Closing_parenthesis.Click += new System.EventHandler(this.Closing_parenthesis_Click);
            // 
            // Seven
            // 
            this.Seven.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Seven.Location = new System.Drawing.Point(170, 292);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(35, 35);
            this.Seven.TabIndex = 10;
            this.Seven.Text = "7";
            this.Seven.UseVisualStyleBackColor = true;
            this.Seven.Click += new System.EventHandler(this.Seven_Click);
            // 
            // Eight
            // 
            this.Eight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Eight.Location = new System.Drawing.Point(210, 292);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(35, 35);
            this.Eight.TabIndex = 11;
            this.Eight.Text = "8";
            this.Eight.UseVisualStyleBackColor = true;
            this.Eight.Click += new System.EventHandler(this.Eight_Click);
            // 
            // Nine
            // 
            this.Nine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Nine.Location = new System.Drawing.Point(250, 292);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(35, 35);
            this.Nine.TabIndex = 12;
            this.Nine.Text = "9";
            this.Nine.UseVisualStyleBackColor = true;
            this.Nine.Click += new System.EventHandler(this.Nine_Click);
            // 
            // Four
            // 
            this.Four.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Four.Location = new System.Drawing.Point(170, 333);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(35, 35);
            this.Four.TabIndex = 13;
            this.Four.Text = "4";
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.Four_Click);
            // 
            // Five
            // 
            this.Five.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Five.Location = new System.Drawing.Point(210, 333);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(35, 35);
            this.Five.TabIndex = 14;
            this.Five.Text = "5";
            this.Five.UseVisualStyleBackColor = true;
            this.Five.Click += new System.EventHandler(this.Five_Click);
            // 
            // Six
            // 
            this.Six.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Six.Location = new System.Drawing.Point(250, 333);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(35, 35);
            this.Six.TabIndex = 15;
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.Six_Click);
            // 
            // One
            // 
            this.One.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.One.Location = new System.Drawing.Point(170, 374);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(35, 35);
            this.One.TabIndex = 16;
            this.One.Text = "1";
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.One_Click);
            // 
            // Two
            // 
            this.Two.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Two.Location = new System.Drawing.Point(210, 374);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(35, 35);
            this.Two.TabIndex = 17;
            this.Two.Text = "2";
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.Two_Click);
            // 
            // Three
            // 
            this.Three.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Three.Location = new System.Drawing.Point(250, 374);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(35, 35);
            this.Three.TabIndex = 18;
            this.Three.Text = "3";
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.Three_Click);
            // 
            // Div
            // 
            this.Div.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Div.Location = new System.Drawing.Point(291, 292);
            this.Div.Name = "Div";
            this.Div.Size = new System.Drawing.Size(35, 35);
            this.Div.TabIndex = 19;
            this.Div.Text = "/";
            this.Div.UseVisualStyleBackColor = true;
            this.Div.Click += new System.EventHandler(this.Div_Click);
            // 
            // Mul
            // 
            this.Mul.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Mul.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Mul.Location = new System.Drawing.Point(291, 333);
            this.Mul.Name = "Mul";
            this.Mul.Size = new System.Drawing.Size(35, 35);
            this.Mul.TabIndex = 20;
            this.Mul.Text = "*";
            this.Mul.UseVisualStyleBackColor = true;
            this.Mul.Click += new System.EventHandler(this.Mul_Click);
            // 
            // Minus
            // 
            this.Minus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Minus.Location = new System.Drawing.Point(291, 374);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(35, 35);
            this.Minus.TabIndex = 21;
            this.Minus.Text = "—";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // Plus
            // 
            this.Plus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Plus.Location = new System.Drawing.Point(291, 415);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(35, 35);
            this.Plus.TabIndex = 22;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // Exponentiation
            // 
            this.Exponentiation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exponentiation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Exponentiation.Location = new System.Drawing.Point(332, 333);
            this.Exponentiation.Name = "Exponentiation";
            this.Exponentiation.Size = new System.Drawing.Size(35, 35);
            this.Exponentiation.TabIndex = 23;
            this.Exponentiation.Text = "^";
            this.Exponentiation.UseVisualStyleBackColor = true;
            this.Exponentiation.Click += new System.EventHandler(this.Exponentiation_Click);
            // 
            // Sinus
            // 
            this.Sinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sinus.Location = new System.Drawing.Point(373, 292);
            this.Sinus.Name = "Sinus";
            this.Sinus.Size = new System.Drawing.Size(50, 35);
            this.Sinus.TabIndex = 24;
            this.Sinus.Text = "sin";
            this.Sinus.UseVisualStyleBackColor = true;
            this.Sinus.Click += new System.EventHandler(this.Sinus_Click);
            // 
            // Cosinus
            // 
            this.Cosinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cosinus.Location = new System.Drawing.Point(373, 333);
            this.Cosinus.Name = "Cosinus";
            this.Cosinus.Size = new System.Drawing.Size(50, 35);
            this.Cosinus.TabIndex = 25;
            this.Cosinus.Text = "cos";
            this.Cosinus.UseVisualStyleBackColor = true;
            this.Cosinus.Click += new System.EventHandler(this.Cosinus_Click);
            // 
            // Tg
            // 
            this.Tg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Tg.Location = new System.Drawing.Point(373, 374);
            this.Tg.Name = "Tg";
            this.Tg.Size = new System.Drawing.Size(50, 35);
            this.Tg.TabIndex = 26;
            this.Tg.Text = "tg";
            this.Tg.UseVisualStyleBackColor = true;
            this.Tg.Click += new System.EventHandler(this.Tg_Click);
            // 
            // Ctg
            // 
            this.Ctg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Ctg.Location = new System.Drawing.Point(373, 415);
            this.Ctg.Name = "Ctg";
            this.Ctg.Size = new System.Drawing.Size(50, 35);
            this.Ctg.TabIndex = 27;
            this.Ctg.Text = "ctg";
            this.Ctg.UseVisualStyleBackColor = true;
            this.Ctg.Click += new System.EventHandler(this.Ctg_Click);
            // 
            // Arcsin
            // 
            this.Arcsin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Arcsin.Location = new System.Drawing.Point(429, 292);
            this.Arcsin.Name = "Arcsin";
            this.Arcsin.Size = new System.Drawing.Size(75, 35);
            this.Arcsin.TabIndex = 28;
            this.Arcsin.Text = "arcsin";
            this.Arcsin.UseVisualStyleBackColor = true;
            this.Arcsin.Click += new System.EventHandler(this.Arcsin_Click);
            // 
            // Arccos
            // 
            this.Arccos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Arccos.Location = new System.Drawing.Point(429, 333);
            this.Arccos.Name = "Arccos";
            this.Arccos.Size = new System.Drawing.Size(75, 35);
            this.Arccos.TabIndex = 29;
            this.Arccos.Text = "arccos";
            this.Arccos.UseVisualStyleBackColor = true;
            this.Arccos.Click += new System.EventHandler(this.Arccos_Click);
            // 
            // Arctg
            // 
            this.Arctg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Arctg.Location = new System.Drawing.Point(429, 374);
            this.Arctg.Name = "Arctg";
            this.Arctg.Size = new System.Drawing.Size(75, 35);
            this.Arctg.TabIndex = 30;
            this.Arctg.Text = "arctg";
            this.Arctg.UseVisualStyleBackColor = true;
            this.Arctg.Click += new System.EventHandler(this.Arctg_Click);
            // 
            // Arcctg
            // 
            this.Arcctg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Arcctg.Location = new System.Drawing.Point(429, 415);
            this.Arcctg.Name = "Arcctg";
            this.Arcctg.Size = new System.Drawing.Size(75, 35);
            this.Arcctg.TabIndex = 31;
            this.Arcctg.Text = "arcctg";
            this.Arcctg.UseVisualStyleBackColor = true;
            this.Arcctg.Click += new System.EventHandler(this.Arcctg_Click);
            // 
            // Sh
            // 
            this.Sh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Sh.Location = new System.Drawing.Point(510, 292);
            this.Sh.Name = "Sh";
            this.Sh.Size = new System.Drawing.Size(75, 35);
            this.Sh.TabIndex = 32;
            this.Sh.Text = "sh";
            this.Sh.UseVisualStyleBackColor = true;
            this.Sh.Click += new System.EventHandler(this.Sh_Click);
            // 
            // Ch
            // 
            this.Ch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Ch.Location = new System.Drawing.Point(510, 333);
            this.Ch.Name = "Ch";
            this.Ch.Size = new System.Drawing.Size(75, 35);
            this.Ch.TabIndex = 33;
            this.Ch.Text = "ch";
            this.Ch.UseVisualStyleBackColor = true;
            this.Ch.Click += new System.EventHandler(this.Ch_Click);
            // 
            // Arcsh
            // 
            this.Arcsh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Arcsh.Location = new System.Drawing.Point(510, 374);
            this.Arcsh.Name = "Arcsh";
            this.Arcsh.Size = new System.Drawing.Size(75, 35);
            this.Arcsh.TabIndex = 34;
            this.Arcsh.Text = "arcsh";
            this.Arcsh.UseVisualStyleBackColor = true;
            this.Arcsh.Click += new System.EventHandler(this.Arcsh_Click);
            // 
            // Arcch
            // 
            this.Arcch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Arcch.Location = new System.Drawing.Point(510, 415);
            this.Arcch.Name = "Arcch";
            this.Arcch.Size = new System.Drawing.Size(75, 35);
            this.Arcch.TabIndex = 35;
            this.Arcch.Text = "arcch";
            this.Arcch.UseVisualStyleBackColor = true;
            this.Arcch.Click += new System.EventHandler(this.Arcch_Click);
            // 
            // Ln
            // 
            this.Ln.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Ln.Location = new System.Drawing.Point(332, 374);
            this.Ln.Name = "Ln";
            this.Ln.Size = new System.Drawing.Size(35, 35);
            this.Ln.TabIndex = 36;
            this.Ln.Text = "ln";
            this.Ln.UseVisualStyleBackColor = true;
            this.Ln.Click += new System.EventHandler(this.Ln_Click);
            // 
            // Lg
            // 
            this.Lg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lg.Location = new System.Drawing.Point(332, 415);
            this.Lg.Name = "Lg";
            this.Lg.Size = new System.Drawing.Size(35, 35);
            this.Lg.TabIndex = 37;
            this.Lg.Text = "lg";
            this.Lg.UseVisualStyleBackColor = true;
            this.Lg.Click += new System.EventHandler(this.Lg_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.button1.Location = new System.Drawing.Point(332, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 38;
            this.button1.Text = "☚";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Delete
            // 
            this.Delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Delete.Location = new System.Drawing.Point(429, 247);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 35);
            this.Delete.TabIndex = 39;
            this.Delete.Text = "CE";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Zero
            // 
            this.Zero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Zero.Location = new System.Drawing.Point(170, 415);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(35, 33);
            this.Zero.TabIndex = 40;
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.Zero_Click);
            // 
            // Point
            // 
            this.Point.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Point.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Point.Location = new System.Drawing.Point(210, 415);
            this.Point.Name = "Point";
            this.Point.Size = new System.Drawing.Size(34, 33);
            this.Point.TabIndex = 41;
            this.Point.Text = ",";
            this.Point.UseVisualStyleBackColor = true;
            this.Point.Click += new System.EventHandler(this.Point_Click);
            // 
            // reader
            // 
            this.reader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reader.Enabled = true;
            this.reader.Location = new System.Drawing.Point(0, 0);
            this.reader.Name = "reader";
            this.reader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reader.OcxState")));
            this.reader.Size = new System.Drawing.Size(752, 556);
            this.reader.TabIndex = 42;
            // 
            // DerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 556);
            this.Controls.Add(this.reader);
            this.Controls.Add(this.Point);
            this.Controls.Add(this.Zero);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lg);
            this.Controls.Add(this.Ln);
            this.Controls.Add(this.Arcch);
            this.Controls.Add(this.Arcsh);
            this.Controls.Add(this.Ch);
            this.Controls.Add(this.Sh);
            this.Controls.Add(this.Arcctg);
            this.Controls.Add(this.Arctg);
            this.Controls.Add(this.Arccos);
            this.Controls.Add(this.Arcsin);
            this.Controls.Add(this.Ctg);
            this.Controls.Add(this.Tg);
            this.Controls.Add(this.Cosinus);
            this.Controls.Add(this.Sinus);
            this.Controls.Add(this.Exponentiation);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.Minus);
            this.Controls.Add(this.Mul);
            this.Controls.Add(this.Div);
            this.Controls.Add(this.Three);
            this.Controls.Add(this.Two);
            this.Controls.Add(this.One);
            this.Controls.Add(this.Six);
            this.Controls.Add(this.Five);
            this.Controls.Add(this.Four);
            this.Controls.Add(this.Nine);
            this.Controls.Add(this.Eight);
            this.Controls.Add(this.Seven);
            this.Controls.Add(this.Closing_parenthesis);
            this.Controls.Add(this.Opening_parenthesis);
            this.Controls.Add(this.X);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DiffTextBox);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.FunctionTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DerForm";
            this.Text = "Производная функции";
            ((System.ComponentModel.ISupportInitialize)(this.reader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FunctionTextBox;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.TextBox DiffTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button X;
        private System.Windows.Forms.Button Opening_parenthesis;
        private System.Windows.Forms.Button Closing_parenthesis;
        private System.Windows.Forms.Button Seven;
        private System.Windows.Forms.Button Eight;
        private System.Windows.Forms.Button Nine;
        private System.Windows.Forms.Button Four;
        private System.Windows.Forms.Button Five;
        private System.Windows.Forms.Button Six;
        private System.Windows.Forms.Button One;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button Three;
        private System.Windows.Forms.Button Div;
        private System.Windows.Forms.Button Mul;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button Exponentiation;
        private System.Windows.Forms.Button Sinus;
        private System.Windows.Forms.Button Cosinus;
        private System.Windows.Forms.Button Tg;
        private System.Windows.Forms.Button Ctg;
        private System.Windows.Forms.Button Arcsin;
        private System.Windows.Forms.Button Arccos;
        private System.Windows.Forms.Button Arctg;
        private System.Windows.Forms.Button Arcctg;
        private System.Windows.Forms.Button Sh;
        private System.Windows.Forms.Button Ch;
        private System.Windows.Forms.Button Arcsh;
        private System.Windows.Forms.Button Arcch;
        private System.Windows.Forms.Button Ln;
        private System.Windows.Forms.Button Lg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Zero;
        private System.Windows.Forms.Button Point;
        private AxAcroPDFLib.AxAcroPDF reader;
    }
}

