using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.Shared.Services;

namespace NKKDotNetCore.RestApi.Controllers.AdoDotNetExampleWithService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetServiceController : ControllerBase
    {
        private readonly AdoDotNetService _service = new AdoDotNetService();
    }
}
