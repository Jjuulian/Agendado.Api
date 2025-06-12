using AgendadoApi.Data;
using AgendadoApi.DTOs;
using AgendadoApi.Models;
using AgendadoApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendadoApi.Services.Implementations
{
    public class CategoryService : ICategoriesService
    {
        private readonly AgendaDbContext _context;

        public CategoryService(AgendaDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> CreateCategoryAsync(CategoryDto dto)
        {
            var newCategory = new Category
            {
                CategoryName = dto.CategoryName
            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return (true, "Categoría registrada correctamente.");
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName
                })
                .ToListAsync();
        }
    }
}
