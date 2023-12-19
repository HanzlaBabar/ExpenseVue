namespace ExpenseVue.API.Data
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; } 
        public DateTime Date { get; set; }
        public string? Vendor { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Foreign key for Category
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; } // Foreign key for Currency
    }
}