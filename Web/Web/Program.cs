

namespace Web
{
    class Program
    {
        static void Main(string[] args)
        {
            WebScraper meals = new WebScraper();

            meals.GetMeals();
            //SmsSender sms = new SmsSender();
            //sms.SendSMS(meals.GetMeals());
        }
    }
}