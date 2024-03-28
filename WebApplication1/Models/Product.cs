using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EStore.Data;
using EStore.Data.Base;
using EStore.Data.Enums;

namespace EStore.Models
{
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public String ProductName { get; set; }

        //public String ProductURL { get; set; }

        public String Description { get; set; }

        public String ImageURL { get; set; }

        public double Price { get; set; }

        public int CompanyId { get; set; }
        
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ProductCategory Category { get; set; }
    }
}
                  