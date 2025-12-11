namespace Neon.CRM.WebApp.Services;

public class NeonService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public NeonService(HttpClient httpClient, IConfiguration config)
    {
        this._httpClient = httpClient;
        this._config = config;

        _httpClient.BaseAddress = new Uri(_config["NeonApi:BaseUrl"]);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config["NeonApi:ApiKey"]);
    }
}


