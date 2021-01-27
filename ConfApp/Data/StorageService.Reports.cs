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
            this.Reports.Include(o => o.Speakers).Include(o => o.Conference).Include(o => o.Attachments).AsNoTracking();

        public async Task<Report> AddReport(Report report)
        {
            EntityEntry<Report> reportEntityEntry = await this.Reports.AddAsync(report);
            await this.SaveChangesAsync();
            return reportEntityEntry.Entity;
        }

        public async Task<Report> UpdateReport(Report report)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            EntityEntry<Report> reportEntityEntry = this.Reports.Update(report);
            await this.SaveChangesAsync();
            return reportEntityEntry.Entity;
        }

        public async Task<Report> DeleteReport(Report report)
        {
            EntityEntry<Report> reportEntityEntry = this.Reports.Remove(report);
            await this.SaveChangesAsync();
            return reportEntityEntry.Entity;
        }
    }
}
