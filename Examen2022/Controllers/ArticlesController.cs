using Examen2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen2022.Controllers
{
    public class ArticlesController : Controller
    {
        public class ArtIndex
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime Date { get; set; }
            public string Category { get; set; }
        }

        private AppDbContext db = new AppDbContext();
        [HttpGet]
        public IActionResult Index()
        {
            var artciles = db.Articles.ToList();

            List<ArtIndex> list = new List<ArtIndex>();
            foreach (var art in artciles)
            {
                ArtIndex ai = new ArtIndex();
                ai.Title = art.Title;
                ai.Content = art.Content;
                ai.Date = art.Date;
                ai.Category = db.Category.Find(art.CategoryId).Title;

                list.Add(ai);
            }

            ViewBag.arts = list;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.cats = db.Category.ToList(); 

            return View();
        }

        [HttpPost]
        public void Add(Article newArt)
        {
            newArt.Date= DateTime.Now;
            var cname = (string)Request.Form["category"];
            newArt.CategoryId = db.Category.Where(x => x.Title == cname).ToList()[0].Id;
            
            db.Add(newArt);
            db.SaveChanges();

            Response.Redirect("/Articles/Show/" + newArt.Id);
        }

        [HttpGet]
        public IActionResult Show(string aid)
        {
            int id;
            if (!int.TryParse(aid, out id))
            {
                id = db.Articles.Where(x => x.Title == aid).ToList()[0].Id;
            }

            ViewBag.art = db.Articles.Find(id);
            ViewBag.cat = db.Category.Find(ViewBag.art.CategoryId);

            return View();
        }

        [HttpGet]
        public IActionResult Edit(string aid)
        {
            int id;
            if(!int.TryParse(aid, out id))
            {
                id = db.Articles.Where(x => x.Title == aid).ToList()[0].Id;
            }

            ViewBag.art = db.Articles.Find(id);
            ViewBag.cat = db.Category.Find(ViewBag.art.CategoryId);
            ViewBag.cats = db.Category.ToList();

            return View();
        }

        [HttpPost]
        public void Edit(Article newArt)
        {
            var cname = (string)Request.Form["category"];
            newArt.CategoryId = db.Category.Where(x => x.Title == cname).ToList()[0].Id;

            Article oldArt = db.Articles.Where(x => x.Title == (string)Request.Form["oldTitle"]).ToList()[0];
            newArt.Id = oldArt.Id;
            newArt.Date = oldArt.Date;

            db.Entry(oldArt).State = EntityState.Detached;

            db.Update(newArt);
            db.SaveChanges();

            Response.Redirect("/Articles/Show/" + newArt.Id);
        }

        [HttpPost]
        public void Delete(string aid)
        {
            int id;
            if (!int.TryParse(aid, out id))
            {
                id = db.Articles.Where(x => x.Title == aid).ToList()[0].Id;
            }

            Article art = db.Articles.Find(id);

            db.Articles.Remove(art);
            db.SaveChanges();

            Response.Redirect("/Articles/Index");
        }
    }
}
