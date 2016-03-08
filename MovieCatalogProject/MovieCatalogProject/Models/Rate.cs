using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.Models
{
    public class Rate
    {
        public int RateId { get; set; }
        public int Rating { get; set; }
        public int IdentityUserId { get; set; }
    }
}