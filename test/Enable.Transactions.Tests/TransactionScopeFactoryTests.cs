using Xunit;

namespace Enable.Transactions
{
    public class TransactionScopeFactoryTests
    {
        [Fact]
        public void CanCreateTransactionScope()
        {
            var sut = new TransactionScopeFactory();

            var transaction = sut.CreateTransactionScope();

            Assert.NotNull(transaction);
        }

        [Fact]
        public void CanCompleteTransactionScope()
        {
            var sut = new TransactionScopeFactory();

            using (var transaction = sut.CreateTransactionScope())
            {
                transaction.Complete();
            }
        }
    }
}
