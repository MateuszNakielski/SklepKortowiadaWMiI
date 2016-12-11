using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SklepKortowiadaWMiI.WebPage
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(bool correct = false)
        {
            return View(correct);
        }



        public RedirectToRouteResult Send(string imie, string temat, string email, string content)
        {
            bool correct = true;
            try
            {
                MailMessage mailMessage = new MailMessage();
                MailAddress fromAddress = new MailAddress(email);
                mailMessage.From = fromAddress;
                mailMessage.To.Add("mt.nakielski@gmail.com");
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = temat;
                var smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("mail", "haslo");
                smtpClient.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
                smtpClient.Send(mailMessage);
                correct = true;
            }
            catch (Exception ex)
            {
                correct = false;
                Response.Write("Could not send the e-mail - error: " + ex.Message);
                
            }
            return RedirectToAction("Index", "Contact", new { correct });
        }
    }
}