namespace MoneyTracker.Controllers.Resources
{
    public class TransactionInput {
        public string Name { get; set; }
        public int Repeat { get; set; }
        public decimal Amount { get; set; }
    }
}