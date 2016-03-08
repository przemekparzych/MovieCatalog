using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web.Mvc;

namespace MovieCatalogProject.Models
{

    public class CastViewModel
    {
        public string CastTypeId { get; set; }
        public string CastType { get; set;  }

        public string FirstName { get; set; }

        public string LastName { get; set; }
       
    }
   public class CastsViewModel
    {
        public List<CastViewModel> Casts { get; set; }
        public SelectListItem[] CastTypes { get; set; }
    }
}