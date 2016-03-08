using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCatalogProject.ViewModels;

namespace MovieCatalogProject.Models.Repository
{
    public class MovieRepository:Repository<Movie>
    {
        public MovieRepository(ApplicationDbContext context):base(context)
        {

        }
        public IEnumerable<MovieViewModel> GetAllMovies()
        {
            var movies = GetAll();
            List<MovieViewModel> moviesViewModel = new List<MovieViewModel>();
            foreach(var item in movies)
            {
                MovieViewModel movie = new MovieViewModel();
                movie.Category = _context.Categories.Find(item.CategoryId).CategoryName;
                movie.Description = item.Description;
                movie.Id = item.Id;
                movie.PosterUrl = item.PosterUrl;
                movie.ProductionYear = item.ProductionYear;
                movie.Title = item.Title;
                movie.Votes = item.Votes;
                moviesViewModel.Add(movie);
            }
            return moviesViewModel;
        }
        public MovieViewModel GetMovieViewModel(int id)
        {
            Movie movie = GetMovie(id);
            MovieViewModel movieViewModel = movie.ToMovieViewModel();
            return movieViewModel;
        }
        public Movie GetMovie(int id)
        {
            Movie movie = Get(id);
            movie.Category = _context.Categories.Find(movie.CategoryId);
            movie.Cast = _context.Casts.Where(p => p.MovieId == id);
            return movie;
        }
        public void AddComment(CommentViewModel commentViewModel)
        {
            Comment comment = new Comment()
            {
                CommentContent = commentViewModel.Comment,
                MovieId = commentViewModel.MovieId,
                UserName = commentViewModel.UserName
            };
            _context.Set<Comment>().Add(comment);
            _context.SaveChanges();
        }
        public CommentsViewModel GetComments(int movieId)
        {
            CommentsViewModel comments = new CommentsViewModel();
            comments.Comments = new List<CommentViewModel>();
            foreach(var item in _context.Comments.Where(p=>p.MovieId==movieId))
            {
                CommentViewModel comment = new CommentViewModel();
                comment.Comment = item.CommentContent;
                comment.MovieId = item.MovieId;
                comment.UserName = item.UserName;
                comments.Comments.Add(comment);
            }
            return comments;
        }
    }
}