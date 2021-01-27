using ConfApp.Data;
using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Shared.Admin
{
    public partial class SpeakerSection : ComponentBase
    {
        [Inject]
        IDialogService Dialog { get; set; }

        [Inject]
        ISpeakerService SpeakerService { get; set; }

        private string searchString = "";
        private Speaker selectedSpeaker = null;
        private IList<Speaker> speakers = null;
        private HashSet<Speaker> selectedItems = new HashSet<Speaker>();
        private readonly string imgPath = "images/speakers";

        protected override void OnInitialized()
        {
            speakers = SpeakerService.GetSpeakersIncludeInstitutions().ToList();
        }

        private bool FilterFunc(Speaker element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.FirstName} {element.LastName}".Contains(searchString))
                return true;
            return false;
        }

        private async Task UpdateSpeaker(Speaker speaker)
        {
            var parameters = new DialogParameters { ["speaker"] = speaker };
            var dialog = Dialog.Show<SpeakerAddOrUpdateDialog>("Редактирование участника коференции", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var updateSpeaker = dialog.Result.Result.Data as Speaker;
                var index = speakers.IndexOf(speaker);
                speakers.Remove(speaker);
                speakers.Insert(index, updateSpeaker);
            }
        }

        private async Task DeleteSpeaker(Speaker speaker)
        {
            var parameters = new DialogParameters { ["speaker"] = speaker };
            var dialog = Dialog.Show<SpeakerDeleteDialog>("Удаление участника конференции", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var deletedSpeaker = dialog.Result.Result.Data as Speaker;
                speakers.Remove(deletedSpeaker);
            }
        }

        private async Task AddSpeaker()
        {
            var dialog = Dialog.Show<SpeakerAddOrUpdateDialog>("Новая участник коференции");
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var newSpeaker = dialog.Result.Result.Data as Speaker;
                speakers.Add(newSpeaker);
            }
        }
    }
}
