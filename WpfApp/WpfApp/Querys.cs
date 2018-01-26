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


        public static bool updateSysChar(string id, string processorName, string processorModel, string RAM, string capacity, string operatingSystem)
        {

            var query =
                "UPDATE [systemCharacteristic] SET processorName = @processorName, processorModel = @processorModel, RAM = @RAM, capacity = @capacity, operatingSystem = @operatingSystem WHERE PCID = @id";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("processorModel", processorModel);
                command.Parameters.AddWithValue("processorName", processorName);
                command.Parameters.AddWithValue("RAM", RAM);
                command.Parameters.AddWithValue("capacity", capacity);
                command.Parameters.AddWithValue("operatingSystem", operatingSystem);

                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool updateHDD(string id, string company, string space, string serialNumber)
        {

            var query =
                "UPDATE [hardDrive] SET company = @company, serialNumber = @serialNumber, space = @space WHERE PCID = @id";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("serialNumber", serialNumber);
                command.Parameters.AddWithValue("company", company);
                command.Parameters.AddWithValue("space", space);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool updateTech(string id, string type, string firm, string model, string sirialNumber, string buisnesNumber)
        {

            var query =
                "UPDATE[technic] SET type = @type, company = @company, model = @model, businessNumber = @businessNumber, serialNumber = @serialNumber WHERE ID = @id";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("type", type);
                command.Parameters.AddWithValue("company", firm);
                command.Parameters.AddWithValue("model", model);
                command.Parameters.AddWithValue("businessNumber", buisnesNumber);
                command.Parameters.AddWithValue("serialNumber", sirialNumber);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool updateEmploy(string id, string name, string surname, string patronymic)
        {

            var query =
                "UPDATE[employment] SET surname = @surname, name = @name, patronymic = @patronymic WHERE ID = @id";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("surname", surname);
                command.Parameters.AddWithValue("patronymic", patronymic);
                command.Parameters.AddWithValue("id", id);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }

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
        public static void addHDD(string pcid, string company, string serialNumber, string space)
        {
            var query =
            $"INSERT INTO [hardDrive] (PCID, company, serialNumber, space) VALUES('{pcid}', '{company}','{serialNumber}', '{space}');";
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
        public static bool DeleteEmploy(string id)
        {
            bool result = false;
            var query = $"DELETE FROM [employment] WHERE ID = '{id}';";


            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    result = command.ExecuteNonQuery() >= 1;

                }
                catch
                {
                    MessageBox.Show("Сотрудник не найден");
                }
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
        public static DataTable hardDriveByEmploy(string roomNumber)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM hardDrive INNER JOIN employment ON hardDrive.PCID = employment.ID WHERE room.roomNumber = " + roomNumber, ConnectionAdres);
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
