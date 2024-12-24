using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Kalash
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private string ConStr;
        private SqlDataAdapter sda;

        public Functions()
        {
            
            ConStr = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Kalash.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr); // Instantiate the SqlConnection
            Cmd = new SqlCommand();
            Cmd.Connection = Con; // Now Con is not null
        }

        public int setData(string Query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }
       
    }
}
