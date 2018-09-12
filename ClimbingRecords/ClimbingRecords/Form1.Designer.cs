namespace ClimbingRecords
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Items.AddRange(new object[] {
            "1: Top Corner Jug",
            "2: Outside Sloper (Square)",
            "3: Inside Sloper (Round)",
            "4: Top Deep Pocket (3 Finger)",
            "5: Medium Edge (4 Finger)",
            "6: Shallow Edge (4 Finger)",
            "7: Deep Flat Edge (4 Finger)",
            "8: Extra Shallow Edge (3 Finger)",
            "9: Deep Flat Pocket (3 Finger)",
            "10: Medium Edge (4 Finger)",
            "11: Extra Shallow Edge (4 Finger)",
            "12: Deep Flat Pocket (2 Finger)",
            "13: Extra Shallow Pocket (2 Finger)",
            "14: Top Centre Jug",
            "15: Top Centre Pocket (4 Finger)",
            "16: Top Centre Pocket (3 Finger)",
            "17: Bottom Centre Pocket (3 Finger)",
            "18: Bottom Centre Pocket (2 Finger)"});
            this.comboBox1.Location = new System.Drawing.Point(101, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Left Hand Hold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Right Hand Hold";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 13;
            this.comboBox2.Items.AddRange(new object[] {
            "1: Top Corner Jug",
            "2: Outside Sloper (Square)",
            "3: Inside Sloper (Round)",
            "4: Top Deep Pocket (3 Finger)",
            "5: Medium Edge (4 Finger)",
            "6: Shallow Edge (4 Finger)",
            "7: Deep Flat Edge (4 Finger)",
            "8: Extra Shallow Edge (3 Finger)",
            "9: Deep Flat Pocket (3 Finger)",
            "10: Medium Edge (4 Finger)",
            "11: Extra Shallow Edge (4 Finger)",
            "12: Deep Flat Pocket (2 Finger)",
            "13: Extra Shallow Pocket (2 Finger)",
            "14: Top Centre Jug",
            "15: Top Centre Pocket (4 Finger)",
            "16: Top Centre Pocket (3 Finger)",
            "17: Bottom Centre Pocket (3 Finger)",
            "18: Bottom Centre Pocket (2 Finger)"});
            this.comboBox2.Location = new System.Drawing.Point(101, 47);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(154, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClimbingRecords.Properties.Resources.Board;
            this.pictureBox1.Location = new System.Drawing.Point(10, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1122, 394);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1144, 423);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 441);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1144, 381);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(270, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search Term";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1120, 282);
            this.dataGridView1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1168, 834);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Hang Board Records";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

