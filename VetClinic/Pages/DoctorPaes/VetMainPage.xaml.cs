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
using VetClinic.Pages.DoctorPaes;

namespace VetClinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class VetMainPage : Page
    {
        private static List<Appointment> appointments;
        private static List<Pets> pets;
        private static List<TypeAnimal> types;
        private static List<Clients> clients;
        public VetMainPage()
        {
            InitializeComponent();

            appointments = new List<Appointment>(DBConnection.clinic.Appointment);
            pets = new List<Pets>(DBConnection.clinic.Pets);
            clients = new List<Clients>(DBConnection.clinic.Clients);
            types = new List<TypeAnimal>(DBConnection.clinic.TypeAnimal);
            appoinmentLv.ItemsSource = appointments.Where(i=> i.DateTime.Date == DateTime.Now.Date && i.DoctorID == User.doctor.DoctorID);
            this.DataContext = this;
        }

        private void appoinmentLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentAppoinment = appoinmentLv.SelectedItem as Appointment;
            NavigationService.Navigate(new EditAppoinment(currentAppoinment));
        }
    }
}
