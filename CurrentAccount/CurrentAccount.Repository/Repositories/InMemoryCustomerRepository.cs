using CurrentAccount.Contracts;
using CurrentAccount.Models;
using FluentResults;

namespace CurrentAccount.Infrastructure.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private static List<Customer> _customers = new();

        public InMemoryCustomerRepository()
        {
            Initialize();
        }

        public Result<Customer> Get(int customerId)
        {
            if (!_customers.Any(x => x.CustomerId == customerId))
            {
                return Result.Fail($"Customer not found: {customerId}");
            }

            var customer = _customers.First(x => x.CustomerId == customerId);

            return Result.Ok(customer);
        }

        private static void Initialize()
        {
            var customer1 = new Customer { CustomerId = 1, Name = "Aaron", Surname = "Bock" };
            var customer2 = new Customer { CustomerId = 2, Name = "John", Surname = "Doe" };
            var customer3 = new Customer { CustomerId = 3, Name = "Jane", Surname = "Doe" };

            // seed customers list
            _customers = [customer1, customer2, customer3];
        }
    }
}
