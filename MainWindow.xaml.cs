using System;
using System.Collections.Generic;
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
using ComboBox = System.Windows.Controls.ComboBox;

namespace ReadComPort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string? com;
        private static bool continueReadData;
        public MainWindow()
        {
            InitializeComponent();
            Database.ExecuteQuery(Query.createMainTable);
            getPorts();
        }
        private void getPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; ++i)
            {
                BoxComPorts.Items.Add(ports[i]);
            }
        }

        private void StartReadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SerialPort _serialPort = new SerialPort("COM1",
                                          2400,
                                          Parity.None,
                                          8,
                                          StopBits.One);
                _serialPort.Handshake = Handshake.None;

                _serialPort.Open();

                _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                if (_serialPort.IsOpen)
                {
                    continueReadData = true;
                    while (continueReadData)
                    {
                        try
                        {
                            string message = _serialPort.ReadLine();
                            ;
                        }
                        catch (TimeoutException) 
                        {

                        }
                    }
                }


                byte sent = 0x55;
                //Console.WriteLine("sent: {0}", sent);
                _serialPort.Write(new byte[1] { sent }, 0, 1);

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString(), "MyProgram", MessageBoxButton.OK);//(MessageBoxImage)MessageBoxIcon.Information);
            }
        }
        private static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:, {0}", indata);
            Console.ReadLine(); //Pause
        }

        private void BoxComPorts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            com = (string)comboBox.SelectedItem;
        }

        private void StopReadData_Click(object sender, RoutedEventArgs e)
        {
            continueReadData = false;
        }
    }
}
