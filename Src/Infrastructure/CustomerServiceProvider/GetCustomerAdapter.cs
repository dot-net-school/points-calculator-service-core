using System.Net.Http.Json;
using Application.Common.Interfaces;
using Application.DTOs.CustomerService;
using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;

namespace Infrastructure.CustomerServiceProvider;

internal class GetCustomerAdapter : IGetCustomerAdapter
{
    private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;

    //TODO remove magic string
    // The URL of the customer service
    private const string CustomerServiceUrl = "http://localhost:3000/getcustomer";

    private readonly HttpClient _httpClient;

    public GetCustomerAdapter(IHttpClientFactory httpClientFactory)
    {
        _circuitBreakerPolicy = Policy.Handle<Exception>()
            .CircuitBreakerAsync(2, TimeSpan.FromMinutes(2));
        _httpClient = httpClientFactory.CreateClient();
    }

    //TODO return operation result or DTO itself? 
    public async Task<ReceivedCustomerInfoDto?> SendAsync(string id)
    {
        var response = await _circuitBreakerPolicy.ExecuteAsync(async () =>
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{CustomerServiceUrl}/{id}", UriKind.Absolute)
                };
                return await _httpClient.SendAsync(request);
            }
        );
        return await response.Content.ReadFromJsonAsync<ReceivedCustomerInfoDto>();
    }
}