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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private SimpleQueryResult SimpleQueryResult;
        //private AddEmploy AddEmploy;

        Window MainWin;
        MainWindow mainWindow = new MainWindow();
        public MainMenu(Window MainWin)
        {
            InitializeComponent();
            this.MainWin = MainWin;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainWin.Title = "Главное меню";
        }
        public void navigateToSQR()
        {
            NavigationService.Navigate(SimpleQueryResult);
        }
        private void allEmploy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employers = Querys.readEmployers();
                mainWindow.successfulConnection();
                SimpleQueryResult = new SimpleQueryResult(employers);
                NavigationService.Navigate(SimpleQueryResult);
                MainWin.Title = "Все сотрудники";
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
            }
        }



        private void allHDD_Click(object sender, RoutedEventArgs e)
        {
            //SimpleQueryResult = new SimpleQueryResult();
            SimpleQueryResult = new SimpleQueryResult(Querys.readHDD());
            NavigationService.Navigate(SimpleQueryResult);
            MainWin.Title = "Все жёсткие диски";
        }

        private void allTech_Click(object sender, RoutedEventArgs e)
        {
            //SimpleQueryResult = new SimpleQueryResult();
            SimpleQueryResult = new SimpleQueryResult(Querys.readTech());
            NavigationService.Navigate(SimpleQueryResult);
            MainWin.Title = "Вся техника";
        }

        private void allCharac_Click(object sender, RoutedEventArgs e)
        {
            //SimpleQueryResult = new SimpleQueryResult();
            SimpleQueryResult = new SimpleQueryResult(Querys.readSysCharacter());
            NavigationService.Navigate(SimpleQueryResult);
            MainWin.Title = "Вся характиристики";
        }

        private void addEmploy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmploy());
            MainWin.Title = "Добавить сотрудника";
        }

       
        private bool HasRows(DataTable room)
        {
            return room.Rows.Count > 0;
        }

        private void addSysCharacter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSystemCharacteristics());
            MainWin.Title = "Добавить сотрудника";
        }


        private void findEmployByRoom_Click(object sender, RoutedEventArgs e)
        {
            SearchEngine searchEngine = new SearchEngine();
            string str;
            bool hasInput = searchEngine.TryGetName("Поиск сотрудника по номеру кабинета", out str);
            if (hasInput)
            {
                var Rooms = Querys.employByRoom(str);
                if (HasRows(Rooms))
                {
                    SimpleQueryResult = new SimpleQueryResult(Rooms);
                    NavigationService.Navigate(SimpleQueryResult);
                }
                else
                {
                    searchEngine.checkError("Поиск сотрудника по номеру кабинета");
                }
            }
        }

        private void removeHDD_Click(object sender, RoutedEventArgs e)
        {
            SearchEngine searchEngine = new SearchEngine();
            string str;
            bool hasInput = searchEngine.TryGetHARDID("Удаление жёсткого диска", out str);
            if (hasInput)
            {
                if (Querys.DeleteHDD(str))
                {
                    MessageBox.Show("Запись удалена");
                }
            }
        }
        private void removeTech_Click(object sender, RoutedEventArgs e)
        {
            SearchEngine searchEngine = new SearchEngine();
            string str;
            bool hasInput = searchEngine.TryGetTech("Удаление техника", out str);
            if (hasInput)
            {
                if (Querys.DeleteTech(str))
                {
                    MessageBox.Show("Запись удалена");
                }
            }          
        }
        private void removeEmploy_Click(object sender, RoutedEventArgs e)
        {
            SearchEngine searchEngine = new SearchEngine();
            string str;
            bool hasInput = searchEngine.TryGetEmploy("Удалить сотрудника", out str);
            if (hasInput)
            {
                if (Querys.DeleteEmploy(str))
                {
                    MessageBox.Show("Запись удалена");
                }
            }
        }

        private void changeEmploy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new updateEmploy());
            MainWin.Title = "Изменить данные о сотруднике";
        }

        private void changeTechInfo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new updateTech());
            MainWin.Title = "Изменить данные о техники";
        }

        private void changeHDDIonfo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new updateHDD());
            MainWin.Title = "Изменить данные о жестком диске";
        }

        private void changeSystemCharac_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new updateSysCharacteristics());
            MainWin.Title = "Изменить данные о системных характиристиках";
        }

        private void addHDD_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addHDD());
            MainWin.Title = "Добавить жёсткий диск";
        }

        private void findHDDByEmploy_Click(object sender, RoutedEventArgs e)
        {
            SearchEngine searchEngine = new SearchEngine();
            string str;
            bool hasInput = searchEngine.TryGetSurname("Поиск жесткого диска по сотруднику", out str);
            if (hasInput)
            {
                var Rooms = Querys.hardDriveByEmploy(str);
                if (HasRows(Rooms))
                {
                    SimpleQueryResult = new SimpleQueryResult(Rooms);
                    NavigationService.Navigate(SimpleQueryResult);
                }
                else
                {
                    searchEngine.checkError("Поиск жесткого диска по сотруднику");
                }
            }
        }
    }
}
