using Framo.Core.Entity.Enum;
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
    public class SliderController : Controller
    {
        SliderService ss = new SliderService();

        public ActionResult Index()
        {
            return View(ss.GetActive());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(HttpPostedFileBase ImagePath, Slider item)
        {
            User u = (User)Session["oturum"];
            item.UserID = u.ID;
            try
            {
                using(TransactionScope ts = new TransactionScope())
                {
                    if (ModelState.IsValid)
                    {
                        bool sonuc;
                        string yoluTut = FxFunction.ImageUpload(ImagePath, Path.Sliders, out sonuc);

                        if (sonuc)
                        {
                            item.ImagePath = yoluTut;
                            if (ss.Add(item))
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
                            ViewBag.Message = $"Resim yükleme işlemi sırasında bir hata oluştu. {yoluTut}";
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
            return View();
        }

        public ActionResult Update(Guid id)
        {
            Slider s = ss.GetByID(id);
            
            return View(ss.GetByID(id));
        }

        [HttpPost]
        public ActionResult Update(HttpPostedFileBase PosterPath, Slider item)
        {
            User u = (User)Session["oturum"];
            item.UserID = u.ID;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (ModelState.IsValid)
                    {
                        item.Status = Status.Updated;
                        if (PosterPath == null)
                        {
                            if (ss.Update(item))
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
                            bool sonuc;
                            string yoluTut = FxFunction.ImageUpload(PosterPath, Path.Sliders, out sonuc);

                            if (sonuc)
                            {
                                string tamYol = Request.MapPath("~/Content/"+item.ImagePath);
                                if (System.IO.File.Exists(tamYol))
                                {
                                    System.IO.File.Delete(tamYol);
                                }
                                item.ImagePath = yoluTut;
                                if (ss.Update(item))
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
                                ViewBag.Message = $"Resim yükleme işlemi sırasında bir hata oluştu. {yoluTut}";
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                ss.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}