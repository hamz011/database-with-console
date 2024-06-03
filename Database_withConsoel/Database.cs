using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_withConsoel
{
    class Database
    {
        public string dbName = "Demo";
        public SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;database=Demo;");

        public SqlDataAdapter adapter;
        public SqlCommand cmd;
        public DataTable dataTable;
        int iddd = 0;

        public void comeData(string sql = "select * from users")
        {
            connection.Open();
            adapter = new SqlDataAdapter(sql, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Print column names
            foreach (DataColumn column in dataTable.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

            // Print rows data from DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------");

        

            Console.WriteLine("İş bitti sorun yok!");
            connection.Close();
        }

        public void test()
        {
            comeData();
        }

        public void Add(int id,string name="Hamza",string surname = "deneme")
        {
            
                try
                {
                    string sql = "INSERT INTO users (id,name,surname) VALUES (@id,@ad,@soyad)";
                    cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@ad", name);
                    cmd.Parameters.AddWithValue("@soyad", surname);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yeni kayıt eklendi!\nID: " + id.ToString());
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show("Hata :"+ex.Message);
                }
                
            
        }
        public void Update(int id, string name = "Hamza", string surname = "deneme")
        {
            if (id < int.MaxValue && id > int.MinValue)
            {
                try
                {
                    string sql = "UPDATE users set name=@ad,surname=@soyad where id=@id";
                    cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@ad", name);
                    cmd.Parameters.AddWithValue("@soyad", surname);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Kayıt güncellendi!\nID: " + id.ToString() + "\tName: " + name + "\tSurname: " + surname);

                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show("Hata :" + ex.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen geçerli ID girin!");
            }
        }
        public void Delete(int id)
        {
            if (id < int.MaxValue && id > int.MinValue)
            {
                try
                {
                    string sql = "DELETE users where id=@id";
                    cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Kayıt silindi!\nID: " + id.ToString());
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show("Hata :" + ex.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen geçerli ID girin!");
            }
        }
    }
}
