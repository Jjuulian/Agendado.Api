using AgendadoApi.DTOs;
using AgendadoApi.Models;
using AgendadoApi.Services.Implementations;
using AgendadoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendadoApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            var created = await _categoriesService.CreateCategoryAsync(dto);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoriesService.GetAllCategories();
            return Ok(categories);
        }
    }
}
