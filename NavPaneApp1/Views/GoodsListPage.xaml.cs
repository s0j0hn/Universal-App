using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SupStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GoodsListPage : Page
    {
        private string XMLFileLocation = "DataGoods.xml";
        ObservableCollection<Good> obs_goods = new ObservableCollection<Good>();
        public GoodsListPage()
        {
            this.InitializeComponent();
            listgoods.Loaded += Goods_Loaded;
        }

        public void Goods_Loaded(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["XML_LOCATION"] = XMLFileLocation;
            XDocument goodsxmldoc = XDocument.Load(XMLFileLocation);
            foreach (var i in goodsxmldoc.Root.Descendants("dataModule"))
            {

                obs_goods.Add(new Good
                {
                    id = Convert.ToInt32(i.Element("id").Value),name = i.Element("name").Value,description = i.Element("description").Value,
                    quantity = i.Element("quantity").Value,location = i.Element("location").Value, storeprice = i.Element("storeprice").Value,
                    globalprice = i.Element("globalprice").Value
                });
            }
            listgoods.ItemsSource = obs_goods;
        }

        private async void loadfile_button_Click(object sender, RoutedEventArgs e)
        {

            /*FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".xml");
            openPicker.ViewMode = PickerViewMode.List;
            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                XDocument goodsxmldoc = XDocument.Parse(filepath);
                foreach (var i in goodsxmldoc.Root.Descendants("dataModule"))
                {

                    obs_goods.Add(new Good
                    {
                        id = Convert.ToInt32(i.Element("id").Value),
                        name = i.Element("name").Value,
                        description = i.Element("description").Value,
                        quantity = i.Element("quantity").Value,
                        location = i.Element("location").Value,
                        storeprice = i.Element("storeprice").Value,
                        globalprice = i.Element("globalprice").Value
                    });
                }
                listgoods.ItemsSource = obs_goods;
            }
            else
            {
                infoFile.Text = "Fail to load this file";
            }*/
        }
    }
}
