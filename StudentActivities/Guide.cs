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
    public partial class Guide : Form
    {
        public bool mId;
        public bool Ok;
        public Guide()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            Guide_edit frm = new Guide_edit();
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
            switch (MessageBox.Show("Удалить задачу ?", "Удаление",
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
                strSQL = @"DELETE FROM Task WHERE id_task =" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
                command1.CommandText = @"select * from Task ";// выборка данных из таблицы в данном случае берется полностью 
                command1.Connection = con1;// order by - сортировать по полю имя
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
