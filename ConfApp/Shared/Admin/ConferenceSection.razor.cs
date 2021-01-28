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
    public partial class ConferenceSection : ComponentBase
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IDialogService Dialog { get; set; }

        [Inject]
        IConferenceService ConferenceService { get; set; }

        private string searchString = "";
        private Conference selectedCoference = null;
        private IList<Conference> conferences = null;
        private HashSet<Conference> selectedItems = new HashSet<Conference>();
        private readonly string imgPath = "images";


        protected override void OnInitialized()
        {
            conferences = ConferenceService.GetConferences().ToList();
        }

        private bool FilterFunc(Conference element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.MainTopic.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.Name} {element.MainTopic}".Contains(searchString))
                return true;
            return false;
        }

        private async Task AddConference()
        {
            var dialog = Dialog.Show<ConferenceAddOrUpdateDialog>("Новая коференция");
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var addedConfirence = await ConferenceService.AddConference(dialog.Result.Result.Data as Conference);
                conferences.Add(addedConfirence);
                Snackbar.Add("Конференция добавлена!", Severity.Success);
            }
        }

        private async Task UpdateConference(Conference conference)
        {
            var parameters = new DialogParameters { ["conference"] = conference };
            var dialog = Dialog.Show<ConferenceAddOrUpdateDialog>("Редактирование конференции", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var updatedConfirence = await ConferenceService.UpdateConference(dialog.Result.Result.Data as Conference);
                var index = conferences.IndexOf(conference);
                conferences.Remove(conference);
                conferences.Insert(index, updatedConfirence);
                Snackbar.Add("Информация о конференции успешно обновлена!", Severity.Success);
            }
        }

        private async Task DeleteConference(Conference conference)
        {
            var parameters = new DialogParameters { ["conference"] = conference };
            var dialog = Dialog.Show<ConferenceDeleteDialog>("Удаление конференции", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var deletedConfirence = await ConferenceService.DeleteConference(dialog.Result.Result.Data as Conference);
                conferences.Remove(deletedConfirence);
                Snackbar.Add("Конференция удалена!", Severity.Success);
            }
        }
    }
}
