using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CandleShop.Models;
using System.Net.Mail;

namespace CandleShop.Controllers
{
    public class MailController : ApiController
    {
        // GET: api/Mail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        public string Post(gmail mail)
        {
            MailMessage mm = new MailMessage(mail.From, mail.To);
            mm.Subject = mail.Subject;
            mm.Body = mail.Body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("candleshooplviv@gmail.com", "CandleShoopLviv838");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            return "Mail send successfully!";
        }

    }
}
