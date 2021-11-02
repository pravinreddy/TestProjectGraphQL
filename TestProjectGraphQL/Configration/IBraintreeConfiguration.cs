using Braintree;

namespace TestProjectGraphQL.Configration
{
    public interface IBraintreeConfiguration
    {
        IBraintreeGateway CreateHTTPGateway();
        IBraintreeGateway GetHTTPGateway();
        GraphQLClient CreateGraphQLGateway();
        GraphQLClient GetGraphQLGateway();
    }
}
