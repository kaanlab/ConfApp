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
    public partial class InstitutionSection : ComponentBase
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IDialogService Dialog { get; set; }

        [Inject]
        IInstitutionService InstitutionService { get; set; }

        private string searchString = "";
        private Institution selectedInstitution = null;
        private IList<Institution> institutions = null;
        private HashSet<Institution> selectedItems = new HashSet<Institution>();
        private readonly string imgPath = @"images/institutions";


        protected override void OnInitialized()
        {
            institutions = InstitutionService.GetInstitutions().ToList();
        }

        private bool FilterFunc(Institution element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        private async Task AddInstitution()
        {
            var dialog = Dialog.Show<InstitutionAddOrUpdateDialog>("Новое учебное заведение");
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var addedInstitution = await InstitutionService.AddInstitution(dialog.Result.Result.Data as Institution);
                institutions.Add(addedInstitution);
                Snackbar.Add("Добавлено новое учебное заведение!", Severity.Success);
            }
        }

        private async Task UpdateInstitution(Institution institution)
        {
            var parameters = new DialogParameters { ["institution"] = institution };
            var dialog = Dialog.Show<InstitutionAddOrUpdateDialog>("Редактирование учебного заведения", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var updatedInstitution = await InstitutionService.UpdateInstitution(dialog.Result.Result.Data as Institution);
                var index = institutions.IndexOf(institution);
                institutions.Remove(institution);
                institutions.Insert(index, updatedInstitution);
                Snackbar.Add("Информация об учебном заведении обновлена!", Severity.Success);
            }
        }

        private async Task DeleteInstitution(Institution institution)
        {
            var parameters = new DialogParameters { ["institution"] = institution };
            var dialog = Dialog.Show<InstitutionDeleteDialog>("Удаление учебного заведения", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var deletedInstitution = await InstitutionService.DeleteInstitution(dialog.Result.Result.Data as Institution);
                institutions.Remove(deletedInstitution);
                Snackbar.Add("Учебное заведение удалено!", Severity.Success);
            }
        }
    }
}

