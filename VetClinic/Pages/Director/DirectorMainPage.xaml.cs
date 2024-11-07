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

namespace VetClinic.Pages.Director
{
    /// <summary>
    /// Логика взаимодействия для DirectorMainPage.xaml
    /// </summary>
    public partial class DirectorMainPage : Page
    {
        private static List<Pets> pets {  get; set; }
        private static List<Doctors> doctors { get; set; }
        private static List<Appointment> appointments { get; set; }
        public DirectorMainPage()
        {
            InitializeComponent();

            Refresh();
            this.DataContext = this;
        }
        private void Refresh()
        {
            pets = new List<Pets>(DBConnection.clinic.Pets);
            doctors = new List<Doctors>(DBConnection.clinic.Doctors);
            appointments = new List<Appointment>(DBConnection.clinic.Appointment);
            var cb = reportCb.SelectedIndex;
            var startDate = startDp.SelectedDate;
            var endDate = endDp.SelectedDate;
            if (startDate > endDate) { MessageBox.Show("Дата начала не может быть больше даты конца", "error", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                if (startDate != null)
                {
                    appointments = appointments.Where(i => i.DateTime >= startDate).ToList();
                }
                    
                if (endDate != null)
                    appointments = appointments.Where(i=>i.DateTime <= endDate).ToList();
            }
            
            if (cb == 0)
            {
                worktimeLv.Visibility = Visibility.Visible;

                foreach (Doctors doctor in doctors)
                {
                    var work = appointments.Where(i => i.DoctorID == doctor.DoctorID).Count();
                    doctor.TimeQuantity = work * 20;
                    doctor.AppoinmentsQuantity = work;
                }
                worktimeLv.ItemsSource = doctors;
            }
            else if (cb == 1) 
            { 
                worktimeLv.Visibility = Visibility.Hidden;
            }
        }
        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            var typeReport = reportCb.SelectedItem;
            if (typeReport == null)
            {
                MessageBox.Show("Не выбран тип отчёта!", "ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            { 
                Refresh();
            }
        }

        private void reportCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
