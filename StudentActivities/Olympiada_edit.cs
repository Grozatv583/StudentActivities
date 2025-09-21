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
    public partial class Olympiada_edit : Form
    {
        public bool Ok;
        public string mId;
        public Olympiada_edit()
        {
            InitializeComponent();
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
            string mdate = Convert.ToString(dateTimePicker1.Value.Date);
            string msdate = mdate.Substring(6, 4) + mdate.Substring(3, 2) + mdate.Substring(0, 2);

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
                strSQL = "UPDATE olympiada SET ";
                strSQL += @"points = '" + textBox1.Text + "', ";
                strSQL += @"season = '" + textBox2.Text + "', ";
                strSQL += @"Dat_event = '" + mdate + "', ";
                strSQL += @"Dats_event = '" + msdate + "' ";
                strSQL += @"WHERE id_oly   =" + mId;

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
            Ok = false;
            Close();
        }

        private void Olympiada_edit_Load(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command1 = new MySqlCommand();

            try
            {
                command1.CommandText = "select * from olympiada where id_oly = " + mId;
                command1.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command1.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                textBox1.Text = aReader["points"].ToString();
                textBox2.Text = aReader["season"].ToString();
                
                dateTimePicker1.Text = aReader["Dat_event"].ToString();
                
                
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
    }
    
}
