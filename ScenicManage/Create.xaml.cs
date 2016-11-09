using System;
using System.Collections.Generic;
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

namespace ScenicManage
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : UserControl
    {
        public MainWindow main;
        public Create(MainWindow main)
        {
            InitializeComponent();
            welcomeDegree.ItemsSource = System.Enum.GetValues(typeof(Popularity));
            this.main=main;
            LeftNode.ItemsSource = main.storedata.scenicnode;
            RightNode.ItemsSource = main.storedata.scenicnode;
        }

        private void CreateNode_Click(object sender, RoutedEventArgs e)
        {
            var newnode = new ScenicNode(name.Text.Trim(), description.Text.Trim(), (Popularity)welcomeDegree.SelectedItem, CanRest.IsChecked.GetValueOrDefault(), IsWC.IsChecked.GetValueOrDefault());
            newnode.id = ++main.storedata.NodeCount;
            main.storedata.scenicnode.Add(newnode);
            MessageBox.Show("成功创建");
            name.Clear();
            description.Clear();
            welcomeDegree.SelectedIndex = -1;
            CanRest.IsChecked = false;
            IsWC.IsChecked = false;
        }

        private void CreateEdge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var leftscenic = (ScenicNode)LeftNode.SelectedItem;
                var rightscenic= (ScenicNode)RightNode.SelectedItem;
                var newledge = new Edge(leftscenic.id, double.Parse(time.Text.Trim()),double.Parse(distance.Text.Trim()));
                var newredge= new Edge(rightscenic.id, double.Parse(time.Text.Trim()), double.Parse(distance.Text.Trim()));
                leftscenic.edges.Add(newredge);
                rightscenic.edges.Add(newledge);
                MessageBox.Show("成功创建联系");
                LeftNode.SelectedIndex = -1;
                RightNode.SelectedIndex = -1;
                time.Clear();
                distance.Clear();
            }
            catch
            {
                MessageBox.Show("输入不合法");
            }
        }
    }
}
