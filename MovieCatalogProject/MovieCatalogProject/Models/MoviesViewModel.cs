using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.Models
{
    public class MoviesViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int ProductionYear { get; set; }
        public Category Category { get; set; }
        public string PosterUrl { get; set; }
    }
}