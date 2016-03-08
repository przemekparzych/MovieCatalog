using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.ViewModels
{
    public class PopularMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public float Rating { get; set; }
        public string Poster { get; set; }
    }
}