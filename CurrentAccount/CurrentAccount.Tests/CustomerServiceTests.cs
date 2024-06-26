using CurrentAccount.Services;
using CurrentAccount.Tests.Fakes;

namespace CurrentAccount.Tests
{
    public class CustomerServiceTests
    {
        private CustomerService _sut { get; set; }

        public CustomerServiceTests()
        {
            var fakeRepository = new FakeCustomerRepository();
            _sut = new CustomerService(fakeRepository);
        }

        [Fact]
        public void CustomerService_Details_WithExistingCustomer_ReturnsCustomer()
        {
            // Arrange

            // Act
            var result = _sut.GetDetails(1);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Value.CustomerId);
        }  
        
        [Fact]
        public void CustomerService_Details_WithInexistingCustomer_ReturnsFailure()
        {
            // Arrange

            // Act
            var result = _sut.GetDetails(10000);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsFailed);
            Assert.Null(result.ValueOrDefault);
        }

    }
}