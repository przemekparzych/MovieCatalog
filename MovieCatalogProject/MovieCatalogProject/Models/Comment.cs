using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
    }
}