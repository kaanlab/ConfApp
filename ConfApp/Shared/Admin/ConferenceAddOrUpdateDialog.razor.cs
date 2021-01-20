﻿using ConfApp.Data;
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
    public partial class ConferenceAddOrUpdateDialog
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IStorageService StorageService { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private bool formInvalid = true;
        private EditContext editContext;

        [Parameter]
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

        async Task AddOrUpdate()
        {
            if (conference.Id > 0)
            {
                var updateConference = await StorageService.UpdateConference(conference);
                MudDialog.Close(DialogResult.Ok(updateConference));
                Snackbar.Add("Конференция обновлена!", Severity.Success);
            }
            else
            {
                var newConference = await StorageService.AddConference(conference);
                MudDialog.Close(DialogResult.Ok(newConference));
                Snackbar.Add("Конференция добавлена!", Severity.Success);
            }
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