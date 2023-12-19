using ExpenseVue.API.Data;

namespace ExpenseVue.API.Services
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetExpensesAsync();
        Task<Expense> GetExpenseAsync(int id);
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id);
    }
}