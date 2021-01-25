using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public class ConferenceService : IConferenceService
    {
        private readonly IStorageService _storageService;

        public ConferenceService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<Conference> AddConference(Conference conference) => await _storageService.AddConference(conference);
        public async Task<Conference> DeleteConference(Conference conference) => await _storageService.DeleteConference(conference);
        public IQueryable<Conference> GetConferences() => _storageService.GetConferences();
        public async Task<Conference> UpdateConference(Conference conference) => await _storageService.UpdateConference(conference);
    }
}
