using System.Transactions;

namespace Enable.Transactions
{
    public interface ITransactionScopeFactory
    {
        ITransactionScope CreateTransactionScope(
            TransactionScopeOption scopeOption = TransactionScopeOption.Required,
            TransactionScopeAsyncFlowOption asyncFlowOption = TransactionScopeAsyncFlowOption.Enabled);
    }
}
