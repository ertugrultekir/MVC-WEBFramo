using Framo.Model.Entities;
using Framo.Service.Option;
using Framo.WebUI.Areas.Administrator.Models;
using Framo.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Framo.WebUI.Areas.Administrator.Controllers
{
    [AdminLogin]
    public class MovieController : Controller
    {
        MovieService ms = new MovieService();
        CategoryService cs = new CategoryService();
        UserService us = new UserService();

        public ActionResult Index()
        {
            return View(ms.GetActive());
        }

        public ActionResult Insert()
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Movie item, HttpPostedFileBase fluAfis)
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "CategoryName");
            
            User u = (User)Session["oturum"];
            item.UserID = u.ID;

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (ModelState.IsValid)
                    {
                        bool islemSonucu;
                        string info = FxFunction.ImageUpload(fluAfis, Path.Posters, out islemSonucu);

                        if (islemSonucu)
                        {
                            item.PosterPath = info;
                            bool sonuc =  ms.Add(item);
                            ts.Complete();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Message = $"Resim yükleme işlemi sırasında bir hata oluştu. {info}";
                        }
                        
                    }
                    else
                    {
                        ViewBag.Message = $"Lütfen kayıt işlemi yapmak için tüm alanların uygun şekilde doldurulduğundan emin olun.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"İşlem sırasında bir hata oluştu. Sorunun devam etmesi durumunda lütfen sistem yöneticinize başvurun. {ex.Message} - Hata Tarihi : {DateTime.Now.ToString()}";
            }   

            return View(item);
        }

        public ActionResult Update(Guid id)
        {
            return View(ms.GetByID(id));
        }

        [HttpPost]
        public ActionResult Update(Movie item, HttpPostedFileBase fluAfis)
        {
            User u = (User)Session["oturum"];
            item.UserID = u.ID;

            try
            {
                using(TransactionScope ts = new TransactionScope())
                {
                    if (ModelState.IsValid)
                    {
                        item.Status = Core.Entity.Enum.Status.Updated;
                        if (fluAfis == null)
                        {
                            if (ms.Update(item))
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
                            bool resimSonuc;
                            string yoluTut = FxFunction.ImageUpload(fluAfis, Path.Posters, out resimSonuc);

                            if (resimSonuc)
                            {
                                string tamYol = Request.MapPath("~/Content/" + item.PosterPath);
                                if (System.IO.File.Exists(tamYol))
                                {
                                    System.IO.File.Delete(tamYol);
                                }
                                item.PosterPath = yoluTut;
                                if (ms.Update(item))
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
                                return View();
                            }
                        }
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

        public ActionResult Delete(Guid id)
        {
            ms.Remove(id);
            return RedirectToAction("Index");
        }
    }
}