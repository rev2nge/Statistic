using Microsoft.AspNetCore.Mvc;
using Statistic.Application.Interfaces;

namespace Statistic.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories(int? parentId = null) => Ok(await _categoryRepository.GetCategoriesAsync(parentId));

        [HttpGet("GetCategory/{id:int}")]
        public async Task<IActionResult> GetCategory(int id) => Ok(await _categoryRepository.GetEntityById(id));
    }
}