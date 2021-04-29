using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Web
{
    class DatabaseConnection
    {
        
        public void databaseConnect()
        {
            string connectionString = @"Data Source=DESKTOP-3M3LSKK\SQLEXPRESS;Initial Catalog=saumenudb;Integrated " +
            "Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
        }
        

        

       

    }
}
 