using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.Models
{
    public class VoteModel
    {

        public int Id { get; set; }
       public bool Active
        {
            get; set;
        }
       public int SectionId
        {
            get; set;
        }
      public string UserName
        {
            get; set;
        }
      public int Vote
        {
            get; set;
        }
        public int VoteForId
        {
            get; set;
        }
    }
}