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
        public async Task<Report> AddReport(Report report) => await _storageService.AddReport(report);
        public async Task<Report> UpdateReport(Report report) => await _storageService.UpdateReport(report);
        public async Task<Report> DeleteReport(Report report) => await _storageService.DeleteReport(report);
    }
}
