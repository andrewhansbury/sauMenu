

using System.Data.SqlClient;
using System;

namespace Web
{
    class Program
    {
      

        static void Main(string[] args)
        {
            
            WebScraper meals = new WebScraper();

            //sms.SendSMS(meals.GetMeals());

            //meals.GetMeals();
            DatabaseConnection database = new DatabaseConnection();

            string [,] meal_array = meals.GetMeals();
            database.updateMeals(meal_array);
            database.printMealsTable();



            //SmsSender sms = new SmsSender();
            
        }
    }
}