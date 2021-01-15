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
    public partial class ConferenceEditDialog
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

        private void DeleteServer()
        {
            //In a real world scenario this bool would probably be a service to delete the item from api/database
            bool serverDeleted = true;
            if (serverDeleted)
            {
                Snackbar.Add("Server Deleted", Severity.Success);
                MudDialog.Close(DialogResult.Ok(conference.Id));
            }
            else
            {
                Snackbar.Add("Could not delete server!", Severity.Error);
                MudDialog.Cancel();
            }
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

