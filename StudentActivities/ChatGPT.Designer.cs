namespace StudentActivities
{
    partial class ChatGPT
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
            button2 = new Button();
            label3 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(87, 87, 87);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(203, 83);
            button2.Name = "button2";
            button2.Size = new Size(194, 28);
            button2.TabIndex = 13;
            button2.Text = "Очистить ответы";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(449, 85);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 11;
            label3.Text = "Ждите ...";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(87, 87, 87);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(80, 83);
            button1.Name = "button1";
            button1.Size = new Size(95, 28);
            button1.TabIndex = 10;
            button1.Text = "Запрос";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(641, 23);
            textBox1.TabIndex = 9;
            textBox1.Text = "Задайте свой вопрос";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(87, 87, 87);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(626, 415);
            button3.Name = "button3";
            button3.Size = new Size(95, 28);
            button3.TabIndex = 14;
            button3.Text = "Выйти";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(87, 87, 87);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(80, 415);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(201, 28);
            button4.TabIndex = 15;
            button4.Text = "Сохранить ответ в базе";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(80, 133);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(641, 276);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // ChatGPT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(204, 204, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "ChatGPT";
            Text = "Интеллектуальный помощник";
            Load += ChatGPT_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
        private RichTextBox richTextBox1;
    }
}