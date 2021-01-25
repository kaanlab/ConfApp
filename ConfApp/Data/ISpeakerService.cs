using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public interface ISpeakerService
    {
        IQueryable<Speaker> GetSpeakers();
        Task<Speaker> AddSpeaker(Speaker speaker);
        Task<Speaker> UpdateSpeaker(Speaker speaker);
        Task<Speaker> DeleteSpeaker(Speaker speaker);
    }
}
