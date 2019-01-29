using Framo.Model.Entities;
using Framo.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Framo.WebUI.Areas.Administrator.Controllers
{
    public class UserController : Controller
    {
        UserService us = new UserService();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User item)
        {
            try
            {
                using(TransactionScope ts = new TransactionScope())
                {
                    if (ModelState.IsValid)
                    {
                        us.Add(item);
                        ts.Complete();
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string EmailAddress, string Password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (us.Any(x => x.EmailAddress == EmailAddress && x.Password == Password))
                    {
                        User u = us.GetByDefault(x => x.EmailAddress == EmailAddress && x.Password == Password);
                        Session["oturum"] = u;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Exit()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}