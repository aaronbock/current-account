using CurrentAccount.Models;
using FluentResults;

namespace CurrentAccount.Contracts
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get the details of an existing customer
        /// </summary>
        /// <param name="customerId">The customerId we want to search by</param>
        /// <returns>The details of the customer</returns>
        Result<Customer> GetDetails(int customerId);
        /// <summary>
        /// Opens an account to an existing customer
        /// </summary>
        /// <param name="customerId">The id of the customer we want to open the account</param>
        /// <param name="initialCredit">The initial deposit the customer will make in the bank</param>
        /// <returns>The existing customer, with a new linked account</returns>
        Result<Customer> OpenAccount(int customerId, double initialCredit);
    }
}