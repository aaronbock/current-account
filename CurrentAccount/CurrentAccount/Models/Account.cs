namespace CurrentAccount.Models
{
    public class Account
    {
        public Account()
        {
            Transactions ??= []; 
        }

        public int CustomerId { get; set; }

        public double Balance { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }

        public void AddTransaction(double initialCredit, DateTime dateTime)
        {
            Transactions.Add(
                new Transaction 
                { 
                    Timestamp = dateTime, 
                    Value = initialCredit 
                });
        }
    }
}