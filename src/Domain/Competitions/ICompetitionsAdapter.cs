using Blazor.Domain.Competitions;
using Domain.Common;
using OneOf;

namespace Domain.Competitions;

public interface ICompetitionsAdapter : IWhaleApiAdapter
{
    public Task<OneOf<Competition, AlreadyExists>> CreateCompetitionAsync(CreateCompetition createCompetition);
    
    public Task<IReadOnlyCollection<Competition>> GetCompetitionsAsync();
}