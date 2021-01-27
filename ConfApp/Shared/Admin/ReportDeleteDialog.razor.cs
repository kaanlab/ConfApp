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
    public partial class ReportDeleteDialog
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IReportService ReportService { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Report Report { get; set; } = new Report();

        private readonly string imgPath = "images";

        void Cancel() => MudDialog.Cancel();

        private async Task Delete()
        {
            var deleteReport= await ReportService.DeleteReport(Report);
            MudDialog.Close(DialogResult.Ok(deleteReport));
            Snackbar.Add("Доклад удален!", Severity.Success);
        }
    }
}
