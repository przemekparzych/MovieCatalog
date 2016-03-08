using System.Collections.Generic;

namespace MovieCatalogProject.Models
{
    public class CastType
    {
        public int CastTypeId { get; set; }
        public string CastTypeName { get; set; }
        public ICollection<Cast> Casts { get; set; }
    }
}