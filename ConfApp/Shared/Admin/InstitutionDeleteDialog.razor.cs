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
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Institution Institution { get; set; } = new Institution();

        private readonly string imgPath = @"images/institutions";

        void Cancel() => MudDialog.Cancel();
        void Delete() => MudDialog.Close(DialogResult.Ok(Institution));
    }
}
