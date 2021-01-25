using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public interface IInstitutionService
    {
        IQueryable<Institution> GetInstitutions();
        Task<Institution> AddInstitution(Institution institution);
        Task<Institution> UpdateInstitution(Institution institution);
        Task<Institution> DeleteInstitution(Institution institution);
    }
}
