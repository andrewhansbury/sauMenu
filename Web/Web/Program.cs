

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


            //meals.GetMeals();
            //atabaseConnection database = new DatabaseConnection();

            string[,] meal_array = meals.GetMeals();

            string text = "";

            for (int i = 0; i<7; i++)
            {
                for (int j=0; i<3; i++)
                {
                    text += meal_array[i, j];

                }
            }

            sms.SendSMS("Friday Lunch : \n" + meal_array[5,1]);

            //database.updateMeals(meal_array);
            //database.printMealsTable();



            

        }
    }
}