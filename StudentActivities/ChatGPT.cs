using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentActivities
{
    public partial class ChatGPT : Form
    {
        public string mId;
        public bool Ok;
        public ChatGPT()
        {
            InitializeComponent();
        }

        private void ChatGPT_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            button1.Enabled = false;

            var apiKey = "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";

            var gpt3 = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });

            var completionResult = await gpt3.ChatCompletion.CreateCompletion
                (new ChatCompletionCreateRequest()
                {
                    Messages = new List<ChatMessage>(new ChatMessage[]
                           { new ChatMessage("user", textBox1.Text.Trim()) }),
                    Model = Models.Gpt_4_vision_preview,
                    Temperature = 0.5F,
                    MaxTokens = 3000,
                    N = 1
                }
                );
            label3.Visible = false;
            button1.Enabled = true;
            if (completionResult.Successful)
            {
                foreach (var choice in completionResult.Choices)
                {
                    richTextBox1.AppendText(choice.Message.Content + "\n");
                    Console.WriteLine(choice.Message.Content);

                }
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }
                Console.WriteLine($"{completionResult.Error.Code}:{completionResult.Error.Message} ");
                MessageBox.Show($"{completionResult.Error.Code}:{completionResult.Error.Message} ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Focus();
                return;
            }

            Db db = new Db();
            //string mComboId1 = Convert.ToString(db.ComboBoxId("students", "iin", comboBox1.Text));

            // Присоединение к базе данных
            MySqlConnection con1 = new MySqlConnection();
            // Строка соединения с Ole -  провайдером
            con1.ConnectionString = db.pathDb;
            con1.Open();
            //MessageBox.Show("Базу открыл");
            MySqlCommand command1 = new MySqlCommand();
            try // Начинаем транзакцию 
            {
                string strSQL;
                strSQL = "INSERT INTO Task ( tquery, task) ";
                strSQL += "VALUES (";
                strSQL += @"'" + textBox1.Text + "', ";
                strSQL += @"'" + richTextBox1.Text + "' ";
                strSQL += @" )";
                //MessageBox.Show(strSQL);
                command1.CommandText = strSQL;
                command1.Connection = con1;
                command1.ExecuteNonQuery();
                con1.Close();
                Ok = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Ok = false;
                textBox1.Focus();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
