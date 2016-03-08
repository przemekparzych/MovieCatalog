namespace MovieCatalogProject.Models
{
    public class Cast
    { 
        public int CastId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Person Person { get; set; }
        public int CastTypeId { get; set; }
        public CastType CastType { get; set; }
    }
}