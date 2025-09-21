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
using System.Diagnostics;


namespace StudentActivities
{
    public partial class Certificates : Form
    {
        public Certificates()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            try
            {
                // Присоединение к базе данных
                MySqlConnection con1 = new MySqlConnection();
                // Строка соединения с Ole -  провайдером
                con1.ConnectionString = db.pathDb;
                con1.Open();
                //MessageBox.Show("Базу открыл");
                MySqlCommand command1 = new MySqlCommand();
                // Запрос
                string sql = "SELECT Certificates.*, Students.* ";
                sql += "FROM Certificates INNER JOIN Students ON Certificates.id_stu = Students.id_stu";
                command1.CommandText = @sql;
                command1.Connection = con1;
                MySqlDataAdapter adapter = new MySqlDataAdapter(command1);
                DataSet dataset = new DataSet();

                // Заполнение сетки
                adapter.Fill(dataset, "frm");
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dataset.Tables["frm"];
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Certificates_add frm = new Certificates_add();
            frm.ShowDialog();
            if (frm.Ok)
            {
                button4_Click(this, e);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удаляем 
            switch (MessageBox.Show("Удалить ", "Удаление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case (DialogResult.No):
                    return;
            }
            Db db = new Db();
            // Присоединение к базе данных
            MySqlConnection con1 = new MySqlConnection();
            // Строка соединения с Ole -  провайдером
            con1.ConnectionString = db.pathDb;
            con1.Open();
            MySqlCommand command1 = new MySqlCommand();
            try // Начинаем транзакцию 
            {
                string strSQL;
                strSQL = @"DELETE FROM certificates WHERE id_cert =" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                command1.CommandText = strSQL;
                command1.Connection = con1;
                command1.ExecuteNonQuery();
                con1.Close();
                button4_Click(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            Certificates_edit frm = new Certificates_edit();
            frm.mId = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            if (frm.Ok)
            {
                button4_Click(this, e);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            string mId = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            Db db = new Db();
            MySqlConnection con1 = new MySqlConnection();
            con1.ConnectionString = db.pathDb;
            MySqlCommand command1 = new MySqlCommand();

            try
            {
                command1.CommandText = "select * from certificates where id_cert = " + mId;
                command1.Connection = con1;
                con1.Open();
                // Создаем DataReader
                MySqlDataReader aReader = command1.ExecuteReader();
                //MessageBox.Show("Базу открыл");
                aReader.Read();
                bool mYes = (aReader["docx_name"].ToString() != "");
                if (!mYes) { return; }

                string filePath2 = aReader["docx_name"].ToString();

                byte[] pop = (byte[])aReader["docx"];
                using (FileStream fileStream = new FileStream(filePath2,
                    FileMode.Create,
                    FileAccess.ReadWrite))
                {
                    BinaryWriter binWriter = new BinaryWriter(fileStream);
                    binWriter.Write(pop, 0, pop.Length);
                }

                aReader.Close();
                con1.Close();

                //Process.Start(@"Reports1.xlsx");
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(filePath2)
                {
                    UseShellExecute = true
                };
                p.Start();

            }
            // обработка ошибок
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Certificates_Load(object sender, EventArgs e)
        {

        }
    }
}
