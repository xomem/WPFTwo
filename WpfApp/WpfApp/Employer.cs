using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class Employer
    {
        static string ConnectionAdres = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SOVAJJ\Google Drive\WpfApp\WpfApp\MainDatabase.mdf;Integrated Security=True";


        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }


        public void GetDataByID(string id)
        {

        }


    }
}
