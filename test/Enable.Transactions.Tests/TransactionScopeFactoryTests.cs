using Xunit;

namespace Enable.Transactions
{
    public static class TransactionScopeFactoryTests
    {
        [Fact]
        public static void CanCreateTransactionScope()
        {
            var sut = new TransactionScopeFactory();

            var transaction = sut.CreateTransactionScope();

            Assert.NotNull(transaction);
        }

        [Fact]
        public static void CanCompleteTransactionScope()
        {
            var sut = new TransactionScopeFactory();

            using (var transaction = sut.CreateTransactionScope())
            {
                transaction.Complete();
            }
        }

        [Fact]
        public static void CanSpecifyTransactionScopeOptions()
        {
            var sut = new TransactionScopeFactory();

            var options = new TransactionScopeOptions();

            using (var transaction = sut.CreateTransactionScope(options))
            {
                transaction.Complete();
            }
        }
    }
}
