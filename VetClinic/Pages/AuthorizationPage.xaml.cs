﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginTb.Text.Trim() == User.userNameAdm && passwordTb.Password.Trim() == User.passwordAdm)
            {
                User.Role = 3;
                MessageBox.Show("Администратор-регистратор");
                NavigationService.Navigate(new AdmMainPage());
            }
            else
            {
               
                Doctors doctor = new Doctors();
                doctor = User.AuthVet(loginTb.Text.Trim(), passwordTb.Password.Trim());
                if (doctor != null)
                {
                    User.Role = 2;
                    NavigationService.Navigate(new VetMainPage());
                }
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
