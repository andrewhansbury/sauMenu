

namespace Web
{
    class Program
    {
        static void Main(string[] args)
        {
            WebScraper meals = new WebScraper();

            SmsSender sms = new SmsSender();
            sms.SendSMS(meals.GetMeals());
        }
    }
}