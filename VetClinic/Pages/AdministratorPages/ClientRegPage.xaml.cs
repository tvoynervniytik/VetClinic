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
using VetClinic.DB;
using VetClinic.Functions;

namespace VetClinic.Pages.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для ClientRegPage.xaml
    /// </summary>
    public partial class ClientRegPage : Page
    {
        public ClientRegPage()
        {
            InitializeComponent();
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTb.Text == "" || PatronymicTb.Text == "" || surnameTb.Text == "" || dateDp.SelectedDate == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                var userR = User.RegClient(nameTb.Text.Trim(), surnameTb.Text.Trim(), PatronymicTb.Text.Trim(), dateDp.SelectedDate.Value);
                if (userR != null)
                {
                    NavigationService.Navigate(new AdmMainPage());
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmMainPage());
        }
    }
}
