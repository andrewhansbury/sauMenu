using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Web
{
    class DatabaseConnection
    {
        
        string connectionString = @"Server=10.14.2.24\SQLEXPRESS;Database=saumenudb;User Id = sa; password=Andr1234;Trusted_Connection=False;MultipleActiveResultSets=true;"
;
        
        

        public void updateMeals(string [,] menu)
        {
            string[] days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();

            
            for (int i =0; i<7; i++)
            {
                command.CommandText = "UPDATE Meals SET Breakfast = @breakfast, Lunch = @lunch, Dinner = @dinner WHERE Day = @day";
                command.Parameters.AddWithValue("@breakfast", menu[i, 0]);
                command.Parameters.AddWithValue("@lunch", menu[i, 1]);
                command.Parameters.AddWithValue("@dinner", menu[i, 2]);
                command.Parameters.AddWithValue("@day", days[i]);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

            }
                

            connection.Close();

        }


        public void clearMeals()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Meals SET Breakfast = NULL, LUNCH = NULL, Dinner=NULL;";
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void printMealsTable()
        {
            DataTable mealsTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Meals";
            SqlCommand command = new SqlCommand(query, connection);
            mealsTable.Load(command.ExecuteReader());
            connection.Close();
            foreach (DataRow dataRow in mealsTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    //Console.WriteLine(item);
                }
            }
        }

        public string getTodayMeals()
        {
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            Console.WriteLine("___________________________");

            string text = "Today's Meals:\n\n";

            DataTable mealsTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Meals WHERE Day = @day;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@day", wk.ToString());
            Console.WriteLine(wk.ToString());

            
            mealsTable.Load(command.ExecuteReader());
            connection.Close();
            
            foreach (DataRow dataRow in mealsTable.Rows)
            {
                Console.WriteLine(dataRow.ItemArray);
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                    text += item;
                    text += "\n";
                }
            }

            Console.WriteLine(text);
            return text;
        }

        public void sendAll(string text)
        {
            SmsSender sms = new SmsSender();

            DataTable mealsTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT DISTINCT number FROM Users ";
            SqlCommand command = new SqlCommand(query, connection);
            
          


            mealsTable.Load(command.ExecuteReader());
            connection.Close();

            foreach (DataRow dataRow in mealsTable.Rows)
            {
                Console.WriteLine(dataRow.ItemArray);
                foreach (var item in dataRow.ItemArray)
                {
                    sms.SendSMS(text,item.ToString());
                }
            }

        }
        
        
    }
}
 