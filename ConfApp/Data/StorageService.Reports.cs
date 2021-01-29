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
        public DbSet<Report> Reports { get; set; }

        public IQueryable<Report> GetReports() =>
            this.Reports.Include(o => o.Speakers)
                        .Include(o => o.Conference)
                        .AsNoTracking()
                        .AsQueryable();

        public async Task<Report> AddReport(Report report)
        {
            var conference = await this.Conferences.FirstOrDefaultAsync(o => o.ConferenceId == report.Conference.ConferenceId);
            var speakers = await this.Speakers
                .Where(o => report.Speakers.Select(o => o.SpeakerId).Contains(o.SpeakerId))
                .ToListAsync();

            var newReport = new Report()
            {
                Topic = report.Topic,
                VideoUrl = report.VideoUrl
            };
            var addedReport = await this.Reports.AddAsync(newReport);
            await this.SaveChangesAsync();

            addedReport.Entity.Conference = conference;
            addedReport.Entity.Speakers = speakers;
            var reportEntry = this.Reports.Update(addedReport.Entity);
            await this.SaveChangesAsync();

            return reportEntry.Entity;
        }

        public async Task<Report> UpdateReport(Report report)
        {
            var conference = await this.Conferences.FirstOrDefaultAsync(o => o.ConferenceId == report.Conference.ConferenceId);
            var speakers = await this.Speakers.Where(o => o.Report.ReportId == report.ReportId).ToListAsync();
            var updatedReport = await this.Reports.FirstOrDefaultAsync(o => o.ReportId == report.ReportId);

            updatedReport.Topic = report.Topic;
            updatedReport.VideoUrl = report.VideoUrl;
            updatedReport.Conference = conference;
            updatedReport.Speakers = speakers;
            var reportEntry = this.Reports.Update(updatedReport);
            await this.SaveChangesAsync();

            return reportEntry.Entity;
        }

        public async Task<Report> DeleteReport(Report report)
        {
            var deletedReport = await this.Reports.FirstOrDefaultAsync(o => o.ReportId == report.ReportId);
            var reportEntry = this.Reports.Remove(report);
            await this.SaveChangesAsync();

            return reportEntry.Entity;
        }
    }
}
