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
    public partial class Users_add : Form
    {
        public bool Ok;
        public Users_add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ok = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim() == "")
            {
                textBox3.Focus();
                return;
            }

            Db db = new Db();
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
                strSQL = "INSERT INTO users (login, password, name, access ) ";
                strSQL += "VALUES (";
                strSQL += @"'" + textBox1.Text.Trim() + "', ";
                strSQL += @"'" + textBox2.Text.Trim() + "', ";
                strSQL += @"'" + textBox3.Text.Trim() + "', ";
                strSQL += @" " + Convert.ToString(comboBox1.SelectedIndex) + " ";
                strSQL += @" )";
                MessageBox.Show(strSQL);
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

        private void Users_add_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
