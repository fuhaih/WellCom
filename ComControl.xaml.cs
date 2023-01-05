using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
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
    /// ComControl.xaml 的交互逻辑
    /// </summary>
    public partial class ComControl : UserControl , INotifyPropertyChanged, IOpenSourceControl
    {
        /// <summary>
        /// 停止位选项
        /// </summary>
        public ObservableCollection<KeyValuePair<string, StopBits>> StopBitOptions { get; set; } = new ObservableCollection<KeyValuePair<string, StopBits>>();

        /// <summary>
        /// 校验位选项
        /// </summary>
        public ObservableCollection<KeyValuePair<string, Parity>> ParityOptions { get; set; } = new ObservableCollection<KeyValuePair<string, Parity>>();

        /// <summary>
        /// 数据位选项
        /// </summary>
        public ObservableCollection<KeyValuePair<string, int>> DataBitsOptions { get; set; } = new ObservableCollection<KeyValuePair<string, int>>();

        /// <summary>
        /// 波特率选项
        /// </summary>
        public ObservableCollection<KeyValuePair<int, int>> BaudRateOptions { get; set; } = new ObservableCollection<KeyValuePair<int, int>>();

        /// <summary>
        /// 串口号选项
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> PortNameOptions { get; set; } = new ObservableCollection<KeyValuePair<string, string>>();

        public SerialPort SerialPortInstance = new SerialPort();

        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits { get; set; } = StopBits.One;

        /// <summary>
        /// 校验位
        /// </summary>
        public Parity Parity { get; set; } = Parity.None;

        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits { get; set; } = 8;

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; } = 9600;

        private string _portName;

        /// <summary>
        /// 串口号
        /// </summary>
        public string PortName {
            get { return _portName; }
            set {
                _portName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortName"));
            }
        }

        private bool _isOpen = false;

        public bool IsOpen { 
            get
            {
                return _isOpen;
            }
            set {
                _isOpen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsOpen"));
            }
        }

        public ComControl()
        {
            InitializeComponent();
            Init_Data();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// 初始化数据/下拉选项
        /// </summary>
        private void Init_Data()
        {
            //停止位选项
            StopBitOptions.Add(new KeyValuePair<string, StopBits>("1", StopBits.One));
            StopBitOptions.Add(new KeyValuePair<string, StopBits>("1.5", StopBits.OnePointFive));
            StopBitOptions.Add(new KeyValuePair<string, StopBits>("2", StopBits.Two));

            //校验位选项
            ParityOptions.Add(new KeyValuePair<string, Parity>("None", Parity.None));
            ParityOptions.Add(new KeyValuePair<string, Parity>("Odd", Parity.Odd));
            ParityOptions.Add(new KeyValuePair<string, Parity>("Even", Parity.Even));
            ParityOptions.Add(new KeyValuePair<string, Parity>("Mark", Parity.Mark));
            ParityOptions.Add(new KeyValuePair<string, Parity>("Space", Parity.Space));

            //数据位选项
            DataBitsOptions.Add(new KeyValuePair<string, int>("5", 5));
            DataBitsOptions.Add(new KeyValuePair<string, int>("6", 6));
            DataBitsOptions.Add(new KeyValuePair<string, int>("7", 7));
            DataBitsOptions.Add(new KeyValuePair<string, int>("8", 8));

            //波特率
            BaudRateOptions.Add(new KeyValuePair<int, int>(110, 110));
            BaudRateOptions.Add(new KeyValuePair<int, int>(300, 300));
            BaudRateOptions.Add(new KeyValuePair<int, int>(600, 600));
            BaudRateOptions.Add(new KeyValuePair<int, int>(1200, 1200));
            BaudRateOptions.Add(new KeyValuePair<int, int>(2400, 2400));
            BaudRateOptions.Add(new KeyValuePair<int, int>(4800, 4800));
            BaudRateOptions.Add(new KeyValuePair<int, int>(9600, 9600));
            BaudRateOptions.Add(new KeyValuePair<int, int>(14400, 14400));
            BaudRateOptions.Add(new KeyValuePair<int, int>(19200, 19200));
            BaudRateOptions.Add(new KeyValuePair<int, int>(38400, 38400));
            BaudRateOptions.Add(new KeyValuePair<int, int>(56000, 56000));
            BaudRateOptions.Add(new KeyValuePair<int, int>(57600, 57600));
            BaudRateOptions.Add(new KeyValuePair<int, int>(115200, 115200));
            BaudRateOptions.Add(new KeyValuePair<int, int>(128000, 128000));
            BaudRateOptions.Add(new KeyValuePair<int, int>(256000, 256000));

            string[] sPorts = SerialPort.GetPortNames().OrderBy(m => m).ToArray();
            foreach (var portName in sPorts)
            {
                PortNameOptions.Add(new KeyValuePair<string, string>(portName, portName));
                PortName = portName;
            }
        }
    }
}
