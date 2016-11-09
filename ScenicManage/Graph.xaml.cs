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
using Microsoft.Msagl;
using Microsoft.Msagl.WpfGraphControl;
using Microsoft.Msagl.Drawing;

namespace ScenicManage
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl
    {
        public MainWindow main;

        public Graph(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            //this.Content = Panel;
            Loaded += MainWindow_Loaded;

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            var nodes = main.storedata.scenicnode;
            GraphViewer graphViewer = new GraphViewer();
            graphViewer.BindToPanel(Panel);
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph();

            foreach(var node in nodes)
            {
                if (node.edges.Count == 0)
                {
                    graph.AddNode(new Node(node.name));
                }
                foreach(var edge in node.edges)
                {
                    graph.AddEdge(node.name, edge.GetDest(nodes).name);
                }
            }
            //graph.AddEdge("A", "B");
            foreach(var node in graph.Nodes)
            {
                node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
                node.Attr.Color = Microsoft.Msagl.Drawing.Color.Purple;
                node.Attr.LabelMargin = 10;
            }
            graph.Attr.LayerDirection = LayerDirection.LR;
            graphViewer.Graph = graph; // throws exception
        }
    }
}
