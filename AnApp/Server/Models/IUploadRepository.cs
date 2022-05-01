namespace AnApp.Server.Models
{
    public class IUploadRepository
    {

        PagedResult<Upload> GetUploads(string? name, int page);
        Task<Upload?> GetUpload(int Id);
        Task<Upload> AddUpload(Upload upload);
        Task<Upload?> UpdateUpload(Upload upload);
        Task<Upload?> DeleteUpload(int id);
    }
}
