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

namespace Messenger.View.Authorization
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Messages.MainMessagesPage());
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Authorization.RegistrationPage());
        }

        private void PswrdVisBtn_Click(object sender, RoutedEventArgs e)
        {
            PswrdTB.Text = PswrdPB.Password;
            PswrdTB.Visibility = Visibility.Visible;
            PswrdPB.Visibility = Visibility.Collapsed;
            PswrdHidBtn.Visibility = Visibility.Visible;
            PswrdVisBtn.Visibility = Visibility.Collapsed;
        }

        private void PswrdHidBtn_Click(object sender, RoutedEventArgs e)
        {
            PswrdPB.Password = PswrdTB.Text;
            PswrdTB.Visibility = Visibility.Collapsed;
            PswrdPB.Visibility = Visibility.Visible;
            PswrdHidBtn.Visibility = Visibility.Collapsed;
            PswrdVisBtn.Visibility = Visibility.Visible;
        }
    }
}
