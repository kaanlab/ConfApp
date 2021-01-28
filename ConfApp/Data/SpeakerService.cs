using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IStorageService _storageService;

        public SpeakerService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<Speaker> AddSpeaker(Speaker speaker) 
        {
            var newSpeaker = new Speaker() 
            { 
                FirstName = speaker.FirstName, 
                LastName = speaker.LastName, 
                Photo = speaker.Photo, 
                Position = speaker.Position 
            };
            var addedSpeaker = await _storageService.AddSpeaker(newSpeaker);
            addedSpeaker.Institution = speaker.Institution;
            return await _storageService.UpdateSpeaker(addedSpeaker);
        }
        public async Task<Speaker> DeleteSpeaker(Speaker speaker) => await _storageService.DeleteSpeaker(speaker);
        public IQueryable<Speaker> GetSpeakers() => _storageService.GetSpeakers();
        public IQueryable<Speaker> GetSpeakersIncludeInstitutions() => _storageService.GetSpeakersIncludeInstitutions();
        public async Task<Speaker> UpdateSpeaker(Speaker speaker) => await _storageService.UpdateSpeaker(speaker);
    }
}
