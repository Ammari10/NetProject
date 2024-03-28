using EStore.Data.Enums;
using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Companies = new List<Company>();
            //Categories = new List<ProductCategory>();
           
        }

        public List<Company> Companies { get; set; }
        //public List<ProductCategory> Categories { get; set; }
       
    }
}
