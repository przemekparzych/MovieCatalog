using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalogProject.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int MovieId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
    }
    public class CommentsViewModel
    {
        public List<CommentViewModel> Comments { get; set; }
    }
}