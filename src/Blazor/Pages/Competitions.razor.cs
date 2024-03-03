using Domain.Competitions;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages;

public partial class Competitions
{
    //public List<CompetitionViewModel> CompetitionViewModels { get; set; }

    [Inject] 
    public ICompetitionsAdapter CompetitionsAdapter { get; set; } = default!;

    /*protected override async Task OnInitializedAsync()
    {
        
    }*/

    public async Task CreateCompetition()
    {
        var result = await CompetitionsAdapter.CreateCompetitionAsync(new CreateCompetition("Test", 10, new DateOnly(2022, 1, 1)));
    }

    public async Task LoadCompetitions()
    {
        var competitions = await CompetitionsAdapter.GetCompetitionsAsync();
    }
}