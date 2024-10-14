using DomainService.Services;
using DomainService.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class KeyController : Controller
    {
        [HttpPost]
        public async Task<ApiResponse> Save(Key key)
        {
            return new ApiResponse();
        }
    }
}
