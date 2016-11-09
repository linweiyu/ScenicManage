using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using Newtonsoft.Json;
using System.IO;

namespace ScenicManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StoreData storedata;
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("ScenicData.json"))
            {
                var data = File.ReadAllText("ScenicData.json");
                storedata = JsonConvert.DeserializeObject<StoreData>(data);
            }
            else
            {
                File.Create("ScenicData.json");
                storedata = new StoreData();
                storedata.scenicnode = new List<ScenicNode>();
            }
            Item.Item create = new Item.Item();
            create.Name = "创建景点分布图";
            create.Content = new Create(this);

            Item.Item graph = new Item.Item();
            graph.Name = "查看景点分布图";
            graph.Content = new Graph(this);
            DemoItemsListBox.Items.Add(graph);
            DemoItemsListBox.Items.Add(create);


        }

        private void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
        }
        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            storedata.NodeCount = storedata.scenicnode.Count;
            File.WriteAllText("ScenicData.json",JsonConvert.SerializeObject(storedata));
        }
    }
}
