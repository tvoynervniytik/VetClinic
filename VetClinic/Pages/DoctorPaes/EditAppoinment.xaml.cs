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

namespace VetClinic.Pages.DoctorPaes
{
    /// <summary>
    /// Логика взаимодействия для EditAppoinment.xaml
    /// </summary>
    public partial class EditAppoinment : Page
    {
        public static Appointment curAppointment;
        public static List<Clients> clients;
        public EditAppoinment(Appointment appointment)
        {
            InitializeComponent();
            AppTb.Text = appointment.AppointmentID.ToString();
            clients = new List<Clients>(DBConnection.clinic.Clients);
            curAppointment = appointment;
            ClientTb.Text = clients.FirstOrDefault(i => i.ClientID == curAppointment.Pets.ClientID).Surname + " "
                + clients.FirstOrDefault(i => i.ClientID == curAppointment.Pets.ClientID).Name[0] + ". "
                + clients.FirstOrDefault(i => i.ClientID == curAppointment.Pets.ClientID).Patronymic[0] + ".";
            DateTb.Text = curAppointment.DateTime.ToString();
            PetTb.Text = curAppointment.PetID.ToString();
            TypeAnimalTb.Text = curAppointment.Pets.TypeAnimal.Name;
            ConsolutionTb.Text = curAppointment.Conclusion;
            if (appointment.Doctors.PostID == 3)
                labBtn.Visibility = Visibility.Hidden;
            this.DataContext = this;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VetMainPage());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            curAppointment.Conclusion = ConsolutionTb.Text;
            DBConnection.clinic.SaveChanges();
            MessageBox.Show("Добавлено заключение");
        }

        private void labBtn_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.PetID = curAppointment.PetID;
            appointment.DoctorID = 8;
            appointment.DateTime = DateTime.Now;
            DBConnection.clinic.Appointment.Add(appointment);
            DBConnection.clinic.SaveChanges();
            MessageBox.Show($"Добавлена запись в лабораторию питомца {appointment.PetID}");
        }
    }
}
