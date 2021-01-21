namespace IsleOfToxinXI
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.highestSamp = new System.Windows.Forms.Label();
            this.highestInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.currSamp = new System.Windows.Forms.Label();
            this.currInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AccessibleName = "Button1";
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Location = new System.Drawing.Point(115, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleName = "Button2";
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.Location = new System.Drawing.Point(330, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.AccessibleName = "TextField";
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.textBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(115, 121);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(509, 171);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = ">Press Start to Begin.";
            // 
            // button3
            // 
            this.button3.AccessibleName = "Button3";
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button3.Location = new System.Drawing.Point(549, 330);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleName = "HealthBar";
            this.progressBar1.BackColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(115, 72);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 50;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(221, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "HP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.OrangeRed;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(646, 121);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button4.Location = new System.Drawing.Point(549, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.groupBox1.Controls.Add(this.highestSamp);
            this.groupBox1.Controls.Add(this.highestInfo);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(646, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 54);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Highest Scores";
            // 
            // highestSamp
            // 
            this.highestSamp.BackColor = System.Drawing.Color.RoyalBlue;
            this.highestSamp.Location = new System.Drawing.Point(6, 31);
            this.highestSamp.Name = "highestSamp";
            this.highestSamp.Size = new System.Drawing.Size(100, 18);
            this.highestSamp.TabIndex = 1;
            this.highestSamp.Text = "Samples:";
            // 
            // highestInfo
            // 
            this.highestInfo.BackColor = System.Drawing.Color.Violet;
            this.highestInfo.Location = new System.Drawing.Point(6, 16);
            this.highestInfo.Name = "highestInfo";
            this.highestInfo.Size = new System.Drawing.Size(100, 15);
            this.highestInfo.TabIndex = 0;
            this.highestInfo.Text = "Information:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Green;
            this.groupBox2.Controls.Add(this.currSamp);
            this.groupBox2.Controls.Add(this.currInfo);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(646, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 58);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Scores";
            // 
            // currSamp
            // 
            this.currSamp.BackColor = System.Drawing.Color.DarkRed;
            this.currSamp.Location = new System.Drawing.Point(6, 29);
            this.currSamp.Name = "currSamp";
            this.currSamp.Size = new System.Drawing.Size(100, 13);
            this.currSamp.TabIndex = 1;
            this.currSamp.Text = "Samples:";
            // 
            // currInfo
            // 
            this.currInfo.BackColor = System.Drawing.Color.Indigo;
            this.currInfo.Location = new System.Drawing.Point(6, 16);
            this.currInfo.Name = "currInfo";
            this.currInfo.Size = new System.Drawing.Size(100, 13);
            this.currInfo.TabIndex = 0;
            this.currInfo.Text = "Information:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Isle Of Toxin XI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label currInfo;
        private System.Windows.Forms.Label currSamp;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.Label highestInfo;
        private System.Windows.Forms.Label highestSamp;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.CheckedListBox checkedListBox1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ProgressBar progressBar1;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        #endregion
    }
}