using SingleWebApplicationDefaultAuth.Code.Authentication;

namespace SingleWebApplicationDefaultAuth.Code.HttpClients
{
    public class HttpDataApiBuilderAuthClient
    {
        private readonly HttpClient _httpClient;
        public HttpDataApiBuilderAuthClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add(AuthConst.DataApiBuilderAuthorizationHeader, AuthConst.SampleRole);
        }

        public async Task<string> GetCustomersAsync()
        {
            return await _httpClient.GetStringAsync("Customer");
        }
        public async Task<string> GetProductsAsync()
        {
            return await _httpClient.GetStringAsync("Product");
        }

    }
}
