using System.Net.Http.Json;
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
        var response = await httpClient.GetFromJsonAsync<IReadOnlyCollection<Competition>>("competitions");
        return response ?? Array.Empty<Competition>();
    }
}