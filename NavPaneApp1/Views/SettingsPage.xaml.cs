using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;

namespace SupStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private int NBOFSHOPS = 3;
        List<string> shops = new List<string>(); 
        public SettingsPage()
        {
            this.InitializeComponent();
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            NBOFSHOPS += 1;
            for (int i = 1; i < NBOFSHOPS; i++)
            {
                shops.Add((string)localSettings.Values["Shop"+i+"_title"]);
            }
            comboBox_shops.ItemsSource = shops;
        }

        private void button_adlink_save_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["AdLink"] = textBox_adlink.Text;
            actuallink_text.Text = "Actual ad link : " + (string)localSettings.Values["AdLink"];
        }

        private void comboBox_shops_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
