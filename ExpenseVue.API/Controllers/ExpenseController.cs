using ExpenseVue.API.Models;
using ExpenseVue.API.Services;
using Microsoft.AspNetCore.Mvc;

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

         /// <summary>
         /// Constructor
         /// </summary>
         /// <param name="expenseService"></param>
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        /// <summary>
        /// Gets a list of expenses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ExpenseModel>>> GetExpensesAsync()
        {
            var expenses = await _expenseService.GetExpensesAsync();
            return Ok(expenses);
        }

        /// <summary>
        /// Gets a single expense
        /// </summary>
        /// <param name="id">The ID of the expense to get</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpenseAsync(int id)
        {
            var expense = await _expenseService.GetExpenseAsync(id);
            return Ok(expense);
        }

        /// <summary>
        /// Adds a new expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> AddExpenseAsync(ExpenseModel expense)
        {
            var addedExpense = await _expenseService.AddExpenseAsync(expense);
            return Ok(addedExpense);
        }

        /// <summary>
        /// Updates an existing expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ExpenseModel>> UpdateExpenseAsync(ExpenseModel expense)
        {
            var updatedExpense = await _expenseService.UpdateExpenseAsync(expense);
            return Ok(updatedExpense);
        }

        /// <summary>
        /// Deletes an existing expense
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpenseAsync(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return Ok();
        }
    }
}