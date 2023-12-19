namespace ExpenseVue.API.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; } 
        public DateTime Date { get; set; }
        public string? Vendor { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
    }
}