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
    /// Interaction logic for updateSysCharacteristics.xaml
    /// </summary>
    public partial class updateSysCharacteristics : Page
    {
        public updateSysCharacteristics()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pcIDBOX.Text != "")
            {
                Querys.updateSysChar(pcIDBOX.Text, prcessorFirm.Text, prcessorModel.Text, RAM.Text, opacty.Text, OS.Text);
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполненно";
            }
        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pcIDBOX.Text != "")
            {
                SysChar sysChar = Querys.GetSysCharDataByID(pcIDBOX.Text);
                if (sysChar != null)
                {
                    prcessorFirm.Text = sysChar.processorName;
                    prcessorModel.Text = sysChar.processorModel;
                    RAM.Text = sysChar.RAM;
                    opacty.Text = sysChar.capacity;
                    OS.Text = sysChar.operatingSystem;
                }
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполненно";
            }
        }
    }
}
