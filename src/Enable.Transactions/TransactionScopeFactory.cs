using System;
using System.Transactions;

namespace Enable.Transactions
{
    public class TransactionScopeFactory : ITransactionScopeFactory
    {
        public ITransactionScope CreateTransactionScope(
            TransactionScopeOption scopeOption = TransactionScopeOption.Required,
            TransactionScopeAsyncFlowOption asyncFlowOption = TransactionScopeAsyncFlowOption.Enabled)
        {
            var options = default(TransactionOptions);
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            return new MockableTransactionScope(scopeOption, options, asyncFlowOption);
        }
    }
}
