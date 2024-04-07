using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using FoodHub.Models;
using System.Net;
using System.Web.Helpers;
using System.Net.Http;

namespace FoodHub.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult Index() {
            Mail mail = new Mail();
            ViewBag.Picture = "~/Pictures/mail-prep.png";
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(Mail model)
        {
            try
            {
                MailMessage message = new MailMessage();
                
                message.From = new MailAddress(model.From);
                message.To.Add(new MailAddress("biljanadimitrova7@gmail.com"));
                message.Subject = "FoodHub contact";
                message.Body = model.Body;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); 
                client.EnableSsl = true;

                
                client.Timeout = 10000;
                client.Send(message);
                
                return RedirectToAction("Success","Email");
            }
            catch (Exception ex)
            {
                // Log the exception for further analysis
                // This will help you identify the root cause of the timeout
                // For now, you can also display the exception message
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View("ErrorView"); // Create an ErrorView.cshtml with the error message
            }
        }
        public ActionResult Success()
        {
            Mail mail = new Mail();
            ViewBag.Picture = "~/Pictures/mail.png";
            return View("Index",mail);
        }
    }

}