using System;
using System.Transactions;

namespace Enable.Transactions
{
    internal class MockableTransactionScope : ITransactionScope, IDisposable
    {
        private readonly TransactionScope _transactionScope;

        public MockableTransactionScope(
            TransactionScopeOptions scopeOptions)
        {
            if (scopeOptions == null)
            {
                throw new ArgumentNullException(nameof(scopeOptions));
            }

            var options = default(TransactionOptions);
            options.IsolationLevel = scopeOptions.IsolationLevel;
            options.Timeout = scopeOptions.ScopeTimeout;

            _transactionScope = new TransactionScope(
                scopeOptions.ScopeOption,
                options,
                scopeOptions.AsyncFlowOption);
        }

        public void Complete()
        {
            _transactionScope.Complete();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_transactionScope != null)
                {
                    _transactionScope.Dispose();
                }
            }
        }
    }
}
