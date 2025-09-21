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
    public partial class Students_edit : Form
    {
        public bool Ok;
        public string mId;
        public Students_edit()
        {
            InitializeComponent();
        }

        private void Students_edit_Load(object sender, EventArgs e)
        {
            Db db = new Db(); // команды для подключения к базе mysql
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command1 = new MySqlCommand();

            try
            {
                command1.CommandText = "select * from students where id_stu = " + mId;
                command1.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command1.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                textBox1.Text = aReader["iin"].ToString();
                textBox2.Text = aReader["name"].ToString();
                textBox3.Text = aReader["email"].ToString();
                textBox4.Text = aReader["phone"].ToString();
                textBox5.Text = aReader["name_lat"].ToString();
                textBox6.Text = aReader["password"].ToString();
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
            Ok = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")  //Проверка, что ИИН не пустой
            {
                MessageBox.Show("ИИН не должен быть пустым");
                textBox1.Focus();
                return;
            }
            long number1 = 0;      // Проверка, что ИИН содержит цифры
            if (!long.TryParse(textBox1.Text.Trim(), out number1))
            {
                MessageBox.Show("ИИН должен содержать числа");
                textBox1.Focus();
                return;
            }
            if (textBox1.Text.Length != 12)   // Проверка, что длина ИИН равна 12 чисел
            {
                MessageBox.Show("ИИН должен быть равным 12 чисел");
                textBox1.Focus();
                return;
            }
            if (!textBox3.Text.Contains("@"))    // Проверка, что емаил содержит символ @
            {
                MessageBox.Show("Введите коректный email");
                textBox3.Focus();
                return;
            }
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
                strSQL = "UPDATE students SET "; // заменить данные в иаблице
                strSQL += @"iin = '" + textBox1.Text + "', ";
                strSQL += @"name = '" + textBox2.Text + "', ";
                strSQL += @"email = '" + textBox3.Text + "', ";
                strSQL += @"phone = " + textBox4.Text + ", ";
                strSQL += @"name_lat = '" + textBox5.Text + "', ";
                strSQL += @"password = '" + textBox6.Text + "' ";
                strSQL += @"WHERE id_stu   =" + mId;

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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
