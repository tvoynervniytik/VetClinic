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

namespace VetClinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private static List<Posts> posts {  get; set; }
        public RegistrationPage()
        {
            InitializeComponent();
            posts = new List<Posts>(DBConnection.clinic.Posts);
            postCb.ItemsSource = posts;
            this.DataContext = this;
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            var post = postCb.SelectedItem as Posts;
            if (nameTb.Text == "" || PatronymicTb.Text == "" || surnameTb.Text == "" || dateDp.SelectedDate == null || diplomTb.Text == "" || post == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                int postId = post.PostID;
                var userR = User.Reg(nameTb.Text.Trim(), surnameTb.Text.Trim(), PatronymicTb.Text.Trim(), dateDp.SelectedDate.Value, diplomTb.Text, postId);
                if (userR != null)
                {
                    NavigationService.Navigate(new AuthorizationPage());
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
