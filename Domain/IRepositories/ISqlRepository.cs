using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ISqlRepository
    {
        Task<List<UnifiedDataModel>> GetAllAsync();
        Task<PersonDetail> GetByIdAsync(int id);
    }
}
