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
    public partial class ConferenceSection
    {
        [Inject]
        IDialogService Dialog { get; set; }

        [Inject]
        IStorageService StorageService { get; set; }

        private string searchString = "";
        private Conference selectedCoference = null;
        private IEnumerable<Conference> Conferences = null;
        private HashSet<Conference> selectedItems = new HashSet<Conference>();


        protected override async Task OnInitializedAsync()
        {
            Conferences = StorageService.GetConferences();
                new List<Conference>()
        {
            new Conference{
                Name = "II научный практико-ориентированый семинар",
                Banner = "21 - 22 января 2021 / г.Петрозаводск",
                MainTopic = "Цифровая трансформация образования",
                Topic = "управленческая, технологическая и кадровая готовность довузовских образовательных организаций Министерства обороны Российской Федерации",
                Logo = "images/logo.png"
            }
        };
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

            }
        }

        private void NewConference()
        {
            Dialog.Show<ConferenceNewDialog>("Новая коференция");
        }
    }
}
