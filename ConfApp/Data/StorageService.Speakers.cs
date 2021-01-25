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
        public DbSet<Speaker> Speakers { get; set; }

        public IQueryable<Speaker> GetSpeakers() => this.Speakers.Include(o => o.Institution).AsNoTracking();

        public async Task<Speaker> AddSpeaker(Speaker speaker)
        {
            EntityEntry<Speaker> speakerEntityEntry = await this.Speakers.AddAsync(speaker);
            await this.SaveChangesAsync();
            return speakerEntityEntry.Entity;
        }

        public async Task<Speaker> UpdateSpeaker(Speaker speaker)
        {
            EntityEntry<Speaker> speakerEntityEntry = this.Speakers.Update(speaker);
            await this.SaveChangesAsync();
            return speakerEntityEntry.Entity;
        }

        public async Task<Speaker> DeleteSpeaker(Speaker speaker)
        {
            EntityEntry<Speaker> speakerEntityEntry = this.Speakers.Remove(speaker);
            await this.SaveChangesAsync();
            return speakerEntityEntry.Entity;
        }
    }
}
