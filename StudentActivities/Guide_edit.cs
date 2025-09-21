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
    public partial class Guide_edit : Form
    {
        public bool Ok;
        public string mId;
        public Guide_edit()
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
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Focus();
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
                strSQL = "UPDATE Task SET ";
                strSQL += @"tquery = '" + textBox1.Text + "', ";
                strSQL += @"task = '" + textBox2.Text + "' ";
                strSQL += @"WHERE id_task   =" + mId;
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

        private void Guide_edit_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            Db db = new Db();
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            //con1.Open();
            //dateTimePicker1.Value = DateTime.Now;
            //Db db = new Db();
            //MySqlConnection con1 = new MySqlConnection();
            //con1.ConnectionString = db.pathDb;
            MySqlCommand command2 = new MySqlCommand();

            try
            {
                string sql = "SELECT * From Task ";
                sql += "where id_task =" + mId;
                command2.CommandText = sql;
                command2.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader2 = command2.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader2.Read();
                textBox1.Text = aReader2["tquery"].ToString();
                textBox2.Text = aReader2["task"].ToString();

                aReader2.Close();
                con1.Close();
            }
            // обработка ошибок
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
