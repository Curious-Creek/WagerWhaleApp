using Domain.Errors;

namespace Blazor.ViewModels.ErrorViewModel;

public class DomainErrorViewModel(string message, string? title = null, int? status = null, List<DomainErrorViewModel>? errors = null)
{
    public string Message { get; } = message;
    public string? Title { get; } = title ?? "Default error title";
    public int? Status { get; } = status;
    public List<DomainErrorViewModel> Errors { get; } = errors ?? [];

    // If I want to support a deeper level than 1x I need to figure out how to do this recursive for now I want to do something else.
    public DomainErrorViewModel(DomainError domainError): this(domainError.Message, domainError.Title, domainError.Status) {}
    
    public override string ToString()
    {
        var str = string.Empty;
        
        if (Title is not null)
        {
            str += $"{Title}"; 
        }

        str += $"\n\r {Message}";    
        
        if (Status is not null)
        {
            str += $"{Status}";
        }

        if (Errors.Count > 0)
        {
            str += $"\n\r Aggregate errors: ";
            
            foreach (var error in Errors)
            {
                str += error.ToString();
                str += "\n\r";
            }
        }
        
        return str;
    }
}