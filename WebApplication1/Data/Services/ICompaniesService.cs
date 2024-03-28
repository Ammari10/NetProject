using EStore.Data.Base;
using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Data.Services
{
    public interface ICompaniesService : IEntityBaseRepository<Company>
    {
    }
}
