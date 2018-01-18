using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Navigation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> favoriteSites;

        public MainWindow()
        {
            InitializeComponent();

            favoriteSites = new ObservableCollection<string>
            {
                "https://www.google.com",
                "https://www.yandex.com",
                "https://www.mail.ru",
            };

            favoriteList.ItemsSource = favoriteSites;
        }

        private void UrlAddress_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (urlAddress.Text == "Введите URL")
            {
                urlAddress.Text = "";
                urlAddress.Foreground = Brushes.Black;
            }
        }

        private void UrlAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            if (urlAddress.Text == "")
            {
                urlAddress.Text = "Введите URL";
                urlAddress.Foreground = Brushes.Gray;
            }
            
        }

        private void AddToFavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            if (urlAddress.Text.Contains("http://") || urlAddress.Text.Contains("https://"))
            {
                favoriteSites.Add(urlAddress.Text);
            }
        }

        private void UrlAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter&&urlAddress.Text.Contains("http://")|| urlAddress.Text.Contains("https://"))
            {
                browser.Navigate(urlAddress.Text);
            }
        }

        private void FavoriteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            browser.Navigate(favoriteList.SelectedItem.ToString());
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(urlAddress.Text);
        }

        private void PasteButton_Click(object sender, RoutedEventArgs e)
        {
            urlAddress.Text = Clipboard.GetText();
        }
    }
}
