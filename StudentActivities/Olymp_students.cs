using MySql.Data.MySqlClient;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.IO;

namespace StudentActivities
{
    public partial class Olymp_students : Form
    {
        public string mId;
        public string mName;
        public Olymp_students()
        {
            InitializeComponent();
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
                string sql = "SELECT Olymp_students.*, Olympiada.*, Students.* ";
                sql += "FROM(Olymp_students INNER JOIN Olympiada ON Olymp_students.id_oly = Olympiada.id_oly) ";
                sql += "INNER JOIN Students ON Olymp_students.id_stu = Students.id_stu ";
                sql += "where Olymp_students.id_oly =" + mId;               
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            Olymp_students_edit frm = new Olymp_students_edit();
            frm.mId = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            if (frm.Ok)
            {
                button4_Click(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Olymp_students_add frm = new Olymp_students_add();
            frm.mId = mId;
            frm.ShowDialog();
            if (frm.Ok)
            {
                button4_Click(this, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удаляем документ
            switch (MessageBox.Show("Удалить пользователя ?", "Удаление",
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
                strSQL = @"DELETE FROM olymp_students WHERE id_oly_stu =" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var eP = new ExcelPackage())
            {
                eP.Workbook.Properties.Author = "Осетров Данила";
                eP.Workbook.Properties.Title = "Отчет";
                eP.Workbook.Properties.Company = "NewSystems";

                // Openning first Worksheet of the template file i.e. 'Sample1.xlsx'
                var sheet = eP.Workbook.Worksheets.Add("Отчет");

                sheet.Cells[1, 1].Value = "Олимпиады за сезон " + mName;
                sheet.Cells[1, 1].Style.Font.Bold = true;
                sheet.Cells[1, 1].Style.Font.Size = 16;


                // шапка
                sheet.Cells[3, 1].Value = "пп";
                sheet.Cells[3, 2].Value = "ИИН";
                sheet.Cells[3, 3].Value = "ФИО";
                sheet.Cells[3, 4].Value = "Класс";
                sheet.Cells[3, 5].Value = "Имя учителя";
                sheet.Cells[3, 6].Value = "Предмет";
                sheet.Cells[3, 7].Value = "Полученные баллы";

                sheet.Cells[3, 1].Style.Font.Bold = true;
                sheet.Cells[3, 2].Style.Font.Bold = true;
                sheet.Cells[3, 3].Style.Font.Bold = true;
                sheet.Cells[3, 4].Style.Font.Bold = true;
                sheet.Cells[3, 5].Style.Font.Bold = true;
                sheet.Cells[3, 6].Style.Font.Bold = true;
                sheet.Cells[3, 7].Style.Font.Bold = true;

                var row = 4;

                Db db = new Db();
                MySqlConnection con1 = new MySqlConnection();
                con1.ConnectionString = db.pathDb;
                con1.Open();
                string sql = "SELECT Olymp_students.*, Olympiada.*, Students.* ";
                sql += "FROM(Olymp_students INNER JOIN Olympiada ON Olymp_students.id_oly = Olympiada.id_oly) ";
                sql += "INNER JOIN Students ON Olymp_students.id_stu = Students.id_stu ";
                sql += "where Olymp_students.id_oly =" + mId;

                int i = 1;
                MySqlCommand command1 = new MySqlCommand(sql, con1);
                try
                {
                    MySqlDataReader aReader = command1.ExecuteReader();
                    while (aReader.Read())
                    {
                        sheet.Cells[row, 1].Value = i;
                        sheet.Cells[row, 2].Value = aReader["iin"].ToString();
                        sheet.Cells[row, 3].Value = aReader["name"].ToString();
                        sheet.Cells[row, 4].Value = aReader["form"].ToString();
                        sheet.Cells[row, 5].Value = aReader["name_teacher"].ToString();
                        sheet.Cells[row, 6].Value = aReader["subject"].ToString();
                        sheet.Cells[row, 7].Value = aReader["scores"].ToString();

                        i++;
                        row++;
                    }
                    aReader.Close();
                    con1.Close();
                    //Делаем рамку
                    var cells = sheet.Cells["A3:G" + Convert.ToString(row - 1).Trim()];
                    cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cells.AutoFitColumns();
                    //Формула
                    //sheet.Cells[row, 5].Formula = "Sum(" + sheet.Cells[1, 5].Address + ":" + sheet.Cells[row - 1, 5].Address + ")";
                    //sheet.Cells[row, 7].Formula = "Sum(" + sheet.Cells[1, 7].Address + ":" + sheet.Cells[row - 1, 7].Address + ")";
                    //sheet.Cells[row, 8].Formula = "Sum(" + sheet.Cells[1, 8].Address + ":" + sheet.Cells[row - 1, 8].Address + ")";

                }
                // обработка ошибок
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // сохраняем в файл
                var bin = eP.GetAsByteArray();
                File.WriteAllBytes(@"Reports1.xlsx", bin);

                //Process.Start(@"Reports1.xlsx");
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(@"Reports1.xlsx")
                {
                    UseShellExecute = true
                };
                p.Start();

            }
        }

        private void Olymp_students_Load(object sender, EventArgs e)
        {
            button4_Click(this, e);
        }
    }
}
