using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Messenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Messenger.View.Authorization.LoginPage();
        }
        private void CollapseBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWdw.WindowState = WindowState.Minimized;
        }

        private void BigWdwBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWdw.WindowState = WindowState.Maximized;
            SmallWdwBtn.Visibility = Visibility.Visible;
            BigWdwBtn.Visibility = Visibility.Collapsed;
            MainContentBorder.Padding = new Thickness(7);
        }

        private void SmallWdwBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWdw.WindowState = WindowState.Normal;
            SmallWdwBtn.Visibility = Visibility.Collapsed;
            BigWdwBtn.Visibility = Visibility.Visible;
            MainContentBorder.Padding = new Thickness(0);
        }

        private void CloseWdwBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWdw.Close();
        }
        private void HeaderBd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWdw.WindowState == WindowState.Maximized)
            {
                MainWdw.WindowState = WindowState.Normal;
                SmallWdwBtn.Visibility = Visibility.Collapsed;
                BigWdwBtn.Visibility = Visibility.Visible;
                MainContentBorder.Padding = new Thickness(0);
            }
            MainWdw.DragMove();
            
        }

        private void MainWdw_StateChanged(object sender, EventArgs e)
        {
            if (MainWdw.WindowState == WindowState.Maximized)
            {
                MainWdw.WindowState = WindowState.Maximized;
                SmallWdwBtn.Visibility = Visibility.Visible;
                BigWdwBtn.Visibility = Visibility.Collapsed;
                MainContentBorder.Padding = new Thickness(7);
            }
            else
            {
                MainWdw.WindowState = WindowState.Normal;
                SmallWdwBtn.Visibility = Visibility.Collapsed;
                BigWdwBtn.Visibility = Visibility.Visible;
                MainContentBorder.Padding = new Thickness(0);
            }
        }
    }
}