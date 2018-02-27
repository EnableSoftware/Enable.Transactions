using System;
using System.Transactions;

namespace Enable.Transactions
{
    internal class MockableTransactionScope : ITransactionScope, IDisposable
    {
        private readonly TransactionScope _transactionScope;

        public MockableTransactionScope(
            TransactionScopeOption scopeOption,
            TransactionOptions options,
            TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _transactionScope = new TransactionScope(
                scopeOption,
                options,
                asyncFlowOption);
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
