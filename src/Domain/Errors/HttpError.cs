namespace Domain.Errors;

public class HttpError : IError
{
    public string Message { get; init; }
    public string Title { get; init; }
    public int HttpStatusCode { get; set; }
}