using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string TestName { get; set; } = "测试数据";

        public ObservableCollection<ActionTabItem> Tabs { get; set; } = new ObservableCollection<ActionTabItem>();

        private ActionTabItem _selectActionTabItem;

        /// <summary>
        /// tab选项
        /// </summary>
        public ActionTabItem SelectActionTabItem { 
            get {
                return _selectActionTabItem;
            } set { 
                _selectActionTabItem = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("SelectActionTabItem"));
            } }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            // Bind the xaml TabControl to view model tabs
            //actionTabs.ItemsSource = Tabs;
            // Populate the view model tabs
            //vmd.Populate();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

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
