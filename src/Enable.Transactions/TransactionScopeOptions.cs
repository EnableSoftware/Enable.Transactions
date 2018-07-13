using System;
using System.Transactions;

namespace Enable.Transactions
{
    /// <summary>
    /// Represents the options used for creating a transaction scope.
    /// </summary>
    public class TransactionScopeOptions
    {
        private TimeSpan _scopeTimeout;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TransactionScopeOptions"/> class.
        /// </summary>
        public TransactionScopeOptions()
        {
            ScopeOption = TransactionScopeOption.Required;
            IsolationLevel = IsolationLevel.ReadCommitted;
            ScopeTimeout = TransactionManager.DefaultTimeout;
            AsyncFlowOption = TransactionScopeAsyncFlowOption.Enabled;
        }

        /// <summary>
        /// Gets or sets the transaction requirements of the transaction
        /// associated with the transaction scope.
        /// </summary>
        /// <remarks>
        /// An instance of the <see cref="TransactionScopeOption"/> enumeration
        /// that describes the transaction requirements associated with the
        /// transaction scope.
        /// <remarks>
        public TransactionScopeOption ScopeOption { get; set; }

        /// <summary>
        /// Gets or sets the isolation level of the transaction associated
        /// with the transaction scope.
        /// </summary>
        /// <remarks>
        /// An instance of the <see cref="IsolationLevel"/> enumeration that
        /// describes the isolation level of the transaction associated with
        /// the transaction scope.
        /// <remarks>
        public IsolationLevel IsolationLevel { get; set; }

        /// <summary>
        /// Gets or sets the timeout period for the transaction.
        /// <summary>
        /// <remarks>
        /// The <see cref="TimeSpan"/> after which the transaction scope times
        /// out and aborts the transaction.
        /// <remarks>
        public TimeSpan ScopeTimeout
        {
            get
            {
                return _scopeTimeout;
            }
            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"The specified value '{value}' is invalid. '{nameof(ScopeTimeout)}' must be greater than zero.");
                }

                _scopeTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the thread continuation flow option for the
        /// transaction associated with the transaction scope.
        /// <summary>
        /// <remarks>
        /// An instance of the <see cref="TransactionScopeAsyncFlowOption"/>
        /// enumeration that describes whether the transaction associated with
        /// the transaction scope will flow across thread continuations when
        /// using see cref="System.Threading.Tasks.Task"/> or
        /// <c>async</c>/<c>await</c> .NET async programming patterns.
        /// <remarks>
        public TransactionScopeAsyncFlowOption AsyncFlowOption { get; set; }
    }
}
