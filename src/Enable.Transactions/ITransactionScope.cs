using System;

namespace Enable.Transactions
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }
}
