using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using mls.ViewModels;
using System.Data.Entity;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace mls.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //if (User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "CustomerOrders");
            //}
            //else if (User.IsInRole("Wastebuilt"))
            //{
            //    return RedirectToAction("WbHome", "CustomerOrders");
            //}
            //else if (User.IsInRole("LogisticsBasic"))
            //{
            //    return RedirectToAction("LogisticsBasic", "CustomerOrders");
            //}
            //else if (User.IsInRole("Nov"))
            //{
            //    return RedirectToAction("NovHome", "CustomerOrders");
            //}
            //else if (User.IsInRole("View"))
            //{
            //    return RedirectToAction("ROIndex", "CustomerOrders");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("stephen.english@unitedhyd.com"));  // replace with valid value 
                message.From = new MailAddress("stephanos.englisch@hotmail.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "stephanos.englisch@hotmail.com",  // replace with valid value
                        Password = "Rea1madrid"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}