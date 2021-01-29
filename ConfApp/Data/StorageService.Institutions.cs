using ConfApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public partial class StorageService
    {
        public DbSet<Institution> Institutions { get; set; }

        public IQueryable<Institution> GetInstitutions() => this.Institutions.AsNoTracking().AsQueryable();

        public async Task<Institution> AddInstitution(Institution institution)
        {
            EntityEntry<Institution> institutinonEntityEntry = await this.Institutions.AddAsync(institution);
            await this.SaveChangesAsync();
            return institutinonEntityEntry.Entity;
        }

        public async Task<Institution> UpdateInstitution(Institution institution)
        {
            EntityEntry<Institution> institutinonEntityEntry = this.Institutions.Update(institution);
            await this.SaveChangesAsync();
            return institutinonEntityEntry.Entity;
        }

        public async Task<Institution> DeleteInstitution(Institution institution)
        {
            EntityEntry<Institution> institutinonEntityEntry = this.Institutions.Remove(institution);
            await this.SaveChangesAsync();
            return institutinonEntityEntry.Entity;
        }
    }
}
