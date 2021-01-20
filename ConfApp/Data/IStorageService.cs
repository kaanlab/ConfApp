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
        ValueTask<Conference> UpdateConference(Conference conference);
        ValueTask<Conference> DeleteConference(Conference conference);

        // Report
        //ValueTask<IEnumerable<Report>> GetReports();
        //ValueTask<Report> AddReport(Report report);
        //ValueTask<Report> UpdateReport(Report report);
        //ValueTask<Report> DeleteReport(Report report);

        //// Speaker
        //ValueTask<IEnumerable<Speaker>> GetSpeakers();
        //ValueTask<Speaker> AddSpeaker(Speaker speaker);
        //ValueTask<Speaker> UpdateSpeaker(Speaker speaker);
        //ValueTask<Speaker> DeleteSpeaker(Speaker speaker);

        //// Institution
        //ValueTask<IEnumerable<Institution>> GetInstitutions();
        //ValueTask<Institution> AddInstitution(Institution institution);
        //ValueTask<Institution> UpdateInstitution(Institution institution);
        //ValueTask<Institution> DeleteInstitution(Institution institution);


    }
}
