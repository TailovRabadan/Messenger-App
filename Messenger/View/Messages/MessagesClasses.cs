using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Messenger.View.Messages
{
    class MessagesClasses
    {
        //Method for creating chat in chat list
        public static Button CreateChatInList(string ImgSrc, string ChatName, string ChatDescription)
        {
            Button ChatButton = new Button();
            ChatButton = _ChatInList(ImgSrc, ChatName, ChatDescription) ;
            return ChatButton;
        }
        //Encapsulation of CreateChatInList method
        private static Button _ChatInList(string ImgSrc, string ChatName, string ChatDescription)
        {
            Button ChatBtn = new Button();
            Border MainChatBorder = new Border();
            Grid ChatGrid = new Grid();
            Image PfpImg = new Image();
            Label ChatNameLabel = new Label();
            Label ChatDescriptionLabel = new Label();
            Border SplitBorder = new Border();
            RowDefinition rowDefinition1 = new RowDefinition();
            RowDefinition rowDefinition2 = new RowDefinition();
            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            ColumnDefinition columnDefinition2 = new ColumnDefinition();

            ChatBtn.VerticalAlignment = VerticalAlignment.Center;
            ChatBtn.HorizontalAlignment = HorizontalAlignment.Center;
            ChatBtn.Margin = new Thickness(0, 5, 0, 5);

            MainChatBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 215, 221, 224));
            MainChatBorder.BorderThickness = new Thickness(1);
            MainChatBorder.VerticalAlignment = VerticalAlignment.Center;
            MainChatBorder.HorizontalAlignment = HorizontalAlignment.Center;

            ChatGrid.Background = new SolidColorBrush(Colors.Transparent);
            ChatGrid.Height = 60;
            ChatGrid.Width = 300;
            ChatGrid.ColumnDefinitions.Add(columnDefinition1);
            ChatGrid.ColumnDefinitions.Add(columnDefinition2);
            ChatGrid.RowDefinitions.Add(rowDefinition1);
            ChatGrid.RowDefinitions.Add(rowDefinition2);

            //PfpImg.OpacityMask = Messenger.Resources.PfpOpacityMask.png
            PfpImg.Source = Base64ToImage(ImgSrc);

            ChatNameLabel.Background = new SolidColorBrush(Colors.Transparent);
            ChatNameLabel.BorderThickness = new Thickness(0);
            ChatNameLabel.FontSize = 16;
            ChatNameLabel.Foreground = new SolidColorBrush(Colors.NavajoWhite);
            ChatNameLabel.VerticalContentAlignment = VerticalAlignment.Center;
            ChatNameLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            ChatNameLabel.Content = ChatName;

            ChatDescriptionLabel.Background = new SolidColorBrush(Colors.Transparent);
            ChatDescriptionLabel.BorderThickness = new Thickness(0);
            ChatDescriptionLabel.FontSize = 16;
            ChatDescriptionLabel.Foreground = new SolidColorBrush(Colors.NavajoWhite);
            ChatDescriptionLabel.VerticalContentAlignment = VerticalAlignment.Center;
            ChatDescriptionLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            ChatDescriptionLabel.Content = ChatDescription;

            SplitBorder.Width = 240;
            SplitBorder.BorderBrush = new SolidColorBrush(Colors.White);
            SplitBorder.BorderThickness = new Thickness(0.25);
            SplitBorder.VerticalAlignment = VerticalAlignment.Center;
            SplitBorder.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(PfpImg, 0);
            Grid.SetColumn(ChatNameLabel, 1);
            Grid.SetColumn(SplitBorder, 1);
            Grid.SetColumn(ChatDescriptionLabel, 1);
            Grid.SetRow(PfpImg, 0);
            Grid.SetRow(ChatNameLabel, 0);
            Grid.SetRow(SplitBorder, 0);
            Grid.SetRow(ChatDescriptionLabel, 0);
            Grid.SetRowSpan(PfpImg, 2);
            Grid.SetRowSpan(SplitBorder, 2);



            columnDefinition1.Width = new GridLength(60);
            columnDefinition1.Width = new GridLength(240);

            ChatGrid.Children.Add(PfpImg);
            ChatGrid.Children.Add(ChatNameLabel);
            ChatGrid.Children.Add(SplitBorder);
            ChatGrid.Children.Add(ChatDescriptionLabel);
            MainChatBorder.Child = ChatGrid;
            ChatBtn.Content = MainChatBorder;
            return ChatBtn;
        }
        //Method to encode image
        public static string ImageToBase64(BitmapImage imageAchieved)
        {
            string result = _ImageToBase64(imageAchieved);
            return result;
        }
        //Encapsulation of ImageToBase64 method
        private static string _ImageToBase64(BitmapImage imageAchieved)
        {
            string result; 
            if (imageAchieved == null) 
            {
                MessageBox.Show("Achieved empty image, try again");
                result = "Error";
                return result;
            }
            else
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imageAchieved));

                byte[] imageBytes = null;
                using (MemoryStream ms =new MemoryStream())
                {
                    encoder.Save(ms);
                    imageBytes = ms.ToArray();
                }
                result = Convert.ToBase64String(imageBytes);
                return result;
            }
        }
        //Method to decode Image from base64
        public static BitmapImage Base64ToImage(string Base64String)
        {
            BitmapImage bitmapImage = _Base64ToImage(Base64String);
            return bitmapImage;
        }
        //Encapsulation of Base64ToImage method
        private static BitmapImage _Base64ToImage(string Base64String)
        {
            if (String.IsNullOrEmpty(Base64String) || Base64String == "Error")
            {
                MessageBox.Show("Achieved empty image");
                return null;
            }
            else
            {
                byte[] imageBytes = Convert.FromBase64String(Base64String);
                BitmapImage result = new BitmapImage();
                using (MemoryStream ms = new MemoryStream())
                {
                    result.BeginInit();
                    result.CacheOption = BitmapCacheOption.OnLoad;
                    result.StreamSource = ms;
                    result.EndInit();
                }
                return result;
            }
        }
        //Method to create preview of sending Image
        public static Image ImagePreviewCreation(BitmapSource image)
        {
            Image ImagePreview = _ImagePreviewCreation(image);

            return ImagePreview;
        }

        //Encapsulation of ImagePreviewCreation method
        private static Image _ImagePreviewCreation(BitmapSource image)
        {
            Image ImagePreview = new Image();
            ImagePreview.Height = 120;
            ImagePreview.Width = 120;
            ImagePreview.Margin = new Thickness(10);
            ImagePreview.Stretch = Stretch.Uniform;
            ImagePreview.Source = image;
            return ImagePreview;
        }

        //Method to convert BitmapSource to BitmapImage
        public static BitmapImage BitmapSrcToImg(BitmapSource bitmapSource)
        {
            BitmapImage FinalImage = _BitmapSrcToImg(bitmapSource);

            return FinalImage;
        }

        //Encapsulation of BitmapSrcToImg method
        private static BitmapImage _BitmapSrcToImg(BitmapSource bitmapSource)
        {
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            MemoryStream ms = new MemoryStream();
            BitmapImage FinalImage = new BitmapImage();

            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.Save(ms);

            ms.Position = 0;
            FinalImage.BeginInit();
            FinalImage.StreamSource = ms;
            FinalImage.EndInit();

            ms.Close();

            return FinalImage;
        }
    }
}
