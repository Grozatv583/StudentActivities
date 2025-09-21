using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace StudentActivities
{
    internal class Db
    {
        public string pathDb;
        protected MySqlConnection myconnect;


        public Db()
        {
            List<string> allLinesText;
            string fileName = "ConnectionStringMySql.txt";
            allLinesText = File.ReadAllLines(@fileName).ToList();
            pathDb = allLinesText[0];

        }

        void Open()
        {
            try
            {
                this.myconnect = new MySqlConnection(this.pathDb);
                this.myconnect.Open();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        void Close()
        {
            try
            {
                myconnect.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        public int ComboBoxId(string strDb, string strField, string ComboBoxText)
        {
            string txtSql = "select * from " + strDb + " order by " + strField;
            this.Open();
            MySqlCommand command = new MySqlCommand(txtSql, this.myconnect);
            command.ExecuteNonQuery();
            MySqlDataReader dbRead = command.ExecuteReader();
            //MySqlDataReader dbRead = command.ExecuteReader();
            int i = -1;
            while (dbRead.Read())
            {
                if (dbRead[strField].ToString() == ComboBoxText)
                {
                    i = Convert.ToInt16(dbRead[0].ToString());
                    dbRead.Close();
                    return i;
                }
            }
            dbRead.Close();
            return -1;
        }

        // Переводит код в техт ComboBox
        // Пример:
        // comboBox1.Text = db.ComboBoxIdText("personnel", "name_personnel", "id_per", aReader3["id_per"].ToString());
        public string ComboBoxIdText(string strDb, string strField, string IdField, string mId)
        {
            string txtSql = "select * from " + strDb + " where " + IdField + " = " + mId;
            this.Open();
            //MySqlCommand command = new MySqlCommand(txtSql, this.connect);
            MySqlCommand command = new MySqlCommand(txtSql, this.myconnect);
            command.ExecuteNonQuery();
            //MySqlDataReader dbRead = command.ExecuteReader();
            MySqlDataReader dbRead = command.ExecuteReader();
            while (dbRead.Read())
            {
                string res = dbRead[strField].ToString();
                dbRead.Close();
                return res;
            }
            dbRead.Close();
            return "";
        }
    }
}
