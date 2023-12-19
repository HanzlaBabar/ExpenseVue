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

        public async Task<List<ExpenseModel>> GetExpensesAsync()
        {
            var expenses = await _expenseRepository.GetExpensesAsync();
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

        public async Task<ExpenseModel> GetExpenseAsync(int id)
        {
            var expense =  await _expenseRepository.GetExpenseAsync(id);

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

        public async Task<ExpenseModel> AddExpenseAsync(ExpenseModel expense)
        {
            var expenseData = new Expense
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date,
                Vendor = expense.Vendor,
                CategoryId = expense.CategoryId,
                CurrencyId = expense.CurrencyId
            };

            var addedExpense = await _expenseRepository.AddExpenseAsync(expenseData);

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

        public async Task<ExpenseModel> UpdateExpenseAsync(ExpenseModel expense)
        {
            var expenseData = new Expense
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date,
                Vendor = expense.Vendor,
                CategoryId = expense.CategoryId,
                CurrencyId = expense.CurrencyId
            };

            var updatedExpense = await _expenseRepository.UpdateExpenseAsync(expenseData);

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

        public async Task DeleteExpenseAsync(int id)
        {
            await _expenseRepository.DeleteExpenseAsync(id);
        }
    }
}