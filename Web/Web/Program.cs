

using System.Data.SqlClient;
using System;

namespace Web
{
    class Program
    {
      

        static void Main(string[] args)
        {
            

            WebScraper meals = new WebScraper();

            //meals.GetMeals();

            DatabaseConnection database = new DatabaseConnection();
            database.databaseConnect();
            
           

            
            //SmsSender sms = new SmsSender();
            //sms.SendSMS(meals.GetMeals());
        }
    }
}