using ExpenseVue.API.Data;
using ExpenseVue.API.Repositories;

namespace ExpenseVue.API.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            return await _expenseRepository.GetExpensesAsync();
        }

        public async Task<Expense> GetExpenseAsync(int id)
        {
            return await _expenseRepository.GetExpenseAsync(id);
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            return await _expenseRepository.AddExpenseAsync(expense);
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            return await _expenseRepository.UpdateExpenseAsync(expense);
        }

        public async Task DeleteExpenseAsync(int id)
        {
            await _expenseRepository.DeleteExpenseAsync(id);
        }
    }
}