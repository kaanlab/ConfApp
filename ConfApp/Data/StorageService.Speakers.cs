using ConfApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public partial class StorageService
    {
        public DbSet<Speaker> Speakers { get; set; }

        public IQueryable<Speaker> GetSpeakers() => this.Speakers.AsNoTracking();
        public IQueryable<Speaker> GetSpeakersIncludeInstitutions() =>
            this.Speakers.Include(o => o.Institution)
                         .AsNoTracking()
                         .AsQueryable();

        public async Task<Speaker> AddSpeaker(Speaker speaker)
        {
            var institution = await this.Institutions.FirstOrDefaultAsync(o => o.InstitutionId == speaker.Institution.InstitutionId);
            var newSpeaker = new Speaker()
            {
                FirstName = speaker.FirstName,
                LastName = speaker.LastName,
                Photo = speaker.Photo,
                Position = speaker.Position,
            };
            var addedSpeaker = await this.Speakers.AddAsync(newSpeaker);
            await this.SaveChangesAsync();

            addedSpeaker.Entity.Institution = institution;
            var updatedSpeaker = this.Speakers.Update(addedSpeaker.Entity);
            await this.SaveChangesAsync();

            return updatedSpeaker.Entity;
        }

        public async Task<Speaker> UpdateSpeaker(Speaker speaker)
        {
            var updatedSpeaker = await this.Speakers.FirstOrDefaultAsync(o => o.SpeakerId == speaker.SpeakerId); ;
            var institution = await this.Institutions.FirstOrDefaultAsync(o => o.InstitutionId == speaker.Institution.InstitutionId);
            
            updatedSpeaker.FirstName = speaker.FirstName;
            updatedSpeaker.LastName = speaker.LastName;
            updatedSpeaker.Photo = speaker.Photo;
            updatedSpeaker.Position = speaker.Position;
            updatedSpeaker.Institution = institution;
            var speakerEntity = this.Speakers.Update(updatedSpeaker);
            await this.SaveChangesAsync();

            return speakerEntity.Entity;
        }

        public async Task<Speaker> DeleteSpeaker(Speaker speaker)
        {
            var deletedSpeaker = await this.Speakers.FirstOrDefaultAsync(o => o.SpeakerId == speaker.SpeakerId);
            var speakerEntry = this.Speakers.Remove(deletedSpeaker);
            await this.SaveChangesAsync();

            return speakerEntry.Entity;
        }
    }
}
