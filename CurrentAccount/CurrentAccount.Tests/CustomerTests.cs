using CurrentAccount.Tests.Fakes;

namespace CurrentAccount.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_OpenAccount_WithWrongDecimalMoney_ReturnsFailure()
        {
            // Arrange
            var fakeRepository = new FakeCustomerRepository();
            var sut = fakeRepository.Get(1);

            // Act
            var result = sut.Value.OpenAccount(158.41154);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsFailed);
            Assert.Null(result.ValueOrDefault);
        }

        [Fact]
        public void Customer_OpenAccount_WithZeroInitialCredit_DoesNotAddBalanceAndTransaction()
        {
            // Arrange
            var fakeRepository = new FakeCustomerRepository();
            var sut = fakeRepository.Get(1);

            // Act
            var result = sut.Value.OpenAccount(0);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(0, result.Value.LinkedAccount?.Balance);
            Assert.Empty(result.Value.LinkedAccount?.Transactions);
        }

        [Fact]
        public void Customer_OpenAccount_WithInitialCredit_AddsBalanceAndTransaction()
        {
            // Arrange
            var fakeRepository = new FakeCustomerRepository();
            var sut = fakeRepository.Get(1);

            // Act
            var result = sut.Value.OpenAccount(198);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(198, result.Value.LinkedAccount?.Balance);
            Assert.Equal(198, result.Value.LinkedAccount?.Transactions.First().Value);
        }

    }
}