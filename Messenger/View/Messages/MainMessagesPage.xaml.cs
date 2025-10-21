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

namespace Messenger.View.Messages
{
    /// <summary>
    /// Логика взаимодействия для MainMessagesPage.xaml
    /// </summary>
    public partial class MainMessagesPage : Page
    {
        public MainMessagesPage()
        {
            InitializeComponent();
            
        }

        private void AttachFileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendMsgBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V)
            {
                if(Clipboard.GetImage() != null)
                {
                    ImageBrush imageBrush = new ImageBrush();
                    AttachedFilesStackPannel.Visibility = Visibility.Visible;
                    Image image = new Image();
                    image.Source = MessagesClasses.ImagePreviewCreation(Clipboard.GetImage()).Source;
                    imageBrush.ImageSource = MessagesClasses.ImagePreviewCreation(Clipboard.GetImage()).Source;
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 120;
                    rectangle.Height = 120;
                    MainGrid.Background = imageBrush;
                       
                }
            }
        }
    }
}
