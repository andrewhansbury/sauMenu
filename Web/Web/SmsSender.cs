using System.Threading;
using System.Net.Mail;
using System.Net;

namespace Web
{
    public class SmsSender
    {
        public void SendSMS()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("saumenu@gmail.com", "Andr1234!"),
                EnableSsl = true,
            };


            var message = new MailMessage();
            message.From = new MailAddress("saumenu@gmail.com");

            message.To.Add(new MailAddress("9095226733@vtext.com"));
            message.Body = "I'm Starting to get pretty hungry";
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