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
    public partial class Report1 : Form
    {
        public Report1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var eP = new ExcelPackage())
            {
                eP.Workbook.Properties.Author = "Остеров Данила";
                eP.Workbook.Properties.Title = "Отчет";
                eP.Workbook.Properties.Company = "NewSystems";

                // Openning first Worksheet of the template file i.e. 'Sample1.xlsx'
                var sheet = eP.Workbook.Worksheets.Add("Отчет");

                sheet.Cells[1, 1].Value = "Проекты за период " + Convert.ToString(dateTimePicker1.Value).Substring(0, 10) + " по " + Convert.ToString(dateTimePicker2.Value).Substring(0, 10);
                sheet.Cells[1, 1].Style.Font.Bold = true;
                sheet.Cells[1, 1].Style.Font.Size = 16;


                // шапка
                sheet.Cells[3, 1].Value = "пп";
                sheet.Cells[3, 2].Value = "Начало проекта";
                sheet.Cells[3, 3].Value = "Предметное направление";
                sheet.Cells[3, 4].Value = "Тема";
                sheet.Cells[3, 5].Value = "Команда";
                sheet.Cells[3, 6].Value = "Конец проекта";
                sheet.Cells[3, 7].Value = "Завершен";
                sheet.Cells[3, 8].Value = "Загружен документ";



                sheet.Cells[3, 1].Style.Font.Bold = true;
                sheet.Cells[3, 2].Style.Font.Bold = true;
                sheet.Cells[3, 3].Style.Font.Bold = true;
                sheet.Cells[3, 4].Style.Font.Bold = true;
                sheet.Cells[3, 5].Style.Font.Bold = true;
                sheet.Cells[3, 6].Style.Font.Bold = true;
                sheet.Cells[3, 7].Style.Font.Bold = true;
                sheet.Cells[3, 8].Style.Font.Bold = true;

                var row = 4;

                string msdate1 = Convert.ToString(dateTimePicker1.Value.Date);
                msdate1 = msdate1.Substring(6, 4) + msdate1.Substring(3, 2) + msdate1.Substring(0, 2);
                string msdate2 = Convert.ToString(dateTimePicker2.Value.Date);
                msdate2 = msdate2.Substring(6, 4) + msdate2.Substring(3, 2) + msdate2.Substring(0, 2);

                Db db = new Db();
                MySqlConnection con1 = new MySqlConnection();
                con1.ConnectionString = db.pathDb;
                con1.Open();
                string strSQL;
                strSQL = "SELECT * from Projects  ";
                strSQL += @"WHERE ";
                strSQL += "dats_start >= '" + msdate1 + "'  AND ";
                strSQL += "dats_start <= '" + msdate2 + "' ";

                int i = 1;
                MySqlCommand command1 = new MySqlCommand(strSQL, con1);
                try
                {
                    MySqlDataReader aReader = command1.ExecuteReader();
                    while (aReader.Read())
                    {
                        sheet.Cells[row, 1].Value = i;
                        sheet.Cells[row, 2].Value = aReader["dat_start"].ToString().Substring(0, 10);
                        sheet.Cells[row, 3].Value = aReader["area_subj"].ToString();
                        sheet.Cells[row, 4].Value = aReader["topic"].ToString();
                        sheet.Cells[row, 5].Value = aReader["commands"].ToString();
                        sheet.Cells[row, 6].Value = aReader["dat_end"].ToString();
                        sheet.Cells[row, 7].Value = aReader["finish"].ToString();
                        sheet.Cells[row, 8].Value = aReader["docx_yes"].ToString();

                        i++;
                        row++;
                    }
                    aReader.Close();
                    con1.Close();
                    //Делаем рамку
                    var cells = sheet.Cells["A3:H" + Convert.ToString(row - 1).Trim()];
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

                this.Close();
            }
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
