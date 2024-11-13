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
    class EmailSending
    {
        string from;
        string to;
        string subject;
        string smtp;
        string username;//cardentials
        string password;//cardenials
        string body;
        public EmailSending(string to, string body)
        {
            this.from = "ijazmahhnoor206@gmail.com";
            this.to = to;
            this.subject = "Helloo Dear Customer";
            this.smtp = "smtp.gmail.com";
            this.username = "ijazmahhnoor206@gmail.com";//cardentials
            this.password = "gbixwcnulbzdwrvd";//cardenials
            this.body = body;
        }
        public string EmailSendingfunc()
        {
            try
            {
                MailMessage mail = new MailMessage(from, to, subject, body);
                SmtpClient client = new SmtpClient(smtp);
                client.Port = 587;
                client.Credentials = new NetworkCredential(username, password);
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
