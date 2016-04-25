using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

namespace SupStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        RandomAccessStreamReference mapIconStreamReference;
        // the default parameter
        Geopoint CAEN_LOCATION = new Geopoint(new BasicGeoposition() { Latitude = 49.201537, Longitude = -0.392917 });
        Geopoint ROUEN_LOCATION = new Geopoint(new BasicGeoposition() { Latitude = 49.412842, Longitude = 1.069670 });
        Geopoint HAVRE_LOCATION = new Geopoint(new BasicGeoposition() { Latitude = 49.493155, Longitude = 0.112374 });
        private String CAEN_TITLE = "Caen Shop";
        private String ROUEN_TITLE = "Rouen Shop";
        private String HAVRE_TITLE = "Havre Shop";

        public MapPage()
        {
            this.InitializeComponent();
                       
            companyMap.Loaded += CompanyMap_Loaded;
            //Marker image
            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPin.png"));
            
        }

        public void CompanyMap_Loaded(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            
            //
            //We init the default numbers for our shops before they can be modifed in settings
            //
            if (localSettings.Values["firstlaunch"].Equals(true))
            {
                localSettings.Values["firstlaunch"] = false;
                localSettings.Values["Shop1_title"] = CAEN_TITLE;
                localSettings.Values["Shop1_latitude"] = CAEN_LOCATION.Position.Latitude;
                localSettings.Values["Shop1_longitude"] = CAEN_LOCATION.Position.Longitude;

                localSettings.Values["Shop2_title"] = ROUEN_TITLE;
                localSettings.Values["Shop2_latitude"] = ROUEN_LOCATION.Position.Latitude;
                localSettings.Values["Shop2_longitude"] = ROUEN_LOCATION.Position.Longitude;

                localSettings.Values["Shop3_title"] = HAVRE_TITLE;
                localSettings.Values["Shop3_latitude"] = HAVRE_LOCATION.Position.Latitude;
                localSettings.Values["Shop3_longitude"] = HAVRE_LOCATION.Position.Longitude;
            }
            
            // center the camera
            companyMap.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 49.201537,
                Longitude = -0.392917
            });
            companyMap.ZoomLevel = 9;
            //Position of all shops
            Geopoint CAEN = new Geopoint(new BasicGeoposition() { Latitude = Convert.ToDouble( localSettings.Values["Shop1_latitude"]), Longitude = Convert.ToDouble(localSettings.Values["Shop1_longitude"]) });
            Geopoint ROUEN = new Geopoint(new BasicGeoposition() { Latitude = Convert.ToDouble(localSettings.Values["Shop2_latitude"]), Longitude = Convert.ToDouble(localSettings.Values["Shop2_longitude"]) });
            Geopoint HAVRE = new Geopoint(new BasicGeoposition() { Latitude = Convert.ToDouble(localSettings.Values["Shop3_latitude"]), Longitude = Convert.ToDouble(localSettings.Values["Shop3_longitude"]) });

            //init of each shop
            MapIcon shop1 = new MapIcon();
            shop1.Location = CAEN; 
            shop1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            shop1.Title = (string) localSettings.Values["Shop1_title"];
            shop1.Image = mapIconStreamReference;
            companyMap.MapElements.Add(shop1);

            MapIcon shop2 = new MapIcon();
            shop2.Location = ROUEN;
            shop2.NormalizedAnchorPoint = new Point(0.5, 1.0);
            shop2.Title = (string) localSettings.Values["Shop2_title"];
            shop2.Image = mapIconStreamReference;
            companyMap.MapElements.Add(shop2);

            MapIcon shop3 = new MapIcon();
            shop3.Location = HAVRE;
            shop3.NormalizedAnchorPoint = new Point(0.5, 1.0);
            shop3.Title = (string) localSettings.Values["Shop3_title"];
            shop3.Image = mapIconStreamReference;
            companyMap.MapElements.Add(shop3);

        }
    }
}
