using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł filmu:")]
        public string Title { get; set; }
        [Display(Name = "Opis:")]
        public string Description { get; set; }
        [Display(Name="Plakat do filmu")]
        public string PosterUrl { get; set; }
        public string DirectorName { get; set; }
        public IEnumerable<MovieCatalogProject.Models.Person> Actors { get; set; }
        public IEnumerable<MovieCatalogProject.Models.Person> Directors { get; set; }
        public IEnumerable<MovieCatalogProject.Models.Person> Writers { get; set; }
        public int ProductionYear { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public string Votes { get; set; }
    }
}