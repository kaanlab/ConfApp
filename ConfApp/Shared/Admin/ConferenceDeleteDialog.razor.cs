using ConfApp.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Components.Forms;
using ConfApp.Data;

namespace ConfApp.Shared.Admin
{
    public partial class ConferenceDeleteDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Conference Сonference { get; set; } = new Conference();

        private readonly string imgPath = "images";

        void Cancel() => MudDialog.Cancel();

        void Delete() => MudDialog.Close(DialogResult.Ok(Сonference));
    }
}

