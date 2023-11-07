namespace ePreschool.Web.Services.FileManager
{
    public interface IFileManager
    {
        Task<string> UploadFile(IFormFile file);
        Task<string> UploadThumbnailPhoto(IFormFile file);
    }
}
