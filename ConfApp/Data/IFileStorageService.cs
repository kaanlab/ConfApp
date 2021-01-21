using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public interface IFileStorageService
    {
        Task UploadFile(string folderPath, IBrowserFile file);
        Task UploadFiles(string folderPath, IReadOnlyList<IBrowserFile> files);

    }
}
