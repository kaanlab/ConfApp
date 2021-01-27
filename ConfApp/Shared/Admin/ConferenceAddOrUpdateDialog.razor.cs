using ConfApp.Data;
using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Shared.Admin
{
    public partial class ConferenceAddOrUpdateDialog
    {
        [Inject]
        IFileStorageService FileStorageService { get; set; }

        [Inject]
        IWebHostEnvironment WebHostEnvironment { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Conference Сonference { get; set; } = new Conference();

        private bool formInvalid = true;
        private EditContext editContext;
        private readonly string imgPath = "images";


        protected override void OnInitialized()
        {
            editContext = new EditContext(Сonference);
            editContext.OnFieldChanged += HandleFieldChanged;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }

        void AddOrUpdate() => MudDialog.Close(DialogResult.Ok(Сonference));
        
        void Cancel() => MudDialog.Cancel();

        async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            var path = Path.Combine(WebHostEnvironment.WebRootPath, imgPath);
            await FileStorageService.UploadFile(path, e.File);
            Сonference.Logo = e.File.Name;
        }
    }
}
