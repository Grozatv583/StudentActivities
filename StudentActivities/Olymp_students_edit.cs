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

    public partial class Olymp_students_edit : Form
    {
        public bool Ok;
        public string mId;
        public Olymp_students_edit()
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
            string mComboId1 = Convert.ToString(db.ComboBoxId("students", "iin", comboBox1.Text));

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
                strSQL = "UPDATE olymp_students SET ";
                strSQL += @"form = '" + textBox2.Text + "', ";
                strSQL += @"name_teacher = '" + textBox3.Text + "', ";
                strSQL += @"subject = '" + textBox4.Text + "', ";
                strSQL += @"scores = '" + textBox5.Text + "' ";
                strSQL += @"WHERE id_oly_stu   =" + mId;
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

        private void Olymp_students_edit_Load(object sender, EventArgs e)
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
            //dateTimePicker1.Value = DateTime.Now;
            //Db db = new Db();
            //MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command2 = new MySqlCommand();

            try
            {
                string sql = "SELECT Olymp_students.*, Olympiada.*, Students.* ";
                sql += "FROM(Olymp_students INNER JOIN Olympiada ON Olymp_students.id_oly = Olympiada.id_oly) ";
                sql += "INNER JOIN Students ON Olymp_students.id_stu = Students.id_stu ";
                sql += "where Olymp_students.id_oly_stu =" + mId;
                command2.CommandText = sql;
                command2.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader2 = command2.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader2.Read();
                textBox1.Text = aReader2["name"].ToString();
                textBox2.Text = aReader2["form"].ToString();
                textBox3.Text = aReader2["name_teacher"].ToString();
                textBox4.Text = aReader2["subject"].ToString();
                textBox5.Text = aReader2["scores"].ToString();
                comboBox1.Text = aReader2["iin"].ToString();

                aReader2.Close();
                con1.Close();
            }
            // обработка ошибок
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
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
    }
}
