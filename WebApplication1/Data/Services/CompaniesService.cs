using EStore.Data.Base;
using EStore.Data.ViewModels;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Data.Services
{
    public class CompaniesService: EntityBaseRepository<Company>, ICompaniesService
    {
        private readonly AppDbContext _context;

        public CompaniesService(AppDbContext context) : base(context)
        {
        }
        
    }
}
