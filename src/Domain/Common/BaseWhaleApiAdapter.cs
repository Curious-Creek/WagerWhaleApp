namespace Domain.Common;

public abstract class BaseWhaleApiAdapter(HttpClient httpClient)
{
    protected HttpClient HttpClient { get; } = httpClient;
}