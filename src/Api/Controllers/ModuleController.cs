using DomainService.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Api.Controllers
{
    public class ModuleController : Controller
    {
        [HttpPost]

        public async Task<ApiResponse> Save(Module module)
        {
            return new ApiResponse();
        }
    }
}
