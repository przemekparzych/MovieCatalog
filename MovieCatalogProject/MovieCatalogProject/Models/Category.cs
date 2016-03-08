using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}