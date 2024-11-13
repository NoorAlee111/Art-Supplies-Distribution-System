using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace ColorFusion
{
    public class EmailSending
    {
        string From;
        string To;
        string Subject;
        string Smtp;
        string Username; //cardentials
        string Password; //cardenials
        string Body;

        public EmailSending(string To, string Body)
        {
            this.From = "ijazmahhnoor206@gmail.com";
            this.To = To;
            this.Subject = "Helloo Dear Customer";
            this.Smtp = "smtp.gmail.com";
            this.Username = "ijazmahhnoor206@gmail.com"; //cardentials
            this.Password = "gbixwcnulbzdwrvd"; //cardenials
            this.Body = Body;
        }

        public string EmailSendingfunc()
        {
            try
            {
                MailMessage mail = new MailMessage(From, To, Subject, Body);
                SmtpClient client = new SmtpClient(Smtp);
                client.Port = 587;
                client.Credentials = new NetworkCredential(Username, Password);
                client.EnableSsl = true;
                client.Send(mail);
                return "Sentt";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
