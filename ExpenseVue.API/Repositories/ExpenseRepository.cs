using ExpenseVue.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseVue.API.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Expense>> GetExpensesAsync(string userId)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task<Expense> GetExpenseAsync(string userId, int id)
        {
            var expense = await _context.Expenses
                .Where(e => e.UserId == userId && e.Id == id)
                .FirstOrDefaultAsync();

            if (expense == null)
            {
                throw new Exception("Expense not found.");
            }

            return expense;
        }

        public async Task<Expense> AddExpenseAsync(string userId, Expense expense)
        {
            expense.UserId = userId;
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateExpenseAsync(string userId, Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task DeleteExpenseAsync(string userId, int id)
        {
            var expense = await _context.Expenses
                .Where(e => e.UserId == userId && e.Id == id)
                .FirstOrDefaultAsync();

            if (expense == null)
            {
                throw new Exception("Expense not found.");
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }
}