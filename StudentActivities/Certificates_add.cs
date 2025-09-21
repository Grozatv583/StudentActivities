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
    
    public partial class Certificates_add : Form
    {
        public bool Ok;
        public Certificates_add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Focus();
                return;
            }

            Db db = new Db();
            string mComboId1 = Convert.ToString(db.ComboBoxId("students", "iin", comboBox1.Text));
            string mdate = Convert.ToString(dateTimePicker1.Value.Date);
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
                strSQL = "INSERT INTO certificates (id_stu, diplom, dat) ";
                strSQL += "VALUES (";
                strSQL += @"" + mComboId1 + ", ";
                strSQL += @"'" + textBox2.Text.Trim() + "', ";
                strSQL += @"'" + mdate + "' ";
                
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

        private void Certificates_add_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            Db db = new Db();
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            con1.Open();
            try
            {
                MySqlCommand command1 = new MySqlCommand("select * from students order by iin", con1);
                MySqlDataReader aReader = command1.ExecuteReader();
                while (aReader.Read())
                {
                    comboBox1.Items.Add(aReader["iin"].ToString());
                }
                aReader.Close();

                con1.Close();
            }
            // обработка ошибок
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dateTimePicker1.Value = DateTime.Now;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command1 = new MySqlCommand();

            try
            {
                string mComboId1 = Convert.ToString(db.ComboBoxId("students", "iin", comboBox1.Text));
                command1.CommandText = "select * from students where id_stu = " + mComboId1;
                command1.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command1.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                textBox1.Text = aReader["name"].ToString();
                aReader.Close();
                con1.Close();
            }
            // обработка ошибок
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
