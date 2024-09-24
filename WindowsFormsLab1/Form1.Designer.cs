namespace WindowsFormsLab1
{
    partial class Form1
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
            this.txtTerminals = new System.Windows.Forms.TextBox();
            this.txtNonTerminals = new System.Windows.Forms.TextBox();
            this.txtRules = new System.Windows.Forms.TextBox();
            this.txtStartSymbol = new System.Windows.Forms.TextBox();
            this.txtLeftBorder = new System.Windows.Forms.TextBox();
            this.txtRightBorder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTestValues = new System.Windows.Forms.Button();
            this.listBoxChains = new System.Windows.Forms.ListBox();
            this.btnBuildTree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTerminals
            // 
            this.txtTerminals.Location = new System.Drawing.Point(263, 32);
            this.txtTerminals.Name = "txtTerminals";
            this.txtTerminals.Size = new System.Drawing.Size(186, 20);
            this.txtTerminals.TabIndex = 0;
            // 
            // txtNonTerminals
            // 
            this.txtNonTerminals.Location = new System.Drawing.Point(263, 72);
            this.txtNonTerminals.Name = "txtNonTerminals";
            this.txtNonTerminals.Size = new System.Drawing.Size(186, 20);
            this.txtNonTerminals.TabIndex = 1;
            // 
            // txtRules
            // 
            this.txtRules.Location = new System.Drawing.Point(263, 119);
            this.txtRules.Multiline = true;
            this.txtRules.Name = "txtRules";
            this.txtRules.Size = new System.Drawing.Size(255, 151);
            this.txtRules.TabIndex = 2;
            // 
            // txtStartSymbol
            // 
            this.txtStartSymbol.Location = new System.Drawing.Point(267, 276);
            this.txtStartSymbol.Name = "txtStartSymbol";
            this.txtStartSymbol.Size = new System.Drawing.Size(65, 20);
            this.txtStartSymbol.TabIndex = 3;
            // 
            // txtLeftBorder
            // 
            this.txtLeftBorder.Location = new System.Drawing.Point(263, 309);
            this.txtLeftBorder.Name = "txtLeftBorder";
            this.txtLeftBorder.Size = new System.Drawing.Size(75, 20);
            this.txtLeftBorder.TabIndex = 4;
            // 
            // txtRightBorder
            // 
            this.txtRightBorder.Location = new System.Drawing.Point(446, 305);
            this.txtRightBorder.Name = "txtRightBorder";
            this.txtRightBorder.Size = new System.Drawing.Size(72, 20);
            this.txtRightBorder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Terminals:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Non-Terminals:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(267, 368);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(316, 214);
            this.txtOutput.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rules (A -> aB | bC):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Start Symbol:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Left border";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Right border:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(164, 366);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 13;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Generated Words:";
            // 
            // btnTestValues
            // 
            this.btnTestValues.Location = new System.Drawing.Point(164, 404);
            this.btnTestValues.Name = "btnTestValues";
            this.btnTestValues.Size = new System.Drawing.Size(75, 23);
            this.btnTestValues.TabIndex = 15;
            this.btnTestValues.Text = "TestValues";
            this.btnTestValues.UseVisualStyleBackColor = true;
            this.btnTestValues.Click += new System.EventHandler(this.btnTestValues_Click);
            // 
            // listBoxChains
            // 
            this.listBoxChains.FormattingEnabled = true;
            this.listBoxChains.Location = new System.Drawing.Point(604, 365);
            this.listBoxChains.Name = "listBoxChains";
            this.listBoxChains.Size = new System.Drawing.Size(380, 212);
            this.listBoxChains.TabIndex = 16;
            // 
            // btnBuildTree
            // 
            this.btnBuildTree.Location = new System.Drawing.Point(695, 336);
            this.btnBuildTree.Name = "btnBuildTree";
            this.btnBuildTree.Size = new System.Drawing.Size(115, 23);
            this.btnBuildTree.TabIndex = 17;
            this.btnBuildTree.Text = "Generate tree";
            this.btnBuildTree.UseVisualStyleBackColor = true;
            this.btnBuildTree.Click += new System.EventHandler(this.BtnBuildTree_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 583);
            this.Controls.Add(this.btnBuildTree);
            this.Controls.Add(this.listBoxChains);
            this.Controls.Add(this.btnTestValues);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRightBorder);
            this.Controls.Add(this.txtLeftBorder);
            this.Controls.Add(this.txtStartSymbol);
            this.Controls.Add(this.txtRules);
            this.Controls.Add(this.txtNonTerminals);
            this.Controls.Add(this.txtTerminals);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTerminals;
        private System.Windows.Forms.TextBox txtNonTerminals;
        private System.Windows.Forms.TextBox txtRules;
        private System.Windows.Forms.TextBox txtStartSymbol;
        private System.Windows.Forms.TextBox txtLeftBorder;
        private System.Windows.Forms.TextBox txtRightBorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTestValues;
        private System.Windows.Forms.ListBox listBoxChains;
        private System.Windows.Forms.Button btnBuildTree;
    }
}

