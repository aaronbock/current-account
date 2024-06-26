using CurrentAccount.Api.ViewModels;
using CurrentAccount.Models;

namespace CurrentAccount.Api.Mappings
{
    public static class CustomerMapping
    {
        public static CustomerDetailsViewModel MapFromCustomer(Customer customer)
        {
            return new CustomerDetailsViewModel 
            { 
                Balance = customer.LinkedAccount?.Balance, 
                CustomerId = customer.CustomerId, 
                Name = customer.Name, 
                Surname = customer.Surname,
                Transactions = customer
                    .LinkedAccount?
                    .Transactions
                    .Select(x => 
                        new TransactionViewModel
                        {
                            Timestamp = x.Timestamp,
                            Value = x.Value
                        }
                    ).ToList()
            };
        }
    }
}
