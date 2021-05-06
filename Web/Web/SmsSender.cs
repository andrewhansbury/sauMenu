using System.Threading;
using System.Net.Mail;
using System.Net;
using System;
using System.Collections.Generic;

namespace Web
{
    public class SmsSender
    {

      
        public void SendSMS(string text, string number)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("saumenu@gmail.com", "Andr1234!"),
                EnableSsl = true,
            };


            var message = new MailMessage();
            message.From = new MailAddress("saumenu@gmail.com");

            // 5012532257
            //message.To.Add(new MailAddress("6178949230@vtext.com"));
            message.To.Add(new MailAddress(number+ "@vtext.com"));
            message.Body = text;
            smtpClient.Send(message);
            Console.WriteLine("Text Sent!");

            /*
                ATT: Compose a new email and use@txt.att.net. For example, 5551234567@txt.att.net.
                Verizon: Similarly, ##@vtext.com
                Sprint: ##@messaging.sprintpcs.com
                TMobile: ##@tmomail.net
            */
            
        }



    }

   


    public class TaskScheduler
    {
        private static TaskScheduler _instance;
        private List<Timer> timers = new List<Timer>();

        private TaskScheduler() { }

        public static TaskScheduler Instance => _instance ?? (_instance = new TaskScheduler());

        public void ScheduleTask(int hour, int min, double intervalInHour, Action task)
        {
            DateTime now = DateTime.Now;
            DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);
            if (now > firstRun)
            {
                firstRun = firstRun.AddDays(1);
            }

            TimeSpan timeToGo = firstRun - now;
            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }

            var timer = new Timer(x =>
            {
                task.Invoke();
            }, null, timeToGo, TimeSpan.FromHours(intervalInHour));

            timers.Add(timer);
        }
    }


}