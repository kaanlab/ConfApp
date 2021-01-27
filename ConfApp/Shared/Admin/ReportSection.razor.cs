using ConfApp.Data;
using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Shared.Admin
{
    public partial class ReportSection : ComponentBase
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IDialogService Dialog { get; set; }

        [Inject]
        IReportService ReportService { get; set; }

        private string searchString = "";
        private Report selectedReport = null;
        private IList<Report> reports = null;
        //private readonly string imgPath = "images";


        protected override void OnInitialized()
        {
            reports = ReportService.GetReports().ToList();
        }

        private bool FilterFunc(Report element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Topic.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.Topic}".Contains(searchString))
                return true;
            return false;
        }

        private async Task AddReport()
        {
            var dialog = Dialog.Show<ReportAddOrUpdateDialog>("Новый доклад");
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var addedReport = await ReportService.AddReport(dialog.Result.Result.Data as Report);
                reports.Add(addedReport);
                Snackbar.Add("Новый доклад успешно добавлен!", Severity.Success);
            }
        }

        private async Task UpdateReport(Report report)
        {
            var parameters = new DialogParameters { ["report"] = report };
            var dialog = Dialog.Show<ReportAddOrUpdateDialog>("Редактирование доклада", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var updatedReport = await ReportService.UpdateReport(dialog.Result.Result.Data as Report);
                var index = reports.IndexOf(report);
                reports.Remove(report);
                reports.Insert(index, updatedReport);
                Snackbar.Add("Информация о докладе успешно обновлена!", Severity.Success);
            }
        }

        private async Task DeleteReport(Report report)
        {
            var parameters = new DialogParameters { ["report"] = report };
            var dialog = Dialog.Show<ReportDeleteDialog>("Удаление доклада", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var deletedReport = await ReportService.DeleteReport(dialog.Result.Result.Data as Report);
                reports.Remove(deletedReport);
                Snackbar.Add("Информация о докладе удалена!", Severity.Success);
            }
        }
    }
}

