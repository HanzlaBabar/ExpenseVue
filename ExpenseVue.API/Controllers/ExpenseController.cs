using ExpenseVue.API.Models;
using ExpenseVue.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseVue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenseModel>>> GetExpensesAsync()
        {
            var expenses = await _expenseService.GetExpensesAsync();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpenseAsync(int id)
        {
            var expense = await _expenseService.GetExpenseAsync(id);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> AddExpenseAsync(ExpenseModel expense)
        {
            var addedExpense = await _expenseService.AddExpenseAsync(expense);
            return Ok(addedExpense);
        }

        [HttpPut]
        public async Task<ActionResult<ExpenseModel>> UpdateExpenseAsync(ExpenseModel expense)
        {
            var updatedExpense = await _expenseService.UpdateExpenseAsync(expense);
            return Ok(updatedExpense);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpenseAsync(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return Ok();
        }
    }
}