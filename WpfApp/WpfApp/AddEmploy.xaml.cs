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
    /// Interaction logic for AddEmploy.xaml
    /// </summary>
    public partial class AddEmploy : Page
    {
        //private Querys querys;
        Querys querys = new Querys();

        public AddEmploy()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(nameBox.Text != "" && srunameBox.Text != "")
            {
                Querys.addEmploy(nameBox.Text, srunameBox.Text, patronymicBox.Text);
                MessageBox.Show("Запись успешно добавленна");
            }
            else if(nameBox.Text == "")
            {
                errorLabel.Content = "Это поле должно быть заполненно";
            }
            else
            {
                errorLabelSur.Content = "Это поле должно быть заполненно";
            }
        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
