using Microsoft.AspNetCore.Mvc;
using Statistic.Application.Interfaces;

namespace Statistic.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourceController : Controller
    {
        private readonly ISourceRepository _sourceRepository;

        public SourceController(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }

        [HttpGet("GetSource/{id:int}")]
        public async Task<IActionResult> GetSource(int id) => Ok(await _sourceRepository.GetSource(id));
    }
}