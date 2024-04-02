namespace Blazor.ViewModels.Competitions;

public record CompetitionRow(string Name,
    decimal RewardPerStage,
    decimal EntryFee,
    decimal PricePool,
    decimal ConsolationPrize,
    DateOnly StartDate);