using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Net.Mail;

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
            //*[@id="accordion-d12e112"]

            var message = new MailMessage();
            message.From = new MailAddress("saumenu@gmail.com");

            message.To.Add(new MailAddress("9095226733@vtext.com"));//See carrier destinations below
                                                                      //message.To.Add(new MailAddress("5551234568@txt.att.net"));

            //message.CC.Add(new MailAddress("carboncopy@foo.bar.com"));
            message.Subject = "Test";
            message.Body = "This is a test";

            var client = new SmtpClient();
            client.Send(message);



            /*
                ATT: Compose a new email and use the recipient's 10-digit wireless phone number, followed by @txt.att.net. For example, 5551234567@txt.att.net.
                Verizon: Similarly, ##@vtext.com
                Sprint: ##@messaging.sprintpcs.com
                TMobile: ##@tmomail.net
             */


        }
    }
}
