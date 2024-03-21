namespace Domain.Errors;

public interface IError
{
    public string Message { get; init; }
    public string Title { get; init; }
}