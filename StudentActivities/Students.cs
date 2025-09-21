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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Students_add frm = new Students_add(); //Создание экземпляра формы студент адд(класс формы на основе нее создается экземпляр frm)
            frm.ShowDialog(); // показ экземпляра на экране c помощью метода showdialog выводим на экран
            if (frm.Ok) // frm в данном случае это название экзмпляра класса глобальная переменная равняется тру
            {
                button4_Click(this, e);// Програмно нажимаем на кнопку 4
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
                command1.CommandText = @"select * from students order by name";// выборка данных из таблицы в данном случае берется полностью 
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

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удаляем документ
            switch (MessageBox.Show("Удалить волонтера ?", "Удаление",// запрос на потверждение
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
                strSQL = @"DELETE FROM students WHERE id_stu =" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
            if (dataGridView1.RowCount == 0) { return; } // Проверка таблицы что не пустая количество строк 
            Students_edit frm = new Students_edit(); //создание экземпляра формы Students_edit frm содержит копию обьект класса Student_edit; создается обьект из класса 
            frm.mId = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();// присвоение mid данных из первых колонок()
            frm.ShowDialog();
            if (frm.Ok)
            {
                button4_Click(this, e);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Students_Load(object sender, EventArgs e)
        {
            button4_Click(this, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            EMail frm = new EMail();
            frm.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
