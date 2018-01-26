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

        public static void addSystemCharcterisitcs(string pcID, string processorName, string processorModel, string RAM, string opasity, string os)
        {
            var query =
            $"INSERT INTO [systemCharacteristic] (PCID, processorName, processorModel, RAM, capacity, operatingSystem) VALUES('{pcID}', '{processorName}','{processorModel}', '{RAM}', '{opasity}','{os}');";
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public static void addEmploy(string name, string surname, string patronymic)
        {
            var query =
            $"INSERT INTO [employment] (surname, name, patronymic) VALUES('{name}', '{surname}','{patronymic}');";
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public static bool DeleteTech(string id)
        {
            var query = $"DELETE FROM [technic] WHERE ID = '{id}';";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool DeleteHDD(string id)
        {
            var query = $"DELETE FROM [employment] WHERE ID = '{id}';";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool DeleteEmploy(string id)
        {
            var query = $"DELETE FROM [hardDrive] WHERE PCID = '{id}';";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
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
