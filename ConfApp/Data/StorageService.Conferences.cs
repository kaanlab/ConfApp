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
        public DbSet<Conference> Conferences { get; set; }

        public IQueryable<Conference> GetConferences() => this.Conferences.AsNoTracking();

        public async Task<Conference> AddConference(Conference conference)
        {
            EntityEntry<Conference> confierenceEntityEntry = await this.Conferences.AddAsync(conference);
            await this.SaveChangesAsync();
            return confierenceEntityEntry.Entity;
        }

        public async ValueTask<Conference> UpdateConference(Conference conference)
        {
            EntityEntry<Conference> confierenceEntityEntry = this.Conferences.Update(conference);
            await this.SaveChangesAsync();
            return confierenceEntityEntry.Entity;
        }

        public async ValueTask<Conference> DeleteConference(Conference conference)
        {
            EntityEntry<Conference> confierenceEntityEntry = this.Conferences.Remove(conference);
            await this.SaveChangesAsync();
            return confierenceEntityEntry.Entity;
        }
    }
}
