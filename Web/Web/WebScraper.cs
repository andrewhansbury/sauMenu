using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

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
            string[,] menu = new string[7, 3];
            List<string> days = new List<string>();
        
            string [] breakfasts = new string[7];
            string [] lunches = new string [7]; 
            string[] dinners = new string[7];
            breakfasts[0] = "Breakfast only in Village Market \n";
            lunches[0] = "Kr's Opens at 4\n";
            dinners[0] = ("Kr's is Open until 10\n");
            

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.southern.edu/administration/food/index.html");
       
            var titles = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div/a"));
          
            foreach (var title in titles)
            {
                days.Add(title.Text);
                title.Click();
            }

            var foods = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div"));
            for (int i =1; i<foods.Count(); i++)
            {     
                breakfasts[i] = (GetMeals(foods[i].Text, "10 a.m.", "Fruit Bar") + "Fruit Bar\n");
                lunches[i] = (GetMeals(foods[i].Text, "2:30 p.m.", "Salad Bar") + "Salad Bar\n");
                dinners[i] = (GetMeals(foods[i].Text, "6:30 p.m.", "Salad Bar") + "Salad Bar\n");
            }
            breakfasts[6] = ("No Breakfasts on Saturday. Enjoy Starvation!\n");
            dinners[6] = ("Kr's Opens at 6!\n");

            for (int day= 0; day<7; day++)
            {
                menu[day, 0] = breakfasts[day];
                menu[day, 1] = lunches[day];
                menu[day, 2] = dinners[day];
            }

            for (int day=0; day <7; day++)
            {  
                Console.WriteLine(days[day] + " Breakfast : " + menu[day,0]);
                Console.WriteLine(days[day] + " Lunch : " + menu[day, 1]);
                Console.WriteLine(days[day] + " Dinner : " + menu[day, 2]);
            }

            return "";

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
