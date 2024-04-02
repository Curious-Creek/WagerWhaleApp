using Domain.Errors;

namespace Domain.Identity;

public class ProblemError
{
    public List<string> Errors { get; set; } = [];

    public override string ToString()
    {
        return string.Join(", ", Errors);
    }
}