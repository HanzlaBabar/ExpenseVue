using ExpenseVue.API.Models;
using ExpenseVue.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseVue.API.Controllers
{
    /// <summary>
    /// Controller for managing categories.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryService">The category service.</param>
        /// <param name="logger">The logger.</param>
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the list of categories.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of categories.</returns>
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetCategoriesAsync()
        {
            try
            {
                _logger.LogInformation("Getting list of categories");
                var categories = await _categoryService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the list of categories");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a category by ID.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the category.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Getting category with ID {id}");
                var category = await _categoryService.GetCategoryAsync(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the category");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The category to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added category.</returns>
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> AddCategoryAsync(CategoryModel category)
        {
            try
            {
                _logger.LogInformation("Adding a new category");
                var newCategory = await _categoryService.AddCategoryAsync(category);
                return CreatedAtAction(nameof(GetCategoryAsync), new { id = newCategory.Id }, newCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the category");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates a category.
        /// </summary>
        /// <param name="category">The category to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated category.</returns>
        [HttpPut]
        public async Task<ActionResult<CategoryModel>> UpdateCategoryAsync(CategoryModel category)
        {
            try
            {
                _logger.LogInformation($"Updating category with ID {category.Id}");
                var updatedCategory = await _categoryService.UpdateCategoryAsync(category);
                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the category");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting category with ID {id}");
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the category");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}