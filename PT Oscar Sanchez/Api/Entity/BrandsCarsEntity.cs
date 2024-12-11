using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entity
{
    [Table("BrandsCars")]
    public class BrandsCarsEntity
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date_register { get; set; }
    }
}
