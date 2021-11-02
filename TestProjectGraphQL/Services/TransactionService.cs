using Braintree;
using Newtonsoft.Json;
using TestProjectGraphQL.Configration;


namespace TestProjectGraphQL.Services
{
	public class TransactionService : ITransactionService
	{
		private readonly IBraintreeConfiguration _braintreeConfiguration;

		public TransactionService(IBraintreeConfiguration braintreeConfiguration)
		{
			_braintreeConfiguration = braintreeConfiguration;

		}
		public async Task<Object?> GetAllTransactions()
		{
			try
			{

				var query = @"query transaction($input: TransactionSearchInput!) {
								search{
								transactions(input: $input){
								  edges{
									node{
									  amount{
										value
									  },
									  customer{
											id
										},
									  orderId
									}
								  }
      
								}  
							  }
							}";

				var status = new Dictionary<string, object>() {
					{ "is", "SETTLED" }
				};

				var variables = new Dictionary<string, object>() {
					{ "input", new Dictionary<string, object>() {
						{ "status", status }
					} }
				};

				var data = JsonConvert.SerializeObject(_braintreeConfiguration.GetGraphQLGateway().QueryAsync(query, variables).Result);

				var transactions = JsonConvert.DeserializeObject<Models.RootObject>(data);

				return transactions?.Data?.Search?.Transactions?.Edges;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
				throw;
			}
		}

		public async Task<Transaction?> GetTransactionById(string id)
		{
			try
			{
				return await _braintreeConfiguration.GetHTTPGateway().Transaction.FindAsync(id);
			}
			catch (Exception)
			{
				return null;
				throw;
			}
		}
	}
}
