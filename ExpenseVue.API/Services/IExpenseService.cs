using ExpenseVue.API.Models;

namespace ExpenseVue.API.Services
{
    public interface IExpenseService
    {
        Task<List<ExpenseModel>> GetExpensesAsync();
        Task<ExpenseModel> GetExpenseAsync(int id);
        Task<ExpenseModel> AddExpenseAsync(ExpenseModel expense);
        Task<ExpenseModel> UpdateExpenseAsync(ExpenseModel expense);
        Task DeleteExpenseAsync(int id);
    }
}