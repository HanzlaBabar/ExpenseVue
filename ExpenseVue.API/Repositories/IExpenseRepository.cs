using ExpenseVue.API.Data;

namespace ExpenseVue.API.Repositories
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetExpensesAsync();
        Task<Expense> GetExpenseAsync(int id);
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id);
    }
}
