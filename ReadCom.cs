using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReadComPort
{
    internal class ReadCom
    {
        public static string? nameComPort;
        public static bool continueReadData;
        private void ReadDataCom()
        {
            try
            {
                StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
                SerialPort serialPort = new(nameComPort,
                                                          2400,
                                                          Parity.None,
                                                          8,
                                                          StopBits.One);
                serialPort.Handshake = Handshake.None;

                serialPort.Open();

                serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                if (serialPort.IsOpen)
                {
                    string message, dateTime;
                    continueReadData = true;
                    try
                    {
                        var a = serialPort.ReadExisting;
                        // Либо так читаем
                        while (continueReadData)
                        {
                            message = serialPort.ReadLine();
                            dateTime = DateTime.Now.ToString();
                            if (message != null)
                            {
                                Database.ExecuteQuery(string.Format(Query.insertData, dateTime, message));
                                DComPort dComPort = new DComPort(dateTime, message, serialPort.PortName);

                                //DataGridPort.ItemsSource = dComPort;
                                //break;
                            }
                            if (stringComparer.Equals("quit"))
                            {
                                continueReadData = false;
                            }
                            else
                            {
                                serialPort.WriteLine(String.Format("<{0}>: {1}", serialPort.PortName, message));
                            }
                        }
                        //// либо так
                        ////  узнаем сколько байт пришло
                        //int buferSize = serialPort.BytesToRead;
                        //for (int i = 0; i < buferSize; ++i)
                        //{
                        //    //  читаем по одному байту
                        //    byte bt = (byte)serialPort.ReadByte();
                        //    //  если встретили начало кадра (0xFF) - начинаем запись в _bufer
                        //    if (0xFF == bt)
                        //    {
                        //        _stepIndex = 0;
                        //        _startRead = true;
                        //        //  раскоментировать если надо сохранять этот байт
                        //        //_bufer[_stepIndex] = bt;
                        //        //++_stepIndex;
                        //    }
                        //    //  дописываем в буфер все остальное
                        //    if (_startRead)
                        //    {
                        //        _bufer[_stepIndex] = bt;
                        //        ++_stepIndex;
                        //    }
                        //    //  когда буфер наполнлся данными
                        //    if (_stepIndex == DataSize && _startRead)
                        //    {
                        //        //  по идее тут должны быть все ваши данные.

                        //        //  .. что то делаем ...
                        //        //  var item = _bufer[7];

                        //        _startRead = false;
                        //    }
                        //}
                    }
                    catch (TimeoutException) { }
                }

                byte sent = 0x55;
                //Console.WriteLine("sent: {0}", sent);
                serialPort.Write(new byte[1] { sent }, 0, 1);

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

    }
}
