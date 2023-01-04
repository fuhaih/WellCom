using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WellCom.Models;

namespace WellCom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TestName { get; set; } = "测试数据";

        public ObservableCollection<ActionTabItem> Tabs { get; set; } = new ObservableCollection<ActionTabItem>();

        public MainWindow()
        {
            InitializeComponent();
            // Bind the xaml TabControl to view model tabs
            actionTabs.ItemsSource = Tabs;
            // Populate the view model tabs
            //vmd.Populate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataContext = this;
            ////Container.Add(new ComControl());
            ComControl control = new ComControl();
            ActionTabItem item = new ActionTabItem();
            //item.Name = "Test";
            item.Header = "窗体1";
            item.Content = control;
            Tabs.Add(item);
            ActionTabItem item2 = new ActionTabItem();
            item2.Header = "窗体2";
            item2.Content = new ComControl();
            Tabs.Add(item2);
            //item.HorizontalAlignment = HorizontalAlignment.Stretch;
            //item.VerticalAlignment = VerticalAlignment.Top;
            //Tabs.Add(item);
            //Container.ItemsSource = Tabs;
            //SubWindow childWindow = new SubWindow();
            //childWindow.Owner = Application.Current.MainWindow;
            //childWindow.Show();
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Tabs.RemoveAt(actionTabs.SelectedIndex);
        }
    }
}
