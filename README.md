# Enable.Transactions

[![Build status](https://ci.appveyor.com/api/projects/status/cugq9vtwcfk2jnhj/branch/main?svg=true)](https://ci.appveyor.com/project/EnableSoftware/enable-transactions/branch/main)

Sensible defaults for .NET transactions.

Transactions in .NET provide a lot of awesomeness. However, the default
construction of [`TransactionScope`](https://docs.microsoft.com/dotnet/api/system.transactions.transactionscope)
[is broken](https://blogs.msdn.microsoft.com/dbrowne/2010/06/03/using-new-transactionscope-considered-harmful/).

`Enable.Transactions` provides a wrapper around `TransactionScope` that
ensures that transactions are generated with sensible default options. 
What's really neat, is that by using this library, your use of transactions
[can easily be unit tested](#testing-and-mocking-transactions)!

## Getting started

In order to avoid being bitten by `TransactionScope`'s nasty default settings,
replace any use of `new TransactionScope()` with the following:

```csharp
var factory = new TransactionScopeFactory();

using (var transaction = factory.CreateTransactionScope())
{
    // Do your clever work here.

    transaction.Complete();
}
```

Behind the scenes, this creates a `TransactionScope` with the following properties:

- [`TransactionScopeOption`](https://docs.microsoft.com/dotnet/api/system.transactions.transactionscopeoption) = `TransactionScopeOption.Required`
- [`TransactionOptions.IsolationLevel`](https://docs.microsoft.com/dotnet/api/system.transactions.transactionoptions.isolationlevel) = `IsolationLevel.ReadCommitted`
- [`TransactionOptions.Timeout`](https://docs.microsoft.com/dotnet/api/system.transactions.transactionoptions.timeout) = `TransactionManager.DefaultTimeout`
- [`TransactionScopeAsyncFlowOption`](https://docs.microsoft.com/dotnet/api/system.transactions.transactionscopeasyncflowoption) = `TransactionScopeAsyncFlowOption.Enabled`

## Overriding the default options

If the default options provided by 
`TransactionScopeFactory.CreateTransactionScope()` are not quite what you'd
like, these can be adjusted.

In the following example, we override the default timeout, increasing this to
5 minutes.

```csharp
var factory = new TransactionScopeFactory();

var options = new TransactionScopeOptions
{
    ScopeTimeout = TimeSpan.FromMinutes(5)
};

using (var transaction = factory.CreateTransactionScope(options))
{
    // Do some lengthy work here.

    transaction.Complete();
}
```

## Testing and mocking transactions

[`TransactionScopeFactory`](src/Enable.Transactions/TransactionScopeFactory.cs)
implements the interface
[`ITransactionScopeFactory`](src/Enable.Transactions/ITransactionScopeFactory.cs).
The transaction scope returned by the `CreateTransactionScope` method on this
interface in turn implements the interface
[`ITransactionScope`](src/Enable.Transactions/ITransactionScope.cs). This makes
it a breeze to mock transactions in tests, and to use `TransactionScopeFactory`
with your favourite Dependency Injection framework.

