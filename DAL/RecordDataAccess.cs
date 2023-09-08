using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using H1_0905_MotionDetector.BLL;

namespace H1_0905_MotionDetector.DAL
{
    public class RecordDataAccess
    {
        string connectionString = ConfigurationManager.AppSettings["MyConn"];
        public Record[] GetAllRecords()
        {
            string selectAllRecords = "SELECT * FROM Distances";

            List<Record> records = new List<Record>();

            // Connect- database and save each record into list records
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(selectAllRecords, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Record record = new Record
                                {
                                    ID = int.Parse(reader["ID"].ToString()),
                                    DistanceInCM = float.Parse(reader["DistanceInCM"].ToString()),
                                    LightCount = int.Parse(reader["LightCount"].ToString()),
                                    ReceivingTime = reader["ReceivingTime"].ToString()
                                };

                                records.Add(record);
                            }
                        }
                    }
                }
                return records.ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error inserting data into the database: " + ex.Message);
                return null;
            }
        }
    }
}

