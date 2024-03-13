using ExpenseVue.API.Data;

namespace ExpenseVue.API.Repositories
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetExpensesAsync(string userId);
        Task<Expense> GetExpenseAsync(string userId, int id);
        Task<Expense> AddExpenseAsync(string userId, Expense expense);
        Task<Expense> UpdateExpenseAsync(string userId, Expense expense);
        Task DeleteExpenseAsync(string userId, int id);
    }
}
