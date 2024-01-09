using ExpenseVue.API.Models;
using ExpenseVue.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpenseVue.API.Controllers
{
    /// <summary>
    /// Expense Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly ILogger<ExpenseController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expenseService"></param>
        /// <param name="logger"></param>
        public ExpenseController(IExpenseService expenseService, ILogger<ExpenseController> logger)
        {
            _expenseService = expenseService;
            _logger = logger;
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
                _logger.LogInformation("Getting list of expenses");
                var expenses = await _expenseService.GetExpensesAsync();
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
                _logger.LogInformation($"Getting expense with ID {id}");
                var expense = await _expenseService.GetExpenseAsync(id);
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
                _logger.LogInformation("Adding a new expense");
                var addedExpense = await _expenseService.AddExpenseAsync(expense);
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
                _logger.LogInformation($"Updating expense with ID {expense.Id}");
                var updatedExpense = await _expenseService.UpdateExpenseAsync(expense);
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
                _logger.LogInformation($"Deleting expense with ID {id}");
                await _expenseService.DeleteExpenseAsync(id);
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