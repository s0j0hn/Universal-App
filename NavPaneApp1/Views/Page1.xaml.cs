using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls;

namespace NavPaneApp1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        RandomAccessStreamReference mapIconStreamReference;
        Geopoint CAEN_LOCATION = new Geopoint(new BasicGeoposition() { Latitude = 49.201537, Longitude = -0.392917 });
        Geopoint ROUEN_LOCATION = new Geopoint(new BasicGeoposition() { Latitude = 49.412842, Longitude = 1.069670 });
        Geopoint HAVRE_LOCATION = new Geopoint(new BasicGeoposition() { Latitude = 49.493155, Longitude = 0.112374 });
        private String CAEN_TITLE = "Caen Shop";
        private String ROUEN_TITLE = "Rouen Shop";
        private String HAVRE_TITLE = "Havre Shop";

        public Page1()
        {
            this.InitializeComponent();
            companyMap.Loaded += CompanyMap_Loaded;
            //Marker image
            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPin.png"));
        }

        public void CompanyMap_Loaded(object sender, RoutedEventArgs e)
        {
            companyMap.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 49.201537,
                Longitude = -0.392917
            });
            companyMap.ZoomLevel = 18;
            //Position of all shops
            MapIcon shop1 = new MapIcon();
            shop1.Location = CAEN_LOCATION;
            shop1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            shop1.Title = CAEN_TITLE;
            shop1.Image = mapIconStreamReference;
            companyMap.MapElements.Add(shop1);

            MapIcon shop2 = new MapIcon();
            shop2.Location = ROUEN_LOCATION;
            shop2.NormalizedAnchorPoint = new Point(0.5, 1.0);
            shop2.Title = ROUEN_TITLE;
            shop2.Image = mapIconStreamReference;
            companyMap.MapElements.Add(shop2);

            MapIcon shop3 = new MapIcon();
            shop3.Location = HAVRE_LOCATION;
            shop3.NormalizedAnchorPoint = new Point(0.5, 1.0);
            shop3.Title = HAVRE_TITLE;
            shop3.Image = mapIconStreamReference;
            companyMap.MapElements.Add(shop3);

        }
    }
}
