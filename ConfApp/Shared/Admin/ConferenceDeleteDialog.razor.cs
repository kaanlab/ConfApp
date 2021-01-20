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
        IStorageService StorageService { get; set; }

        [CascadingParameter] 
        MudDialogInstance MudDialog { get; set; }

        [Parameter] 
        public Conference conference { get; set; } = new Conference();

        private void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task Update()
        {
            //In a real world scenario this bool would probably be a service to delete the item from api/database
            var updateConference = await StorageService.UpdateConference(conference);
            MudDialog.Close(DialogResult.Ok(updateConference));
            Snackbar.Add("Конференция обновлена!", Severity.Success);

        }

        private async Task Delete()
        {
            var deleteConference = await StorageService.DeleteConference(conference);
            MudDialog.Close(DialogResult.Ok(deleteConference));
            Snackbar.Add("Конференция удалена!", Severity.Success);
        }


        private void UploadFiles(IFileInfo entrie)
        {
            conference.Logo = entrie.Name;
            //TODO upload the files to the server
        }

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            conference.Logo = e.File.Name;
        }
    }
}

