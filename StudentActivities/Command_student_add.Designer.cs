namespace StudentActivities
{
    partial class Command_student_add
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
            comboBox1 = new ComboBox();
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            textBox6 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            panel2 = new Panel();
            button1 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(178, 68);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(304, 23);
            comboBox1.TabIndex = 12;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(102, 153, 255);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(542, 45);
            panel1.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(18, 7);
            label1.Name = "label1";
            label1.Size = new Size(137, 37);
            label1.TabIndex = 0;
            label1.Text = "Команда";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(204, 204, 255);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(textBox6);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(542, 289);
            panel3.TabIndex = 20;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(174, 340);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(308, 23);
            textBox6.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 104);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 2;
            label3.Text = "Имя";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(178, 104);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(308, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 70);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 0;
            label2.Text = "ИИН";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(87, 87, 87);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(261, 6);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(183, 34);
            button2.TabIndex = 1;
            button2.Text = "Выйти";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(102, 153, 255);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 289);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(542, 49);
            panel2.TabIndex = 19;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(87, 87, 87);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(10, 6);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(193, 34);
            button1.TabIndex = 0;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(178, 146);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(304, 23);
            textBox2.TabIndex = 3;
            textBox2.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 146);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 4;
            label4.Text = "Класс";
            label4.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 180);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 14;
            label5.Text = "Имя Учительницы";
            label5.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 210);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 15;
            label7.Text = "Предмет";
            label7.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(191, 178);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(304, 23);
            textBox3.TabIndex = 17;
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(199, 208);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(304, 23);
            textBox4.TabIndex = 18;
            textBox4.Visible = false;
            // 
            // Command_student_add
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 338);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Command_student_add";
            Text = "Добавить";
            Load += Command_student_add_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox comboBox1;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private TextBox textBox6;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Button button2;
        private Panel panel2;
        private Button button1;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label7;
        private Label label5;
        private Label label4;
        private TextBox textBox2;
    }
}