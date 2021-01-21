using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public class FileStorageService : IFileStorageService
    {

        public async Task UploadFile(string folderPath, IBrowserFile file)
        {
            using var uploadFile = File.OpenWrite(Path.Combine(folderPath, file.Name));
            using var stream = file.OpenReadStream();
            var buffer = new byte[4 * 1096];
            int bytesRead;
            double totalRead = 0;

            while ((bytesRead = await stream.ReadAsync(buffer)) != 0)
            {
                totalRead += bytesRead;
                await uploadFile.WriteAsync(buffer);
            }
        }

        public async Task UploadFiles(string folderPath, IReadOnlyList<IBrowserFile> files)
        {
            foreach (var file in files)
            {
                await UploadFile(folderPath, file);
            }
        }
    }
}
