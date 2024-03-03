namespace Blazor.Domain.Competitions;

public record Competition(
    string Name,
    decimal RewardPerStage,
    decimal EntryFee,
    decimal PricePool,
    decimal ConsolationPrize,
    DateOnly StartDate);