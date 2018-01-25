using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //SqlConnection SqlConnection;
        private MainMenu MainMenu;
        Querys Query = new Querys();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new MainMenu();
            MainMenu = new MainMenu(this);
            MainFrame.Navigate(MainMenu);
            //Query.connectDB(this);
            //string ConnectionAdres = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Edward\source\repos\WpfApp\WpfApp\MainDatabase.mdf;Integrated Security=True";
            //SqlConnection = new SqlConnection(ConnectionAdres);

            //await SqlConnection.OpenAsync();

            //SqlDataReader SQLDReader = null;

            //SqlCommand GetAllEmployCommand = new SqlCommand("SELECT * FROM [employment]", SqlConnection);

            //try
            //{
            //    SQLDReader = await GetAllEmployCommand.ExecuteReaderAsync();

            //    while(await SQLDReader.ReadAsync())
            //    {
            //        string test = Convert.ToString(SQLDReader["ID"]) + Convert.ToString(SQLDReader["surname"]) + Convert.ToString(SQLDReader["name"]) + Convert.ToString(SQLDReader["patronymic"]);
            //        //MessageBox.Show(test);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //finally
            //{
            //    if (SQLDReader != null)
            //    {
            //        SQLDReader.Close();
            //    }
            //}
        }

        public void checkConnect(string test)
        {
            MessageBox.Show(test);
        }
        public void successfulConnection()
        {
            Status.Content = "Запрос выполнен успешно";
        }
        public void errorConnection(Exception ex)
        {
            Status.Content = "Ошибка выполнения запроса - " + ex;
        }
        public void connectError(Exception ex)
        {
            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private  void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
            //{
            //    SqlConnection.Close();
            //}
            //Query.closeConnect();
        }
    }
}
