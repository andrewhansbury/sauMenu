using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace Web
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.southern.edu/administration/food/index.html");
            driver.FindElement(By.XPath("//*[@id=\"SouthernFramework\"]/div/div/main/div[2]/div/div/div[2 ]/a")).Click();
            Thread.Sleep(5000);
       
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("saumenu@gmail.com", "Andr1234!"),
                EnableSsl = true,
            };

   
            var message = new MailMessage();
            message.From = new MailAddress("saumenu@gmail.com");

            message.To.Add(new MailAddress("9095226733@vtext.com"));
            message.Body = "Sarah Jane is a fat noob ";

           // var client = new SmtpClient();
            smtpClient.Send(message);



            /*
                ATT: Compose a new email and use@txt.att.net. For example, 5551234567@txt.att.net.
                Verizon: Similarly, ##@vtext.com
                Sprint: ##@messaging.sprintpcs.com
                TMobile: ##@tmomail.net
             */


        }
    }
}
