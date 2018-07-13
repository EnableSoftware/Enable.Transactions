using System;
using System.Transactions;

namespace Enable.Transactions
{
    public class TransactionScopeFactory : ITransactionScopeFactory
    {
        public ITransactionScope CreateTransactionScope(
            TransactionScopeOptions scopeOptions = null)
        {
            scopeOptions = scopeOptions ?? new TransactionScopeOptions();

            return new MockableTransactionScope(scopeOptions);
        }
    }
}
