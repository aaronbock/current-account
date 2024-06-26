namespace CurrentAccount.Models
{
    public class Transaction
    {
        public int AccountId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
    }
}