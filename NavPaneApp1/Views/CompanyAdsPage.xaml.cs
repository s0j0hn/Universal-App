using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SupStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CompanyAdsPage : Page
    {
       
        public CompanyAdsPage()
        {
            this.InitializeComponent();
            advideo.Loaded += Advideo_Loaded;
        }

        public void Advideo_Loaded(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Uri link = new Uri((string) localSettings.Values["AdLink"]);
            
            advideo.Source = link;
        }
    }
}
