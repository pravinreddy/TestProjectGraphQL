using Braintree;
using Microsoft.Extensions.Options;

namespace TestProjectGraphQL.Configration
{
    public class BraintreeConfiguration : IBraintreeConfiguration
    {
        private IOptions<ConfigrationSettings.Braintree> _braintree;
        private string Environment { get; set; }
        private string MerchantId { get; set; }
        private string PublicKey { get; set; }
        private string PrivateKey { get; set; }
        private IBraintreeGateway BraintreeHTTPGateway { get; set; }
        private GraphQLClient BraintreeGraphQLGateway { get; set; }

        public BraintreeConfiguration(IOptions<ConfigrationSettings.Braintree> Braintree)
		{
            _braintree = Braintree;
            Environment = _braintree.Value.Environment;
            MerchantId = _braintree.Value.MerchantId;
            PublicKey = _braintree.Value.PublicKey;
            PrivateKey = _braintree.Value.PrivateKey;
        }

        public IBraintreeGateway CreateHTTPGateway()
        {
            return new BraintreeGateway(Environment, MerchantId, PublicKey, PrivateKey);
        }

        public IBraintreeGateway GetHTTPGateway()
        {
            if (BraintreeHTTPGateway == null)
            {
                BraintreeHTTPGateway = CreateHTTPGateway();
            }

            return BraintreeHTTPGateway;
        }

        public GraphQLClient CreateGraphQLGateway()
        {
            return new BraintreeGateway(Environment, MerchantId, PublicKey, PrivateKey).GraphQLClient;
        }

        public GraphQLClient GetGraphQLGateway()
        {
            if (BraintreeGraphQLGateway == null)
            {
                BraintreeGraphQLGateway = CreateGraphQLGateway();
            }

            return BraintreeGraphQLGateway;
        }
	}
}
