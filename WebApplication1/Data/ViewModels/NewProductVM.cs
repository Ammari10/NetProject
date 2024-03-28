using EStore.Data.Enums;
using EStore.Models;
using EStore.Data;
using EStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product name is required")]
        public String ProductName { get; set; }

        //public String ProductURL { get; set; }

        [Display(Name = "Product description")]
        public String Description { get; set; }

        [Display(Name = "Product Image URL")]

        public String ImageURL { get; set; }

        public double Price { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ProductCategory Category { get; set; }
    }
}
