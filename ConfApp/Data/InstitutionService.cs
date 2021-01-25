using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IStorageService _storageService;

        public InstitutionService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<Institution> AddInstitution(Institution institution) => await _storageService.AddInstitution(institution);
        public async Task<Institution> DeleteInstitution(Institution institution) => await _storageService.DeleteInstitution(institution);
        public IQueryable<Institution> GetInstitutions() => _storageService.GetInstitutions();
        public async Task<Institution> UpdateInstitution(Institution institution) => await _storageService.UpdateInstitution(institution);
    }
}
