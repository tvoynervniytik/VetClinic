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
    /// Логика взаимодействия для PetRegPAge.xaml
    /// </summary>
    public partial class PetRegPage : Page
    {
        private static List<Clients> clients {  get; set; }
        private static List<TypeAnimal> types {  get; set; }
        public PetRegPage()
        {
            InitializeComponent();

            clients = new List<Clients>(DBConnection.clinic.Clients);
            types = new List<TypeAnimal>(DBConnection.clinic.TypeAnimal);
            clientsCb.ItemsSource = clients;
            typeCb.ItemsSource = types;
            this.DataContext = this;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmMainPage());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var client = clientsCb.SelectedItem as Clients;
            var type = typeCb.SelectedItem as TypeAnimal;
            if (clientsCb.SelectedItem == null || typeCb.SelectedItem == null || birthdayDp.SelectedDate == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                var userR = User.RegPet(type.TypeAnimalID, client.ClientID, birthdayDp.SelectedDate.Value);
                if (userR != null)
                {
                    NavigationService.Navigate(new AdmMainPage());
                }
            }
        }
    }
}
