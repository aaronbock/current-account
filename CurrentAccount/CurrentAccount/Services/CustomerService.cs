using CurrentAccount.Contracts;
using CurrentAccount.Models;
using FluentResults;

namespace CurrentAccount.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Result<Customer> GetDetails(int customerId)
        {
            var customerResult = _customerRepository.Get(customerId);
            return customerResult;
        }

        public Result<Customer> OpenAccount(int customerId, double initialCredit)
        {
            var existingCustomer = _customerRepository.Get(customerId);

            if (existingCustomer.IsFailed)
            {
                return existingCustomer;
            }    

            var customerWithTheAccount = existingCustomer.Value.OpenAccount(initialCredit);
            return customerWithTheAccount;
        }
    }
}
