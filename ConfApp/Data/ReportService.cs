using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public class ReportService : IReportService
    {
        private readonly IStorageService _storageService;

        public ReportService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public IQueryable<Report> GetReports() => _storageService.GetReports();

        public async Task<Report> AddReport(Report report) 
        {
            var conference = report.Conference;
            var speakers = report.Speakers;
            var newReport = new Report() { ReportDate = report.ReportDate, Topic = report.Topic, VideoUrl = report.VideoUrl };
            var addedReport = await _storageService.AddReport(newReport);
            addedReport.Conference = conference;
            addedReport.Speakers = speakers;
            return await _storageService.UpdateReport(addedReport);
        }

        public async Task<Report> UpdateReport(Report report)
        {
            //var conference = report.Conference;
            //var speakers = report.Speakers;
            //report.Conference = null;
            //report.Speakers = null;
            //var updatedReport = await _storageService.UpdateReport(report);
            //updatedReport.Conference = conference;
            //updatedReport.Speakers = speakers;
            return await _storageService.UpdateReport(report);
        }
        public async Task<Report> DeleteReport(Report report) => await _storageService.DeleteReport(report);
    }
}
