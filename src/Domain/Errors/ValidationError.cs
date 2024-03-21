namespace Domain.Errors;

//public sealed record ValidationError(string Title, string Message, string PropertyName) : IError;

public sealed class ValidationError : IError
{
    public string Title { get; init; }
    public string Message { get; init; }
    public string PropertyName { get; init; }

    public ValidationError(string title, string message, string propertyName)
    {
        Title = title;
        Message = message;
        PropertyName = propertyName;
    }
}