using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Web
{
    public class WebScraper
    {
        public string GetMeals()
        // Writes webscrapes meals from southern site
        // and organizes them into an array of dictionaries
        // then writes info into dictionary
        // Known bugs: "when dinner is "Taco Bar" the "Bar" will cause the string to end because thats the word im searching for
        {
            Dictionary<string, Dictionary<string, string>> meals = new Dictionary<string, Dictionary<string, string>> ();
            Dictionary<string, string> menu = new Dictionary<string, string>();
            List<string> days = new List<string>();
            List<string> breakfasts = new List<string>() { "Breakfast only in Village Market \n" };
            List<string> lunches = new List<string>() { "Kr's Opens at 4\n" }; 
            List<string> dinners = new List<string>() { "Kr's is Open until 10\n" };

            


           
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.southern.edu/administration/food/index.html");

            
            var titles = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div/a"));

          
            foreach (var title in titles)
            {
                days.Add(title.Text);
                title.Click();
                
            }

      
            var foods = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div"));
            foreach(var food in foods)
            {
                
                breakfasts.Add(GetMeals(food.Text, "10 a.m.", "Fruit Bar") + "Fruit Bar\n");
                lunches.Add(GetMeals(food.Text, "2:30 p.m.", "Salad Bar") + "Salad Bar\n");
                dinners.Add(GetMeals(food.Text, "6:30 p.m.", "Salad Bar") + "Salad Bar\n");
            }
            breakfasts.Add("No Breakfasts on Saturday. Enjoy Starvation!\n");
            dinners.Add("Kr's Opens at 6!\n");


            /*
            foreach(KeyValuePair<string, string> val in menu)
            {
                Console.WriteLine("{0} : {1}", val.Key, val.Value);
                Console.WriteLine();
                Console.WriteLine(); 
            }
            */

            //Console.WriteLine(readText);
            //Thread.Sleep(5000);


            meals.Add("Sunday", null);


            string allmeals = "";
            foreach (var str in breakfasts)
            {
                allmeals += str;
            }
            foreach (var str in lunches)
            {
                allmeals += str;
            }
            foreach (var str in dinners)
            {
                allmeals += str;
            }


            Console.WriteLine(allmeals);
            return allmeals;

        }

        public static string GetMeals(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart))
                strSource = strSource.Substring(strSource.IndexOf(strStart));
            
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        public void writeFile()
        {
            
        }

    }

    
}
