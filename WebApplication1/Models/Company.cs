using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EStore.Data.Base;
using EStore.Data.Enums;

namespace EStore.Models
{
    public class Company:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }

        [Display (Name = "Company Website")]
        public string CompanyURL { get; set; }
        
        [Display(Name = "Company Logo")]
        public string CompanyLogoURL { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }

        //public List<ProductCategory> ProductCategory { get; set; }
    }
}
