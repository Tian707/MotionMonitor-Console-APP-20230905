using H1_0905_MotionDetector.BLL;
using H1_0905_MotionDetector.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_0905_MotionDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            


            ArManager arManager = new ArManager();
            arManager.SetUpAr();

            //RecordManager recordManagerGetData = new RecordManager();
            //Record[] record = recordManagerGetData.ReturnRecordsFromDAL();
            //foreach (Record rec in record)
            //{
            //    Console.WriteLine($"ID: {rec.ID}, distance: {rec.DistanceInCM}cm, light counts: {rec.LightCount}, receiving time: {rec.ReceivingTime}");
            //}
           

            Console.ReadKey();  
        }
    }
}
