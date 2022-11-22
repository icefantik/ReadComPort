using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
using ComboBox = System.Windows.Controls.ComboBox;

namespace ReadComPort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.ExecuteQuery(Query.createMainTable);
            GetPorts();
        }
        private void GetPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; ++i)
            {
                BoxComPorts.Items.Add(ports[i]);
            }
        }
        private void StartReadData_Click(object sender, RoutedEventArgs e)
        {
            Thread readDataTread = new (ReadCom.ReadDataCom); // поток для фоновой работы
            readDataTread.Start();
        }

        private void BoxComPorts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ReadCom.nameComPort = (string)comboBox.SelectedItem;
        }

        private void StopReadData_Click(object sender, RoutedEventArgs e)
        {
            ReadCom.continueReadData = false;
        }
    }
}
