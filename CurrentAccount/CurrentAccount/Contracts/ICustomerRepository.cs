using CurrentAccount.Models;
using FluentResults;

namespace CurrentAccount.Contracts
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets an existing customer by it´s customerId
        /// </summary>
        /// <param name="customerId">The customerId we want to search by</param>
        /// <returns>An existing customer or an error if the id is not in the customers list</returns>
        Result<Customer> Get(int customerId);
    }
}
