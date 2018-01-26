using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class SearchEngine
    {
        public bool TryGetName(string title, out string name)
        {
            Search search = new Search(title);
            search.TitleLabel.Content = "Введите номер кабинета";

            search.ShowDialog();
            name = search.Input;

            return !String.IsNullOrWhiteSpace(name);
        }
        public bool TryGetHARDID(string title, out string name)
        {
            Delete delete = new Delete(title);
            delete.TitleLabel.Content = "Введите ID ПК";
            delete.ShowDialog();
            name = delete.Input;

            return !String.IsNullOrWhiteSpace(name);
        }
        public bool TryGetEmploy(string title, out string name)
        {
            Delete delete = new Delete(title);
            delete.TitleLabel.Content = "Введите ID сотрудника";
            delete.ShowDialog();
            name = delete.Input;

            return !String.IsNullOrWhiteSpace(name);
        }
        public bool TryGetTech(string title, out string name)
        {
            Delete delete = new Delete(title);
            delete.TitleLabel.Content = "Введите ID техники";
            delete.ShowDialog();
            name = delete.Input;

            return !String.IsNullOrWhiteSpace(name);
        }
        public void checkError(string title)
        {
            Search search = new Search(title);
            search.ErrorLabel.Content = "Совпадений не найдено";
        }
        public bool TryGetSurname(string title, out string name)
        {
            Search search = new Search(title);
            search.TitleLabel.Content = "Введите фамилию сотрудника";
            search.ShowDialog();
            name = search.Input;

            return !String.IsNullOrWhiteSpace(name);
        }
    }
}
