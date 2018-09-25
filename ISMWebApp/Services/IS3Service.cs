using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ISMWebApp.Services
{
    public interface IS3Service
    {
        Task<string> UploadAsync(IFormFile file);
    }
}