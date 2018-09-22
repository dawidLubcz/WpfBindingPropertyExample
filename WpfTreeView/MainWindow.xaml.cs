using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            treeViewInstance.Items.Add(new TestItem() { Name = "Name1", Value = "Value1" });
            treeViewInstance.Items.Add(new TestItem() { Name = "Name2", Value = "Value2" });
            treeViewInstance.Items.Add(new TestItem() { Name = "Name3", Value = "Value3" });
        }

        private void treeViewInstance_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
        }

        private void treeViewInstance_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                TreeView tree = sender as TreeView;
                var item = tree.SelectedItem as TestItem;
                if (item != null)
                    item.Selected = false;
            }
        }
    }

    public class TestItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Value { get; set; }

        private bool _Selected;
        public bool Selected
        {
            get { return _Selected; }
            set
            {
                _Selected = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
