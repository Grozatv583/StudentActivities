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
    public partial class Command_student_edit : Form
    {
        public bool Ok;
        public string mId;
        public Command_student_edit()
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
                strSQL = "UPDATE command_student SET ";
                strSQL += @"form = '" + textBox2.Text + "', ";
                strSQL += @"name_teacher = '" + textBox3.Text + "', ";
                strSQL += @"subject = '" + textBox4.Text + "' ";
                strSQL += @"WHERE id_pro_stu   =" + mId;
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

        private void Command_student_edit_Load(object sender, EventArgs e)
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
                string sql = "SELECT Command_student.*, Projects.*, Students.* ";
                sql += "FROM(Command_student INNER JOIN Projects ON Command_student.id_pro = Projects.id_pro) ";
                sql += "INNER JOIN Students ON Command_student.id_stu = Students.id_stu ";
                sql += "where Command_student.id_pro_stu =" + mId;
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
    }
}
