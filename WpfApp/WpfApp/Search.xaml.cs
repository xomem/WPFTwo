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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    /// 

    public partial class Search : Window
    {
        public string Input { get; private set; }

        public Search(string title)
        {
            InitializeComponent();
            this.Title = title;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text != "")
            {
                Input = TextBox.Text;
                Close();
            }
            else
            {
                ErrorLabel.Content = "Поле должно быть заполнено";
            }
        }
    }
}
