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
        ISnackbar Snackbar { get; set; }

        [Inject]
        ISpeakerService SpeakerService { get; set; }

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
        private readonly string imgPath = @"images/speakers";
        private ImmutableArray<Institution> institutions;

        [Parameter]
        public Speaker Speaker { get; set; } = new Speaker() { };

        protected override void OnInitialized()
        {
            editContext = new EditContext(Speaker);
            editContext.OnFieldChanged += HandleFieldChanged;
            institutions = InstitutionService.GetInstitutions().ToImmutableArray();
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }

        async Task AddOrUpdate()
        {
            if (Speaker.Id > 0)
            {
                var updateSpeaker = await SpeakerService.UpdateSpeaker(Speaker);
                MudDialog.Close(DialogResult.Ok(updateSpeaker));
                Snackbar.Add("Информация об участнике конференции обновлена!", Severity.Success);
            }
            else
            {
                var institution = new Institution()
                {
                    Id = Speaker.Institution.Id,
                    Name = Speaker.Institution.Name,
                    Logo = Speaker.Institution.Logo
                };
                Speaker.Institution = null;
                await SpeakerService.AddSpeaker(Speaker);

                Speaker.Institution = institution;
                var newSpeaker = await SpeakerService.UpdateSpeaker(Speaker);
                MudDialog.Close(DialogResult.Ok(newSpeaker));
                Snackbar.Add("Участник конференции добавлен!", Severity.Success);
            }
        }
        void Cancel() => MudDialog.Cancel();

        async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            var path = Path.Combine(WebHostEnvironment.WebRootPath, imgPath);
            await FileStorageService.UploadFile(path, e.File);
            Speaker.Photo = e.File.Name;
        }

        Func<Institution, string> converter = p => p?.Name;
    }
}
