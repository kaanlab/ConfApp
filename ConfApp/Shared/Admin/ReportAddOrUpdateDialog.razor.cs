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
    public partial class ReportAddOrUpdateDialog 
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        ISpeakerService SpeakerService { get; set; }

        [Inject]
        IReportService ReportService { get; set; }

        [Inject]
        IConferenceService ConferenceService { get; set; }

        [Inject]
        IFileStorageService FileStorageService { get; set; }

        [Inject]
        IWebHostEnvironment WebHostEnvironment { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private bool formInvalid = true;
        private EditContext editContext;
        private readonly string imgPath = @"images/speakers";
        private ImmutableArray<Speaker> speakers;
        private ImmutableArray<Conference> conferences;
        private Speaker value { get; set; } = new Speaker() { };
        private HashSet<Speaker> selectedSpeakers { get; set; } = new HashSet<Speaker>() { };
        private Conference selectedConference { get; set; } = new Conference() { };


        [Parameter]
        public Report Report { get; set; } = new Report() { };

        protected override void OnInitialized()
        {
            editContext = new EditContext(Report);
            editContext.OnFieldChanged += HandleFieldChanged;
            speakers = SpeakerService.GetSpeakers().ToImmutableArray();
            conferences = ConferenceService.GetConferences().ToImmutableArray();
            if (Report.Speakers is { })
                selectedSpeakers = Report.Speakers.ToHashSet();
            if (Report.Conference is { })
                selectedConference = Report.Conference;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }

        async Task AddOrUpdate()
        {
            if (Report.Id > 0)
            {
                Report.Speakers = selectedSpeakers;
                Report.Conference = selectedConference;
                var updateReport = await ReportService.UpdateReport(Report);
                MudDialog.Close(DialogResult.Ok(updateReport));
                Snackbar.Add("Информация о докладе обновлена!", Severity.Success);
            }
            else
            {
                await ReportService.AddReport(Report);

                Report.Speakers = selectedSpeakers;
                Report.Conference = selectedConference;

                var newReport = await ReportService.UpdateReport(Report);
                MudDialog.Close(DialogResult.Ok(newReport));
                Snackbar.Add("Доклад добавлен!", Severity.Success);
            }
        }
        void Cancel() => MudDialog.Cancel();

        async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            var path = Path.Combine(WebHostEnvironment.WebRootPath, imgPath);
            await FileStorageService.UploadFile(path, e.File);
            //Speaker.Photo = e.File.Name;
        }

        Func<Conference, string> conferenceConverter = p => p?.MainTopic;
        Func<Speaker, string> speakerConverter = p => p?.LastName;
    }
}

