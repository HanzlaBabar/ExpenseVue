using ExpenseVue.API.Models;

namespace ExpenseVue.API.Services
{
    public interface IExpenseService
    {
        Task<List<ExpenseModel>> GetExpensesAsync(string userId);
        Task<ExpenseModel> GetExpenseAsync(string userId, int id);
        Task<ExpenseModel> AddExpenseAsync(string userId, ExpenseModel expense);
        Task<ExpenseModel> UpdateExpenseAsync(string userId, ExpenseModel expense);
        Task DeleteExpenseAsync(string userId, int id);
    }
}