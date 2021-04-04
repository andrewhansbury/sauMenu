using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;



namespace Web
{
    public class WebScraper
    {
        public void GetMeals()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.southern.edu/administration/food/index.html");
            driver.FindElement(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div[2]/a")).Click();
            Thread.Sleep(5000);
           
        }

    }

    
}
