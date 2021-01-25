using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public interface IConferenceService
    {
        IQueryable<Conference> GetConferences();
        Task<Conference> AddConference(Conference conference);
        Task<Conference> UpdateConference(Conference conference);
        Task<Conference> DeleteConference(Conference conference);
    }
}
