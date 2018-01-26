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
    /// Interaction logic for updateTech.xaml
    /// </summary>
    public partial class updateTech : Page
    {
        public updateTech()
        {
            InitializeComponent();
        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (techID.Text != "")
            {
                Querys.updateTech(techID.Text, typeBox.Text, firmBox.Text, modelNumber.Text, sirialNumber.Text, buisnesNumber.Text);
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполненно";
            }
        }
    }
}
