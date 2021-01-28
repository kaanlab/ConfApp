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
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Report Report { get; set; } = new Report();

        void Cancel() => MudDialog.Cancel();
        void Delete() => MudDialog.Close(DialogResult.Ok(Report));
    }
}
