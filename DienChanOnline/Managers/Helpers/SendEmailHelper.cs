using System.Net.Mail;

namespace DienChanOnline.Managers.Helpers
{
    public interface ISendEmailHelper
    {
        void SendEmail(string msg);
    }

    public class SendEmailHelper: ISendEmailHelper
    {
        public void SendEmail(string msg)
        {
           var message = new MailMessage();

            message.From = new MailAddress("support@dienchanus.com", "DienChanUs");

            message.To.Add(new MailAddress("tunguyen161088@gmail.com"));

            message.To.Add(new MailAddress("academiedienchan@gmail.com"));

            message.Subject = "Thông tin người dùng";

            message.Body = msg;

            var client = new SmtpClient("",1);

            client.Send(message);
        }
    }
}