namespace Domain.Errors;

public record DomainError
{
    public string Message { get; }
    public string? Title { get; }
    public int? Status { get; }
    public List<DomainError>? Errors { get; }

    public DomainError(string message, string? title = null, int? status = null, List<DomainError>? errors = null)
    {
        Message = message;
        Title = title;
        Status = status;
        Errors = errors ?? [];
    }

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

        if (Errors is not null)
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