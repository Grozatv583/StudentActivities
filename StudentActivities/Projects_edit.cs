using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace StudentActivities
{
    public partial class Projects_edit : Form
    {
        public bool Ok;
        public string mId;

        public Projects_edit()
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

            string mdate = Convert.ToString(dateTimePicker1.Value.Date);
            string msdate = mdate.Substring(6, 4) + mdate.Substring(3, 2) + mdate.Substring(0, 2);

            string mdate2 = Convert.ToString(dateTimePicker2.Value.Date);
            string msdate2 = mdate2.Substring(6, 4) + mdate2.Substring(3, 2) + mdate2.Substring(0, 2);
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
                strSQL = "UPDATE projects SET ";
                strSQL += @"area_subj = '" + textBox1.Text + "', ";
                strSQL += @"topic = '" + textBox2.Text + "', ";
                strSQL += @"commands = '" + textBox3.Text + "', ";
                strSQL += @"dat_start = '" + mdate + "', ";
                strSQL += @"dats_start = '" + msdate + "', ";
                strSQL += @"dat_end = '" + mdate2 + "', ";
                strSQL += @"dats_end = '" + msdate2 + "', ";
                strSQL += @"finish = " + Convert.ToString(checkBox1.Checked) + ", ";
                strSQL += @"docx_yes = " + Convert.ToString(checkBox2.Checked) + " ";
                strSQL += @"WHERE id_pro  =" + mId;

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

        private void Projects_edit_Load(object sender, EventArgs e)
        {
            Db db = new Db();
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command1 = new MySqlCommand();

            try
            {
                command1.CommandText = "select * from projects where id_pro = " + mId;
                command1.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command1.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                textBox1.Text = aReader["area_subj"].ToString();
                textBox2.Text = aReader["topic"].ToString();
                textBox3.Text = aReader["commands"].ToString();
                dateTimePicker1.Text = aReader["dat_start"].ToString();
                dateTimePicker2.Text = aReader["dat_end"].ToString();
                checkBox1.Checked = Convert.ToBoolean(aReader["finish"].ToString());
                checkBox2.Checked = Convert.ToBoolean(aReader["docx_yes"].ToString());
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            string filename2 = Path.GetFileName(openFileDialog1.FileName);

            //* Узнаем размер файла, если больше 20Мб, то не загружаем
            FileInfo fileInf = new FileInfo(filename);  //Создаем экземпляр класса FileInfo, который содержит нужную нам инфу
            long fsize = fileInf.Length;     //определяем размер файла, используя свойство Length
            if (fsize > 20 * 1024 * 1024)
            {
                MessageBox.Show("Размер файла не должен превышать 20 МБ"); //Выводим сообщение
                return;
            }
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
                strSQL = "UPDATE projects SET ";
                strSQL += @"docx_name = '" + filename2 + "', ";
                strSQL += @"docx      =  @Content , ";
                strSQL += @"docx_yes  = " + '1' + "  ";
                strSQL += @"WHERE id_pro  =" + mId;


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
    }
}
