using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_0905_MotionDetector.BLL
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public class ArManager
    {
        public void SetUpAr()
        {
            SerialPort serialPort = new SerialPort("COM3", 9600);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);

            serialPort.Open();
            Console.WriteLine("Listening on " + serialPort.PortName);
            Console.ReadKey();
            serialPort.Close();
        }
        /// <summary>
        /// incoming data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine();
            Console.WriteLine("Received: " + data);

            RecordManager recordManager = new RecordManager();
            (float distanceInCM, int lightCount)= recordManager.ExtractData(data);

            recordManager.InsertData(distanceInCM, lightCount);
        }
    }
}
