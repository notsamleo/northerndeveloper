using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectRamReo.Models;

namespace ProjectRamReo.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        [HttpGet]
        public ActionResult ContactForm()
        {
            ViewBag.Title = "Contact";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("notsamleo@gmail.com"));
                message.From = new MailAddress("sam.leo@live.co.uk");
                message.Subject = "Northern Dev Query";
                message.Body = string.Format(body, model.Name, model.Email, model.Comments);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "sam.leo@live.co.uk",
                        Password = "ASDF626"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("EmailSent");
                }
            }
            return View(model);
        }

        public ActionResult EmailSent()
        {
            ViewBag.Title = "Email Sent!";
            return View();
        }

    }
}
