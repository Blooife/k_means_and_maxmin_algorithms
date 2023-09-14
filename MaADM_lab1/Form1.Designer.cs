namespace MaADM_lab1
{
    partial class Form1
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
            this.bCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nuPoints = new System.Windows.Forms.NumericUpDown();
            this.nuClasses = new System.Windows.Forms.NumericUpDown();
            this.rbKMeans = new System.Windows.Forms.RadioButton();
            this.rbMaxMin = new System.Windows.Forms.RadioButton();
            this.rbKM = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nuPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // bCalculate
            // 
            this.bCalculate.Location = new System.Drawing.Point(520, 481);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(88, 35);
            this.bCalculate.TabIndex = 3;
            this.bCalculate.Text = "Рассчитать";
            this.bCalculate.UseVisualStyleBackColor = true;
            this.bCalculate.Click += new System.EventHandler(this.bCalculate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество точек";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество классов";
            // 
            // nuPoints
            // 
            this.nuPoints.Location = new System.Drawing.Point(28, 496);
            this.nuPoints.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nuPoints.Name = "nuPoints";
            this.nuPoints.Size = new System.Drawing.Size(100, 20);
            this.nuPoints.TabIndex = 6;
            // 
            // nuClasses
            // 
            this.nuClasses.Location = new System.Drawing.Point(144, 496);
            this.nuClasses.Name = "nuClasses";
            this.nuClasses.Size = new System.Drawing.Size(92, 20);
            this.nuClasses.TabIndex = 7;
            // 
            // rbKMeans
            // 
            this.rbKMeans.Location = new System.Drawing.Point(253, 492);
            this.rbKMeans.Name = "rbKMeans";
            this.rbKMeans.Size = new System.Drawing.Size(104, 24);
            this.rbKMeans.TabIndex = 8;
            this.rbKMeans.TabStop = true;
            this.rbKMeans.Text = "k-средних";
            this.rbKMeans.UseVisualStyleBackColor = true;
            this.rbKMeans.Click += new System.EventHandler(this.rbKMeans_Click);
            // 
            // rbMaxMin
            // 
            this.rbMaxMin.Location = new System.Drawing.Point(331, 492);
            this.rbMaxMin.Name = "rbMaxMin";
            this.rbMaxMin.Size = new System.Drawing.Size(104, 24);
            this.rbMaxMin.TabIndex = 9;
            this.rbMaxMin.TabStop = true;
            this.rbMaxMin.Text = "Максимин";
            this.rbMaxMin.UseVisualStyleBackColor = true;
            this.rbMaxMin.Click += new System.EventHandler(this.rbMaxMin_Click);
            // 
            // rbKM
            // 
            this.rbKM.Location = new System.Drawing.Point(410, 481);
            this.rbKM.Name = "rbKM";
            this.rbKM.Size = new System.Drawing.Size(104, 46);
            this.rbKM.TabIndex = 10;
            this.rbKM.TabStop = true;
            this.rbKM.Text = "k-средних\r\n+\r\nМаксимин";
            this.rbKM.UseVisualStyleBackColor = true;
            this.rbKM.Click += new System.EventHandler(this.rbKM_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(688, 528);
            this.Controls.Add(this.rbKM);
            this.Controls.Add(this.rbMaxMin);
            this.Controls.Add(this.rbKMeans);
            this.Controls.Add(this.nuClasses);
            this.Controls.Add(this.nuPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCalculate);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nuPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuClasses)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RadioButton rbKMeans;
        private System.Windows.Forms.RadioButton rbMaxMin;
        private System.Windows.Forms.RadioButton rbKM;

        private System.Windows.Forms.Button bCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuPoints;
        private System.Windows.Forms.NumericUpDown nuClasses;

        #endregion
    }
}