using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCatalogProject.ViewModels;
using System.Data.Entity;
using MovieCatalogProject.Models;
using System.IO;
using System.Data.Entity.Infrastructure;
using System.Collections.Specialized;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Text;
using MovieCatalogProject.Models.Repository;

namespace MovieCatalogProject.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        List<Cast> casts = new List<Cast>();
        // GET: Movie
        public ActionResult Index(int Id)
        {
            Models.Repository.MovieRepository repo = new Models.Repository.MovieRepository(db);

            return View(repo.GetMovieViewModel(Id));
        }
        [HttpPost]
        public ActionResult Index(MovieViewModel movie)
        {
            Models.Repository.MovieRepository repo = new Models.Repository.MovieRepository(db);
            var user = User.Identity.Name;
            CommentViewModel comment = new CommentViewModel()
            {
                Comment = movie.Comment,
                MovieId = movie.Id,
                UserName = user
            };
            repo.AddComment(comment);
            return View(repo.GetMovieViewModel(movie.Id));
        }
        [HttpPost]
        public ActionResult Search(ViewModels.SearchViewModel search)
        {
            SearchRepository repo = new SearchRepository(db);
            var movies = repo.FindMoviesByTitle(search.Title);
            return View("MoviesList",movies);
        }
        public ActionResult MoviesList()
        {
            Models.Repository.MovieRepository repo = new Models.Repository.MovieRepository(db);
            return View(repo.GetAllMovies());
        }
        
        [ChildActionOnly]
        public ActionResult Comments(MovieViewModel movie)
        {
            Models.Repository.MovieRepository repo = new Models.Repository.MovieRepository(db);
            return View(repo.GetComments(movie.Id));
        }
        public ActionResult Comment()
        {
            return PartialView(new CommentViewModel());
        }
        public ActionResult Create()
        {
            HttpCookie cookie = Request.Cookies["casts"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(cookie);
            }

            ViewBag.Categories = GetCategories();
            ViewBag.CastsTypes = GetCastTypes();
            ViewBag.Casts = casts;
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Title, Description, ProductionYear, Category, Cast")]CreateMovieViewModel movie, HttpPostedFileBase poster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string posterName = "";
                    if (poster != null && poster.ContentLength > 0)
                    {                        
                        var fileName = Path.GetFileName(poster.FileName);
                        posterName = movie.Title.Replace(" ","_") + "." + fileName.Split('.').Last();
                        var path = Path.Combine(Server.MapPath("~/images"),posterName );
                        poster.SaveAs(path);
                        ViewBag.Categories = GetCategories();
                    }
                    Movie movieModel = new Movie()
                    {
                        Title = movie.Title.Trim(),
                        CategoryId = Int32.Parse(movie.Category),
                        Description = movie.Description.Trim(),
                        PosterUrl = posterName,
                        User = User.Identity.Name,
                        ProductionYear = movie.ProductionYear
                    };
                   var movieResult = db.Set<Movie>().Add(movieModel);
                    db.SaveChanges();
                    var casts = movie.Cast;
                    foreach(var item in casts)
                    {
                        item.MovieId = movieResult.Id;
                    }
                    db.Set<Cast>().AddRange(casts);
                    db.SaveChanges();
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.Categories = GetCategories();
            ViewBag.CastsTypes = GetCastTypes();
            return View();
        }
        public ActionResult Edit(int id)
        {
            Models.Repository.MovieRepository repo = new Models.Repository.MovieRepository(db);
            ViewBag.Categories = GetCategories();
            ViewBag.CastsTypes = GetCastTypes();
            return View(repo.GetMovie(id));
        }
        public JsonResult SendCast(CastViewModel cast)
        {        
            cast.CastType = GetCastTypes().Where(p => p.Value == cast.CastTypeId).FirstOrDefault().Text;
            HttpCookie cookie = Request.Cookies["casts"];
            if (cookie == null)
            {
                cookie = new HttpCookie("casts");
                cookie.Expires = DateTime.MaxValue;
                Response.Cookies.Add(cookie);
                cookie["0"] = cast.CastType + " " +cast.CastTypeId + " " + cast.FirstName.Trim() + " " + cast.LastName.Trim();
            }
            else
            {
                var i = (cookie.Values.AllKeys.Count()).ToString();
                cookie[i] = cast.CastType + " " + cast.CastTypeId + " " + cast.FirstName.Trim() + " " + cast.LastName.Trim();
            }
            Response.Cookies.Add(cookie);
            var casts = DeserializeCookie(cookie);
            var casts2 = new CastsViewModel() { Casts = new List<CastViewModel>()};
            casts2.Casts.AddRange(casts);
            casts2.CastTypes = GetCastTypes();
            var jsonObj = JsonConvert.SerializeObject(casts2);
            return Json(jsonObj);
        }
        private SelectListItem[] GetCategories()
        {
            return (from cat in db.Categories
                    select new SelectListItem
                    {
                        Text = cat.CategoryName,
                        Value = cat.CategoryId.ToString()
                    }).ToArray();
        }
        private SelectListItem[] GetCastTypes()
        {
            return (from cat in db.CastTypes
                    select new SelectListItem
                    {
                        Text = cat.CastTypeName,
                        Value = cat.CastTypeId.ToString()
                    }).ToArray();
        }
        List<CastViewModel> DeserializeCookie(HttpCookie cookie)
        {
            List<CastViewModel> casts = new List<CastViewModel>();
            for (int i = 0; i < cookie.Values.AllKeys.Count(); i++)
            {
                var tab = cookie[i.ToString()].Split(' ');
                var cast = new CastViewModel();
                cast.CastType = tab[0];
                cast.CastTypeId = tab[1];
                cast.FirstName = tab[2];
                cast.LastName = tab[3];

                casts.Add(cast);
            }
            return (casts);
        }
        List<Cast> GetCastFromViewModel(List<CastViewModel> castsViewModel, Movie movie)
        {
            List<Cast> casts = new List<Cast>();
            foreach (var item in castsViewModel)
            {
                Cast cast = new Cast();
                cast.CastType = db.CastTypes.Where(p=>p.CastTypeName == item.CastType).FirstOrDefault();
                cast.CastTypeId = cast.CastType.CastTypeId;
                cast.MovieId = movie.Id;
                cast.Movie = movie;
                cast.Person = new Person()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName
                };
                casts.Add(cast);
            }
            return casts;
        }
    }
   
    
}