using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using MovieCatalogProject.ViewModels;

namespace MovieCatalogProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Cast> Cast { get; set; }
        public int ProductionYear { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public string User { get; set; }
        public string PosterUrl { get; set; }
        public string Votes { get; set; }
        public MovieViewModel ToMovieViewModel()
        {
            MovieViewModel movie = new MovieViewModel();
            if(this.Category!= null)
            movie.Category = this.Category.CategoryName;
            movie.Description = this.Description;
            movie.Id = this.Id;
            movie.PosterUrl = this.PosterUrl;
            movie.ProductionYear = this.ProductionYear;
            movie.Title = this.Title;
            if (this.Votes != null)
                movie.Votes = this.Votes;
            else
                movie.Votes = "0,0,0,0,0";
            if (this.Cast != null)
            {
                if (this.Cast.Where(p => p.CastId == 2)!=null)
                {
                    List<Person> actors = new List<Person>();
                    foreach (var item in this.Cast.Where(p => p.CastTypeId == 2))
                    {
                        actors.Add(item.Person);
                    }
                    movie.Actors = actors;
                }
                if (this.Cast.Where(p => p.CastId == 2) != null)
                {
                    List<Person> directors = new List<Person>();
                    foreach (var item in this.Cast.Where(p => p.CastTypeId == 1))
                    {
                        directors.Add(item.Person);
                    }
                    movie.Directors = directors;
                }
                if (this.Cast.Where(p => p.CastId == 2) != null)
                {
                    List<Person> writers = new List<Person>();
                    foreach (var item in this.Cast.Where(p => p.CastTypeId == 3))
                    {
                        writers.Add(item.Person);
                    }
                    movie.Writers = writers;
                }

            }
            return movie;
        }
    }
}