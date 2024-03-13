using ExpenseVue.API.Data;
using ExpenseVue.API.Models;
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

        public async Task<List<ExpenseModel>> GetExpensesAsync(string userId)
        {
            var expenses = await _expenseRepository.GetExpensesAsync(userId);
            return expenses.Select(e => new ExpenseModel
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Date = e.Date,
                Vendor = e.Vendor,
                CategoryId = e.CategoryId,
                CurrencyId = e.CurrencyId
            }).ToList();
        }

        public async Task<ExpenseModel> GetExpenseAsync(string userId, int id)
        {
            var expense =  await _expenseRepository.GetExpenseAsync(userId, id);

            return new ExpenseModel
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date,
                Vendor = expense.Vendor,
                CategoryId = expense.CategoryId,
                CurrencyId = expense.CurrencyId
            };
        }

        public async Task<ExpenseModel> AddExpenseAsync(string userId, ExpenseModel expense)
        {
            var expenseData = new Expense
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date,
                Vendor = expense.Vendor,
                CategoryId = expense.CategoryId,
                CurrencyId = expense.CurrencyId,
                UserId = userId
            };

            var addedExpense = await _expenseRepository.AddExpenseAsync(userId, expenseData);

            return new ExpenseModel
            {
                Id = addedExpense.Id,
                Description = addedExpense.Description,
                Amount = addedExpense.Amount,
                Date = addedExpense.Date,
                Vendor = addedExpense.Vendor,
                CategoryId = addedExpense.CategoryId,
                CurrencyId = addedExpense.CurrencyId
            };
        }

        public async Task<ExpenseModel> UpdateExpenseAsync(string userId, ExpenseModel expense)
        {
            var expenseData = new Expense
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date,
                Vendor = expense.Vendor,
                CategoryId = expense.CategoryId,
                CurrencyId = expense.CurrencyId,
                UserId = userId
            };

            var updatedExpense = await _expenseRepository.UpdateExpenseAsync(userId, expenseData);

            return new ExpenseModel
            {
                Id = updatedExpense.Id,
                Description = updatedExpense.Description,
                Amount = updatedExpense.Amount,
                Date = updatedExpense.Date,
                Vendor = updatedExpense.Vendor,
                CategoryId = updatedExpense.CategoryId,
                CurrencyId = updatedExpense.CurrencyId
            };
        }

        public async Task DeleteExpenseAsync(string userId, int id)
        {
            await _expenseRepository.DeleteExpenseAsync(userId, id);
        }
    }
}