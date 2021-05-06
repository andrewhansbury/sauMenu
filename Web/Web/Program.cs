

using System.Data.SqlClient;
using System;

namespace Web
{
    class Program
    {


        static void Main(string[] args)
        {

            WebScraper meals = new WebScraper();
            SmsSender sms = new SmsSender();

            DatabaseConnection database = new DatabaseConnection();


            database.updateMeals(meals.GetMeals());
            //database.clearMeals();
            //database.printMealsTable();

            string text = database.getTodayMeals();
            database.sendAll(text);
            
            

        }
            
    }
}