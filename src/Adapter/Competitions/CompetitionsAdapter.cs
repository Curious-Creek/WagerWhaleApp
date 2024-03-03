using System.Net.Http.Json;
using Blazor.Domain.Competitions;
using Domain.Common;
using Domain.Competitions;
using OneOf;

namespace Adapter.Competitions;

public class CompetitionsAdapter(HttpClient httpClient) : ICompetitionsAdapter
{
    public async Task<OneOf<Competition, AlreadyExists>> CreateCompetitionAsync(CreateCompetition createCompetition)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("", createCompetition);
        return await response.Content.ReadFromJsonAsync<OneOf<Competition, AlreadyExists>>();
    }

    public async Task<IReadOnlyCollection<Competition>> GetCompetitionsAsync()
    {
        Console.WriteLine(httpClient.BaseAddress);
        var testResponse = await httpClient.GetAsync("competitions");
        
        var test123 = await testResponse.Content.ReadAsStringAsync();
        var response = await httpClient.GetFromJsonAsync<IReadOnlyCollection<Competition>>("competitions");
        return response ?? Array.Empty<Competition>();
    }
}