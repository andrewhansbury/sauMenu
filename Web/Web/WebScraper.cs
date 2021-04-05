using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;

namespace Web
{
    public class WebScraper
    {
        public string GetMeals()
        // Writes webscrapes meals from southern site
        // and organizes them into an array of dictionaries
        // then writes info into a text file
        {
            StreamWriter writer = new StreamWriter("Meals.txt");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.southern.edu/administration/food/index.html");

            
            var titles = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div/a"));

            Console.WriteLine(titles);
            foreach (var title in titles)
            {
                title.Click();
                //Console.WriteLine(title.Text);
            }

            var foods = driver.FindElements(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div"));
            foreach(var food in foods)
            {
               
                Console.Write(food.Text);
                writer.WriteLine(food.Text);
                    
                
                    
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string readText = File.ReadAllText("Meals.txt");
            //Console.WriteLine(readText);
            //Thread.Sleep(5000);
            return readText;



            
           
        }

    }

    
}
