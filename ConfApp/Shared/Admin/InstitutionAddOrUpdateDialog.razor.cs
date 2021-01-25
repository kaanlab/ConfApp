using ConfApp.Data;
using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Shared.Admin
{
    public partial class InstitutionAddOrUpdateDialog
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IInstitutionService InstitutionService { get; set; }

        [Inject]
        IFileStorageService FileStorageService { get; set; }

        [Inject]
        IWebHostEnvironment WebHostEnvironment { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private bool formInvalid = true;
        private EditContext editContext;
        private readonly string imgPath = @"images/institutions";

        [Parameter]
        public Institution Institution { get; set; } = new Institution();

        protected override void OnInitialized()
        {
            editContext = new EditContext(Institution);
            editContext.OnFieldChanged += HandleFieldChanged;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }

        async Task AddOrUpdate()
        {
            if (Institution.Id > 0)
            {
                var updateInstitution = await InstitutionService.UpdateInstitution(Institution);
                MudDialog.Close(DialogResult.Ok(updateInstitution));
                Snackbar.Add("Учебное заведение обновлено!", Severity.Success);
            }
            else
            {
                var newInstitution = await InstitutionService.AddInstitution(Institution);
                MudDialog.Close(DialogResult.Ok(newInstitution));
                Snackbar.Add("Учебное заведение добавлено!", Severity.Success);
            }
        }
        void Cancel() => MudDialog.Cancel();

        async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            var path = Path.Combine(WebHostEnvironment.WebRootPath, imgPath);
            await FileStorageService.UploadFile(path, e.File);
            Institution.Logo = e.File.Name;
        }
    }    
}

