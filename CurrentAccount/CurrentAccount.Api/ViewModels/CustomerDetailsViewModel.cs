namespace CurrentAccount.Api.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double? Balance { get; set; }
        public IReadOnlyCollection<TransactionViewModel>? Transactions { get; set; }
    }
}
