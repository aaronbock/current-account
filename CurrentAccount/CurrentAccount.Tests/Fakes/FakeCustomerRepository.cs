using CurrentAccount.Contracts;
using CurrentAccount.Models;
using FluentResults;

namespace CurrentAccount.Tests.Fakes
{
    /// <summary>
    /// Fake implementation of customer repository, used in the tests
    /// </summary>
    internal class FakeCustomerRepository : ICustomerRepository
    {
        private readonly IReadOnlyCollection<Customer> _customers;

        public FakeCustomerRepository()
        {
            var customer1 = new Customer { CustomerId = 1, Name = "Aaron", Surname = "Bock" };
            var customer2 = new Customer { CustomerId = 2, Name = "John", Surname = "Doe" };
            var customer3 = new Customer { CustomerId = 3, Name = "Jane", Surname = "Doe" };

            // seed customers list
            _customers = [customer1, customer2, customer3];
        }

        public Result<Customer> Get(int customerId)
        {
            if (customerId < 0 || customerId > 3)
            {
                return Result.Fail("Customer invalid or not found");
            }

            return Result.Ok(_customers.First(x => x.CustomerId == customerId));
        }
    }
}
