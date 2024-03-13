using ExpenseVue.API.Data;
using ExpenseVue.API.Models;
using ExpenseVue.API.Repositories;

namespace ExpenseVue.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return categories.Select(c => new CategoryModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public async Task<CategoryModel> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryModel> AddCategoryAsync(CategoryModel category)
        {
            var newCategory = new Category
            {
                Name = category.Name
            };
            var addedCategory = await _categoryRepository.AddCategoryAsync(newCategory);
            return new CategoryModel
            {
                Id = addedCategory.Id,
                Name = addedCategory.Name
            };
        }

        public async Task<CategoryModel> UpdateCategoryAsync(CategoryModel category)
        {
            var updatedCategory = new Category
            {
                Id = category.Id,
                Name = category.Name
            };
            var categoryToUpdate = await _categoryRepository.UpdateCategoryAsync(updatedCategory);
            return new CategoryModel
            {
                Id = categoryToUpdate.Id,
                Name = categoryToUpdate.Name
            };
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}