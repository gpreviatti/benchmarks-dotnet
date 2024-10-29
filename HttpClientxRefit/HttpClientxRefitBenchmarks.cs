using BenchmarkDotNet.Attributes;
using Refit;
using System.Net.Http.Json;

namespace HttpClientxRefit;

[MemoryDiagnoser]
[HardwareCounters]
[MarkdownExporter]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class HttpClientxRefitBenchmarks
{
    private IRefitUsersApi? _refitUsersApi;
    private HttpClient? _httpClient;

    [GlobalSetup(Target = nameof(SendRequestWithRefit))]
    public void SendRequestWithRefitSetup() => _refitUsersApi = RestService.For<IRefitUsersApi>("http://localhost:8080");

    [GlobalSetup(Target = nameof(SendRequestWithHttpClient))]
    public void SendRequestWithHttpClientSetup() => _httpClient = new();



    [Benchmark(Description = "Send request with HttpClient")]
    public async Task SendRequestWithHttpClient() =>
        await _httpClient!.GetFromJsonAsync<IReadOnlyCollection<User>>("http://localhost:8081/users");

    [Benchmark(Description = "Send request with refit")]
    public async Task SendRequestWithRefit() =>
        await _refitUsersApi!.GetUsers();
}