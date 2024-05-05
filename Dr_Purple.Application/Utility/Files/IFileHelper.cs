using Microsoft.AspNetCore.Http;

namespace Dr_Purple.Application.Utility.Files;
public interface IFileHelper
{
    public string Upload(string UploadPath, IFormFile file);
    public bool Delete(string fileName);
    public bool IsImage(string fileName);
}