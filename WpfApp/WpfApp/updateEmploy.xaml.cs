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
    /// Interaction logic for updateEmploy.xaml
    /// </summary>
    public partial class updateEmploy : Page
    {
        public updateEmploy()
        {
            InitializeComponent();
        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(employID.Text != "")
            {
                Querys.updateEmploy(employID.Text, nameBox.Text, srunameBox.Text, patronymicBox.Text);
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполннено";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(employID.Text != "")
            {
                Employer employer = Querys.GetEmployDataByID(employID.Text);
                if (employer != null)
                {
                    nameBox.Text = employer.name;
                    srunameBox.Text = employer.surname;
                    patronymicBox.Text = employer.patronymic;
                }
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполннено";
            }
        }
    }
}
