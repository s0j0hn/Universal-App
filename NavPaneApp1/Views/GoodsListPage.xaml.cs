using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SupStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GoodsListPage : Page
    {
        ObservableCollection<Good> obs_goods = new ObservableCollection<Good>();
        public GoodsListPage()
        {
            this.InitializeComponent();
            listgoods.Loaded += Goods_Loaded;
        }

        public void Goods_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument goodsxmldoc = XDocument.Load("DataGoods.xml");
            foreach (var i in goodsxmldoc.Root.Descendants("dataModule"))
            {

                obs_goods.Add(new Good
                {
                    id = Convert.ToInt32(i.Element("id").Value),name = i.Element("name").Value,description = i.Element("description").Value,
                    quantity = i.Element("quantity").Value,location = i.Element("location").Value
                });
            }
            listgoods.ItemsSource = obs_goods;
        }
    }
}
