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
    /// Interaction logic for updateHDD.xaml
    /// </summary>
    public partial class updateHDD : Page
    {
        public updateHDD()
        {
            InitializeComponent();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(hddID.Text != "")
            {
                Querys.updateHDD(hddID.Text, company.Text, space.Text, serialNumber.Text);
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполннено";
            }
        }
    }
}
