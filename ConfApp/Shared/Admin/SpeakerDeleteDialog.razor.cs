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
    public partial class SpeakerDeleteDialog
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        ISpeakerService SpeakerService { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Speaker Speaker { get; set; } = new Speaker();

        private readonly string imgPath = @"images/speakers";

        void Cancel() => MudDialog.Cancel();

        private async Task Delete()
        {
            var deleteSpeaker = await SpeakerService.DeleteSpeaker(Speaker);
            MudDialog.Close(DialogResult.Ok(deleteSpeaker));
            Snackbar.Add("Участник конференции удален!", Severity.Success);
        }
    }
}

