using MovieCatalogProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.Models.Repository
{
    public class SearchRepository:Repository<Movie>
    {
        public SearchRepository(ApplicationDbContext context): base(context)
        {

        }
        public IEnumerable<MovieViewModel> FindMoviesByTitle(string title)
        {
            IEnumerable<Movie> movies = new List<Movie>();
            movies = from m in _context.Movies
                     where m.Title.StartsWith(title)
                     select m;
            IList<MovieViewModel> moviesViewModel = new List<MovieViewModel>();
            foreach(var item in movies)
                moviesViewModel.Add(item.ToMovieViewModel());
            return moviesViewModel;
        }
    }
}