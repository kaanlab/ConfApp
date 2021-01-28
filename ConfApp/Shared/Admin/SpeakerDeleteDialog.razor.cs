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
    public partial class SpeakerDeleteDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Speaker Speaker { get; set; } = new Speaker();

        private readonly string imgPath = @"images/speakers";

        void Cancel() => MudDialog.Cancel();
        void Delete() => MudDialog.Close(DialogResult.Ok(Speaker));
    }
}

