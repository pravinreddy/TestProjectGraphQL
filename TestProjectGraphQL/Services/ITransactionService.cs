using Braintree;

namespace TestProjectGraphQL.Services
{
	public interface ITransactionService
	{
		public Task<Transaction?> GetTransactionById(string id);

		public Task<Object?> GetAllTransactions();
	}
}
