using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace Web
{
    public class WebScraper
    {
        public string GetMeals()
        // Writes webscrapes meals from southern site
        // and organizes them into an array of dictionaries
        // then writes info into dictionary
        {
            Dictionary<string, string> menu = new Dictionary<string, string>();
            List<string> days = new List<string>();

            //StreamWriter writer = new StreamWriter("Meals.txt");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.southern.edu/administration/food/index.html");

            
            var titles = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div/a"));

            Console.WriteLine(titles);
            foreach (var title in titles)
            {
                days.Add(title.Text);
                title.Click();
                //Console.WriteLine(title.Text);
            }

            int i = 0;
            var foods = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div"));
            foreach(var food in foods)
            {
                menu.Add(days[i], food.Text);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            foreach(KeyValuePair<string, string> val in menu)
            {
                Console.WriteLine("{0} : {1}", val.Key, val.Value);
                Console.WriteLine();
                Console.WriteLine();
               
            }

            //string readText = File.ReadAllText("Meals.txt");
            //Console.WriteLine(readText);
            //Thread.Sleep(5000);
            return "balagadoo";

        }

    }

    
}
