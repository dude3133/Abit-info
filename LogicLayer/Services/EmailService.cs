using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace LogicLayer.Services
{
    public class EmailService : IIdentityMessageService
    {
        public  Task SendAsync(IdentityMessage message)
        {
            return configSendGridasync(message);
        }

        private async Task configSendGridasync(IdentityMessage message)
        {
            //var smtpClient = new SmtpClient(SMTP_HOST,SMTP_CLIENT_PORT);
            //smtpClient.EnableSsl = true;
            //var credentials =
            //    new NetworkCredential(EMAIL_ADDRESS,EMAIL_PASSWORD);
            //smtpClient.Credentials = credentials;
            //using (var mail = new MailMessage())
            //{
            //    mail.Subject = message.Subject;
            //    mail.Body = message.Body;
            //    mail.IsBodyHtml = true;
            //    mail.From =
            //        new MailAddress(EMAIL_ADDRESS,
            //            EMAIL_MESSAGE_AUTHOR);
            //    mail.To.Add(message.Destination);
            //    await smtpClient.SendMailAsync(mail);
            //}
        }
    }
}
