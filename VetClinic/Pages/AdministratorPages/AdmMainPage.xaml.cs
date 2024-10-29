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
using VetClinic.Pages.AdministratorPages;

namespace VetClinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class AdmMainPage : Page
    {
        public AdmMainPage()
        {
            InitializeComponent();
        }

        private void clientAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientRegPage());
        }

        private void petAddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
