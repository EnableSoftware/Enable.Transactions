using System.Transactions;

namespace Enable.Transactions
{
    public interface ITransactionScopeFactory
    {
        ITransactionScope CreateTransactionScope(
            TransactionScopeOptions scopeOptions);
    }
}
