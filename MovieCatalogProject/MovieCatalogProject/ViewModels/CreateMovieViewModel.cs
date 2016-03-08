using MovieCatalogProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.ViewModels
{
    public class CreateMovieViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł filmu:")]
        public string Title { get; set; }
        [Display(Name = "Opis:")]
        public string Description { get; set; }
        [Display(Name = "Plakat do filmu")]
        public string Poster { get; set; }
        public string DirectorName { get; set; }
        public List<string> Actors { get; set; }
        public int ProductionYear { get; set; }
        public string Category { get; set; }
        public Cast[] Cast { get; set; }
    }
}