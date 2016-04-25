using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
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
            //populate the combobox
            for (int i = 1; i < NBOFSHOPS; i++)
            {
                shops.Add((string)localSettings.Values["Shop"+i+"_title"]);
            }
            comboBox_shops.ItemsSource = shops;
            actuallink_text.Text = "Actual ad link : " + (string)localSettings.Values["AdLink"];
        }

        private void button_adlink_save_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["AdLink"] = textBox_adlink.Text.Replace(" ", "");
            actuallink_text.Text = "Actual ad link : " + (string)localSettings.Values["AdLink"];
        }

        private void comboBox_shops_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            int shopindex = comboBox_shops.SelectedIndex;
            switch (shopindex)
            {
                case 0:
                    textBox_shop_name.Text = (string)localSettings.Values["Shop1_title"];
                    textBox_shop_latitude.Text = localSettings.Values["Shop1_latitude"].ToString();
                    textBox_shop_longitude.Text = localSettings.Values["Shop1_longitude"].ToString();
                    break;
                case 1:
                    textBox_shop_name.Text = (string)localSettings.Values["Shop2_title"];
                    textBox_shop_latitude.Text = (string)localSettings.Values["Shop2_latitude"].ToString();
                    textBox_shop_longitude.Text = (string)localSettings.Values["Shop2_longitude"].ToString();
                    break;
                case 2:
                    textBox_shop_name.Text = (string)localSettings.Values["Shop3_title"];
                    textBox_shop_latitude.Text = (string)localSettings.Values["Shop3_latitude"].ToString();
                    textBox_shop_longitude.Text = (string)localSettings.Values["Shop3_longitude"].ToString();
                    break;
                default:
                    break;
            }
        }

        private void button_shop_save_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            int shopindex = comboBox_shops.SelectedIndex;
            switch (shopindex)
            {
                case 0:
                    localSettings.Values["Shop1_title"] = textBox_shop_name.Text;
                    localSettings.Values["Shop1_latitude"] = textBox_shop_latitude.Text;
                    localSettings.Values["Shop1_longitude"] = textBox_shop_longitude.Text;
                    break;
                case 1:
                    localSettings.Values["Shop2_title"] = textBox_shop_name.Text;
                    localSettings.Values["Shop2_latitude"] = textBox_shop_latitude.Text;
                    localSettings.Values["Shop2_longitude"] = textBox_shop_longitude.Text;
                    break;
                case 2:
                    localSettings.Values["Shop3_title"] = textBox_shop_name.Text;
                    localSettings.Values["Shop3_latitude"] = textBox_shop_latitude.Text;
                    localSettings.Values["Shop3_longitude"] = textBox_shop_longitude.Text;
                    break;
                default:
                    break;
            }
        }

        private void button_reset_settings(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            //reset the settings for each value
            foreach (KeyValuePair<string, object> s in localSettings.Values)
            {
                localSettings.Values.Remove(s.Key);
            }
            var localSetting = ApplicationData.Current.LocalSettings;
            localSettings.Values["firstlaunch"] = true;
            localSettings.Values["AdLink"] = "http://Yourlink.mkv";
            actuallink_text.Text = "Actual ad link : " + (string)localSettings.Values["AdLink"];
        }
    }
}
