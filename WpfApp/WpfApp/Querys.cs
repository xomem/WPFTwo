using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;


namespace WpfApp
{
    public class Querys
    {
        //static string ConnectionAdres = @"Data source=(LocalDB)\MSSQLLocalDB;Attachdbfilename=|DataDirectory|\MainDatabase.mdf;‌​Integrated Security=True;MultipleActiveResultSets=True;";
        static string ConnectionAdres = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SOVAJJ\Google Drive\WpfApp\WpfApp\MainDatabase.mdf;Integrated Security=True";

        public static void addEmploy(string name, string surname, string patronymic)
        {
            var query =
            $"INSERT INTO employment (surname, name, patronymic) VALUES({surname}, {surname},{patronymic});";
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public static DataTable employByRoom(string roomNumber)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM employment INNER JOIN room ON employment.ID = room.employID WHERE room.roomNumber = " + roomNumber, ConnectionAdres);
            DataTable dt = new DataTable("Call Reciept");
            da.Fill(dt);
            return dt;

        }
        public static DataTable readEmployers()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [employment]", ConnectionAdres);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable readHDD()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [hardDrive]", ConnectionAdres);
                DataTable dt = new DataTable("Call Reciept");
                da.Fill(dt);
                mainWindow.successfulConnection();
                return dt;
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
                return null;
            }
        }
        public static DataTable readTech()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [technic]", ConnectionAdres);
                DataTable dt = new DataTable("Call Reciept");
                da.Fill(dt);
                mainWindow.successfulConnection();
                return dt;
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
                return null;
            }
        }
        public static DataTable readSysCharacter()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [systemCharacteristic]", ConnectionAdres);
                DataTable dt = new DataTable("Call Reciept");
                da.Fill(dt);
                mainWindow.successfulConnection();
                return dt;
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
                return null;
            }
        }
    }
}
