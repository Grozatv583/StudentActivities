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
    public partial class Certificates_edit : Form
    {
        public bool Ok;
        public string mId;
        public Certificates_edit()
        {
            InitializeComponent();
        }

        private void Certificates_edit_Load(object sender, EventArgs e)
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
                string sql = "SELECT Certificates.*, Students.* ";
                sql += "FROM Certificates INNER JOIN Students ON Certificates.id_stu = Students.id_stu where id_cert = " + mId;

                command2.CommandText = sql;
                command2.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command2.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                textBox1.Text = aReader["name"].ToString();
                textBox2.Text = aReader["diplom"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(aReader["dat"].ToString());
                comboBox1.Text = aReader["iin"].ToString();
             
                aReader.Close();
                con1.Close();
            }
            // обработка ошибок
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //textBox1.Focus();
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
                strSQL = "UPDATE certificates SET ";
                strSQL += @"diplom = '" + textBox2.Text + "', ";
                strSQL += @"dat = '" + mdate + "' ";

                strSQL += @"WHERE id_cert   =" + mId;

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

        private void button2_Click(object sender, EventArgs e)
        {
            Ok=false;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            string filename2 = Path.GetFileName(openFileDialog1.FileName);

            byte[] result = File.ReadAllBytes(filename);


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
                strSQL = "UPDATE certificates SET ";
                strSQL += @"docx_name = '" + filename2 + "', ";
                strSQL += @"docx      =  @Content  ";
               strSQL += @"WHERE id_cert  =" + mId;


                //MessageBox.Show(strSQL);
                command1.CommandText = strSQL;
                command1.Connection = con1;
                command1.Parameters.AddWithValue("@Content", result);
                command1.ExecuteNonQuery();
                con1.Close();
                Ok = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Ok = false;

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
