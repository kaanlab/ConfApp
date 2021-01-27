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

        public async Task<Speaker> AddSpeaker(Speaker speaker) => await _storageService.AddSpeaker(speaker);
        public async Task<Speaker> DeleteSpeaker(Speaker speaker) => await _storageService.DeleteSpeaker(speaker);
        public IQueryable<Speaker> GetSpeakers() => _storageService.GetSpeakers();
        public IQueryable<Speaker> GetSpeakersIncludeInstitutions() => _storageService.GetSpeakersIncludeInstitutions();
        public async Task<Speaker> UpdateSpeaker(Speaker speaker) => await _storageService.UpdateSpeaker(speaker);
    }
}
