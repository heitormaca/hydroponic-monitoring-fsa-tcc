using System;
using System.Net;
using System.Net.Mail;

namespace Hydroponics.Useful
{
    public class Email
    {
        public bool SendEmail(string email, string titulo, string body)
        {
            try
            {
                MailMessage _mailMessage = new MailMessage();
                _mailMessage.From = new MailAddress("comp.hidroponia@gmail.com");
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = titulo;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = body;
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("comp.hidroponia@gmail.com", "Hidro@2019");
                _smtpClient.EnableSsl = true;
                _smtpClient.Send(_mailMessage);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}