using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VetClinic.DB;

namespace VetClinic.Functions
{
    public class User
    {
        public static Clients Auth(string login, string password)
        {
            List<Clients> clients = new List<Clients>(DBConnection.clinic.Clients);
            var userExists = clients.FirstOrDefault(i=> i.Surname.Trim() == login && i.ClientID.ToString() == password);
            if (userExists == null)
            {
                MessageBox.Show("Такого пользователя не существует", "Ошибка пользователя", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show($"Клиент {userExists.Surname} {userExists.Name}", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return userExists;
        }
        public static Clients Reg(string Surname, string Name, string Patronymic, DateTime Birthday)
        {
            List<Clients> clients = new List<Clients>(DBConnection.clinic.Clients);
            Clients userReg = new Clients();
            if (Surname == null || Name == null || Patronymic == null || Birthday == null)
            {
                MessageBox.Show("Не все поля заполнены");
                userReg = null;
            }
            else
            {
                userReg.Surname = Surname;
                userReg.Name = Name;
                userReg.Patronymic = Patronymic;
                userReg.Birthday = Birthday;
                DBConnection.clinic.Clients.Add(userReg);
                DBConnection.clinic.SaveChanges();
                clients = new List<Clients>(DBConnection.clinic.Clients);
                userReg = clients.First(i => i.Surname == Surname && i.Name == Name);
                MessageBox.Show($"Ваш пароль {userReg.ClientID}");
            }
            return userReg;

        }

    }
}
