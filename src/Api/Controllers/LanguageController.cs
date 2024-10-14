using DomainService.Services;
using DomainService.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class LanguageController : Controller
    {
        [HttpPost]

        public async Task<ApiResponse> Save(Language language)
        {
            await Task.Delay(500);

            return new ApiResponse();
        }
    }
}
