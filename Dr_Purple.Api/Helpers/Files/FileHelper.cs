using Dr_Purple.Application.Utility.Files;

namespace Dr_Purple.Api.Helpers.Files;
public class FileHelper : IFileHelper
{
    private readonly IWebHostEnvironment _environment;

    public static readonly List<string> ImageExtensions = new()
    {
        ".JPG", ".JPE", ".BMP", ".GIF", ".PNG"
    };

    public FileHelper(IWebHostEnvironment environment)
       => _environment = environment;

    public string Upload(string UploadPath, IFormFile file)
    {
        if (!IsImage(file.FileName))
            return string.Empty;

        string fullPath = Path.Combine(_environment.WebRootPath,
                                      CreateDirectory(UploadPath),
                                      file.FileName);

        using FileStream stream = new(fullPath, FileMode.Create);
        file.CopyTo(stream);

        return fullPath;

    }
    public string CreateDirectory(string UploadPath)
    {
        if (!Directory.Exists(UploadPath))
            Directory.CreateDirectory(UploadPath);

        return UploadPath;
    }
    public bool Delete(string picPath)
    {
        if (!Directory.Exists(picPath))
            return false;

        File.Delete(picPath);
        return true;
    }

    public bool IsImage(string fileName)
        => ImageExtensions.Contains(Path.GetExtension(fileName).ToUpper());
}