using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Samachar.Core.Helper
{
    /// <summary>
    /// Represents a helper for file processing
    /// </summary>
    public interface IFileHelper
    {
        Task<bool> CopyFormFilesAsync(IList<IFormFile> formFiles, string filePath);
        Task<bool> CopyFormFileAsync(IFormFile formFile, string filePath);
    }

    public class FileHelper : IFileHelper
    {
        public FileHelper()
        {
        }

        public async Task<bool> CopyFormFileAsync(IFormFile formFile, string filePath)
        {
            if (formFile.Length > 0)
            {
                string directoryPath = new FileInfo(filePath).Directory.FullName;
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> CopyFormFilesAsync(IList<IFormFile> formFiles, string filePath)
        {
            bool result = true;
            string directoryPath = new FileInfo(filePath).Directory.FullName;
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            foreach (var formFile in formFiles)
            {
                if (!await CopyFormFileAsync(formFile, filePath))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public Task<bool> CopyFormFilesAsync(IFormFileCollection formFiles)
        {
            throw new System.NotImplementedException();
        }
    }
}
