using Framo.Model.Entities;
using Framo.Service.Option;
using Framo.WebUI.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framo.WebUI.Areas.Administrator.Controllers
{
    [AdminLogin]
    public class CommentController : Controller
    {
        CommentService cs = new CommentService();

        public ActionResult Index(Guid filmId)
        {
            List<Comment> cTut = cs.GetActive();
            cTut = cTut.Where(x => x.Movie.ID == filmId).ToList();
            Comment c = cTut.Find(x => x.MovieID == filmId);
            ViewBag.FilmAdi = c.Movie.Name;

            return View(cTut);
        }

        public ActionResult Delete(Guid id, string filmId)
        {
            try
            {
                cs.Remove(id);
                return RedirectToAction("Index", new { filmId });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}