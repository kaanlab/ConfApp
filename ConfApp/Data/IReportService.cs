using ConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public interface IReportService
    {
        IQueryable<Report> GetReports();
        Task<Report> AddReport(Report report);
        Task<Report> UpdateReport(Report report);
        Task<Report> DeleteReport(Report report);
    }
}
