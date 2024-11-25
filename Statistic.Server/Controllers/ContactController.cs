using Microsoft.AspNetCore.Mvc;
using Statistic.Application.Interfaces;

namespace Statistic.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetContact/{id:int}")]
        public async Task<IActionResult> GetContact(int id) => Ok(await _contactRepository.GetContact(id));
    }
}