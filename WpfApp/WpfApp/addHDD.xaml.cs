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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for addHDD.xaml
    /// </summary>
    public partial class addHDD : Page
    {
        public addHDD()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pcid.Text != "")
            {
                Querys.addHDD(pcid.Text, company.Text, serialNumber.Text, space.Text);
                MessageBox.Show("Запись успешно добавленна");
            }
            else
            {
                errorLabel.Content = "Это поле должоно быть заполнено";
            }
        }
    }
}
