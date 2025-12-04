using System.Drawing;


namespace ModBus
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
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.txtBoxOutput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.IPAddr_textBox = new System.Windows.Forms.TextBox();
            this.InstanceID_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InstanceID_to_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(6, 21);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(504, 24);
            this.comboBoxPorts.TabIndex = 0;
            this.comboBoxPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxPorts_SelectedIndexChanged);
            this.comboBoxPorts.Click += new System.EventHandler(this.comboBoxPorts_Onclick);
            // 
            // txtBoxOutput
            // 
            this.txtBoxOutput.Location = new System.Drawing.Point(12, 12);
            this.txtBoxOutput.Multiline = true;
            this.txtBoxOutput.Name = "txtBoxOutput";
            this.txtBoxOutput.Size = new System.Drawing.Size(776, 224);
            this.txtBoxOutput.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(516, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(673, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 25);
            this.button3.TabIndex = 4;
            this.button3.Text = "Read";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(673, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 25);
            this.button4.TabIndex = 5;
            this.button4.Text = "Connect";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // IPAddr_textBox
            // 
            this.IPAddr_textBox.Location = new System.Drawing.Point(40, 80);
            this.IPAddr_textBox.Name = "IPAddr_textBox";
            this.IPAddr_textBox.Size = new System.Drawing.Size(627, 22);
            this.IPAddr_textBox.TabIndex = 6;
            this.IPAddr_textBox.Text = "192.168.1.100:47808";
            this.IPAddr_textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // InstanceID_textBox
            // 
            this.InstanceID_textBox.Location = new System.Drawing.Point(383, 45);
            this.InstanceID_textBox.Name = "InstanceID_textBox";
            this.InstanceID_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InstanceID_textBox.Size = new System.Drawing.Size(108, 22);
            this.InstanceID_textBox.TabIndex = 7;
            this.InstanceID_textBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "BacnetObject instanceId";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // InstanceID_to_textBox
            // 
            this.InstanceID_to_textBox.Location = new System.Drawing.Point(561, 48);
            this.InstanceID_to_textBox.Name = "InstanceID_to_textBox";
            this.InstanceID_to_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InstanceID_to_textBox.Size = new System.Drawing.Size(106, 22);
            this.InstanceID_to_textBox.TabIndex = 9;
            this.InstanceID_to_textBox.Text = "0";
            this.InstanceID_to_textBox.TextChanged += new System.EventHandler(this.InstanceID_to_textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.comboBoxPorts);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(11, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 65);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ModBus ON RS485";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.InstanceID_to_textBox);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.InstanceID_textBox);
            this.groupBox2.Controls.Add(this.IPAddr_textBox);
            this.groupBox2.Location = new System.Drawing.Point(11, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 125);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BACNet/IP";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(692, 23);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(79, 22);
            this.button5.TabIndex = 4;
            this.button5.Text = "Slave";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBoxOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.TextBox txtBoxOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox IPAddr_textBox;
        private System.Windows.Forms.TextBox InstanceID_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InstanceID_to_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
    }
}

