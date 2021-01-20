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
        IDialogService Dialog { get; set; }

        [Inject]
        IStorageService StorageService { get; set; }

        private string searchString = "";
        private Conference selectedCoference = null;
        private IList<Conference> Conferences = null;
        private HashSet<Conference> selectedItems = new HashSet<Conference>();

        protected override void OnInitialized()
        {
            Conferences = StorageService.GetConferences().ToList();
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

        private async Task EditConference(Conference conference)
        {
            var parameters = new DialogParameters { ["conference"] = conference };
            var dialog = Dialog.Show<ConferenceEditDialog>("Редактирование конференции", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                //var id = dialog.Result.Id;
            }
        }

        private async Task NewConference()
        {
            var dialog = Dialog.Show<ConferenceNewDialog>("Новая коференция");
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var newConfirence = dialog.Result.Result.Data as Conference;
                Conferences.Add(newConfirence);
            }
        }
    }
}
