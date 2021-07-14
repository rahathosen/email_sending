using EmailClient.Models;
using Microsoft.AspNetCore.Mvc;
using QuickMailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailClient.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(MailMessage mailMessage)
        {
            try
            {
                string msg = "Email Send Faild";
                Email email = new Email();
               bool isSend = email.SendEmail(mailMessage.To, Credential.Email, Credential.Password, mailMessage.Subject, mailMessage.Body);
                
                if(isSend)
                {
                    msg = "Email has been send";
                }
                ViewBag.Msg = msg;
                
                return View();
            }
            catch (Exception)
            {

                throw;
            }  

            

        }
        
    }
}
