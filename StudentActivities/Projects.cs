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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace StudentActivities
{
    public partial class Projects : Form
    {
        public Projects()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
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
                command1.CommandText = @"select * from projects";
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
            Projects_add frm = new Projects_add();
            frm.ShowDialog();
            if (frm.Ok)
            {
                button4_Click(this, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            Projects_edit frm = new Projects_edit();
            frm.mId = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            if (frm.Ok)
            {
                button4_Click(this, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удаляем документ
            switch (MessageBox.Show("Удалить проект ?", "Удаление",
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
                strSQL = @"DELETE FROM projects WHERE id_pro =" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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

        private void Projects_Load(object sender, EventArgs e)
        {
            button4_Click(this, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            Command_student frm = new Command_student();
            frm.mId = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            string mId = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

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
                bool mYes = Convert.ToBoolean(aReader["docx_yes"].ToString());
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
    }
}
