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
    public partial class InstitutionDeleteDialog
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IStorageService StorageService { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Institution Institution { get; set; } = new Institution();

        private readonly string imgPath = @"images/institutions";

        void Cancel() => MudDialog.Cancel();

        private async Task Delete()
        {
            var deleteInstitution = await StorageService.DeleteInstitution(Institution);
            MudDialog.Close(DialogResult.Ok(deleteInstitution));
            Snackbar.Add("Учебное заведение удалено!", Severity.Success);
        }
    }
}
