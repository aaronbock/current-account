using FluentResults;

namespace CurrentAccount.Models
{
    public class Customer
    {
        /// <summary>
        /// Returns the existing customer with a newly created account or an error
        /// </summary>
        /// <param name="initialCredit">The initial amount the customer will deposit in the bank</param>
        /// <returns>A customer with the account linked</returns>
        public Result<Customer> OpenAccount(double initialCredit)
        {
            // initial credit needs to be greater than zero
            if (initialCredit < 0)
            {
                return Result.Fail("Initial credit needs to be greater than zero");
            }

            if (Math.Round(initialCredit, 2) != initialCredit)
            {
                return Result.Fail("Initial credit needs to be a valid monetary amount with maximum 2 decimal places");
            }

            var account = new Account
            {
                CustomerId = CustomerId,
                Balance = initialCredit
            };

            if (initialCredit > 0)
            {
                var timestamp = DateTime.UtcNow;

                account.AddTransaction(initialCredit, timestamp);
            }

            LinkedAccount = account;

            return Result.Ok(this);
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Account? LinkedAccount { get; set; }

    }
}