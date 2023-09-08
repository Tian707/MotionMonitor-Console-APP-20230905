using H1_0905_MotionDetector.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace H1_0905_MotionDetector.BLL
{
    
    
    /// <summary>
    /// creates an instance of RecordDataAccess
    /// then create a method 
    /// DALObject.DALMethod, returns an array of records objects
    /// this happens in the DAL, 
    /// this time without a BLL,
    /// the list will be used directly by GUI to present data on webpage
    /// </summary>
    
    public class RecordManager
    {
        private static string connectionString = ConfigurationManager.AppSettings["MyConn"];

        /// <summary>
        /// Use the result from ExtractData(string data)
        /// Populate database
        /// </summary>
        /// <param name="distanceInCM"></param>
        /// <param name="lightCount"></param>
        public void InsertData(float distanceInCM, int lightCount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // use store procedures
                    using (SqlCommand cmd = new SqlCommand("dbo.InsertIntoDistances", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters for DistanceInCM and LightCount
                        cmd.Parameters.AddWithValue("@DistanceInCM", distanceInCM);
                        cmd.Parameters.AddWithValue("@LightCount", lightCount);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error inserting data into the database: " + ex.Message);
            }
        }

        /// <summary>
        /// Get string data from Arduino in ArManager
        /// extract the float and int for INSERT into database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (float, int) ExtractData(string data)
        {
            float distanceInCM = 0.0f;
            int lightCount = 0;
            if (data.Contains(","))
            {
                string[] dataParts = data.Split(',');
                if (dataParts.Length == 2)
                {
                    if (float.TryParse(dataParts[0], out distanceInCM) && int.TryParse(dataParts[1], out lightCount))
                    {
                        return (distanceInCM, lightCount);
                    }
                }
            }
            return (0, 0);
        }

        /// <summary>
        /// This method was created to get data from DAL then send to GUI
        /// so DAL is not directly sending data to GUI
        /// </summary>
        /// <returns></returns>
        public Record[] ReturnRecordsFromDAL()
        {
            RecordDataAccess recordDataAccess = new RecordDataAccess();
            return recordDataAccess.GetAllRecords();
        }


    }
}
