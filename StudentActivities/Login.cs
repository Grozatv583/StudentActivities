using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentActivities
{
    public partial class Login : Form
    {
        public bool Ok;
        public string mIdUser;
        public string mFioUser;
        public int access;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            Db db = new Db();
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            con1.Open();
            MySqlCommand command1 = new MySqlCommand("select * from users order by name", con1);
            try
            {
                MySqlDataReader aReader = command1.ExecuteReader();
                while (aReader.Read())
                {
                    comboBox1.Items.Add(aReader["name"].ToString());
                }
                aReader.Close();
                con1.Close();
            }
            // обработка ошибок
            catch (MySqlException e_combo1)
            {
                MessageBox.Show(e_combo1.ErrorCode.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                comboBox1.Focus();
                return;
            }
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Focus();
                return;
            }

            Db db = new Db();
            string mComboId = Convert.ToString(db.ComboBoxId("users", "name", comboBox1.Text));
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command1 = new MySqlCommand();

            try
            {
                command1.CommandText = "select * from users where id_users = " + mComboId;
                command1.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command1.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                mFioUser = aReader["name"].ToString();
                mIdUser = aReader["id_users"].ToString();
                access = Convert.ToInt16(aReader["access"].ToString());
                if (mFioUser == "")
                {
                    Ok = false;
                    this.Close();
                }

                if (textBox1.Text.Trim() != aReader["password"].ToString().Trim())
                {
                    Ok = false;
                    MessageBox.Show("Пароль неверный");
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Прошел");
                    aReader.Close();
                    con1.Close();
                    Ok = true;
                    this.Close();
                }
            }
            // обработка ошибок
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ok = false;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                comboBox1.Focus();
                return;
            }
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Focus();
                return;
            }

            Db db = new Db();
            string mComboId = Convert.ToString(db.ComboBoxId("users", "name", comboBox1.Text));
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command1 = new MySqlCommand();

            try
            {
                command1.CommandText = "select * from users where id_users = " + mComboId;
                command1.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command1.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                mFioUser = aReader["name"].ToString();
                mIdUser = aReader["id_users"].ToString();
                access = Convert.ToInt16(aReader["access"].ToString());
                if (mFioUser == "")
                {
                    Ok = false;
                    this.Close();
                }

                if (textBox1.Text.Trim() != aReader["password"].ToString().Trim())
                {
                    Ok = false;
                    MessageBox.Show("Пароль неверный");
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Прошел");
                    aReader.Close();
                    con1.Close();
                    Ok = true;
                    this.Close();
                }
            }
            // обработка ошибок
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
