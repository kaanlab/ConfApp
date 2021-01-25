using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Components.Forms;
using ConfApp.Data;

namespace ConfApp.Shared.Admin
{
    public partial class ConferenceDeleteDialog
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IConferenceService ConferenceService { get; set; }

        [CascadingParameter] 
        MudDialogInstance MudDialog { get; set; }

        [Parameter] 
        public Conference Сonference { get; set; } = new Conference();

        private readonly string imgPath = "images";

        void Cancel() => MudDialog.Cancel();

        private async Task Delete()
        {
            var deleteConference = await ConferenceService.DeleteConference(Сonference);
            MudDialog.Close(DialogResult.Ok(deleteConference));
            Snackbar.Add("Конференция удалена!", Severity.Success);
        }
    }
}

