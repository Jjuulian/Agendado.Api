using AgendadoApi.DTOs;
using AgendadoApi.Models;

namespace AgendadoApi.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<(bool Success, string Message)> CreateCategoryAsync(CategoryDto dto);
        Task<List<CategoryDto>> GetAllCategories();
    }
}
