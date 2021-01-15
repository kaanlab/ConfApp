using ConfApp.Data;
using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.FileProviders;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Shared.Admin
{
    public partial class ConferenceNewDialog
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IStorageService StorageService { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        public Conference conference { get; set; } = new Conference();


        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

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
