using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public interface IStorageService
    {
        // Conference
        IQueryable<Conference> GetConferences();
        Task<Conference> AddConference(Conference conference);
        Task<Conference> UpdateConference(Conference conference);
        Task<Conference> DeleteConference(Conference conference);

        // Report
        //ValueTask<IEnumerable<Report>> GetReports();
        //ValueTask<Report> AddReport(Report report);
        //ValueTask<Report> UpdateReport(Report report);
        //ValueTask<Report> DeleteReport(Report report);

        // Speaker
        IQueryable<Speaker> GetSpeakers();
        Task<Speaker> AddSpeaker(Speaker speaker);
        Task<Speaker> UpdateSpeaker(Speaker speaker);
        Task<Speaker> DeleteSpeaker(Speaker speaker);

        // Institution
        IQueryable<Institution> GetInstitutions();
        Task<Institution> AddInstitution(Institution institution);
        Task<Institution> UpdateInstitution(Institution institution);
        Task<Institution> DeleteInstitution(Institution institution);


    }
}
