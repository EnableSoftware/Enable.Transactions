using System;
using System.Transactions;
using Xunit;

namespace Enable.Transactions
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Design",
        "CA1034:NestedTypesShouldNotBeVisible",
        Justification = "Nested classes used to group related tests.")]
    public static class TransactionScopeOptionsTests
    {
        public static class DefaultConstructorTests
        {
            [Fact]
            public static void SetsCorrectTransactionScopeOption()
            {
                var sut = new TransactionScopeOptions();

                Assert.Equal(
                    TransactionScopeOption.Required,
                    sut.ScopeOption);
            }

            [Fact]
            public static void SetsCorrectTransactionScopeIsolationLevel()
            {
                var sut = new TransactionScopeOptions();

                Assert.Equal(
                    IsolationLevel.ReadCommitted,
                    sut.IsolationLevel);
            }

            [Fact]
            public static void SetsCorrectTransactionScopeTimeout()
            {
                var sut = new TransactionScopeOptions();

                Assert.Equal(
                    TimeSpan.FromSeconds(60),
                    sut.ScopeTimeout);
            }

            [Fact]
            public static void SetsCorrectTransactionScopeAsyncFlowOption()
            {
                var sut = new TransactionScopeOptions();

                Assert.Equal(
                    TransactionScopeAsyncFlowOption.Enabled,
                    sut.AsyncFlowOption);
            }
        }

        public static class PropertyValidationTests
        {
            [Fact]
            public static void TransactionScopeTimeoutThrowsIfLessThanZero()
            {
                var sut = new TransactionScopeOptions();

                var exception = Record.Exception(() =>
                    sut.ScopeTimeout = TimeSpan.FromMilliseconds(-1));

                Assert.NotNull(exception);
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
