using ExpenseVue.API.Models;
using ExpenseVue.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseVue.API.Controllers
{
    /// <summary>
    /// Expense Controller
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly ILogger<ExpenseController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expenseService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public ExpenseController(IExpenseService expenseService, ILogger<ExpenseController> logger, UserManager<IdentityUser> userManager)
        {
            _expenseService = expenseService;
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets a list of expenses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ExpenseModel>>> GetExpensesAsync()
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                _logger.LogInformation($"Getting list of expenses for user {userId}");
                var expenses = await _expenseService.GetExpensesAsync(userId);
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the list of expenses");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets a single expense
        /// </summary>
        /// <param name="id">The ID of the expense to get</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpenseAsync(int id)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                _logger.LogInformation($"Getting expense with ID {id} for user {userId}");
                var expense = await _expenseService.GetExpenseAsync(userId, id);
                return Ok(expense);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting expense with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Adds a new expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> AddExpenseAsync(ExpenseModel expense)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                _logger.LogInformation($"Adding a new expense for user {userId}");
                var addedExpense = await _expenseService.AddExpenseAsync(userId, expense);
                return Ok(addedExpense);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new expense");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Updates an existing expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ExpenseModel>> UpdateExpenseAsync(ExpenseModel expense)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                _logger.LogInformation($"Updating expense with ID {expense.Id} for user {userId}");
                var updatedExpense = await _expenseService.UpdateExpenseAsync(userId, expense);
                return Ok(updatedExpense);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating expense with ID {expense.Id}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes an existing expense
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpenseAsync(int id)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                _logger.LogInformation($"Deleting expense with ID {id} for user {userId}");
                await _expenseService.DeleteExpenseAsync(userId, id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting expense with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}