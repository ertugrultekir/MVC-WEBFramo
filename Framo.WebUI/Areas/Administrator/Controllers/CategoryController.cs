using Framo.Core.Entity.Enum;
using Framo.Model.Entities;
using Framo.Service.Option;
using Framo.WebUI.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Framo.WebUI.Areas.Administrator.Controllers
{
    [AdminLogin]
    public class CategoryController : Controller
    {
        CategoryService cs = new CategoryService();

        public ActionResult Index()
        {
            try
            {
                return View(cs.GetActive());
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable, "Tanimlanamayan bir hata olustu");
            }
            
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Category item)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (ModelState.IsValid)
                    {
                        if (cs.Add(item))
                        {
                            ts.Complete();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View(item);
                        }
                    }
                    else
                    {
                        return View(item);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult Update(Guid id)
        {
            Category item = cs.GetByID(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(Category item)
        {
            try
            {
                using(TransactionScope ts = new TransactionScope())
                {
                    if (ModelState.IsValid)
                    {
                        item.Status = Status.Updated;
                        cs.Update(item);
                        ts.Complete();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.HataMesaji = $"İşlem sırasında bir hata oluştu {ex.Message}";
                return View(item);
            }
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                cs.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}