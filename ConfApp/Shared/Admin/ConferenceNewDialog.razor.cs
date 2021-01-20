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

        private bool formInvalid = true;
        private EditContext editContext;
        public Conference conference { get; set; } = new Conference();

        protected override void OnInitialized()
        {
            editContext = new EditContext(conference);
            editContext.OnFieldChanged += HandleFieldChanged;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }

        async Task Save()
        {
            var newConference = await StorageService.AddConference(conference);
            MudDialog.Close(DialogResult.Ok(newConference));
            Snackbar.Add("Конференция добавлена!", Severity.Success);
        }
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

        private async Task OnValidSubmit(EditContext context)
        {
            
            StateHasChanged();
        }
    }
}
