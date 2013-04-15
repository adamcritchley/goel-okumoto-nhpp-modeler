namespace WindowsFormsApplication1
{
    partial class main
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.number = new System.Windows.Forms.ColumnHeader();
            this.failure = new System.Windows.Forms.ColumnHeader();
            this.predicted = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.skipHeader = new System.Windows.Forms.CheckBox();
            this.skipLastItem = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.maxPrediction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.inCum = new System.Windows.Forms.CheckBox();
            this.outCum = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.failure,
            this.predicted});
            this.listView1.Location = new System.Drawing.Point(12, 75);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(617, 297);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // number
            // 
            this.number.Text = "Error No";
            this.number.Width = 78;
            // 
            // failure
            // 
            this.failure.Text = "Time to Failure";
            this.failure.Width = 126;
            // 
            // predicted
            // 
            this.predicted.Text = "NHPP Prediction";
            this.predicted.Width = 124;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Data...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Comma Seperated Values|*.csv";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(483, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 22);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save Predicted...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(483, 42);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 28);
            this.textBox2.TabIndex = 4;
            // 
            // skipHeader
            // 
            this.skipHeader.AutoSize = true;
            this.skipHeader.Location = new System.Drawing.Point(135, 16);
            this.skipHeader.Name = "skipHeader";
            this.skipHeader.Size = new System.Drawing.Size(89, 17);
            this.skipHeader.TabIndex = 5;
            this.skipHeader.Text = "Skip header?";
            this.skipHeader.UseVisualStyleBackColor = true;
            // 
            // skipLastItem
            // 
            this.skipLastItem.AutoSize = true;
            this.skipLastItem.Location = new System.Drawing.Point(135, 45);
            this.skipLastItem.Name = "skipLastItem";
            this.skipLastItem.Size = new System.Drawing.Size(94, 17);
            this.skipLastItem.TabIndex = 6;
            this.skipLastItem.Text = "Skip last item?";
            this.skipLastItem.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "Comma Seperated Values|*.csv";
            // 
            // maxPrediction
            // 
            this.maxPrediction.Location = new System.Drawing.Point(377, 16);
            this.maxPrediction.Name = "maxPrediction";
            this.maxPrediction.Size = new System.Drawing.Size(100, 20);
            this.maxPrediction.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Maximum Prediction";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(391, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Re-calc Prediction";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // inCum
            // 
            this.inCum.AutoSize = true;
            this.inCum.Location = new System.Drawing.Point(247, 16);
            this.inCum.Name = "inCum";
            this.inCum.Size = new System.Drawing.Size(110, 17);
            this.inCum.TabIndex = 10;
            this.inCum.Text = "Input cumulative?";
            this.inCum.UseVisualStyleBackColor = true;
            // 
            // outCum
            // 
            this.outCum.AutoSize = true;
            this.outCum.Location = new System.Drawing.Point(247, 42);
            this.outCum.Name = "outCum";
            this.outCum.Size = new System.Drawing.Size(118, 17);
            this.outCum.TabIndex = 11;
            this.outCum.Text = "Output cumulative?";
            this.outCum.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 384);
            this.Controls.Add(this.outCum);
            this.Controls.Add(this.inCum);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxPrediction);
            this.Controls.Add(this.skipLastItem);
            this.Controls.Add(this.skipHeader);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "main";
            this.Text = "Goel-Okumoto NHPP Modeling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader failure;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader predicted;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox skipHeader;
        private System.Windows.Forms.CheckBox skipLastItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox maxPrediction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox inCum;
        private System.Windows.Forms.CheckBox outCum;
    }
}

