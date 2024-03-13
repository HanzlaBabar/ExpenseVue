using ExpenseVue.API.Models;

namespace ExpenseVue.API.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetCategoriesAsync();
        Task<CategoryModel> GetCategoryAsync(int id);
        Task<CategoryModel> AddCategoryAsync(CategoryModel category);
        Task<CategoryModel> UpdateCategoryAsync(CategoryModel category);
        Task DeleteCategoryAsync(int id);
    }
}