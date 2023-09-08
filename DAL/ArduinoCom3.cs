using H1_0905_MotionDetector.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace H1_0905_MotionDetector
//{/// <summary>
/// This class handles raw data from Arduino
/// 1. Get connection to the Serial Port
/// 2. Receive data from SerialPort
/// 3. Save data into database
/// 4. Close connection
/// </summary>
//    public class ArduinoCom3
//    {
        
//        private SerialPort serialPort;
//        public string Data { get; private set; }

//        /// <summary>
//        /// Open connection with serial port
//        /// </summary>
//        public void ConnectSerialPort()
//        {
//            // Initialize and open the serial port
//            serialPort = new SerialPort("COM3", 9600);

//            /* serialPort is an instance of the SerialPort class, 
//             * responsible for handling communication with the serial port connected to Arduino.
//             *  DataReceived event of the SerialPort class allows defining a method 
//             *  that will be called whenever data is received from the serial port. 
//             *  here: capture and process data from the Arduino as it arrives.
//             * 
//             * ? new SerialDataReceivedEventHandler(SerialPortDataReceived) is creating a new instance 
//             * of the SerialDataReceivedEventHandler delegate, which is required for event handling. 
//             * It specifies that the method SerialPortDataReceived should be called whenever data is received.
//             */
//            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
//            // Extract data
//            //(float distanceInCM, int lightCount) = ExtractData(Data);

//            // Insert data into database
//            //InsertSerialPortDataIntoDatabase(distanceInCM, lightCount);

//            serialPort.Open();

//            Console.WriteLine("Listening on " + serialPort.PortName);
//            //serialPort.Close();
//        }



//        /// <summary>
//        /// Colse connection
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
//        {
//            /*
//             * 
//             * 
//             */
//            SerialPort sp = (SerialPort)sender;
//            Data = sp.ReadLine();



//            Console.WriteLine("Received: " + Data);
//             /* Seperate cw to GUI, because cw only exists in console app
//             * So use Debug.WriteLine() instead for better decoupling in the future
//             */
//            Debug.WriteLine(Data);

//            /*   // Gemme data i en tekstfil
//            *    using (StreamWriter sw = new StreamWriter("output.html", true))
//            *    {
//            *      sw.WriteLine(data);
//            *    }
//            */

//        }


        

//        /// <summary>
//        /// Extract data (DistanceInCM and LightCount) from the received data
//        /// 
//        /// 
//        /// </summary>
//        /// <param name="data"></param>
//        /// <returns></returns>
        

//    }
//}
