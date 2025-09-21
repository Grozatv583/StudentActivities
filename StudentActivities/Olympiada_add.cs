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
 
    public partial class Olympiada_add : Form
    {
        public bool Ok;
        public Olympiada_add()
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
                strSQL = "INSERT INTO olympiada (points, season, Dat_event,Dats_event) ";
                strSQL += "VALUES (";
                strSQL += @"" + textBox1.Text.Trim() + ", ";
                strSQL += @"'" + textBox2.Text.Trim() + "', ";
                strSQL += @"'" + mdate + "', ";
                strSQL += @"'" + msdate + "' ";
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
    }
}
