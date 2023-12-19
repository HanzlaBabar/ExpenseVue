using Microsoft.EntityFrameworkCore;

namespace ExpenseVue.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public ApplicationDbContext(DbContextOptions<DbContext> options) : base(options) { }
    }
}