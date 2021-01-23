using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CandleShop.Models;
using System.Net.Mail;
using System.IO;
using System.Web;

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
            mm.IsBodyHtml = true;
            mm.Body = PopulateBody("marian", "123456");

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

        private string PopulateBody(string user_name, string order_id)
        {;
            string body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/MailTemplates/NewOrder.html"));
            
            body = body.Replace("{user_name}", user_name);
            body = body.Replace("{order_id}", order_id);

            return body;
        }

    }
}
