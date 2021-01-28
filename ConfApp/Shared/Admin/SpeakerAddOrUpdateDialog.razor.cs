using ConfApp.Data;
using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Shared.Admin
{
    public partial class SpeakerAddOrUpdateDialog
    {
        [Inject]
        IInstitutionService InstitutionService { get; set; }

        [Inject]
        IFileStorageService FileStorageService { get; set; }

        [Inject]
        IWebHostEnvironment WebHostEnvironment { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Speaker Speaker { get; set; } = new Speaker() { };

        private Institution selectedInstitution { get; set; } = new Institution() { };
        private bool formInvalid = true;
        private EditContext editContext;
        private readonly string imgPath = @"images/speakers";
        private ImmutableArray<Institution> institutions;

        protected override void OnInitialized()
        {
            editContext = new EditContext(Speaker);
            editContext.OnFieldChanged += HandleFieldChanged;
            institutions = InstitutionService.GetInstitutions().ToImmutableArray();
            if (Speaker.Institution is { })
                selectedInstitution = Speaker.Institution;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }

        void AddOrUpdate()
        {
            Speaker.Institution = selectedInstitution;
            MudDialog.Close(DialogResult.Ok(Speaker));
        }
        void Cancel() => MudDialog.Cancel();

        async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            var path = Path.Combine(WebHostEnvironment.WebRootPath, imgPath);
            await FileStorageService.UploadFile(path, e.File);
            Speaker.Photo = e.File.Name;
        }

        Func<Institution, string> institutionConverter = p => p?.Name;
    }
}
