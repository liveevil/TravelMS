﻿using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelMS
{
    public class TravelDALayer
    {
        public static bool TravelReqDAL(Models.NewTravelRequestModel userData)
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand insertCmmnd = new SqlCommand("INSERT INTO TRAVEL_REQUESTS ([Travel_Request_ID],[Emp_ID],[Trip_Name],[Travel_Type_Purpose],[Travel_Date],[Mode_of_Travel],[Travel_Class],[Source_City],[Destination_City],[Travel_Time_hh],[Travel_Time_mm],[First_Level_Approver],[Agent_ID],[Remarks]) VALUES (@Travel_Request_ID,@Emp_ID,@Trip_Name,@Travel_Type_Purpose,@Travel_Date,@Mode_of_Travel,@Travel_Class,@Source_City,@Destination_City,@Travel_Time_hh,@Travel_Time_mm,@First_Level_Approver,@Agent_ID,@Remarks)");
            insertCmmnd.CommandType = CommandType.Text;

            insertCmmnd.Parameters.AddWithValue("@Travel_Request_ID", userData.Travel_Request_ID);
            insertCmmnd.Parameters.AddWithValue("@Emp_ID", userData.Emp_ID);
            insertCmmnd.Parameters.AddWithValue("@Trip_Name", userData.Trip_Name);
            insertCmmnd.Parameters.AddWithValue("@Travel_Type_Purpose", userData.Travel_Type_Purpose);
            insertCmmnd.Parameters.AddWithValue("@Travel_Date", userData.Travel_Date);
            insertCmmnd.Parameters.AddWithValue("@Mode_of_Travel", userData.Mode_of_Travel);
            insertCmmnd.Parameters.AddWithValue("@Travel_Class", userData.Travel_Class);
            insertCmmnd.Parameters.AddWithValue("@Source_City", userData.Source_City);
            insertCmmnd.Parameters.AddWithValue("@Destination_City", userData.Destination_City);
            insertCmmnd.Parameters.AddWithValue("@Travel_Time_hh", userData.Travel_Time_hh);
            insertCmmnd.Parameters.AddWithValue("@Travel_Time_mm", userData.Travel_Time_mm);
            insertCmmnd.Parameters.AddWithValue("@First_Level_Approver", userData.First_Level_Approver);
            insertCmmnd.Parameters.AddWithValue("@Agent_ID", userData.Agent_ID);
            insertCmmnd.Parameters.AddWithValue("@Remarks", userData.Remarks);      

            int rowsAffected = travelMSysDB.ExecuteNonQuery(insertCmmnd);
            Console.Write("rowsAffected " + rowsAffected);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public static List<Models.NewTravelRequestModel> GetRequestList()
        {
            SqlDatabase travelMSysDB = new SqlDatabase(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelMS_Sep16.mdf;Integrated Security=True");

            SqlCommand reqListCmmnd=new SqlCommand("SELECT * FROM TRAVEL_REQUESTS");

            IDataReader nReader= travelMSysDB.ExecuteReader(reqListCmmnd);

            List<Models.NewTravelRequestModel> rList = new List<Models.NewTravelRequestModel>();
            /*
            Object values[]=new Object[];
            nReader.GetValues(values);

            while (nReader.Read())
            {
                rList.Add(nReader.Get );
            }*/

            return null;
        }
    }
}